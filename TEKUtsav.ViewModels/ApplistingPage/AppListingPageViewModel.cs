using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.ViewModels.BaseViewModel;
using TEKUtsav.Infrastructure.Settings;
using TEKUtsav.Infrastructure;
using TEKUtsav.Models;
using TEKUtsav.Infrastructure.Constants;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace TEKUtsav.ViewModels.AppListingPage
{
    public class AppListingPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ISettings _settings;
        private AppUnit[] _businessUnits;
        private string _filter;
        private List<AppUnit> _filteredBusinessUnits;
		private ICommand _toggleSortCommand;
		private bool _toggle;
		private ICommand _menuClickCommand;


        public AppUnit[] BusinessUnits
        {
            get
            {
				_businessUnits = ArrayInitializer.InitializeArray<AppUnit>(1);
				_businessUnits[0].Name = Globals.TEKUtsavSCAN;
                return _businessUnits;
            }
            set
            {
                _businessUnits = value;
                OnPropertyChanged();
            }
        }
        public List<AppUnit> FilteredBusinessUnits
        {
            get
            {
                return _filteredBusinessUnits;
            }
            set
            {
                _filteredBusinessUnits = value;
                OnPropertyChanged();
            }
        }


		public bool Toggle
		{
			get
			{
				return _toggle;
			}
			set
			{
				_toggle = value;
				OnPropertyChanged("Toggle");
			}
		}


        public String Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                OnPropertyChanged("Filter");
                if(this.FilteredBusinessUnits != null)
                {   
                    this.FilteredBusinessUnits = this.BusinessUnits.Where(delegate(AppUnit Item) {
                        if (string.IsNullOrEmpty(Filter)) return true; 
						return Item.Name.ToLower().Contains(Filter.ToLower()); }).ToList();
                }
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

		public AppListingPageViewModel(INavigationService navigationService, ISettings settings) : base(navigationService, settings)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            if (settings == null) throw new ArgumentNullException("settings");
            _navigationService = navigationService;
            _settings = settings;
        }

        public override async Task OnViewAppearing(object navigationParams = null)
        {
			this.SetCurrentPage(TEKUtsavAppPage.AppListingPage);

            this.FilteredBusinessUnits = this.BusinessUnits.ToList();

			return;
        }


        public override Task OnViewDisappearing()
        {
            return Task.Run(() => { });
        }

        public override void Dispose()
        {
        }

		public ICommand ToggleSortCommand
		{
			get { 
				return _toggleSortCommand; 
			}
			protected set
			{
				_toggleSortCommand = value;
				OnPropertyChanged("ToggleSortCommand");
			}
		}

		public Command<AppUnit> BusinessUnitNavigationCommand
        {
            get
            {
				return new Command<AppUnit>((BusinessUnitClicked) =>
                {
					var userrole = GetUserRole();
                    switch (BusinessUnitClicked.Name)
                    {
						case Globals.TEKUtsavSCAN:
							if (userrole.ToLower() == Globals.WAREHOUSE_USER)
							{
								//true for warehouse user. false for logistics user
								_navigationService.NavigateTo(TEKUtsavAppPage.MasterMenuPage, true);
							}
							else if (userrole.ToLower() == Globals.LOGISTICS_USER)
							{
								_navigationService.NavigateTo(TEKUtsavAppPage.MasterMenuPage, false);
							}
							else
							{
								_navigationService.NavigateTo(TEKUtsavAppPage.MasterMenuPage, true);
							}
                            break;
                    }
                });

            }
        }

		private string GetUserRole()
		{
			try
			{
				return Application.Current.Properties["role"] as string;
			}
			catch (Exception e)
			{
				return Globals.WAREHOUSE_USER;
			}
		}
    }
}
