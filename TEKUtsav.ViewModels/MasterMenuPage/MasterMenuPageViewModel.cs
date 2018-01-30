using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using System.Windows.Input;
using TEKUtsav.ViewModels.BaseViewModel;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.CookieStorage;
using TEKUtsav.Infrastructure.Settings;
using TEKUtsav.Models;
using TEKUtsav.Infrastructure.Constants;

namespace TEKUtsav.ViewModels.MasterMenuPage
{
	public class MasterMenuPageViewModel : ViewModelBase
	{
		public Action<TEKUtsavAppPage> MenuItemSelectionChanged;
		private readonly INavigationService _navigationService;
		private List<HamburgerMenuItem> _businessUnits;
		private IPlatformCookieStore _cookieStore;
		private ICommand _tapCommand, _applicationsListingCommand;

		private int _height;
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

		private int _settingsHeight;
		public int SettingsHeight
		{
			get
			{
				return _settingsHeight;
			}
			set
			{
				_settingsHeight = value;
				OnPropertyChanged("SettingsHeight");
			}
		}



		public List<HamburgerMenuItem> BusinessUnits
		{
			get
			{
				if (_businessUnits == null)
				{
					var list = new List<HamburgerMenuItem>();
					list.Add(new HamburgerMenuItem() { Name = "Inbound", IsSelected = false });
					list.Add(new HamburgerMenuItem() { Name = "Outbound", IsSelected = false });
					list.Add(new HamburgerMenuItem() { Name = "Inventory", IsSelected = false });
					return list;
				}
				else
				{
					return _businessUnits;
				}
			}
			set
			{
				_businessUnits = value;
				OnPropertyChanged("BusinessUnits");
			}
		}

		public ICommand TapCommand
		{
			get { return _tapCommand; }
			protected set
			{
				_tapCommand = value;
				OnPropertyChanged();
			}
		}

		public ICommand ApplicationsListingCommand
		{
			get { return _applicationsListingCommand; }
			protected set
			{
				_applicationsListingCommand = value;
				OnPropertyChanged();
			}
		}

		private ICommand _logoutCommand;
		public ICommand LogoutCommand
		{
			get { return _logoutCommand; }
			protected set
			{
				_logoutCommand = value;
				OnPropertyChanged("LogoutCommand");
			}
		}

		private string _userName;
		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
				OnPropertyChanged("UserName");
			}
		}

		public MasterMenuPageViewModel(ISettings settings,
		   INavigationService navigationService, IPlatformCookieStore cookieStore)
				   : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (cookieStore == null) throw new ArgumentNullException("cookieStore");
			_navigationService = navigationService;
			_cookieStore = cookieStore;
		}

		public override Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.MasterMenuPage);

			this.TapCommand = new Command(() =>
			{
				_navigationService.CloseMenu();
			}
			, () => true);

			this.ApplicationsListingCommand = new Command(() =>
			{
				_navigationService.CloseMenu();
				_navigationService.NavigateToRoot();
				_navigationService.NavigateTo(TEKUtsavAppPage.AppListingMasterMenuPage);
			}
			, () => true);


			this.LogoutCommand = new Command(() =>
			{
                DeleteCookies();
				_navigationService.NavigateTo(TEKUtsavAppPage.LoginPage);
			}
			, () => true);

			this.SettingsHeight = (this.BusinessUnits.Count() * 100) / 2 - 15;

			try
			{
				string cookie = Application.Current.Properties[".AspNet.ExternalCookie"] as string;
				string username = Application.Current.Properties["username"] as string;
				if (username.Length < 10)
				{
					this.UserName = username;
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.StackTrace);
			}

			HamburgerMenuNavigationCommand.Execute(new HamburgerMenuItem() { IsSelected = false, Name = "Inbound"});

			return Task.Run(() => { });
		}

		public override Task OnViewDisappearing()
		{
			return Task.Run(() => { });
		}

		public override void Dispose()
		{
			throw new NotImplementedException();
		}

		public Command<HamburgerMenuItem> HamburgerMenuNavigationCommand
		{
			get
			{
				return new Command<HamburgerMenuItem>((HamburgerMenuItemClicked) =>
				{
                    SetSelected(HamburgerMenuItemClicked);
				});

			}
		}

		private void SetSelected(HamburgerMenuItem menuItem)
		{
			var localBusinessUnits = new List<HamburgerMenuItem>();
			foreach (var item in BusinessUnits)
			{
				if (item.Name == menuItem.Name)
				{
					if (!item.IsSelected)
					{
						item.IsSelected = true;
						if (item.Name == "Inbound")
						{
							_navigationService.CloseMenu();
						}
					}
				}
				else
				{
					item.IsSelected = false;
				}
				localBusinessUnits.Add(item);
			}
			this.BusinessUnits = localBusinessUnits;
		}

		public void DeleteCookies()
		{
			_cookieStore.DeleteAllCookiesForSite(Globals.OKTA_SP_URL);
			_cookieStore.DeleteAllCookiesForSite(Globals.OKTA_IDP_URL);
			_cookieStore.DeleteAllCookiesForSite(Globals.OKTAUSERDOMAIN);
		}
	}
}
