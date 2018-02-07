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
using Plugin.DeviceInfo;

namespace TEKUtsav.ViewModels.RegistrationPage
{
	public class RegistrationPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly ISettings _settings;
		private bool clicked = false;
		private ICommand _menuClickCommand, _registerClickedCommand;

		public ICommand RegisterClickedCommand
		{
            get { return _registerClickedCommand; }
			protected set
			{
                var deviceId = CrossDeviceInfo.Current.Id; // Fetches the unique device Id

                _registerClickedCommand = value;
                OnPropertyChanged("RegisterClickedCommand");
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

            var v = CrossDeviceInfo.Current.Id;

			Task.Run(() => { });
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
