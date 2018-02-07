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
using TEKUtsav.ViewModels.BaseViewModel;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.Settings;
using TEKUtsav.Models.Entities;
using TEKUtsav.Infrastructure.Constants;

namespace TEKUtsav.ViewModels.SingleSelectionPage
{
    public class SingleSelectionPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ISettings _settings;
		private SingleSelectionItem[] _locationArr;
        private List<SingleSelectionItem> _selectionItems;
		private ICommand _menuClickCommand;
		private int _height;
		private string _title;

		public SingleSelectionItem[] LocationArr
		{
			get
			{
                _locationArr = InitializeArray<SingleSelectionItem>(2);
                _locationArr[0].Name = Globals.ECOSPACE;
                _locationArr[1].Name = Globals.WHITEFIELD;

                foreach (var type in _locationArr)
				{
                    type.Type = Globals.LOCATION;
				}

                return _locationArr;
			}
			set
			{
                _locationArr = value;
				OnPropertyChanged();
			}
		}

		public List<SingleSelectionItem> SelectionItems
		{
			get
			{
				return _selectionItems;
			}
			set
			{
				_selectionItems = value;
				OnPropertyChanged();
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
				OnPropertyChanged();
			}
		}

		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
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


		public Command<SingleSelectionItem> MenuItemClickCommand
		{
			get
			{
				return new Command<SingleSelectionItem>((selectionItemClicked) =>
				{
					MessagingCenter.Send(selectionItemClicked, Globals.SINGLE_SELECTION);
					_navigationService.ClosePopup();
				});

			}
		}

		public SingleSelectionPageViewModel(INavigationService navigationService, ISettings settings) : base(navigationService, settings)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			_settings = settings;
            _navigationService = navigationService;
        }
        public override Task OnViewAppearing(object navigationParams = null)
        {

			if (this.NavigationParameter != null)
			{
				var origin = this.NavigationParameter.ToString();
				PopulateMenuItems(origin);
				this.NavigationParameter = null;
				this.Height = (this.SelectionItems.Count * 100) / 2;
			}

            return Task.Run(() => { });
        }


		private void PopulateMenuItems(string origin)
		{
            this.SelectionItems = this.LocationArr.ToList();
            if (origin == Globals.LOCATION)
			{
				this.SelectionItems.Clear();
                this.SelectionItems = this.LocationArr.ToList();
                this.Title = Globals.LOCATION;
			}
		}

        public override Task OnViewDisappearing()
        {
            return Task.Run(() => { });
        }

        public override void Dispose()
        {
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
