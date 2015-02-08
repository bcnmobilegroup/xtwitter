using System;
using Xamarin.Forms;
using XTwitter.Views;

namespace XTwitter
{
	public class MainApplication : Application
	{
		public MainApplication (Page page)
		{
			MainPage = page;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

	}
}

