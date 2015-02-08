using System;
using AutoMapper;

namespace XTwitter.ViewModels
{
	public class Mappings
	{
		public static void Map()
		{
			Mapper.CreateMap<XTwitter.Core.Models.Tweet, TimelineTweetViewModel> ()
				.ForMember(t => t.Username, opts => opts.MapFrom(d => d.Creator.Name))
				.ForMember(t => t.ScreenUsername, opts => opts.MapFrom(d => d.Creator.ScreenName))
				.ForMember(t => t.UserImageUrl, opts => opts.MapFrom(d => d.Creator.ProfileImageUrl)); 
		}
	}
}

