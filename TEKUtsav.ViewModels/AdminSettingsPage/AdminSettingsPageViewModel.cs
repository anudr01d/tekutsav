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

namespace TEKUtsav.ViewModels.AdminSettingsPage
{
	public class AdminSettingsPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly ISettings _settings;
		private bool clicked = false;
        private List<Notification> _notifications;
        private ICommand _enableVotingCommand;

		public ICommand EnableVotingCommand
		{
            get { return _enableVotingCommand; }
			protected set
			{
                _enableVotingCommand = value;
                OnPropertyChanged("EnableVotingCommand");
			}
		}

        public AdminSettingsPageViewModel(INavigationService navigationService, ISettings settings) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			_navigationService = navigationService;
			_settings = settings;
		}

		public override async Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.AdminSettingsPage);


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
