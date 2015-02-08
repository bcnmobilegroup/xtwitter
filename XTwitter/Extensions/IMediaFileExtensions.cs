using System;
using Acr.XamForms.Mobile.Media;
using System.IO;

namespace XTwitter.Extensions
{
	public static class IMediaFileExtensions
	{
		public static byte[] GetBytes(this IMediaFile file)
		{
			byte[] bytes;
			using (var ms = new MemoryStream ()) {
				file.GetStream ().CopyTo (ms);
				bytes = ms.ToArray ();
			}
			return bytes;
		}
	}
}

