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
using TEKUtsav.Infrastructure.Constants;

namespace TEKUtsav.ViewModels.PurchaseOrderDetailsPage
{
	public class PurchaseOrderDetailsPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly ISettings _settings;
		private ICommand _menuClickCommand;
		private string _purchaseOrderId;
		private readonly IPurchaseOrdersBusinessService _purchaseOrdersBusinessService;
		private bool clicked = false;

		private List<PurchaseOrderMaterial> _materialList;
		public List<PurchaseOrderMaterial> MaterialList
		{
			get
			{
				return _materialList;
			}
			protected set
			{
				_materialList = value;
				OnPropertyChanged("MaterialList");
			}
		}
		private PurchaseOrder _purchaseOrderItem;
		public PurchaseOrder PurchaseOrderItem
		{
			get
			{
				return _purchaseOrderItem;
			}
			protected set
			{
				_purchaseOrderItem = value;
				OnPropertyChanged("PurchaseOrderItem");
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

		private ICommand _moveToNextScreenCommand;
		public ICommand MoveToNextScreenCommand
		{
			get
			{
				return _moveToNextScreenCommand;
			}
			set
			{
				_moveToNextScreenCommand = value;
				OnPropertyChanged("MoveToNextScreenCommand");
			}
		}

		private ICommand _moveToScanCompletedCommand;
		public ICommand MoveToScanCompletedCommand
		{
			get
			{
				return _moveToScanCompletedCommand;
			}
			set
			{
				_moveToScanCompletedCommand = value;
               	OnPropertyChanged("MoveToScanCompletedCommand");
			}
		}

		private int _materialListHeight;
		public int MaterialListHeight
		{
			get { return _materialListHeight; }
			protected set
			{
				_materialListHeight = value;
				OnPropertyChanged("MaterialListHeight");
			}
		}

		private int _purchaseOrderMaterialCount;
		public int PurchaseOrderMaterialCount
		{
			get { return _purchaseOrderMaterialCount; }
			protected set
			{
				_purchaseOrderMaterialCount = value;
               	OnPropertyChanged("PurchaseOrderMaterialCount");
			}
		}


		private string _title;
		public string Title
		{
			get { return _title; }
			protected set
			{
				_title = value;
				OnPropertyChanged("Title");
			}
		}

		private bool _isLoading = true;
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

		private ICommand _navigateToPurchaseOrders;
		public ICommand NavigateToPurchaseOrders
		{
			get
			{
				return _navigateToPurchaseOrders;
			}
			protected set
			{
				_navigateToPurchaseOrders = value;
             	OnPropertyChanged("NavigateToPurchaseOrders");
			}
		}

		private ICommand _submitCommand;
		public ICommand SubmitCommand
		{
			get
			{
				return _submitCommand;
			}
			protected set
			{
				_submitCommand = value;
				OnPropertyChanged("SubmitCommand");
			}
		}

		private bool _isEnabled = false;
		public bool IsEnabled
		{
			get
			{
				return _isEnabled;
			}
			set
			{
				_isEnabled = value;
				OnPropertyChanged("IsEnabled");
				if (this.SubmitCommand != null) { ((Command)this.SubmitCommand).ChangeCanExecute(); }
			}
		}

		private string _submitColor = Globals.SUBMITDISABLED;
		public string SubmitColor
		{
			get
			{
				return _submitColor;
			}
			set
			{
				_submitColor = value;
				OnPropertyChanged("SubmitColor");
			}
		}

		private string _textColor = Globals.WHITE;
		public string TextColor
		{
			get
			{
				return _textColor;
			}
			set
			{
				_textColor = value;
				OnPropertyChanged("TextColor");
			}
		}


		private string _containerType = Globals.NONE;
		public string ContainerType
		{
			get
			{
				return _containerType;
			}
			set
			{
				_containerType = value;
				OnPropertyChanged("ContainerType");
			}
		}

		public PurchaseOrderDetailsPageViewModel(INavigationService navigationService, ISettings settings, IPurchaseOrdersBusinessService purchaseOrderBusinessService) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			if (purchaseOrderBusinessService == null) throw new ArgumentException("purchaseorderbusinessservice");
			_purchaseOrdersBusinessService = purchaseOrderBusinessService;
			_navigationService = navigationService;
			_settings = settings;
		}

		public override async Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.PurchaseOrderDetails);

