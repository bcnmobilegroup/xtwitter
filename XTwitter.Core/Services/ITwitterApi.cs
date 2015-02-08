using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XTwitter.Core.Services.Twitter
{
	public interface ITwitterApi
	{
		//Properties
		Models.TwitterUser UserLogged { get; }

		//Sync API
		void SetupTwitterApi(string twitterAccessToken, string twitterAccessTokenSecret, 
							 string twitterConsumerKey, string twitterConsumerSecret);

		IEnumerable<Models.Tweet> GetTimeline ();

		IEnumerable<Models.Tweet> GetTimelineByUser (string twitterUsername);

		Models.Tweet PublishTweet (Models.Tweet tweet);

		//Async API
		Task SetupTwitterApiAsync(string twitterAccessToken, string twitterAccessTokenSecret, 
							       string twitterConsumerKey, string twitterConsumerSecret);

		Task SetUserConnected();

		Task<IEnumerable<Models.Tweet>> GetTimelineAsync();

		Task<IEnumerable<Models.Tweet>> GetTimelineByUserAsync (string twitterUsername);

		Task<Models.Tweet> PublishTweetAsync (Models.Tweet tweet);
	}
}

