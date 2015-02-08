using System;
using Autofac;
using XTwitter.Core.Services.Twitter;

namespace XTwitter.Core
{
	public class XTwitterCoreModule : Module
	{
		protected override void Load (ContainerBuilder builder)
		{
			builder.RegisterType<TwitterApi> ()
				   .As<ITwitterApi> ()
				   .SingleInstance();

			Mappings.Mappings.Map ();
		}
	}
}

