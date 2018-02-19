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
using TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.ViewModels.AdminSettingsPage
{
	public class AdminSettingsPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
        private readonly IEventBusinessService _eventBusinesservice;
		private readonly ISettings _settings;
        private ICommand  _enableVotingCommand;
        private List<AdminListItem> _getEventType;

        public ICommand Toggled { get; set; }

        private bool _isVotingEnabled;
        public bool IsVotingEnabled
        {
            get { return _isVotingEnabled; }

            set
            {
                _isVotingEnabled = value;
                OnPropertyChanged("IsVotingEnabled");
            }
        }
        private bool _isVoting;

        public bool IsVoting
        {
            get { return _isVoting; }

            set
            {
                _isVoting = value;
                OnPropertyChanged("IsVoting");
            }
        }
     

        public ICommand EnableVotingCommand
        {
            get { return _enableVotingCommand; }
            protected set
            {
                _enableVotingCommand = value;
                OnPropertyChanged("EnableVotingCommand");
            }
        }

       
        public void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
           
            var s = sender as Switch;
            IsVotingEnabled = s.IsToggled;
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

/*            this.EnableVotingCommand = new ExecuteLoadedCommandAsync(async (e) =>
            {
                var item = (e as TEKUtsav.Mobile.Service.Domain.DataObjects.Event);

                //Call api for enabling and disabling voting lines
                DS.EventVotingSchedule eventVoting = new DS.EventVotingSchedule();

                eventVoting.EventTypeId = item.EventTypeId;
                eventVoting.IsVotingOpen = IsVotingEnabled;

                var response = await _eventBusinesservice.enableDiableVoting(eventVoting);
                //Use the response and identify if the user is an admin or not, persist additional useful information
                if (response != null)
                {
                    await _navigationService.DisplayAlert("Voting Updated", "Voting Lines updated", "OK");

                }
                else
                {
                    await _navigationService.DisplayAlert("Error in Voting", "Error Updating Voting Lines", "OK");
                }
            });
*/
            this.EnableVotingCommand = new Command(async(args) => 
            {
                var item = (args as TEKUtsav.Models.AdminListItem);

                //Call api for enabling and disabling voting lines
                DS.EventVotingSchedule eventVoting = new DS.EventVotingSchedule();

                eventVoting.EventTypeId = item.Id;
                eventVoting.IsVotingOpen = item.IsVotingOpen;

                var response = await _eventBusinesservice.enableDiableVoting(eventVoting);
                //Use the response and identify if the user is an admin or not, persist additional useful information
                if (response != null)
                {
                    await _navigationService.DisplayAlert("Voting Updated", "Voting Lines updated", "OK");

                }
                else
                {
                    await _navigationService.DisplayAlert("Error in Voting", "Error Updating Voting Lines", "OK");
                }
            }, (args) => true);

			Task.Run(() => { });
		}

        public List<AdminListItem> GetEventTypes
        {
            get
            {
                var eventTypes = Task.Run(() => _eventBusinesservice.GetEventTypes());
                if (eventTypes != null)
                {
                    var list = new List<AdminListItem>();

                    foreach (var ev in eventTypes.Result)
                    {
                        list.Add(new AdminListItem() { Title = ev.Title, Description = ev.Description,Id = ev.Id , IsVotingOpen = ev.EventVotingSchedules.FirstOrDefault().IsVotingOpen});
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
                OnPropertyChanged("GetEventTypes");
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
