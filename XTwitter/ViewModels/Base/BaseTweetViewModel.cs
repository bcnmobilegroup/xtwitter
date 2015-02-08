using System;
using XForms.Framework.Services;
using XTwitter.Core.Models;

namespace XTwitter.ViewModels.Base
{
	public abstract class BaseTweetViewModel : XForms.Framework.ViewModels.ViewModelBase
	{

		#region Private Members

		readonly INavigator _navigator;

		string _username;
		string _screenUsername;
		string _userImageUrl;
		string _text;
		Tweet _tweet;

		#endregion

		#region Properties

		public string Username 
		{ 
			get
			{
				return _username;
			}
			set
			{
				base.SetProperty (ref _username, value, "Username");
			}
		}

		public string ScreenUsername 
		{ 
			get
			{
				return _screenUsername;
			}
			set
			{
				var text = string.Format ("@{0}", value);
				base.SetProperty (ref _screenUsername, text, "ScreenUsername");
			}
		}

		public string UserImageUrl 
		{ 
			get
			{
				return _userImageUrl;
			}
			set
			{
				base.SetProperty (ref _userImageUrl, value, "UserImageUrl");
			}
		}

		public string Text
		{ 
			get
			{
				return _text;
			}
			set
			{
				base.SetProperty (ref _text, value, "Text");
			}
		}

		public Tweet Tweet 
		{
			get
			{
				return _tweet;
			}
			set
			{
				_tweet = value;
				InitData ();
			}
		}

		protected INavigator Navigator
		{
			get
			{
				return _navigator;
			}
		}

		#endregion

		#region Constructor

		public BaseTweetViewModel (INavigator navigator)
		{
			_navigator = navigator;
		}

		#endregion

		#region Pretected Methods

		protected virtual void InitData()
		{
			if (_tweet != null) 
			{
				this.Username = _tweet.Creator.Name;
				this.ScreenUsername = _tweet.Creator.ScreenName;
				this.UserImageUrl = _tweet.Creator.ProfileImageUrl;
				this.Text = _tweet.Text;
			}
		}

		#endregion

	}
}

