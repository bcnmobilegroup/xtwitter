using System;

namespace XTwitter.Droid
{
	public class XEditorRenderer : Xamarin.Forms.Platform.Android.EditorRenderer
	{
		protected override void OnElementChanged (Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Editor> e)
		{
			base.OnElementChanged (e);
			var xEditor = (XTwitter.Views.XEditor)e.NewElement;
			if (xEditor != null) {
				Control.TextSize = (float)xEditor.FontSize;
			}
		}
	}
}

