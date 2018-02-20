using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using System.Text.RegularExpressions;
using TEKUtsav.Models;
using TEKUtsav.ViewModels.BaseViewModel;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.Settings;
using TEKUtsav.Models.Entities;
using TEKUtsav.Infrastructure.Constants;
using TEKUtsav.Infrastructure;
using TEKUtsav.Business.Measurements;
using TEKUtsav.Models.FireBase;

using Plugin.DeviceInfo;
using System.Diagnostics.Contracts;
using TEKUtsav.Business.User;
using TEKUtsav.Mobile.Service.Domain.DataObjects;
using Command = Xamarin.Forms.Command;
using Acr.UserDialogs;

namespace TEKUtsav.ViewModels.RegistrationPage
{
    public class RegistrationPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserBusinessService _userBusinessService;
        private readonly ISettings _settings;
        private bool clicked = false;
        private ICommand _locationClickedCommand, _registerClickedCommand;
        private string _location;

        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public ICommand RegisterClickedCommand
        {
            get { return _registerClickedCommand; }
            protected set
            {
                _registerClickedCommand = value;
                OnPropertyChanged("RegisterClickedCommand");
            }
        }

        public ICommand LocationClickedCommand
        {
            get { return _locationClickedCommand; }
            protected set
            {
                _locationClickedCommand = value;
                OnPropertyChanged("LocationClickedCommand");
            }
        }

        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _mobileNumber;
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set
            {
                _mobileNumber = value;
                OnPropertyChanged("MobileNumber");
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private void sendPush()
        {
            var deviceId = CrossDeviceInfo.Current.Id; // Fetches the unique device Id...
            FireBasePush push = new FireBasePush(Globals.FIREBASE_SERVER_KEY);
            push.SendPush(new PushMessage
            {
                to = "/topics/news",
                notification = new PushMessageData
                {
                    title = "Dance",
                    text = "Event Started",
                    click_action = "click_action"
                },
                data = new
                {
                    example = "this is a example"
                }
            });
        }

        public RegistrationPageViewModel(INavigationService navigationService, ISettings settings, IUserBusinessService userBusinessService) : base(navigationService, settings)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            if (settings == null) throw new ArgumentNullException("settings");
            if (userBusinessService == null) throw new ArgumentNullException("userBusinessService");
            _userBusinessService = userBusinessService;
            _navigationService = navigationService;
            _settings = settings;
        }

        public override async Task OnViewAppearing(object navigationParams = null)
        {
            this.SetCurrentPage(TEKUtsavAppPage.RegistrationPage);

            this.RegisterClickedCommand = new Command(async () =>
            {
                User user = new User();
                if (this.Location == null || this.Location.Contains("Select"))
                {
                    await _navigationService.DisplayAlert("Location", "Please select a Location", "OK");
                    return;
                }
                if (this.Name == null)
                {
                    await _navigationService.DisplayAlert("Name", "Invalid Name", "OK");
                    return;
                }
                bool IsEmailValid = (Regex.IsMatch(this.Email, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                if (IsEmailValid == false)
                {
                    await _navigationService.DisplayAlert("Email", "Invalid Email Address", "OK");
                    return;
                }
                double result;
                bool IsNumberValid = double.TryParse(this.MobileNumber, out result);
                if (IsNumberValid == false || this.MobileNumber.Length != 10)
                {
                    await _navigationService.DisplayAlert("Phone", "Invalid Mobile Number", "OK");
                    return;
                }
                if (!string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.MobileNumber) && !string.IsNullOrEmpty(this.Email) && !string.IsNullOrEmpty(this.Location))
                {
                    user.FirstName = this.Name;
                    user.Email = this.Email;
                    user.Mobile = this.MobileNumber;
                    user.WorkLocation = this.Location;
                    user.CreatedBy = CrossDeviceInfo.Current.Id;
                    List<DeviceRegister> lstDevices = new List<DeviceRegister>();
                    lstDevices.Add(new DeviceRegister() { UDID = CrossDeviceInfo.Current.Id, CreatedBy = CrossDeviceInfo.Current.Id });
                    user.Devices = lstDevices;


                    UserDialogs.Instance.ShowLoading("Registering..", MaskType.Black);
                    var response = await _userBusinessService.RegisterUser(user);
                    UserDialogs.Instance.HideLoading();

                    //Use the response and identify if the user is an admin or not, persist additional useful information
                    if (!string.IsNullOrEmpty(response.FirstName))
                    {
                        Application.Current.Properties["UserUDID"] = response.Devices.FirstOrDefault().UDID;
                        Application.Current.Properties["IsAdmin"] = response.IsAdmin;
                        Application.Current.Properties["UserEmail"] = response.Email;
                        Application.Current.Properties["UserPhone"] = response.Mobile;
                        _navigationService.NavigateTo(TEKUtsavAppPage.MasterMenuPage);
                    }
                    else
                    {
                        await _navigationService.DisplayAlert("Error in registration", response.ToString(), "OK");
                    }
                }
                else
                {
                    await _navigationService.DisplayAlert("Please fill all the required fields.", "", "OK");
                }
            });

            this.LocationClickedCommand = new Command(() =>
            {
                _navigationService.ShowPopup(TEKUtsavAppPage.SingleSelectionPage, Globals.LOCATION);
            });


            var v = CrossDeviceInfo.Current.Id;

            this.Location = "Select";
            MessagingCenter.Subscribe<SingleSelectionItem>(this, Globals.SINGLE_SELECTION, (args) =>
            {
                if (args.Name != null)
                {
                    this.Location = args.Name;
                }
            });

            Task.Run(() => { });
        }

		public override Task OnViewDisappearing()
		{
			return Task.Run(() => { });
		}

		public override void Dispose()
		{
            MessagingCenter.Unsubscribe<SingleSelectionItem>(this, Globals.SINGLE_SELECTION);	
		}
	}
}
