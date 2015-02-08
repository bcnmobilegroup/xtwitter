using System;
using System.Collections.Generic;

namespace XTwitter.Core.Models
{
	public class Tweet
	{
		public string Text { get; set; }
		public TwitterUser Creator { get; set; }
		public List<TwitterMedia> Media { get; set; }
		public List<TwitterUrl> Urls { get; set; }

		#region Internal Properties

		internal byte[] ImageFile { get; private set; }

		#endregion

		#region Fluent Api

		/// <summary>
		/// Add a image to a Tweet that will be posted.
		/// </summary>
		/// <returns>This Tweet.</returns>
		/// <param name="bytes">Image Bytes.</param>
		public Tweet WithImage(byte[] bytes)
		{
			this.ImageFile = bytes;
			return this;
		}

		#endregion

	}
}

