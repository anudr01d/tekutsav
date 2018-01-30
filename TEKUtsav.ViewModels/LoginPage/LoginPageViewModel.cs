//using TEKUtsav.Business.Login;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.Settings;
using TEKUtsav.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using TEKUtsav.Infrastructure;
using TEKUtsav.Infrastructure.Constants;
using TEKUtsav.Infrastructure.CookieStorage;

namespace TEKUtsav.ViewModels.LoginPage
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ISettings _settings;
        private string _userName;
        private ICommand _loginCommand;
		private ICommand _navEndCommand;
        private string _password;
        private bool _invalid;
		private bool _isOn;
		private IPlatformCookieStore _cookieStore;
		private System.Net.Cookie _aspnetCookie;


        public ICommand LoginCommand
        {
            get { return _loginCommand; }
            protected set
            {
                _loginCommand = value;
                OnPropertyChanged();
            }
        }

		public ICommand NavEndCommand
		{
			get { return _navEndCommand; }
			protected set
			{
				_navEndCommand = value;
				OnPropertyChanged();
			}
		}

		private ICommand _navigatingCommand;
		public ICommand NavigatingCommand
		{
			get { return _navigatingCommand; }
			protected set
			{
				_navigatingCommand = value;
				OnPropertyChanged();
			}
		}

        public LoginPageViewModel(INavigationService navigationService, ISettings settings, IPlatformCookieStore platformCookieStore) : base(navigationService, settings)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            if (settings == null) throw new ArgumentNullException("settings");
			if (platformCookieStore == null) throw new ArgumentNullException("platformCookieStore");

            _navigationService = navigationService;
            _settings = settings;
			_cookieStore = platformCookieStore;
        }

        public override Task OnViewAppearing(object navigationParams = null)
        {
			this.NavEndCommand = new Command(() =>
			{
				Navigated();
			}
			, () => true);


			this.NavigatingCommand = new Command((args) =>
			{
				Navigating(args); 
			}
			, (args) => true);
			

            return Task.Run(() =>
            {

            });
        }

		public void Navigating(object args)
		{
			Debug.WriteLine(args);
		}


		public void Navigated()
		{
			_cookieStore.DumpAllCookiesToLog();
			_aspnetCookie = _cookieStore.CurrentCookies.FirstOrDefault(cc => cc.Name == Globals.COOKIE);
			if (_aspnetCookie != null)
			{
				// Even cookies need saving.
				Application.Current.Properties[".AspNet.ExternalCookie"] = _aspnetCookie.Value;
				Debug.WriteLine("Cookie Domain : " + _aspnetCookie.Domain);
				_navigationService.NavigateTo(TEKUtsavAppPage.AppListingMasterMenuPage);
			}
		}

        public override Task OnViewDisappearing()
        {
            return Task.Run(() => { });
        }

        public override void Dispose()
        {
        }
    }
}
