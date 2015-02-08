using System;
using Xamarin.Forms;

namespace XTwitter.Views
{
	public class AddTweetView : ContentPage
	{

		XEditor _tweetEntry;

		public AddTweetView ()
		{
			this.SetBinding (TitleProperty, "Title");

			var headerUserInfoLayout = TwitterViewHelpers.GetHeaderUserLayout ();
			var tweetEntryLayout = GetTweetEntryLayout ();
			var imageLayout = GetImageLayout ();

			Content = new ScrollView{
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.FillAndExpand,
					Padding = 15,
					Children = { headerUserInfoLayout, tweetEntryLayout, imageLayout }
				}
			};

			var toolbarItemAdd = new ToolbarItem ();
			//toolbarItemAdd.Text = "Send";
			toolbarItemAdd.Icon = "send.png";
			toolbarItemAdd.SetBinding (ToolbarItem.CommandProperty, "SendTweetCommand");
			ToolbarItems.Add (toolbarItemAdd);
		}

		StackLayout GetTweetEntryLayout()
		{
			var charactersCounterLabel = new Label {
				VerticalOptions = LayoutOptions.Start,
				XAlign = TextAlignment.End,
				TextColor = Styles.XTwitterColors.TweetCharactersCounterOKTextColor,
				FontSize = 12,
				Text = "140"
			};
			charactersCounterLabel.SetBinding (Label.TextProperty, "CharactersCounter");
			charactersCounterLabel.SetBinding (Label.TextColorProperty, "CharactersCounterColor");

			_tweetEntry = new XEditor {
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = 16,
				HeightRequest = 100
			};
			_tweetEntry.SetBinding (XEditor.TextProperty, "Text", BindingMode.TwoWay);

			return new StackLayout { 
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 150,
				Children = { charactersCounterLabel, _tweetEntry }
			};
		}

		StackLayout GetImageLayout()
		{
			var image = new Image
			{
				Aspect = Aspect.AspectFill,
				Source = "cameraicon.png", 
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			image.SetBinding (Image.SourceProperty, "Image");

			var addImageButton = new Button {
				Text = "Image",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 40,
				WidthRequest = 100,
				BackgroundColor = Styles.XTwitterColors.TweetSelectImageButtonColor,
				TextColor = Styles.XTwitterColors.TweetSelectImageButtonTextColor,
			};
			addImageButton.SetBinding (Button.CommandProperty, "ChoiceImageSourceCommand");

			var layout = new StackLayout {
				Children = { image, addImageButton }
			};

			return layout;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			_tweetEntry.Focus ();
		}
	}
}

