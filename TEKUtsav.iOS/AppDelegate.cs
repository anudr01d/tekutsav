using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Foundation;
using TEKUtsav.Infrastructure.CookieStorage;
using TEKUtsav.Infrastructure.Logging;
using TEKUtsav.Infrastructure.Settings;
using TEKUtsav.iOS.DeviceImpl;
using UIKit;

namespace TEKUtsav.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			//Azure services
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			//Zxing barcode scanning lib
			global::ZXing.Net.Mobile.Forms.iOS.Platform.Init();

			TimeZoneInfo.GetSystemTimeZones();
			var builder = new ContainerBuilder();

			RegisterDeviceSpecificImpl(builder);
			var TEKUtsavApp = new App(builder);


			LoadApplication(TEKUtsavApp);

			CurrentDomain_UnhandledException(App.AppLogger);

			return base.FinishedLaunching(app, options);
		}

		private void CurrentDomain_UnhandledException(ILogger logger)
		{
			AppDomain.CurrentDomain.UnhandledException += (object sender, UnhandledExceptionEventArgs e) =>
			{
				var exception = e.ExceptionObject as Exception;
				logger.LogUnhandledExceptionAsync(exception);
			};

			TaskScheduler.UnobservedTaskException += (object sender, UnobservedTaskExceptionEventArgs e) =>
			{
				var exception = e.Exception as Exception;
				logger.LogUnhandledExceptionAsync(exception);
			};
		}

		private void RegisterDeviceSpecificImpl(ContainerBuilder builder)
		{
			builder.RegisterType<SettingProviderIos>().As<ISettings>();
			builder.RegisterType<IOSCookieStore>().As<IPlatformCookieStore>();

		}
	}
}
