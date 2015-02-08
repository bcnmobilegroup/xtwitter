using System;
using Autofac;
using XForms.Framework.Bootstrapping;
using XForms.Framework.Factories;
using XForms.Framework;
using XTwitter.Core;
using Xamarin.Forms;
using XTwitter.ViewModels;
using XTwitter.Views;
using XForms.Framework.Services;

namespace XTwitter
{
	public class Bootstrapper : AutofacBootstrapper
	{

		#region Members

		private readonly App _application;

		#endregion

		#region Static Members

		private static IContainer _container;

		/// <summary>
		/// Gets a instance of the IoC container.
		/// </summary>
		public static IContainer Container
		{
			get
			{
				return _container;
			}
		}

		#endregion

		#region Constructor

		public Bootstrapper(App application)
		{
			_application = application;           
		}

		#endregion

		#region Overrides Methods

		protected override void ConfigureContainer(ContainerBuilder builder)
		{
			base.ConfigureContainer(builder);
			builder.RegisterModule<XTwitterCoreModule>();
			builder.RegisterModule<XTwitterFormsModule>();
		} 

		protected override void RegisterViews(IViewFactory viewFactory)
		{
			viewFactory.Register<TimelineViewModel, TimelineView>();
			viewFactory.Register<AddTweetViewModel, AddTweetView>();
			viewFactory.Register<TweetViewModel, TweetView>();
		}

		protected override void ConfigureApplication(IContainer container)
		{
			_container = container;
			var viewFactory = container.Resolve<IViewFactory> ();
			var mainPage = viewFactory.Resolve<TimelineViewModel> ();

			var navigationPage = new NavigationPage (mainPage){
				BarBackgroundColor = Styles.XTwitterColors.NavigationbarBackgroundColor,
				BarTextColor = Styles.XTwitterColors.NavigationbarTextColor
			};

			_application.Application = new MainApplication (navigationPage);
		}

		#endregion

	}
}

