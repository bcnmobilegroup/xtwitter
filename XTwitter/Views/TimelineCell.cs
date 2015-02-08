using System;
using Xamarin.Forms;

namespace XTwitter.Views
{
	public class TimelineCell : ViewCell
	{
		public TimelineCell()
		{
			var imageLayout = CreateImageLayout ();
			var nameLayout = CreateTweetLayout();

			var viewLayout = new StackLayout()
			{
				Padding = 10,
				Orientation = StackOrientation.Horizontal,
				Children = { imageLayout, nameLayout }
			};

			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.SetBinding (TapGestureRecognizer.CommandProperty, "ShowTweetCommand");

			viewLayout.GestureRecognizers.Add (tapGestureRecognizer);

			View = viewLayout;
		}

		StackLayout CreateImageLayout()
		{
			var image = new XImage
			{
				HorizontalOptions = LayoutOptions.Start
			};
			image.SetBinding(Image.SourceProperty, "UserImageUrl");
			image.WidthRequest = image.HeightRequest = 50;
			image.VerticalOptions = LayoutOptions.Start;
			return new StackLayout {
				Children = { image }
			};
		}

		StackLayout CreateTweetLayout()
		{

			var nameLabel = new Label
			{
				HorizontalOptions= LayoutOptions.StartAndExpand,
				YAlign = TextAlignment.Center,
				FontSize = 16,
				FontAttributes = FontAttributes.Bold,
			};
			nameLabel.SetBinding(Label.TextProperty, "Username");

			var twitterLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Start,
				YAlign = TextAlignment.Center,
				FontSize = 12,
				TextColor = Styles.XTwitterColors.ScreenUsernameColor
			};
			twitterLabel.SetBinding(Label.TextProperty, "ScreenUsername");

			var nameLayout = new StackLayout 
			{
				HorizontalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Horizontal,
				Children = { nameLabel, twitterLabel }
			};

			var tweetLabel = new Label
			{
				HorizontalOptions= LayoutOptions.StartAndExpand,
				FontSize = 14,
				TextColor = Styles.XTwitterColors.TweetTextColor
			};
			tweetLabel.SetBinding(Label.TextProperty, "Text");

			return new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { nameLayout,  tweetLabel },
				Padding = new Thickness(10, 0, 0, 0)
			};
		}
	}
}

