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
using TEKUtsav.Models.Entities;
using TEKUtsav.Infrastructure.Constants;

namespace TEKUtsav.ViewModels.VotingPage
{
    public class VotingPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
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


        private List<Event> _danceEvents;
        public List<Event> DanceEvents
        {
            get
            {
                if (_danceEvents == null)
                {
                    var list = new List<Event>();
                    list.Add(new Event() { Name = "Dancing Toons", Desc = "A bunch of dancing cartoons. " });
                    list.Add(new Event() { Name= "Dancing Cartoons", Desc="A bunch of dancing cartoons. Extra animated lot." });
                    list.Add(new Event() { Name = "Dancing Cartoons", Desc = "A bunch of dancing cartoon. Extra animated lot." });
                    return list;
                }
                else
                {
                    return _danceEvents;
                }
            }
            set
            {
                _danceEvents = value;
                OnPropertyChanged("Notifications");
            }
        }


        private List<Event> _fsEvents;
        public List<Event> FsEvents
        {
            get
            {
                if (_fsEvents == null)
                {
                    var list = new List<Event>();
                    list.Add(new Event() { Name = "Fashion Toons", Desc = "A bunch of dancing cartoons with a sense of fashion. (who knew) " });
                    list.Add(new Event() { Name = "Dashing Cartoons", Desc = "A bunch of dancing cartoons with a sense of fashion." });
                    list.Add(new Event() { Name = "Ramp Walkers", Desc = "Nightwalkers, the ramp version. (I'll show myself out)" });
                    return list;
                }
                else
                {
                    return _fsEvents;
                }
            }
            set
            {
                _fsEvents = value;
                OnPropertyChanged("Notifications");
            }
        }

        private List<Event> _seEvents;
        public List<Event> SeEvents
        {
            get
            {
                if (_seEvents == null)
                {
                    var list = new List<Event>();
                    list.Add(new Event() { Name = "Special Events Team", Desc = "A bunch of Special events folks. " });
                    list.Add(new Event() { Name = "Second place people", Desc = "Losers." });
                    list.Add(new Event() { Name = "All the rest", Desc = "..." });
                    return list;
                }
                else
                {
                    return _seEvents;
                }
            }
            set
            {
                _seEvents = value;
                OnPropertyChanged("Notifications");
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

        public VotingPageViewModel(INavigationService navigationService, ISettings settings) : base(navigationService, settings)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            if (settings == null) throw new ArgumentNullException("settings");
            _navigationService = navigationService;
            _settings = settings;
        }

        public override Task OnViewAppearing(object navigationParams = null)
        {
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

			return Task.Run(() => { 	
			});
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
