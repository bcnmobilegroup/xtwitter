using System;
using Xamarin.Forms;
using Acr.XamForms.UserDialogs;
using XForms.Framework;

namespace XTwitter
{
	public class XTwitterApp : App
	{

		public XTwitterApp()
			:base()
		{
			var bootstrapper = new Bootstrapper (this);
			bootstrapper.Run ();
		}

		public new static App Current
		{
			get { return App.Current ?? new XTwitterApp(); }
		}

	}
}

