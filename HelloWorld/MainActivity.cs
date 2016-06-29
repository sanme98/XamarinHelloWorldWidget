using Android.App;
using Android.Widget;
using Android.OS;

namespace HelloWorld
{
	[Activity(Label = "HelloWorld", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Toast.MakeText(this, "AppWidget ready to be added!", ToastLength.Long).Show();

			Finish();
		}
	}
}


