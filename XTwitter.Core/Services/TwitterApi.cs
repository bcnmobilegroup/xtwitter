using System;
using Tweetinvi;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Logic.Model;

namespace XTwitter.Core.Services.Twitter
{
	internal class TwitterApi : ITwitterApi
	{

		#region ITwitterApi implementation

		public Models.TwitterUser UserLogged { get; private set; }

		#region Sync API

		public void SetupTwitterApi (string twitterAccessToken, string twitterAccessTokenSecret, 
			string twitterConsumerKey, string twitterConsumerSecret)
		{
			TwitterCredentials.SetCredentials(twitterAccessToken, twitterAccessTokenSecret, 
				twitterConsumerKey, twitterConsumerSecret);

			var user = User.GetLoggedUser ();
			UserLogged = AutoMapper.Mapper.Map<Models.TwitterUser> (user);

		}
			
		public IEnumerable<Models.Tweet> GetTimeline()
		{
			var tweets = Timeline.GetHomeTimeline ();
			return AutoMapper.Mapper.Map<List<Models.Tweet>> (tweets);
		}

		public IEnumerable<Models.Tweet> GetTimelineByUser(string twitterUsername)
		{
			var tweets = Timeline.GetUserTimeline (twitterUsername);
			return AutoMapper.Mapper.Map<List<Models.Tweet>> (tweets);
		}

		public Models.Tweet PublishTweet (Models.Tweet tweet)
		{
			var tweetPosted = tweet.ImageFile == null ? Tweet.PublishTweet(tweet.Text) :
														Tweet.PublishTweetWithMedia(tweet.Text, tweet.ImageFile);
			return AutoMapper.Mapper.Map<Models.Tweet> (tweetPosted);
		}

		#endregion

		#region Async API

		public async Task SetupTwitterApiAsync (string twitterAccessToken, string twitterAccessTokenSecret, 
			    						        string twitterConsumerKey, string twitterConsumerSecret)
		{
			await Task.Run (() => {
				SetupTwitterApi(twitterAccessToken, twitterAccessTokenSecret, 
								twitterConsumerKey, twitterConsumerSecret);
			});
		}

		public async Task SetUserConnected()
		{
			var user = await UserAsync.GetLoggedUser ();
			UserLogged = AutoMapper.Mapper.Map<Models.TwitterUser> (user);
		}

		public async Task<IEnumerable<Models.Tweet>> GetTimelineAsync()
		{
			return await Task<IEnumerable<Models.Tweet>>.Run (() => {
				return this.GetTimeline();
			});
		}

		public async Task<IEnumerable<Models.Tweet>> GetTimelineByUserAsync (string twitterUsername)
		{
			return await Task<IEnumerable<Models.Tweet>>.Run (() => {
				return this.GetTimelineByUser(twitterUsername);
			});
		}
			
		public Task<Models.Tweet> PublishTweetAsync (Models.Tweet tweet)
		{
			return Task.Run (() => {
				return this.PublishTweet(tweet);
			});
		}

		#endregion

		#endregion

	}
}

