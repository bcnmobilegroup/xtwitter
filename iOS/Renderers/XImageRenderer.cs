using System;
using Xamarin.Forms;

[assembly: ExportRendererAttribute(typeof(XTwitter.Views.XImage), typeof(XTwitter.iOS.Renderers.XImageRenderer))]
namespace XTwitter.iOS.Renderers
{
	public class XImageRenderer : Xamarin.Forms.Platform.iOS.ImageRenderer
	{
		protected override void OnElementChanged (Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Xamarin.Forms.Image> e)
		{
			base.OnElementChanged (e);
			Control.Layer.CornerRadius = 10;
		}
	}
}

