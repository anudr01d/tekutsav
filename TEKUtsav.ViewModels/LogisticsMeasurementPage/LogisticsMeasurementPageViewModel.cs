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
using TEKUtsav.Business.PurchaseOrders;

namespace TEKUtsav.ViewModels.LogisticsMeasurementPage
{
	public class LogisticsMeasurementPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly ISettings _settings;
		private ICommand _menuClickCommand, _measurementsClickedCommand;
		private readonly IPurchaseOrdersBusinessService _purchaseOrderBusinessService;

		public List<PurchaseOrderMaterial> MaterialList
		{
			get
			{
				var list = new List<PurchaseOrderMaterial>();
				list.Add(new PurchaseOrderMaterial() { Name = "Terol 925 # 13721", NetWeight ="850 kg" });
				list.Add(new PurchaseOrderMaterial() { Name = "Terol 250 # 14365", NetWeight ="850 kg" });
				list.Add(new PurchaseOrderMaterial() { Name = "Jeffol R 470 # 255717", NetWeight ="850 kg" });
				return list;
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

		public ICommand MeasurementsClickedCommand
		{
			get { return _measurementsClickedCommand; }
			protected set
			{
				_measurementsClickedCommand = value;
               	OnPropertyChanged("MeasurementsClickedCommand");
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

		private string _unitName;
		public string UnitName
		{
			get { return _unitName;}
			set
			{
				_unitName = value;
				OnPropertyChanged("UnitName");
			}
		}


		private Unit _unit;
		public Unit Unit
		{
			get { return _unit; }
			protected set
			{
				_unit = value;
				OnPropertyChanged("Unit");
			}
		}


		private decimal _insideStart;
		public decimal InsideStart
		{
			get
			{
				return _insideStart;
			}
			set
			{
				_insideStart = value;
				OnPropertyChanged("InsideStart");
			}
		}


		private int _outsideStartMajor;
		public int OutsideStartMajor
		{
			get
			{
				return _outsideStartMajor;
			}
			set
			{
				_outsideStartMajor = value;
				OnPropertyChanged("OutsideStartMajor");
			}
		}

		private int _outsideStartMinor;
		public int OutsideStartMinor
		{
			get
			{
				return _outsideStartMinor;
			}
			set
			{
				_outsideStartMinor = value;
				OnPropertyChanged("OutsideStartMinor");
			}
		}


		private decimal _insideFinish;
		public decimal InsideFinish
		{
			get
			{
				return _insideFinish;
			}
			set
			{
				_insideFinish = value;
				OnPropertyChanged("InsideFinish");
			}
		}


		private int _outsideFinishMajor;
		public int OutsideFinishMajor
		{
			get
			{
				return _outsideFinishMajor;
			}
			set
			{
				_outsideFinishMajor = value;
				OnPropertyChanged("OutsideFinishMajor");
			}
		}

		private int _outsideFinishMinor;
		public int OutsideFinishMinor
		{
			get
			{
				return _outsideFinishMinor;
			}
			set
			{
				_outsideFinishMinor = value;
				OnPropertyChanged("OutsideFinishMinor");
			}
		}


		private decimal _truckTemperature;
		public decimal TruckTemperature
		{
			get
			{
				return _truckTemperature;
			}
			set
			{
				_truckTemperature = value;
				OnPropertyChanged("TruckTemperature");
			}
		}


		private decimal _sampleTemperature;
		public decimal SampleTemperature
		{
			get
			{
				return _sampleTemperature;
			}
			set
			{
				_sampleTemperature = value;
				OnPropertyChanged("SampleTemperature");
			}
		}



		private decimal _truckScale;
		public decimal TruckScale
		{
			get
			{
				return _truckScale;
			}
			set
			{
				_truckScale = value;
				OnPropertyChanged("TruckScale");
			}
		}


		private decimal _digitalScale;
		public decimal DigitalScale
		{
			get
			{
				return _digitalScale;
			}
			set
			{
				_digitalScale = value;
				OnPropertyChanged("DigitalScale");
			}
		}


		private decimal _sapWeightReceipt;
		public decimal SapWeightReceipt
		{
			get
			{
				return _sapWeightReceipt;
			}
			set
			{
				_sapWeightReceipt = value;
				OnPropertyChanged("SapWeightReceipt");
			}
		}

		private string _sapMigoNumber;
		public string SAPMIGONumber
		{
			get
			{
				return _sapMigoNumber != null ? _sapMigoNumber : string.Empty;
			}
			set
			{
				_sapMigoNumber = value;
				OnPropertyChanged("SAPMIGONumber");
			}
		}

		private ScannedMaterial _material;
		public ScannedMaterial Material
		{
			get
			{
				return _material;
			}
			set
			{
				_material = value;
				OnPropertyChanged("Material");
			}
		}

		private string _tankNumber;
		public string TankNumber
		{
			get
			{
				return _tankNumber!=null ? _tankNumber : string.Empty;
			}
			set
			{
				_tankNumber = value;
				OnPropertyChanged("TankNumber");
			}
		}


		private string _sealNumber;
		public string SealNumber
		{
			get
			{
				return _sealNumber!=null ? _sealNumber : string.Empty;
			}
			set
			{
				_sealNumber = value;
				OnPropertyChanged("SealNumber");
			}
		}

		private string _title = Globals.PURCHASEORDERNUMBER;
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

		public LogisticsMeasurementPageViewModel(INavigationService navigationService, ISettings settings, IPurchaseOrdersBusinessService purchaseOrderBusinessService) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			if (purchaseOrderBusinessService == null) throw new ArgumentNullException("containerConditionsBusinessService");
			_purchaseOrderBusinessService = purchaseOrderBusinessService;
			_navigationService = navigationService;
			_settings = settings;

		}
		public override async Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.MeasurementPage);

			if (navigationParams != null)
			{
				this.Material = navigationParams as ScannedMaterial;
                this.Title = Globals.PURCHASEORDERNUMBER + this.Material.Number;
			}

			var poWorkFlow = await _purchaseOrderBusinessService.GetContainerChecklist(this.Material.PurchaseOrderId);
			PopulateFields(poWorkFlow);

			this.MaterialListHeight = (this.MaterialList.Count() * 100) / 2 - 15;

			Task.Run(() => { });
		}

		protected void PopulateFields(PurchaseOrder po)
		{
			var MaterialMeasurements = po.PurchaseOrderWorkFlow.FirstOrDefault().MaterialMeasurements.Where(x => x.MaterialId == this.Material.MaterialId).FirstOrDefault();
			switch (int.Parse(MaterialMeasurements.MeasurementUnitTag))
			{
				case 1 :
                    this.UnitName = Globals.US_CUSTOMARY;
					this.Unit = new UsCustomary();
					break;
				case 2:
					this.UnitName = Globals.METRIC_SYSTEM;
					this.Unit = new MetricSystems();
					break;
				case 3 :
					this.UnitName = Globals.INTERNATIONAL_UNITS;
					this.Unit = new InternationalUnits();
					break;
				default:
					break;
			}

			this.InsideStart = decimal.Parse(MaterialMeasurements.InsideStart);
			var startList = MaterialMeasurements.OutsideStart.Split((char[])null);
			this.OutsideStartMajor = int.Parse(startList[0].ToString());
            this.OutsideStartMinor = int.Parse(startList[1].ToString());
			var finishList = MaterialMeasurements.OutsideFinish.Split((char[])null);
			this.OutsideFinishMajor = int.Parse(finishList[0].ToString());
            this.OutsideFinishMinor = int.Parse(finishList[1].ToString());
			this.InsideFinish = decimal.Parse(MaterialMeasurements.InsideFinish);
			this.TruckTemperature = decimal.Parse(MaterialMeasurements.TruckTemperature);
			this.SampleTemperature = decimal.Parse(MaterialMeasurements.SampleTemperature);
			this.TruckScale = decimal.Parse(MaterialMeasurements.TruckScale);
			this.DigitalScale = decimal.Parse(MaterialMeasurements.DigitalScale);
			this.SapWeightReceipt = decimal.Parse(MaterialMeasurements.SAPWeightReceipt);
			this.TankNumber = MaterialMeasurements.TankNumber;
			this.SealNumber = MaterialMeasurements.SealNumber;
			this.SAPMIGONumber = MaterialMeasurements.SAPMIGONumber;
		}
		public override Task OnViewDisappearing()
		{
			return Task.Run(() => { });
		}

		public override void Dispose()
		{
			//MessagingCenter.Unsubscribe<MultiSelectionItem>(this, Globals.MULTIPLE_SELECTION);
		}
	}
}
