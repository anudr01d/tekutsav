using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
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
           
            this.RegisterClickedCommand = new Command( async() => {
                User user = new User();
                if (!string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.MobileNumber) && !string.IsNullOrEmpty(this.Email))
                {
                    user.FirstName = this.Name;
                    user.Email = this.Email;
                    user.Mobile = this.MobileNumber;
                    List<DeviceRegister> lstDevices = new List<DeviceRegister>();
                    lstDevices.Add(new DeviceRegister() { UDID = CrossDeviceInfo.Current.Id, CreatedBy= CrossDeviceInfo.Current.Id });
                    user.Devices = lstDevices;

                    var response = await _userBusinessService.RegisterUser(user);
                    //Use the response and identify if the user is an admin or not, persist additional useful information

                    _navigationService.NavigateTo(TEKUtsavAppPage.MasterMenuPage);
                }
            });

            this.LocationClickedCommand = new Command(() =>
            {
                _navigationService.ShowPopup(TEKUtsavAppPage.SingleSelectionPage, Globals.LOCATION);
            });


            var v = CrossDeviceInfo.Current.Id;

            this.Location = "Location";
            MessagingCenter.Subscribe<SingleSelectionItem>(this, Globals.SINGLE_SELECTION, (args) =>
            {
                if(args.Name!=null) 
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
