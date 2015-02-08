using System;
using Xamarin.Forms;

namespace XTwitter.Styles
{
	internal static class XTwitterColors
	{
		//General
		internal static Color NavigationbarBackgroundColor { get { return Color.FromRgb(34, 163, 201); } }
		internal static Color NavigationbarTextColor { get { return Color.White; } }

		//User
		internal static Color ScreenUsernameColor { get { return Color.Gray; } }

		//Tweet
		internal static Color TweetCharactersCounterOKTextColor { get { return Color.Gray; }}
		internal static Color TweetCharactersCounterKOTextColor { get { return Color.Red; }}
		internal static Color TweetSelectImageButtonTextColor { get { return Color.Gray; }}
		internal static Color TweetSelectImageButtonColor { get { return Color.FromRgb(34, 163, 201); }}
		internal static Color TweetTextColor { get { return Color.FromRgb (130, 131, 132); }}
	}
}

