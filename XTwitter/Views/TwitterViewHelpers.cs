using System;
using Xamarin.Forms;

namespace XTwitter.Views
{
	public static class TwitterViewHelpers
	{

		/// <summary>
		/// Helper to get a layout that contains:
		/// (1) Twitter User Image.
		/// (2) Username.
		/// (3) Screen username (@username).
		/// </summary>
		/// <returns>A Stack layout with user info detailed.</returns>
		/// <param name="userUrlProperty">Property name to bind the user image url with the view model.</param>
		/// <param name="usernameProperty">Property name to bind the username with the view model.</param>
		/// <param name="screenUserNameProperty">Property name to bind the screen username with the view model.</param>
		public static StackLayout GetHeaderUserLayout(string userImageUrlProperty = "UserImageUrl", 
											          string usernameProperty = "Username", 
													  string screenUserNameProperty = "ScreenUsername")
		{
			var image = new XImage
			{
				HorizontalOptions = LayoutOptions.Start
			};
			image.SetBinding(Image.SourceProperty, userImageUrlProperty);
			image.WidthRequest = image.HeightRequest = 50;
			image.VerticalOptions = LayoutOptions.Start;

			var nameLabel = new Label
			{
				HorizontalOptions= LayoutOptions.StartAndExpand,
				FontSize = 16,
				FontAttributes = FontAttributes.Bold,
			};
			nameLabel.SetBinding(Label.TextProperty, usernameProperty);

			var twitterLabel = new Label
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontSize = 12,
				TextColor = Styles.XTwitterColors.ScreenUsernameColor
			};
			twitterLabel.SetBinding(Label.TextProperty, screenUserNameProperty);

			var userLayout = new StackLayout { 
				Orientation = StackOrientation.Vertical, 
				VerticalOptions = LayoutOptions.Fill,
				Padding = new Thickness(10, 0, 0, 0),
				Children = { nameLabel, twitterLabel }
			};

			var headerLayout = new StackLayout { 
				HeightRequest = 75,
				Orientation = StackOrientation.Horizontal,
				Children = { image,  userLayout }
			};

			return headerLayout;
		}
	}
}

