using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using System.Windows.Input;
using TEKUtsav.ViewModels.BaseViewModel;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.CookieStorage;
using TEKUtsav.Infrastructure.Settings;
using TEKUtsav.Models;
using TEKUtsav.Infrastructure.Constants;
using Plugin.ExternalMaps;


namespace TEKUtsav.ViewModels.MasterMenuPage
{
	public class MasterMenuPageViewModel : ViewModelBase
	{
		public Action<TEKUtsavAppPage> MenuItemSelectionChanged;
		private readonly INavigationService _navigationService;
		private List<HamburgerMenuItem> _businessUnits;
		private IPlatformCookieStore _cookieStore;
		private ICommand _tapCommand, _applicationsListingCommand;

		private int _height;
		public int Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
				OnPropertyChanged("Height");
			}
		}

		public ICommand TapCommand
		{
			get { return _tapCommand; }
			protected set
			{
				_tapCommand = value;
				OnPropertyChanged();
			}
		}

		public ICommand ApplicationsListingCommand
		{
			get { return _applicationsListingCommand; }
			protected set
			{
				_applicationsListingCommand = value;
				OnPropertyChanged();
			}
		}

		private ICommand _logoutCommand;
		public ICommand LogoutCommand
		{
			get { return _logoutCommand; }
			protected set
			{
				_logoutCommand = value;
				OnPropertyChanged("LogoutCommand");
			}
		}

        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get { return _settingsCommand; }
            protected set
            {
                _settingsCommand = value;
                OnPropertyChanged("SettingsCommand");
            }
        }

        private ICommand _eventScheduleCommand;
        public ICommand EventScheduleCommand
        {
            get { return _eventScheduleCommand; }
            protected set
            {
                _eventScheduleCommand = value;
                OnPropertyChanged("EventScheduleCommand");
            }
        }

        private ICommand _notificationCommand;
        public ICommand NotificationCommand
        {
            get { return _notificationCommand; }
            protected set
            {
                _notificationCommand = value;
                OnPropertyChanged("NotificationCommand");
            }
        }

        private ICommand _eventLocationCommand;
        public ICommand EventLocationCommand
        {
            get { return _eventLocationCommand; }
            protected set
            {
                _eventLocationCommand = value;
                OnPropertyChanged("EventLocationCommand");
            }
        }

		private string _userName;
		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
				OnPropertyChanged("UserName");
			}
		}

		public MasterMenuPageViewModel(ISettings settings,
		   INavigationService navigationService, IPlatformCookieStore cookieStore)
				   : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (cookieStore == null) throw new ArgumentNullException("cookieStore");
			_navigationService = navigationService;
			_cookieStore = cookieStore;
		}

		public override Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.MasterMenuPage);

			this.TapCommand = new Command(() =>
			{
				_navigationService.CloseMenu();
			}
			, () => true);


            this.SettingsCommand = new Command(() =>
            {
                _navigationService.NavigateTo(TEKUtsavAppPage.AdminSettingsPage);
                _navigationService.CloseMenu();
            }
            , () => true);
            
            this.EventScheduleCommand = new Command(() =>
            {
                _navigationService.NavigateTo(TEKUtsavAppPage.EventSchedulePage);
                _navigationService.CloseMenu();
            }
            , () => true);

            this.NotificationCommand = new Command(() =>
            {
                _navigationService.NavigateTo(TEKUtsavAppPage.NotificationsPage);
                _navigationService.CloseMenu();
            }
            , () => true);

            this.EventLocationCommand = new Command(async() =>
            {
                var success = await CrossExternalMaps.Current.NavigateTo("Kanva Star Resort", 13.1034, 77.4372);
                if (!success)
                {
                    await _navigationService.DisplayAlert("Error displaying location", "Please look for Kanva Star Resort within Google Maps", "Ok");
                }
                _navigationService.CloseMenu();
            });
            
			return Task.Run(() => { });
		}

		public override Task OnViewDisappearing()
		{
			return Task.Run(() => { });
		}

		public override void Dispose()
		{
			throw new NotImplementedException();
		}

	}
}
