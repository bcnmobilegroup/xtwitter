using System;
using System.Linq;
using XTwitter.Core.Models;
using XForms.Framework.Services;

namespace XTwitter.ViewModels
{
	public class TweetViewModel : Base.BaseTweetViewModel
	{

		#region Private members

		string _tweetImage;

		#endregion

		#region Properties

		public string TweetImageUrl
		{ 
			get
			{
				return _tweetImage;
			}
			set
			{
				base.SetProperty (ref _tweetImage, value, "TweetImageUrl");
			}
		}

		public bool TweetImageVisible
		{ 
			get
			{
				return !string.IsNullOrEmpty(_tweetImage);
			}
		}

		#endregion

		#region Constructor
	
		public TweetViewModel (INavigator navigator)
			: base(navigator)
		{
			Title = "Tweet";
		}

		#endregion

		#region Overrides

		protected override void InitData ()
		{
			base.InitData ();
			if (base.Tweet.Media.Count > 0 && base.Tweet.Media.First ().MediaType.Equals("photo")) 
			{
				this.TweetImageUrl = base.Tweet.Media.First ().MediaURL;
			}
		}

		#endregion

	}
}

