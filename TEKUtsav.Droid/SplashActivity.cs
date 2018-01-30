using Android.App;
using Android.OS;
using TEKUtsav.Droid;

namespace TEKUtsav.Droid
{
    [Activity(Theme = "@style/SplashTheme",MainLauncher = true, NoHistory = true)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			System.Threading.Thread.Sleep(2000);
			this.StartActivity(typeof(MainActivity));
		}
	}
}

