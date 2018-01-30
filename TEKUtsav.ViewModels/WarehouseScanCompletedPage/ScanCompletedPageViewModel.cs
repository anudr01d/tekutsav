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

namespace TEKUtsav.ViewModels.ScanCompletedPage
{
	public class ScanCompletedPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly ISettings _settings;
		private ICommand _menuClickCommand;
		private readonly IPurchaseOrdersBusinessService _purchaseOrderBusinessService;

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


        private ScannedMaterial _material;                                                                                                                                                                                                  
		public ScannedMaterial Material
		{
			get { return _material; }
			set
			{
				_material = value;
				OnPropertyChanged("Material");
			}
		}

		private string _title;
		public string Title
		{
			get
			{
				return _title;
			}
			set
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
			set
			{
				_isLoading = value;
				OnPropertyChanged("IsLoading");
			}
		}

		public ScanCompletedPageViewModel(INavigationService navigationService, ISettings settings, IPurchaseOrdersBusinessService purchaseOrderBusinessService) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			if (purchaseOrderBusinessService == null) throw new ArgumentNullException("purchaseOrderBusinessService");
			_purchaseOrderBusinessService = purchaseOrderBusinessService;
			_navigationService = navigationService;
			_settings = settings;
		}
		public override async Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.ScanCompletedPage);

			this.Title = Globals.PURCHASEORDERNUMBER;
			this.IsLoading = true;
			if (navigationParams != null)
			{
				ScanResult res = (TEKUtsav.Models.ScanResult)navigationParams;
				if (res.RemoveScan)
				{
					_navigationService.RemoveScannerPage();
				}
				navigationParams = null;
				if (res.PurchaseOrderId != null && res.MaterialId != null)
				{
					this.Material = await _purchaseOrderBusinessService.GetPurchaseOrderMaterial(res.PurchaseOrderId, res.MaterialId);
					this.Title = Globals.PURCHASEORDERNUMBER + Material.Number;
				}
				this.IsLoading = false;
			}

			this.MoveToNextScreenCommand = new Command(() =>
		   {
				if (this.Material.PoFlow != null)
				{
					var Comments = this.Material.PoFlow.ContainerConditionComments
									   .Where(x =>
											  x.MaterialId == this.Material.MaterialId
											  && x.WorkflowId == Material.PoFlow.Id)
									   .FirstOrDefault();
					if (Comments != null)
					{
						if (Comments.IsContainerApproved)
						{
						   var mat = this.Material.PoFlow.MaterialMeasurements
									 .Where(x =>
											x.MaterialId == this.Material.MaterialId
											&& x.WorkflowId == Material.PoFlow.Id)
										  .FirstOrDefault();
						   if (mat == null)
						   {
							   _navigationService.NavigateTo(TEKUtsavAppPage.MeasurementPage, this.Material);
						   }
						}
				   }
				   else
				   {
						_navigationService.NavigateTo(TEKUtsavAppPage.ContainerConditionsPage, this.Material);
				   }
			   }
			   else
			   {
					_navigationService.NavigateTo(TEKUtsavAppPage.ContainerConditionsPage, this.Material);
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
