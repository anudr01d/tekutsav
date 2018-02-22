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
using CarouselView.FormsPlugin.Android;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace TEKUtsav.Droid
{
    [Activity(Label = "TEKUtsav.Droid", ScreenOrientation = ScreenOrientation.Portrait,  MainLauncher = true, Icon = "@drawable/ic_launcher", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.KeyboardHidden)]
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
            FirebaseMessaging.Instance.SubscribeToTopic("/topics/news");
            Log.Debug(TAG, "Subscribed to remote notifications");

			global::Xamarin.Forms.Forms.Init(this, bundle);
            UserDialogs.Init(this);
            CarouselViewRenderer.Init();

			ImageCircleRenderer.Init();
            var builder = new ContainerBuilder();

			RegisterDeviceSpecificImpl(builder);
            LoadApplication(new TEKUtsav.App(builder));

            //var mBundle = Intent.Extras;
            //if (mBundle != null)
            //{
            //    var pageParameter = mBundle.GetString("pageParameter");
            //    if (!string.IsNullOrEmpty(pageParameter))
            //    {
            //        MessagingCenter.Send<object, string>(this, "Push", pageParameter);
            //    }
            //}
		}

		private void RegisterDeviceSpecificImpl(ContainerBuilder builder)
		{
			builder.RegisterType<SettingProviderDroid>().As<ISettings>();
			builder.Register(c => new DroidCookieStore(Globals.OKTA_SP_URL)).As<IPlatformCookieStore>();
		}

       
	}
}
