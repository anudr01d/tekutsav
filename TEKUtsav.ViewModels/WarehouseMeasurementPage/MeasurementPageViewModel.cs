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

namespace TEKUtsav.ViewModels.MeasurementPage
{
	public class MeasurementPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly ISettings _settings;
		private bool clicked = false;
		private ICommand _menuClickCommand, _measurementsClickedCommand;
		private readonly IMeasurementsBusinessService _measurementsBusinessService;

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
			protected set
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

		private Decimal _insideStart;
		public Decimal InsideStart
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


		private decimal _outsideFinishMajor;
		public decimal OutsideFinishMajor
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

		private decimal _outsideFinishMinor;
		public decimal OutsideFinishMinor
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

		private ICommand _verifyCommand;
		public ICommand VerifyCommand
		{
			get
			{
				return _verifyCommand;
			}
			protected set
			{
				_verifyCommand = value;
				OnPropertyChanged("VerifyCommand");
			}
		}

		private ICommand _rejectCommand;
		public ICommand RejectCommand
		{
			get
			{
				return _rejectCommand;
			}
			protected set
			{
				_rejectCommand = value;
				OnPropertyChanged("RejectCommand");
			}
		}

		private bool _isVerifyEnabled;
		public bool IsVerifyEnabled
		{
			get { return _isVerifyEnabled; }
			set
			{
				_isVerifyEnabled = value;
				OnPropertyChanged("IsVerifyEnabled");
				if (this.VerifyCommand != null) { ((Command)this.VerifyCommand).ChangeCanExecute(); }
			}
		}

		private bool _isRejectEnabled;
		public bool IsRejectEnabled
		{
			get { return _isRejectEnabled; }
			set
			{
				_isRejectEnabled = value;
				OnPropertyChanged("IsRejectEnabled");
				if (this.RejectCommand != null) { ((Command)this.RejectCommand).ChangeCanExecute(); }
			}
		}


		private string _rejectColor = Globals.SUBMITDISABLED;
		public string RejectColor
		{
			get
			{
				return _rejectColor;
			}
			set
			{
				_rejectColor = value;
				OnPropertyChanged("RejectColor");
			}
		}

		private string _verifyColor = Globals.SUBMITDISABLED;
		public string VerifyColor
		{
			get
			{
				return _verifyColor;
			}
			set
			{
				_verifyColor = value;
				OnPropertyChanged("VerifyColor");
			}
		}


		private string _verifyTextColor = Globals.WHITE;
		public string VerifyTextColor
		{
			get
			{
				return _verifyTextColor;
			}
			set
			{
				_verifyTextColor = value;
				OnPropertyChanged("VerifyTextColor");
			}
		}

		private string _rejectTextColor = Globals.WHITE;
		public string RejectTextColor
		{
			get
			{
				return _rejectTextColor;
			}
			set
			{
				_rejectTextColor = value;
				OnPropertyChanged("RejectTextColor");
			}
		}


