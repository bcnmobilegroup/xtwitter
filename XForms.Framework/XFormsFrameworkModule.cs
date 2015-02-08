using System;
using Autofac;
using XForms.Framework.Factories;
using XForms.Framework.Services;
using Xamarin.Forms;

namespace XForms.Framework
{
    public class XFormsFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // service registration
            builder.RegisterType<ViewFactory>()
                .As<IViewFactory>()
                .SingleInstance();

            builder.RegisterType<Navigator>()
                .As<INavigator>()
                .SingleInstance();

            // navigation registration
            builder.Register<INavigation>(context => 
				App.Current.Application.MainPage.Navigation
            ).SingleInstance();
        }
    }
}

