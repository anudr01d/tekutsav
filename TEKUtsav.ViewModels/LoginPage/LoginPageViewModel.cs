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
        private ICommand _startCommand;
		private ICommand _navEndCommand;
        private string _password;
        private bool _invalid;
		private bool _isOn;
		private IPlatformCookieStore _cookieStore;
		private System.Net.Cookie _aspnetCookie;


        public ICommand StartCommand
        {
            get { return _startCommand; }
            protected set
            {
                _startCommand = value;
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
            this.StartCommand = new Command(() => 
            {
                if(GetUserEmail()) 
                {
                    _navigationService.NavigateTo(TEKUtsavAppPage.MasterMenuPage);   
                } else 
                {
                    _navigationService.NavigateTo(TEKUtsavAppPage.RegistrationPage);   
                }
            });

            return Task.Run(() =>
            {

            });
        }

        private bool GetUserEmail()
        {
            var val = Application.Current.Properties.ContainsKey("UserEmail") ? true : false;
            return val;
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
