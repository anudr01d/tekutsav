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

namespace TEKUtsav.ViewModels.LogisticsHomePage
{
	public class LogisticsHomePageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly ISettings _settings;
		private ICommand _menuClickCommand;
		private PurchaseOrder[] _requisitions;
		public List<PurchaseOrder> _purchaseOrders;
		private readonly IPurchaseOrdersBusinessService _purchaseOrdersBusinessService;

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

		public ICommand MenuClickCommand
		{
			get { return _menuClickCommand; }
			protected set
			{
				_menuClickCommand = value;
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
				((Command)_menuClickCommand).ChangeCanExecute();
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

		private ICommand _refreshCommand;
		public ICommand RefreshCommand
		{
			get { return _refreshCommand; }
			set
			{
				_refreshCommand = value;
				OnPropertyChanged("RefreshCommand");
			}
		}

		public LogisticsHomePageViewModel(INavigationService navigationService, ISettings settings, IPurchaseOrdersBusinessService purchaseOrdersBusinessService) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			if (purchaseOrdersBusinessService == null) throw new ArgumentNullException("purchaseOrdersBusinessService");
			_navigationService = navigationService;
			_settings = settings;
			_purchaseOrdersBusinessService = purchaseOrdersBusinessService;
		}
		public override async Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.HomePage);

			await GetPurchaseOrders();

            this.RefreshCommand = new Command(async () =>
			{
                this.IsLoading = true;
				var syncStatus = await _purchaseOrdersBusinessService.SyncSapData();
				this.IsLoading = false;

				if (syncStatus)
				{
					await GetPurchaseOrders();
				}
			});

			await Task.Run(() => { });
		}

		private async Task GetPurchaseOrders()
		{
            this.IsLoading = true;
			this.PurchaseOrders = await _purchaseOrdersBusinessService.GetCompletedPurchaseOrders();
			this.IsLoading = false;
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
					if (PurchaseOrderClick.PurchaseOrderStatus!=null)
					{
						_navigationService.NavigateTo(TEKUtsavAppPage.LogisticsPurchaseOrderDetails, PurchaseOrderClick.Id);
					}
					else
					{
						_navigationService.ShowPopup(TEKUtsavAppPage.LogisticsIncompleteWorkflow);
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
