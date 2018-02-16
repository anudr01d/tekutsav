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
using TEKUtsav.Business.PurchaseOrders;
using Plugin.ExternalMaps;
using TEKUtsav.Business.EventService;
using TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Infrastructure.Constants;

namespace TEKUtsav.ViewModels.HomePage
{
	public class HomePageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
        private readonly IEventBusinessService _eventBusinessService;
		private readonly ISettings _settings;
		private ICommand _notificationsCommand;
		private PurchaseOrder[] _requisitions;
		public List<PurchaseOrder> _purchaseOrders;

		int _tapCount = 0;

		public List<PurchaseOrder> PurchaseOrders
		{
			get
			{
				return _purchaseOrders;
			}
			set
			{
				_purchaseOrders = value;
				OnPropertyChanged();
			}
		}

        public ICommand NotificationsCommand
		{
			get { return _notificationsCommand; }
			protected set
			{
				_notificationsCommand = value;
				OnPropertyChanged();
			}
		}

        private ICommand _eventScheduleCommand;
        public ICommand EventScheduleCommand
        {
            get { return _eventScheduleCommand; }
            protected set
            {
                _eventScheduleCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _contactDetailsCommand;
        public ICommand ContactDetailsCommand
        {
            get { return _contactDetailsCommand; }
            protected set
            {
                _contactDetailsCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _votingCommand;
        public ICommand VotingCommand
        {
            get { return _votingCommand; }
            protected set
            {
                _votingCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _eventLocationCommand;
        public ICommand EventLocationCommand
        {
            get { return _eventLocationCommand; }
            protected set
            {
                _eventLocationCommand = value;
                OnPropertyChanged();
            }
        }

		private bool _canExecute = true;
		public bool CanExecute
		{
			get
			{
				return _canExecute;
			}
			protected set
			{
				_canExecute = value;
				((Command)_notificationsCommand).ChangeCanExecute();
				OnPropertyChanged();
			}
		}

		private bool _isLoading = false;
		public bool IsLoading
		{
			get
			{
				return _isLoading;
			}
			protected set
			{
				_isLoading = value;
				OnPropertyChanged("IsLoading");
			}
		}

        private string _html = "<html><body><iframe src=\"https://www.youtube.com/watch?v=a2A2APdahn4\" frameborder=\"0\" allowfullscreen></iframe></body></html>";
        public string Html
        {
            get
            {
                return _html;
            }
            protected set
            {
                _html = value;
                OnPropertyChanged("Html");
            }
        }

		private bool _isSyncing = false;
		public bool IsSyncing
		{
			get
			{
				return _isSyncing;
			}
			protected set
			{
				_isSyncing = value;
				OnPropertyChanged("IsSyncing");
			}
		}

        public HomePageViewModel(INavigationService navigationService, ISettings settings, IEventBusinessService eventBusinessService) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			//if (purchaseOrdersBusinessService == null) throw new ArgumentNullException("purchaseOrdersBusinessService");
			_navigationService = navigationService;
			_settings = settings;
            _eventBusinessService = eventBusinessService;
			//_purchaseOrdersBusinessService = purchaseOrdersBusinessService;
		}
		public override async Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.HomePage);

            await GetEventTypes();

            this.NotificationsCommand = new Command(() =>
			{
                _navigationService.NavigateTo(TEKUtsavAppPage.NotificationsPage);
			});

            this.VotingCommand = new Command(() =>
            {
                _navigationService.NavigateTo(TEKUtsavAppPage.VotingPage);
            });

            this.EventScheduleCommand = new Command(() =>
            {
                _navigationService.NavigateTo(TEKUtsavAppPage.EventSchedulePage);
            });

            this.ContactDetailsCommand = new Command(() =>
            {
                _navigationService.NavigateTo(TEKUtsavAppPage.ContactDetailsPage);
            });

            this.EventLocationCommand = new Command(async() => 
            { 
                var success = await CrossExternalMaps.Current.NavigateTo("Kanva Star Resort", 13.1034, 77.4372); 
                if(!success) 
                {
                   await _navigationService.DisplayAlert("Error displaying location", "Please look for Kanva Star Resort within Google Maps", "Ok");    
                }
            });

			await Task.Run(() => { });
		}

		private async Task GetEventTypes()
		{
            var lstEventTypes = await _eventBusinessService.GetEventTypes();
            foreach (var ev in lstEventTypes)
            {
                if (ev.Title.Equals(Globals.DANCE))
                {
                    Application.Current.Properties["DanceTypeId"] = ev.Id;
                }
                else if (ev.Title.Equals(Globals.FASHION_SHOW))
                {
                    Application.Current.Properties["FsTypeId"] = ev.Id;
                }
                else if (ev.Title.Equals(Globals.SPECIAL_EVENTS))
                {
                    Application.Current.Properties["SeTypeId"] = ev.Id;
                }
            }
             
        }

		public override Task OnViewDisappearing()
		{
			return Task.Run(() => { });
		}

		public override void Dispose()
		{
		}

		public Command<PurchaseOrder> PurchaseOrderNavigationCommand
		{
			get
			{
				return new Command<PurchaseOrder>((PurchaseOrderClick) =>
				{
					if (PurchaseOrderClick.PurchaseOrderStatus == null)
					{
						_navigationService.NavigateTo(TEKUtsavAppPage.PurchaseOrderDetails, PurchaseOrderClick.Id);
					}
					else
					{
						_navigationService.ShowPopup(TEKUtsavAppPage.WorkFlowCompletedPopupPage, null);
					}
				});
			}
		}

		T[] InitializeArray<T>(int length) where T : new()
		{
			T[] array = new T[length];
			for (int i = 0; i < length; ++i)
			{
				array[i] = new T();
			}

			return array;
		}
	}
}
