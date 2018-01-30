using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TEKUtsav.Infrastructure.Settings;
using ImageCircle.Forms.Plugin.Droid;
using TEKUtsav.Infrastructure.CookieStorage;
using Autofac;
using TEKUtsav.Infrastructure.Constants;
using TEKUtsav.Droid.DeviceImpl;

namespace TEKUtsav.Droid
{
[Activity(Label = "TEKUtsav.Droid", Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.KeyboardHidden)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			global::ZXing.Net.Mobile.Forms.Android.Platform.Init();
			ImageCircleRenderer.Init();
            var builder = new ContainerBuilder();

			RegisterDeviceSpecificImpl(builder);
            LoadApplication(new TEKUtsav.App(builder));
		}

		private void RegisterDeviceSpecificImpl(ContainerBuilder builder)
		{
			builder.RegisterType<SettingProviderDroid>().As<ISettings>();
			builder.Register(c => new DroidCookieStore(Globals.OKTA_SP_URL)).As<IPlatformCookieStore>();
		}
	}
}
