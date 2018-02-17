using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using TEKUtsav.ViewModels.BaseViewModel;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.Settings;
using TEKUtsav.Infrastructure.Constants;
using TEKUtsav.Business.EventService;
using TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.ViewModels.VotingPage
{
    public class VotingPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IEventBusinessService _eventBusinesservice;
        private readonly ISettings _settings;

		private ICommand _voteCommand;
        private ICommand _danceCommand, _fsCommand, _seCommand;
        private ICommand _navigateToResults, _navigateToResult;

        private ICommand _changeTabCommand;
        private ICommand _changeYearTabCommand;

        private bool _isTabOneVisible, _isTabTwoVisible, _isTabThreeVisible, _isEnabled, _isBtnEnabled;
		private string _danceTabColor, _fsTabColor, _seTabColor;
		
        private bool _isDanceSelected;
		private bool _isFsSelected;
		private bool _isSeSelected;

		private IEnumerable<Event> _danceEvent;
		private IEnumerable<Event> _fsEvent;
        private IEnumerable<Event> _spEvent;


		private String[] _tagName = new String[] { "DANCE", "FASHION" + System.Environment.NewLine + "  SHOW", "SPECIAL" + System.Environment.NewLine + " EVENTS" };


        private List<Event> _danceEvents = new List<Event>();
        public List<Event> DanceEvents
        {
            get
            {
                 return _danceEvents;
            }
            set
            {
                _danceEvents = value;
                OnPropertyChanged("DanceEvents");
            }
        }


        private List<Event> _fsEvents = new List<Event>();
        public List<Event> FsEvents
        {
            get
            {
                return _fsEvents;
            }
            set
            {
                _fsEvents = value;
                OnPropertyChanged("FsEvents");
            }
        }

        private List<Event> _seEvents = new List<Event>();
        public List<Event> SeEvents
        {
            get
            {
                return _seEvents;
            }
            set
            {
                _seEvents = value;
                OnPropertyChanged("SeEvents");
            }
        }


		public String [] TagName { 
			get {
				return _tagName;
			}
			set {
				_tagName = value;
				OnPropertyChanged();
			}

		}
		public IEnumerable<Event> DanceEvent { 
            get { return _danceEvent; }
			set {
                _danceEvent = value;
				OnPropertyChanged();
			}

		} 
		public IEnumerable<Event> FsEvent
		{
            get { return _fsEvent; }
			set
			{
                _fsEvent = value;
				OnPropertyChanged();
			}

		}

		public bool IsDanceSelected
		{
            get { return _isDanceSelected; }

			set
			{
                _isDanceSelected = value;
				OnPropertyChanged();
			}
		}

		public bool IsFsSelected
		{
            get { return _isFsSelected; }

			set
			{
                _isFsSelected = value;
				OnPropertyChanged();
			}
		}

		public bool IsSeSelected
		{
            get { return _isSeSelected; }

			set
			{
                _isSeSelected = value;
				OnPropertyChanged();
			}
		}

        private bool _isDanceVoted;
        public bool IsDanceVoted
        {
            get { return _isDanceVoted; }

            set
            {
                _isDanceVoted = value;
                OnPropertyChanged();
            }
        }

        private bool _isFsVoted;
        public bool IsFsVoted
        {
            get { return _isFsVoted; }

            set
            {
                _isFsVoted = value;
                OnPropertyChanged();
            }
        }

        private bool _isSeVoted;
        public bool IsSeVoted
        {
            get { return _isSeVoted; }

            set
            {
                _isSeVoted = value;
                OnPropertyChanged();
            }
        }

		public ICommand ChangeTabCommand
		{
			get { return _changeTabCommand; }

			set
			{
				_changeTabCommand = value;
				OnPropertyChanged();
			}
		}

		public ICommand ChangeYearTabCommand
		{
			get { return _changeYearTabCommand; }

			set
			{
				_changeYearTabCommand = value;
				OnPropertyChanged();
			}
		}

		public bool IsTabOneVisible
		{
			get
			{
				return _isTabOneVisible;
			}
			set
			{
				_isTabOneVisible = value;
				OnPropertyChanged();
			}
		}

		public bool IsTabTwoVisible
		{
			get
			{
				return _isTabTwoVisible;
			}
			set
			{
				_isTabTwoVisible = value;
				OnPropertyChanged();
			}
		}

		public bool IsTabThreeVisible
		{
			get
			{
				return _isTabThreeVisible;
			}
			set
			{
				_isTabThreeVisible = value;
				OnPropertyChanged();
			}
		}

		public bool IsEnabled
		{
			get
			{
				return _isEnabled;
			}
			set
			{
				_isEnabled = value;
				OnPropertyChanged();
			}
		}

		public string DanceTabColor
		{
			get
			{
				return _danceTabColor;
			}
			set
			{
				_danceTabColor = value;
				OnPropertyChanged();
			}
		}

		public string FsTabColor
		{
			get
			{
				return _fsTabColor;
			}
			set
			{
				_fsTabColor = value;
				OnPropertyChanged();
			}
		}

		public string SeTabColor
		{
			get
			{
				return _seTabColor;
			}
			set
			{
				_seTabColor = value;
				OnPropertyChanged();
			}
		}

		public ICommand DanceCommand
		{
			get { return _danceCommand; }
			protected set
			{
				_danceCommand = value;
				OnPropertyChanged();
			}
		}

		public ICommand FsCommand
		{
            get { return _fsCommand; }
			protected set
			{
                _fsCommand = value;
				OnPropertyChanged();
			}
		}

		public ICommand SeCommand
        {
            get { return _seCommand; }
            protected set
            {
                _seCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _danceListClickedCommand;
        public ICommand DanceListClickedCommand
        {
            get { return _danceListClickedCommand; }
            protected set
            {
                _danceListClickedCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _fsListClickedCommand;
        public ICommand FsListClickedCommand
        {
            get { return _fsListClickedCommand; }
            protected set
            {
                _fsListClickedCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _seListClickedCommand;
        public ICommand SeListClickedCommand
        {
            get { return _seListClickedCommand; }
            protected set
            {
                _seListClickedCommand = value;
                OnPropertyChanged();
            }
        }
    
        public VotingPageViewModel(INavigationService navigationService, ISettings settings, IEventBusinessService eventBusinessService) : base(navigationService, settings)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            if (eventBusinessService == null) throw new ArgumentNullException("eventBusinessService");
            if (settings == null) throw new ArgumentNullException("settings");
            _eventBusinesservice = eventBusinessService;
            _navigationService = navigationService;
            _settings = settings;
        }

        public override async Task OnViewAppearing(object navigationParams = null)
        {
            var events = await _eventBusinesservice.GetEvents();
            if (events != null)
            {
                ProcessEvents(events);
            }

            this.IsDanceVoted = false;
            this.IsSeVoted = false;
            this.IsFsVoted = false;

			SetSelectedTab();

			MessagingCenter.Subscribe<string>(this, Globals.CHANGETAB, (tab) =>
			{
				ChangeTab(tab);
			});

            this.DanceListClickedCommand = new Command(async(args) =>
            {
                var DanceListItemClicked = args as Event;
                EventVote ev = new EventVote();
                ev.EventId = DanceListItemClicked.Id;
                ev.EventTypeId = DanceListItemClicked.EventTypeId;
                ev.CreatedBy = GetUDID();
                var udid = GetUDID();
                ev.EventUserDevices = new List<EventUserDevice>() { new EventUserDevice() { EventId = DanceListItemClicked.Id, UDID = udid, CreatedBy = udid } };
                var result = await _eventBusinesservice.CaptureUserVote(ev);
                if (result != null)
                {
                    IsDanceVoted = true;
                }
                else
                {
                    await _navigationService.DisplayAlert("Error in voting", "There was an error in submitting your vote. Please contact the organizers.", "OK");
                }


            }, (args) => true);

            this.FsListClickedCommand = new Command(async(args) =>
            {
                var FsListItemClicked = args as Event;
                EventVote ev = new EventVote();
                ev.EventId = FsListItemClicked.Id;
                ev.EventTypeId = FsListItemClicked.EventTypeId;
                var udid = GetUDID();
                ev.EventUserDevices = new List<EventUserDevice>() { new EventUserDevice() { EventId = FsListItemClicked.Id, UDID = udid, CreatedBy = udid } };
                var result = await _eventBusinesservice.CaptureUserVote(ev);
                if (result!=null)
                {
                    IsFsVoted = true;
                }
                else
                {
                    await _navigationService.DisplayAlert("Error in voting", "There was an error in submitting your vote. Please contact the organizers.", "OK");
                }


            }, (args) => true);

            this.SeListClickedCommand = new Command(async(args) =>
            {
                var SeListItemClicked = args as Event;
                EventVote ev = new EventVote();
                ev.EventId = SeListItemClicked.Id;
                ev.EventTypeId = SeListItemClicked.EventTypeId;
                var udid = GetUDID();
                ev.EventUserDevices = new List<EventUserDevice>() { new EventUserDevice() { EventId = SeListItemClicked.Id, UDID = udid, CreatedBy = udid } };
                var result = await _eventBusinesservice.CaptureUserVote(ev);
                if (result != null)
                {
                    IsSeVoted = true;
                }
                else
                {
                    await _navigationService.DisplayAlert("Error in voting", "There was an error in submitting your vote. Please contact the organizers.", "OK");
                }

            }, (args) => true);


			this.ChangeTabCommand = new Command((tab) =>
			{
				ChangeTab(tab.ToString());
			});
			
			
            this.DanceTabColor = "#000000";
            this.FsTabColor = "#B5B5B5";
            this.SeTabColor = "#B5B5B5";
			
			
			this.DanceCommand = new Command(() =>
			{
                this.DanceTabColor = "#000000";
                this.FsTabColor = "#B5B5B5";
                this.SeTabColor = "#B5B5B5";
				this.IsTabOneVisible = true;
				this.IsTabTwoVisible = false;
				this.IsTabThreeVisible = false;
			}
			, () => true);

			this.FsCommand = new Command(() =>
			{
                this.DanceTabColor = "#B5B5B5";
				this.FsTabColor = "#000000";
				this.SeTabColor = "#B5B5B5";
				this.IsTabOneVisible = false;
				this.IsTabTwoVisible = true;
				this.IsTabThreeVisible = false;
			}
			, () => true);
			
			this.SeCommand = new Command(() =>
			{
				this.DanceTabColor = "#B5B5B5";
				this.FsTabColor = "#B5B5B5";
				this.SeTabColor = "#000000";
				this.IsTabOneVisible = false;
				this.IsTabTwoVisible = false;
				this.IsTabThreeVisible = true;
			}
			, () => true);
            
			this.IsTabOneVisible = true;

            await Task.Run(() => { });
        }

        private string GetUDID()
        {
            return Application.Current.Properties["UserUDID"] as string;
        }

        private string GetDanceId()
        {
            return Application.Current.Properties["DanceTypeId"] as string;
        }

        private string GetFsId()
        {
            return Application.Current.Properties["FsTypeId"] as string;
        }

        private string GetSeId()
        {
            return Application.Current.Properties["SeTypeId"] as string;
        }

        private async Task<int> CheckIfUserVoted(string typeId)
        {
            return await _eventBusinesservice.CheckIfUserHasVoted(typeId, GetUDID());    
        }

        private void ProcessEvents(IEnumerable<Event> events) 
        {
            foreach (var ev in events)
            {
                if(ev.EventType.Title.Equals(Globals.FASHION_SHOW)) 
                {
                    FsEvents.Add(ev);

                } else if (ev.EventType.Title.Equals(Globals.DANCE))
                {
                    DanceEvents.Add(ev);

                } else if (ev.EventType.Title.Equals(Globals.SPECIAL_EVENTS))
                {
                    SeEvents.Add(ev);
                }
            }
        }

		private async void SetSelectedTab()
		{
            //Check for dance voted for the first time
            if (await CheckIfUserVoted(GetDanceId()) >= 1)
            {
                IsDanceVoted = true;
            }
            else
            {
                IsDanceVoted = false;
            }

			if (!this.IsDanceSelected && !this.IsFsSelected && !this.IsSeSelected)
			{
                this.IsDanceSelected = true;
                this.IsFsSelected = false;
                this.IsSeSelected = false;
			}
		}

        public override Task OnViewDisappearing()
        {
            return Task.Run(() => { });
        }

        public override void Dispose()
        {
			MessagingCenter.Unsubscribe<string>(this, Globals.CHANGETAB);
        }

		public async void ChangeTab(string tab)
		{
            this.IsDanceSelected = false;
			this.IsFsSelected = false;
			this.IsSeSelected = false;
			switch (tab.ToString())
			{
				case "Dance": 
					IsDanceSelected = true;
                    if(await CheckIfUserVoted(GetDanceId()) >= 1) 
                    {
                        IsDanceVoted = true;
                    } else {
                        IsDanceVoted = false;  
                    }
				break;
				case "FashionShow": 
					IsFsSelected = true; 
                    if (await CheckIfUserVoted(GetFsId()) >= 1)
                    {
                        IsFsVoted = true;
                    }
                    else
                    {
                        IsFsVoted = false;
                    }
				break;
				case "SpecialEvents": 
					IsSeSelected = true; 
                    if (await CheckIfUserVoted(GetSeId()) >= 1)
                    {
                        IsSeVoted = true;
                    }
                    else
                    {
                        IsSeVoted = false;
                    }
				break;
			}
		}
    }
}
