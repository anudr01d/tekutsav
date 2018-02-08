using Android.App;
using Android.OS;
using TEKUtsav.Droid;

namespace TEKUtsav.Droid
{
    [Activity(Theme = "@style/SplashTheme", NoHistory = true)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			this.StartActivity(typeof(MainActivity));
		}
	}
}

