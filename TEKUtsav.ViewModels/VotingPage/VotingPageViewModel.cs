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
         

		//public Command<SavedInput> ListViewItemClickedCommand
		//{
		//	get
		//	{
		//		return new Command<SavedInput>((ListViewItemClicked) =>
		//		{
		//			if (IsEditModeOn)
		//			{
		//				SetDeleteButtonVisible(ListViewItemClicked);
		//			}
		//			else {
		//				_navigationService.NavigateTo(HuntsmanAppPage.SavedInputParametersPage, ListViewItemClicked);
		//			}
		//		});

		//	}
		//}

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
            ProcessEvents(events);

			SetSelectedTab();

			MessagingCenter.Subscribe<string>(this, Globals.CHANGETAB, (tab) =>
			{
				ChangeTab(tab);
			});

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

		private void SetSelectedTab()
		{
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

		public void ChangeTab(string tab)
		{
            this.IsDanceSelected = false;
			this.IsFsSelected = false;
			this.IsSeSelected = false;
			switch (tab.ToString())
			{
				case "Dance": 
					IsDanceSelected = true;
				break;
				case "FashionShow": 
					IsFsSelected = true; 
				break;
				case "SpecialEvents": 
					IsSeSelected = true; 
				break;
			}
		}
    }
}
