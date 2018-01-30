using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.Settings;
using TEKUtsav.ViewModels.BaseViewModel;
using TEKUtsav.Models.Entities;
using TEKUtsav.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using System.Diagnostics;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System.ComponentModel;
using System.Collections.ObjectModel;
using TEKUtsav.Infrastructure;

namespace TEKUtsav.ViewModels.MultiSelectionPage
{
    public class MultiSelectionPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ISettings _settings;
		private int _height;

		public List<MultiSelectionItem> MeasurementItems
		{
			get
			{
				var list = new List<MultiSelectionItem>();
				list.Add(new MultiSelectionItem() { Name = Globals.US_CUSTOMARY, Unit = MeasurementUnits.USCustomary});
				list.Add(new MultiSelectionItem() { Name = Globals.METRIC_SYSTEM, Unit = MeasurementUnits.MetricSystem});
				list.Add(new MultiSelectionItem() { Name = Globals.INTERNATIONAL_UNITS, Unit = MeasurementUnits.InternationalUnits});
				return list;
			}
		}

		public int Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
				OnPropertyChanged("Height");
			}
		}

		public Command<MultiSelectionItem> MenuItemClickCommand
		{
			get
			{
				return new Command<MultiSelectionItem>((cell) =>
				{
					var item = cell;
					var selectedItem = this.MeasurementItems.SingleOrDefault(i => i.Name==cell.Name);
					MessagingCenter.Send(selectedItem, Globals.MULTIPLE_SELECTION);
				});

			}
		}

		public  MultiSelectionPageViewModel(INavigationService navigationService, ISettings settings) : base(navigationService, settings)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			_settings = settings;
            _navigationService = navigationService;
        }
        public override async Task OnViewAppearing(object navigationParams = null)
        {
			this.SetCurrentPage(TEKUtsavAppPage.MultiSelectionPage);

			this.Height = (this.MeasurementItems.Count * 100) / 2;
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
