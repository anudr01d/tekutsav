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
using TEKUtsav.Infrastructure.CookieStorage;

namespace TEKUtsav.ViewModels.StartPage
{
    public class StartPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ISettings _settings;
        private ICommand _startCommand;

        public ICommand StartCommand
        {
            get { return _startCommand; }
            protected set
            {
                _startCommand = value;
                OnPropertyChanged();
            }
        }

        public StartPageViewModel(INavigationService navigationService, ISettings settings) : base(navigationService, settings)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            if (settings == null) throw new ArgumentNullException("settings");

            _navigationService = navigationService;
            _settings = settings;
        }

        public override Task OnViewAppearing(object navigationParams = null)
        {
            return Task.Run(() =>
            {

            });
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