			this.Title = Globals.PURCHASEORDERNUMBER;
			if (navigationParams != null)
			{
				_purchaseOrderId = navigationParams.ToString();
				this.PurchaseOrderItem = await _purchaseOrdersBusinessService.GetPurchaseOrder(_purchaseOrderId);
				this.ContainerType = this.PurchaseOrderItem.PurchaseOrderMaterials.FirstOrDefault().ContainerType;
				this.MaterialList = this.PurchaseOrderItem.PurchaseOrderMaterials;
				this.PurchaseOrderMaterialCount = this.PurchaseOrderItem.PurchaseOrderMaterials.Count;
				this.Title = Globals.PURCHASEORDERNUMBER + PurchaseOrderItem.Number;
				this.MaterialListHeight = this.MaterialList.Count() * 80; //-40;//(this.MaterialList.Count() * 100) / 2 -30;//this.MaterialList.Count() * 80;//

				var mat = this.MaterialList.Where(x=> (x.PurchaseOrderMaterialStatus!=null && x.PurchaseOrderMaterialStatus.IsMaterialRejected.HasValue));
				if (mat.Count() == this.MaterialList.Count())
				{
					this.SubmitColor = Globals.GREEN;
					this.IsEnabled = true;
					this.TextColor = Globals.WHITE;
				}
			}
			this.IsLoading = false;

            this.NavigateToPurchaseOrders = new Command(() =>
		   {
			   _navigationService.NavigateBack();
		   });

            this.MoveToScanCompletedCommand = new Command(() =>
			{
				_navigationService.NavigateTo(TEKUtsavAppPage.ScannerPage, null);
			});

			this.SubmitCommand = new Command(() =>
			{
				if (!this.clicked)
				{
					this.clicked = true;
					_navigationService.ShowPopup(TEKUtsavAppPage.WarehouseApprovalPopupPage);
					this.clicked = false;
				}

			}, () => { return IsEnabled; });


			MessagingCenter.Subscribe<RejectionItem>(this, Globals.SUBMIT_ITEM, async (args) =>
			{
				await Submit();
			});

			Task.Run(() => { });
		}

		private async Task Submit()
		{
			var postatus = new PurchaseOrderStatus() { IsSubmitted = true };
			this.PurchaseOrderItem.PurchaseOrderStatus = postatus;
			var PO = await _purchaseOrdersBusinessService.SubmitPurchaseOrder(this.PurchaseOrderItem);
			if (PO != null)
			{
				_navigationService.NavigateBack();
			}
		}


		public Command<PurchaseOrderMaterial> PurchaseOrderMaterialClickedCommand
		{
			get
			{
				return new Command<PurchaseOrderMaterial>((PurchaseOrderClick) =>
				{
					if (PurchaseOrderClick.PurchaseOrderMaterialStatus == null)
					{
						ScanResult res = new ScanResult() { RemoveScan = false, ResultText = "", MaterialId = PurchaseOrderClick.MaterialId, PurchaseOrderId = PurchaseOrderClick.PurchaseOrderId };
						_navigationService.NavigateTo(TEKUtsavAppPage.ScanCompletedPage, res);
					}
					else
					{
						if (!PurchaseOrderClick.PurchaseOrderMaterialStatus.IsMaterialRejected.HasValue)
						{
							ScanResult res = new ScanResult() { RemoveScan = false, ResultText = "", MaterialId = PurchaseOrderClick.MaterialId, PurchaseOrderId = PurchaseOrderClick.PurchaseOrderId };
							_navigationService.NavigateTo(TEKUtsavAppPage.ScanCompletedPage, res);
						}
					}

				});
			}
		}


		public override Task OnViewDisappearing()
		{
			return Task.Run(() => { });
		}

		public override void Dispose()
		{
			MessagingCenter.Unsubscribe<RejectionItem>(this, Globals.SUBMIT_ITEM);
		}
	}
}
