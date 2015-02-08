using System;
using XTwitter.Core.Models;
using AutoMapper;
using System.Windows.Input;
using XForms.Framework.Services;
using Xamarin.Forms;

namespace XTwitter.ViewModels
{
	public class TimelineTweetViewModel : Base.BaseTweetViewModel
	{

		#region Commands

		public ICommand ShowTweetCommand { get; set; }

		#endregion

		#region Constructor

		public TimelineTweetViewModel (Tweet tweet, INavigator navigator)
			: base(navigator)
		{
			ShowTweetCommand = new Command (ShowTweetView);
			base.Tweet = tweet;
		}

        #endregion

		#region Private Methods

		private void ShowTweetView()
		{
			base.Navigator.PushAsync<TweetViewModel> (viewModel => {
				viewModel.Tweet = base.Tweet;
			});
		}

		#endregion

	}
}

