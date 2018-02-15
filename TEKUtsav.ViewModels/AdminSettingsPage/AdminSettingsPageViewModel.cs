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
using TEKUtsav.Business.EventService;
using TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.ViewModels.AdminSettingsPage
{
	public class AdminSettingsPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
        private readonly IEventBusinessService _eventBusinesservice;
		private readonly ISettings _settings;
        private ICommand _enableDanceVotingCommand, _enableFsVotingCommand, _enableSeVotingCommand;


        private bool _isDanceVotingEnabled;
        public bool IsDanceVotingEnabled
        {
            get { return _isDanceVotingEnabled; }

            set
            {
                _isDanceVotingEnabled = value;
                OnPropertyChanged();
            }
        }

        private bool _isFsVotingEnabled;
        public bool IsFsVotingEnabled
        {
            get { return _isFsVotingEnabled; }

            set
            {
                _isFsVotingEnabled = value;
                OnPropertyChanged();
            }
        }

        private bool _isSeVotingEnabled;
        public bool IsSeVotingEnabled
        {
            get { return _isSeVotingEnabled; }

            set
            {
                _isSeVotingEnabled = value;
                OnPropertyChanged();
            }
        }

		public ICommand EnableDanceVotingCommand
		{
            get { return _enableDanceVotingCommand; }
			protected set
			{
                _enableDanceVotingCommand = value;
                OnPropertyChanged("EnableDanceVotingCommand");
			}
		}

        public ICommand EnableFsVotingCommand
        {
            get { return _enableFsVotingCommand; }
            protected set
            {
                _enableFsVotingCommand = value;
                OnPropertyChanged("EnableFsVotingCommand");
            }
        }

        public ICommand EnableSeVotingCommand
        {
            get { return _enableSeVotingCommand; }
            protected set
            {
                _enableSeVotingCommand = value;
                OnPropertyChanged("EnableSeVotingCommand");
            }
        }

        public AdminSettingsPageViewModel(INavigationService navigationService, ISettings settings, IEventBusinessService eventBusinesservice) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
            if (eventBusinesservice == null) throw new ArgumentNullException("eventBusinessService");
			_navigationService = navigationService;
			_settings = settings;
            _eventBusinesservice = eventBusinesservice;


		}

        public override async Task OnViewAppearing(object navigationParams = null)
        {
            this.SetCurrentPage(TEKUtsavAppPage.AdminSettingsPage);

            this.EnableDanceVotingCommand = new Command( async () =>
            {
                //Call api for enabling and disabling voting lines
                EventVotingSchedule eventVoting = new EventVotingSchedule();

                eventVoting.EventTypeId = "6F77A69A-45EA-4E82-B773-E650AA71F39B";
                eventVoting.IsVotingOpen = IsDanceVotingEnabled;

                var response = await _eventBusinesservice.enableDiableVoting(eventVoting);
                //Use the response and identify if the user is an admin or not, persist additional useful information
                if (response != null)
                {
                    await _navigationService.DisplayAlert("Voting Updated", response.ToString(), "OK");

                }
                else
                {
                    await _navigationService.DisplayAlert("Error in Voting", "Error", "OK");
                }
            });

            this.EnableFsVotingCommand = new Command(async () =>
            {
                //Call api for enabling and disabling voting lines
                EventVotingSchedule eventVoting = new EventVotingSchedule();

                eventVoting.EventTypeId = "BD8A4F1A-841C-4449-BD11-FE8B21C98F41";
                eventVoting.IsVotingOpen = IsFsVotingEnabled;

                var response = await _eventBusinesservice.enableDiableVoting(eventVoting);
                //Use the response and identify if the user is an admin or not, persist additional useful information
                if (response != null)
                {
                    await _navigationService.DisplayAlert("Voting Updated", response.ToString(), "OK");

                }
                else
                {
                    await _navigationService.DisplayAlert("Error in Voting", "Err", "OK");
                }
            });

            this.EnableSeVotingCommand = new Command(async () =>
            {
                //Call api for enabling and disabling voting lines
                EventVotingSchedule eventVoting = new EventVotingSchedule();

                eventVoting.EventTypeId = "BD8A4F1A-841C-4449-BD11-FE8B21C98F41";
                eventVoting.IsVotingOpen = IsSeVotingEnabled;

                var response = await _eventBusinesservice.enableDiableVoting(eventVoting);
                //Use the response and identify if the user is an admin or not, persist additional useful information
                if (response != null)
                {
                    await _navigationService.DisplayAlert("Voting Updated", response.ToString(), "OK");

                }
                else
                {
                    await _navigationService.DisplayAlert("Error in Voting", response.ToString(), "OK");
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
			
		}
	}
}
