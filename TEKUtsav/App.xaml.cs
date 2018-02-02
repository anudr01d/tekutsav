using System;
using Autofac;
using TEKUtsav.Infrastructure.Logging;
using TEKUtsav.Infrastructure.Settings;
using TEKUtsav.Infrastructure.Navigation;
using Xamarin.Forms;
using TEKUtsav.Infrastructure.CookieStorage;
using TEKUtsav.Infrastructure.Constants;
using System.Linq;

namespace TEKUtsav
{
	public partial class App : Application
	{
		private ILifetimeScope _applicationLifetimeScope;
		public static IContainer Container { get; set; }

		public static ILogger AppLogger { get; set; }
		private DateTime dateTimeOnSleep, dateTimeOnResume;


		public App(ContainerBuilder builder)
		{
			// Handle when your app starts
			if (builder == null) throw new ArgumentNullException("builder");

			AppBootstrap.Initialize(builder);
			Container = builder.Build();
			_applicationLifetimeScope = Container.BeginLifetimeScope();
			//AppLogger = _applicationLifetimeScope.Resolve<ILogger>();
			var settings = _applicationLifetimeScope.Resolve<ISettings>();
            _applicationLifetimeScope.Resolve<INavigationService>().NavigateTo(TEKUtsavAppPage.LoginPage);
			dateTimeOnSleep = DateTime.Now;
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
			dateTimeOnResume = DateTime.Now;
			if (dateTimeOnResume.Subtract(dateTimeOnSleep) > TimeSpan.FromMinutes(5))
			{
				ClearCookies();
				Logout();
			}
		}
		private void ClearCookies()
		{
			var cookieStore = _applicationLifetimeScope.Resolve<IPlatformCookieStore>();
			if (cookieStore != null)
			{
				cookieStore.DeleteAllCookiesForSite(Globals.OKTA_IDP_URL);
				cookieStore.DeleteAllCookiesForSite(Globals.OKTA_SP_URL);
			}
		}

		private void Logout()
		{
			var cookieStore = _applicationLifetimeScope.Resolve<IPlatformCookieStore>();
			var _aspnetCookie = cookieStore.CurrentCookies.FirstOrDefault(cc => cc.Name == Globals.COOKIE);
			if (_aspnetCookie == null)
			{
				_applicationLifetimeScope.Resolve<INavigationService>().NavigateTo(TEKUtsavAppPage.LoginPage);
			}
		}
	}
}
