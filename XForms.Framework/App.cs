using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace XForms.Framework
{
    public class App : BindableObject
    {
        public App()
        {
            Current = this;
        }

        public ResourceDictionary Resources { get; set; }

        public static App Current { get; protected set; }

		public Application Application { get; set; }
    }
}

