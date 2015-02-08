using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace XForms.Framework.ViewModels
{
    public abstract class ViewModelBase : IViewModel
    {
        public string Title { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetState<T>(Action<T> action) where T : class, IViewModel
        {
            action(this as T);
        }

		public virtual void OnAppearing()
		{

		}

		public virtual void OnDisappearing()
		{

		}

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);

            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.OnPropertyChanged(propertyName);
        }

    }
}

