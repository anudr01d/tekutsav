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

using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.ViewModels.AdminSettingsPage
{
	public class AdminSettingsPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
        private readonly IEventBusinessService _eventBusinesservice;
		private readonly ISettings _settings;
        private ICommand _enableDanceVotingCommand, _enableFsVotingCommand, _enableSeVotingCommand;
        private List<DS.Event> _getEventType;

        public ICommand Toggled { get; set; }

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
     

        public async void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {

            var s = sender as Switch;
            DS.EventVotingSchedule eventVoting = new DS.EventVotingSchedule();

            eventVoting.EventTypeId = "BD8A4F1A-841C-4449-BD11-FE8B21C98F41";
            eventVoting.IsVotingOpen = s.IsToggled;

            var response = await _eventBusinesservice.enableDiableVoting(eventVoting);
            //Use the response and identify if the user is an admin or not, persist additional useful information
            if (response != null)
            {
                await _navigationService.DisplayAlert("Voting Updated", "Voting feature updated", "OK");

            }
            else
            {
                await _navigationService.DisplayAlert("Error in Voting", "Err", "OK");
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


            this.EnableFsVotingCommand = new Command(async () =>
            {
                //Call api for enabling and disabling voting lines
                DS.EventVotingSchedule eventVoting = new DS.EventVotingSchedule();

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
                DS.EventVotingSchedule eventVoting = new DS.EventVotingSchedule();

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

        public List<DS.Event> GetEventType
        {
            get
            {
                //var notificationEvents = await _notificationBusinesservice.GetNotifications();
                var eventTypes = Task.Run(() => _eventBusinesservice.GetEventType());
                if (eventTypes != null)
                {
                    var list = new List<DS.Event>();

                    foreach (var ev in eventTypes.Result)
                    {
                        list.Add(new DS.Event() { Title = ev.Title, Description = ev.Description ,EventTypeId = ev.Id });

                    }
                    return list;
                }
                else
                {
                    return _getEventType;
                }
            }
            set
            {
                _getEventType = value;
                OnPropertyChanged("GetEventType");
            }
        }
       
		public override Task OnViewDisappearing()
		{
			return Task.Run(() => { });
		}

		public override void Dispose()
		{
			
		}

        public void Handle_Toggled()
        {
            throw new NotImplementedException();
        }
    }
}
