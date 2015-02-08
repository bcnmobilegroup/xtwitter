using System;
using XTwitter.IoC.Crosscutting;
using Microsoft.Practices.Unity;

namespace XTwitter.IoC
{
	public static class IoCInitializer
	{
		public static void Initialize()
		{
			IoCManager.Instance.Container.RegisterType<XTwitter.Core.Twitter.ITwitterApi, XTwitter.Core.Twitter.TwitterApi> ();
		}
	}
}

