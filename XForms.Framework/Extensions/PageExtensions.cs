using System;
using XForms.Framework.ViewModels;

namespace XForms.Framework.Extensions
{
	internal static class PageExtensions
	{
		/// <summary>
		/// Binds the Appearing and Disappearing between page and his view model.
		/// </summary>
		/// <param name="page">Page.</param>
		/// <param name="viewModel">View model.</param>
		internal static void BindShowEvents(this Xamarin.Forms.Page page, IViewModel viewModel)
		{
			page.Appearing += (sender, args1) => viewModel.OnAppearing();
			page.Disappearing += (sender, args1) => viewModel.OnDisappearing();
		}
	}
}

