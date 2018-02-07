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

namespace TEKUtsav.ViewModels.RegistrationPage
{
	public class RegistrationPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly ISettings _settings;
		private bool clicked = false;
		private ICommand _locationClickedCommand, _registerClickedCommand;
        private string _location;

        public ICommand RegisterClickedCommand
        {
            get { return _registerClickedCommand; }
            protected set
            {
                var deviceId = CrossDeviceInfo.Current.Id; // Fetches the unique device Id...
                FireBasePush push = new FireBasePush(Globals.FIREBASE_SERVER_KEY);
                push.SendPush(new PushMessage
                {
                    to =  "/topics/news",
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
            protected set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        public RegistrationPageViewModel(INavigationService navigationService, ISettings settings) : base(navigationService, settings)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            if (settings == null) throw new ArgumentNullException("settings");
            _navigationService = navigationService;
            _settings = settings;
        }

        public override async Task OnViewAppearing(object navigationParams = null)
        {
            this.SetCurrentPage(TEKUtsavAppPage.RegistrationPage);
           
            this.RegisterClickedCommand = new Command(() => {
                _navigationService.NavigateTo(TEKUtsavAppPage.MasterMenuPage);
            });

            this.LocationClickedCommand = new Command(() => {
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
