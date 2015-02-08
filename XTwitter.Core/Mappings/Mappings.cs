using System;
using AutoMapper;

namespace XTwitter.Core.Mappings
{
	public static class Mappings
	{
		public static void Map()
		{
			Mapper.CreateMap<Tweetinvi.Core.Interfaces.IUser, XTwitter.Core.Models.TwitterUser> ();
			Mapper.CreateMap<Tweetinvi.Core.Interfaces.ILoggedUser, XTwitter.Core.Models.TwitterUser> ();
			Mapper.CreateMap<Tweetinvi.Core.Interfaces.Models.Entities.IMediaEntity, XTwitter.Core.Models.TwitterMedia> ();
			Mapper.CreateMap<Tweetinvi.Core.Interfaces.Models.Entities.IUrlEntity, XTwitter.Core.Models.TwitterUrl> ();
			Mapper.CreateMap<Tweetinvi.Core.Interfaces.ITweet, XTwitter.Core.Models.Tweet> ();
		}
	}
}

