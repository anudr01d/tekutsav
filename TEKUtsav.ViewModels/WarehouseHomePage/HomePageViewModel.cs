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

namespace TEKUtsav.ViewModels.HomePage
{
	public class HomePageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
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

		public HomePageViewModel(INavigationService navigationService, ISettings settings) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			//if (purchaseOrdersBusinessService == null) throw new ArgumentNullException("purchaseOrdersBusinessService");
			_navigationService = navigationService;
			_settings = settings;
			//_purchaseOrdersBusinessService = purchaseOrdersBusinessService;
		}
		public override async Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.HomePage);

			await GetPurchaseOrders();

            this.NotificationsCommand = new Command(async () =>
			{
                _navigationService.NavigateTo(TEKUtsavAppPage.NotificationsPage);
				//this.IsLoading = true;
				////var syncStatus = await _purchaseOrdersBusinessService.SyncSapData();
				//this.IsLoading = false;

				//if (syncStatus)
				//{
				//	await GetPurchaseOrders();
				//}
			});

            this.VotingCommand = new Command(() =>
            {
                _navigationService.NavigateTo(TEKUtsavAppPage.VotingPage);
            });

			await Task.Run(() => { });
		}

		private async Task GetPurchaseOrders()
		{
   //         this.IsLoading = true;
			//this.PurchaseOrders = await _purchaseOrdersBusinessService.GetPurchaseOrders();
			//this.IsLoading = false;
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
