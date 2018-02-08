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
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;

namespace TEKUtsav.Droid
{
    [Activity(Label = "TEKUtsav.Droid", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.KeyboardHidden)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
        const string TAG = "MainActivity";

		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

            // Firebase //
            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                }
            }
            // Firebase subscribe to an topic
            FirebaseMessaging.Instance.SubscribeToTopic("news");
            Log.Debug(TAG, "Subscribed to remote notifications");

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
