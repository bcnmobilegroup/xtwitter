using System;
using Xamarin.Forms;
using UIKit;

[assembly: ExportRendererAttribute(typeof(XTwitter.Views.XEditor), typeof(XTwitter.iOS.Renderers.XEditorRenderer))]
namespace XTwitter.iOS.Renderers
{
	public class XEditorRenderer : Xamarin.Forms.Platform.iOS.EditorRenderer
	{
		protected override void OnElementChanged (Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Xamarin.Forms.Editor> e)
		{
			base.OnElementChanged (e);
			var xEditor = (XTwitter.Views.XEditor)e.NewElement;
			if (xEditor != null) {
				Control.Font = UIFont.SystemFontOfSize ((nfloat)xEditor.FontSize);
				Control.Layer.CornerRadius = 10;
			}
		}
	}
}

