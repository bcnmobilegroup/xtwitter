using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;

namespace XTwitter.Droid
{
	[Activity (Label = "XTwitter.Droid", 
		       Icon = "@drawable/icon", 
			   MainLauncher = true, 
			   Theme="@android:style/Theme.Holo.Light",
			   ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (XTwitterApp.Current.Application);
		}
	}
}

