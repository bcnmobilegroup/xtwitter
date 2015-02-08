using System;
using Autofac;
using Acr.XamForms.UserDialogs;
using Xamarin.Forms;
using Acr.XamForms.Mobile.Media;
using XTwitter.ViewModels;
using XTwitter.Views;

namespace XTwitter
{
	public class XTwitterFormsModule : Module
	{
		protected override void Load (ContainerBuilder builder)
		{
			//Mappings
			Mappings.Map();

			//External services.
			builder.RegisterInstance<IUserDialogService> (DependencyService.Get<IUserDialogService> ());
			builder.RegisterInstance<IMediaPicker> (DependencyService.Get<IMediaPicker> ());

			//View Models
			builder.RegisterType<TimelineViewModel> ().SingleInstance();
			builder.RegisterType<TimelineTweetViewModel> ();
			builder.RegisterType<AddTweetViewModel> ();
			builder.RegisterType<TweetViewModel> ();

			//Views
			builder.RegisterType<TimelineView> ().SingleInstance();
			builder.RegisterType<AddTweetView> ();
			builder.RegisterType<TweetView> ();

		}
	}
}

