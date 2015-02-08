using System;
using Microsoft.Practices.Unity;

namespace XTwitter.IoC.Crosscutting
{
	public class IoCManager
	{

		public IUnityContainer Container { get; private set; }

		#region Singleton

		public static IoCManager Instance { get; private set; }

		static IoCManager()
		{
			Instance = new IoCManager ();
		}

		private IoCManager()
		{
			Container = new UnityContainer ();
		}

		#endregion

	}
}

