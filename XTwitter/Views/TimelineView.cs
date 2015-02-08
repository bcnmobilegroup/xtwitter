using System;

using Xamarin.Forms;
using XForms.Framework.ViewModels;

namespace XTwitter.Views
{
	public class TimelineView : ContentPage
	{
		public TimelineView ()
		{
			this.SetBinding (ContentPage.TitleProperty, "Title");

			var listView = new ListView ();
			listView.RowHeight = 120;
			listView.SetBinding (ListView.ItemsSourceProperty, "Tweets");
			listView.ItemTemplate = new DataTemplate(typeof(TimelineCell));
			listView.VerticalOptions = LayoutOptions.Fill;

			this.Content = listView;

			var toolbarItemReload = new ToolbarItem ();
			toolbarItemReload.Icon = "reloadicon.png";
			toolbarItemReload.SetBinding (ToolbarItem.CommandProperty, "ReloadTimelineCommand");
			ToolbarItems.Add (toolbarItemReload);

			var toolbarItemAdd = new ToolbarItem ();
			toolbarItemAdd.Icon = "twittericon.png";
			toolbarItemAdd.SetBinding (ToolbarItem.CommandProperty, "AddTweetCommand");
			ToolbarItems.Add (toolbarItemAdd);

		}
	}
}


