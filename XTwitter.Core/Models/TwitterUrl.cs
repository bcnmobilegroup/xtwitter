using System;

namespace XTwitter.Core.Models
{
	public class TwitterUrl
	{

		/// <summary>
		/// URL that is displayed in the screen (example.com).
		/// </summary>
		public string DisplayedURL { get; set; }

		/// <summary>
		/// Expanded URL (hhtp://example.com).
		/// </summary>
		/// <value>The expanded URL.</value>
		public string ExpandedURL { get; set; }

	}
}

