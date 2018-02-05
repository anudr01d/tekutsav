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
using System.Net;
using System.IO;
using Newtonsoft.Json;
//using TEKUtsav.Models.Entities;
using TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.ViewModels.AppListingMasterMenuPage
{
	public class AppListingMasterMenuPageViewModel : ViewModelBase
	{
		public Action<TEKUtsavAppPage> MenuItemSelectionChanged;
		private readonly INavigationService _navigationService;
		private HamburgerMenuItem[] _businessUnits, _businessActions;
		private IPlatformCookieStore _cookieStore;
		private ICommand _tapCommand, _homeCommand;

		public ICommand TapCommand
		{
			get { return _tapCommand; }
			protected set
			{
				_tapCommand = value;
				OnPropertyChanged();
			}
		}

		public ICommand HomeCommand
		{
			get { return _homeCommand; }
			protected set
			{
				_homeCommand = value;
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

		public AppListingMasterMenuPageViewModel(ISettings settings,
		   //ILoginBusinessService loginBusinessService,
		   INavigationService navigationService, IPlatformCookieStore cookieStore)
				   : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (cookieStore == null) throw new ArgumentNullException("cookieStore");
			_navigationService = navigationService;
			_cookieStore = cookieStore;
		}

		public override async Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.AppListingMasterMenuPage);

			this.TapCommand = new Command(() =>
			{
				_navigationService.CloseMenu();
			}
			, () => true);

			this.HomeCommand = new Command(() =>
			{
				_navigationService.CloseMenu();
				_navigationService.NavigateToRoot();
			}
			, () => true);

			this.LogoutCommand = new Command(() =>
			{
				DeleteCookies();
				_navigationService.NavigateTo(TEKUtsavAppPage.LoginPage);
			}
			, () => true);
            

			var cookie = GetCookie();
			await GetUserRole(cookie);
			return;
		}

		private async Task GetUserRole(string cookie)
		{
			try
			{
				var userobj = await MakeGetRequest(cookie);
				User user = JsonConvert.DeserializeObject<User>(userobj);
				if (user != null)
				{
                    this.UserName = user.Devices.FirstOrDefault().UDID;
                    Application.Current.Properties["username"] = user.Devices.FirstOrDefault().UDID;
                    Application.Current.Properties["role"] = user.IsAdmin;
				}
			}
			catch (Exception e)
			{
				
			}
		}

		private string GetCookie()
		{
			string cookie = null;
			try
			{
				return cookie = Application.Current.Properties[".AspNet.ExternalCookie"] as string;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.StackTrace);
				return string.Empty;
			}
		}

		public static async Task<string> MakeGetRequest(string cookie)
		{
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create( Globals.OKTA_USER_URL);
				request.ContentType = "text/html";
				request.Method = "GET";

				CookieContainer container = new CookieContainer();
				container.Add(new Uri(Globals.OKTA_USER_URL), new Cookie(".AspNet.ExternalCookie", cookie));
				request.CookieContainer = container;

				var response = await request.GetResponseAsync();
				var respStream = response.GetResponseStream();
				respStream.Flush();

				using (StreamReader sr = new StreamReader(respStream))
				{
					//Need to return this response 
					string strContent = sr.ReadToEnd();
					respStream = null;
					return strContent;
				}
			}
			catch (Exception e)
			{
				return string.Empty;
			}
		}

		public override Task OnViewDisappearing()
		{
			return Task.Run(() => { });

		}

		public override void Dispose()
		{
			throw new NotImplementedException();
		}


		public void DeleteCookies()
		{
			_cookieStore.DeleteAllCookiesForSite(Globals.OKTA_SP_URL);
			_cookieStore.DeleteAllCookiesForSite(Globals.OKTA_IDP_URL);
			_cookieStore.DeleteAllCookiesForSite(Globals.OKTAUSERDOMAIN);
		}


	}
}
