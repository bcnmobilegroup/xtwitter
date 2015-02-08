using System;
using Xamarin.Forms;

namespace XTwitter.Views
{
	public class TweetView : ContentPage
	{

		public TweetView ()
		{
			this.SetBinding (TitleProperty, "Title");

			var userLayout = TwitterViewHelpers.GetHeaderUserLayout ();
			var tweetLayout = this.CreateTweetLayot ();


			Content = new ScrollView {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.FillAndExpand,
					Padding = 15,
					Children = { userLayout, tweetLayout }
				}
			};
		}

		StackLayout CreateTweetLayot()
		{
			var tweetLabel = new Label
			{
				HorizontalOptions= LayoutOptions.StartAndExpand,
				FontSize = 20,
				TextColor = Styles.XTwitterColors.TweetTextColor
			};
			tweetLabel.SetBinding(Label.TextProperty, "Text");

			var image = new Image
			{
				Aspect = Aspect.AspectFill,
				HorizontalOptions = LayoutOptions.Fill
			};
			image.SetBinding (Image.SourceProperty, "TweetImageUrl");
			image.SetBinding (Image.IsVisibleProperty, "TweetImageVisible");

			return new StackLayout { 
				Padding = new Thickness(0, 10, 0, 0),
				Spacing = 30,
				Children = { tweetLabel, image }
			};
		}

	}
}

