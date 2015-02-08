using System;
using System.Threading.Tasks;
using XForms.Framework.ViewModels;

namespace XForms.Framework.Services
{
    /// <summary>
    /// This is an MVVM friendly version of INavigation that navigates with IViewModel rather than Page.
    ///  
    /// </summary>
    public interface INavigator
    {
        Task<IViewModel> PopAsync();

        Task<IViewModel> PopModalAsync();

        Task PopToRootAsync();

        Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> setStateAction = null) 
            where TViewModel : class, IViewModel;

        Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) 
            where TViewModel : class, IViewModel;

        Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> setStateAction = null) 
            where TViewModel : class, IViewModel;

        Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) 
            where TViewModel : class, IViewModel;
    }
}

