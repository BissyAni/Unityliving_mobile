using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content.PM;

namespace Unity.Living.AppAndroid
{
    [Activity(Theme = "@style/MyTheme.Splash", Label = "UnityLiving", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            StartActivity(typeof(MainActivity));
        }
    }
}