		private string _bgColor = Globals.SUBMITDISABLED;
		public string BgColor
		{
			get
			{
				return _bgColor;
			}
			set
			{
				_bgColor = value;
				OnPropertyChanged("BgColor");
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


		private bool _isUnitSelected;
		public bool IsUnitSelected
		{
			get { return _isUnitSelected; }
			set
			{
				_isUnitSelected = value;
				OnPropertyChanged("IsUnitSelected");
			}
		}

		public MeasurementPageViewModel(INavigationService navigationService, ISettings settings, IMeasurementsBusinessService measurementsBusinessService) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			if (measurementsBusinessService == null) throw new ArgumentNullException("containerConditionsBusinessService");
			_measurementsBusinessService = measurementsBusinessService;
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

			this.MaterialListHeight = (this.MaterialList.Count() * 100) / 2 - 15;
			this.UnitName = "Select Measurement (Units)";
			this.MeasurementsClickedCommand = new Command(() => {
				_navigationService.ShowPopup(TEKUtsavAppPage.MultiSelectionPage, null);
			});

            this.VerifyCommand = new Command(async () =>
			{
				if (!this.clicked)
				{
					this.clicked = true;
					var workFlowItem = PopulateWorkflowItem(false, string.Empty);
					if (VerifyWorkFlowItem(workFlowItem))
					{
						var workflow = await _measurementsBusinessService.VerifyMeasurements(workFlowItem);
						if (workflow != null)
						{
							_navigationService.NavigateBack(TEKUtsavAppPage.PurchaseOrderDetails, null);
						}
					}
                    this.clicked = false;
				}
			});


			this.RejectCommand = new Command(() =>
			{
				if (!this.clicked)
				{
					this.clicked = true;
					var WorkFlowItem = PopulateWorkflowItem(true, string.Empty);
					if (VerifyWorkFlowItem(WorkFlowItem))
					{
						_navigationService.ShowPopup(TEKUtsavAppPage.RejectPopupPage, Material.Name);
					}
					this.clicked = false;
				}
			});

			this.VerifyWorkflow(string.Empty);

			Xamarin.Forms.MessagingCenter.Subscribe<MultiSelectionItem>(this, Globals.MULTIPLE_SELECTION, (args) =>
			{
				this.UnitName = args.Name;
				switch (args.Unit)
				{
					case MeasurementUnits.USCustomary :
						this.Unit = new UsCustomary();
						break;
					case MeasurementUnits.MetricSystem :
						this.Unit = new MetricSystems();
						break;
					case MeasurementUnits.InternationalUnits :
						this.Unit = new InternationalUnits();
						break;
					default:
						break;
				}

				this.IsUnitSelected = true;
				this.VerifyWorkflow(string.Empty);

				_navigationService.ClosePopup();
			});

			MessagingCenter.Subscribe<RejectionItem>(this, Globals.REJECTION_ITEM, async (args) =>
			{
				_navigationService.ClosePopup();
				//if (args.Comments != null && args.Comments != string.Empty)
				//{
					var WorkFlowItem = PopulateWorkflowItem(true, args.Comments);
					if (WorkFlowItem!=null && VerifyWorkFlowItem(WorkFlowItem))
					{
						var item = await _measurementsBusinessService.RejectContainer(WorkFlowItem);
						if (item != null)
						{
							_navigationService.NavigateBack(TEKUtsavAppPage.PurchaseOrderDetails, null); //(TEKUtsavAppPage.ScanCompletedPage, null);
						}
					}
				//}
			});

			Task.Run(() => { });
		}


		private bool VerifyWorkFlowItem(MaterialMeasurement item)
		{
			if (this.Unit == null)
			{
				return false;
			}

			if (!(item.SealNumber != string.Empty && item.SAPMIGONumber != string.Empty && item.TankNumber != string.Empty))
			{
				return false;
			}
			return true;
		}


		public void VerifyWorkflow(string comments)
		{
			var workFlowItem = PopulateWorkflowItem(false, string.IsNullOrEmpty(comments) ? string.Empty : comments);
			if (VerifyWorkFlowItem(workFlowItem))
			{
				IsRejectEnabled = true;
				IsVerifyEnabled = true;
				RejectColor = Globals.RED;
				VerifyColor = Globals.GREEN;
				BgColor = Globals.WHITE;
				RejectTextColor = Globals.RED;
				VerifyTextColor = Globals.GREEN;
			}
			else
			{
				//IsRejectEnabled = false;
				//IsVerifyEnabled = false;
				RejectColor = Globals.SUBMITDISABLED;
				VerifyColor = Globals.SUBMITDISABLED;
				BgColor = Globals.SUBMITDISABLED;
				RejectTextColor = Globals.WHITE;
				VerifyTextColor = Globals.WHITE;
			}
		}

		private MaterialMeasurement PopulateWorkflowItem(bool rejection, string comments)
		{
			if (Unit != null)
			{
				var measurments = new MaterialMeasurement();
				measurments.MeasurementUnitTag = Unit.MeasurementUnitId.ToString();
				measurments.MaterialId = Material.MaterialId;
				measurments.OutsideFinish = OutsideFinishMajor + " " + OutsideFinishMinor;
				measurments.OutsideStart = OutsideStartMajor + " " + OutsideStartMinor;
				measurments.InsideStart = InsideStart.ToString();
				measurments.InsideFinish = InsideFinish.ToString();
				measurments.SampleTemperature = SampleTemperature.ToString();
				measurments.SAPMIGONumber = SAPMIGONumber;
				measurments.DigitalScale = DigitalScale.ToString();
				measurments.TruckTemperature = TruckTemperature.ToString();
				measurments.TruckScale = TruckScale.ToString();
				measurments.TankNumber = TankNumber;
				measurments.SAPWeightReceipt = SapWeightReceipt.ToString();
				measurments.SealNumber = SealNumber;
				measurments.WorkflowId = Material.PoFlow.Id;
				measurments.MaterialId = Material.MaterialId;

				//Add Measurements comment
				var measurementComment = new MaterialMeasurementComment();
				measurementComment.MaterialId = Material.MaterialId;
				measurementComment.WorkflowId = Material.PoFlow.Id;
				if (!rejection)
				{
					measurementComment.IsMaterialApproved = true;
				}
				else
				{
					measurementComment.IsMaterialApproved = false;
					measurementComment.MaterialRejectionComments = comments;
				}
				List<MaterialMeasurementComment> matComList = new List<MaterialMeasurementComment>();
				matComList.Add(measurementComment);
				measurments.MaterialMeasurementComments = matComList;
				return measurments;
			}
			else
			{
				return null;
			}
		}

		public override Task OnViewDisappearing()
		{
			return Task.Run(() => { });
		}

		public override void Dispose()
		{
			MessagingCenter.Unsubscribe<RejectionItem>(this, Globals.REJECTION_ITEM);
		}
	}
}
