using System;
using Xamarin.Forms;

namespace XTwitter.Views
{
	public class XEditor : Editor
	{

		#region BindableProperties

		/// <summary>
		/// The font property
		/// </summary>
		public static readonly BindableProperty FontSizeProperty = BindableProperty.Create<XEditor, double> (p => p.FontSize, default(double));

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the font size.
		/// </summary>
		/// <value>The font size.</value>
		public double FontSize 
		{
			get { return (double)GetValue (FontSizeProperty); }
			set { SetValue (FontSizeProperty, value); }
   		}

		#endregion

	}
}

