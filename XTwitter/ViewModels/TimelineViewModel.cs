using System;
using XTwitter.Core.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using XTwitter.Core.Services.Twitter;
using Acr.XamForms.UserDialogs;
using XForms.Framework.ViewModels;
using System.Threading.Tasks;
using XTwitter.Forms;
using AutoMapper;
using System.Windows.Input;
using XForms.Framework.Services;
using Xamarin.Forms;

namespace XTwitter.ViewModels
{
	public class TimelineViewModel : ViewModelBase
	{

		#region Private Members

		readonly ITwitterApi _twitterService;
		readonly IUserDialogService _userDialogService;
		readonly INavigator _navigator;
		readonly Func<Tweet, TimelineTweetViewModel> _timelineTweetViewModelFactory;

		bool _reloadTimeline = true;
		IEnumerable<TimelineTweetViewModel> _tweets;

		#endregion

		#region Public Properties

		public IEnumerable<TimelineTweetViewModel> Tweets 
		{ 
			get
			{
				return _tweets;
			}
			set
			{
				base.SetProperty(ref _tweets, value, "Tweets");
			}
		}

		#endregion

		#region Commands

		public ICommand AddTweetCommand { get; set; }
		public ICommand ReloadTimelineCommand { get; set; }

		#endregion

		#region Constructor

		public TimelineViewModel (ITwitterApi twitterService, 
							      IUserDialogService userDialogService,
								  INavigator navigator,
								  Func<Tweet, TimelineTweetViewModel> timelineTweetViewModelFactory)
		{
			Title = "XTwitter";

			_twitterService = twitterService;
			_userDialogService = userDialogService;
			_navigator = navigator;
			_timelineTweetViewModelFactory = timelineTweetViewModelFactory;

			AddTweetCommand = new Command (ShowAddTweetView);
			ReloadTimelineCommand = new Command (ReloadTimeline);

			MessagingCenter.Subscribe<AddTweetViewModel> (this, "ReloadTimeline", (sender) => {
				_reloadTimeline = true;
			});
		}

		#endregion

		#region Public Methods

		public async override void OnAppearing ()
		{
			if (_reloadTimeline) 
			{
				_reloadTimeline = false;
				if(_twitterService.UserLogged == null)
				{
					using (var dlg = _userDialogService.Loading ("Authenticating user...")) {
						await _twitterService.SetupTwitterApiAsync (TwitterApiData.TWITTER_ACCESS_TOKEN, TwitterApiData.TWITTER_ACCESS_TOKEN_SECRET, 
							TwitterApiData.TWITTER_CONSUMER_KEY, TwitterApiData.TWITTER_CONSUMER_SECRET);
					}
				}
				await LoadTweets ();
			}
		}

		#endregion

		#region Private Methods

		async Task LoadTweets ()
		{
			using (var dlg = _userDialogService.Loading ("Loading Tweets...")) {
				//Get timeline for current user.
				var tweets = await _twitterService.GetTimelineAsync ();
				Tweets = tweets.Select (tweet => _timelineTweetViewModelFactory (tweet)).ToList ();
			}
		}

		private void ShowAddTweetView()
		{
			_navigator.PushAsync<AddTweetViewModel> ();
		}

		private async void ReloadTimeline()
		{
			_reloadTimeline = true;
			await LoadTweets();
			_reloadTimeline = false;
		}

		#endregion

	}
}

