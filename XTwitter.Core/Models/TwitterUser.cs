using System;

namespace XTwitter.Core.Models
{
	public class TwitterUser
	{

		/// <summary>
		/// Displays the full name of the user.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Displays the twitter usernames (@username).
		/// </summary>
		public string ScreenName  { get; set; }

		/// <summary>
		/// User profile image URL.
		/// </summary>
		public string ProfileImageUrl  { get; set; }

	}
}

