using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TEKUtsav.Infrastructure;

namespace TEKUtsav.ViewModels.BaseViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public INavigationService NavigationService { get; private set; }
        public ISettings Settings { get; private set; }

        protected ViewModelBase(INavigationService navigationService,
           ISettings settings)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            if (settings == null) throw new ArgumentNullException("settings");
            NavigationService = navigationService;
            Settings = settings;
        }

		public bool IsDisposed { get; set; }

        private object _navParameter;
        public object NavigationParameter
        {
            get { return _navParameter; }

            set
            {
                    _navParameter = value;
            }
        }
        private TEKUtsavAppPage _pageName;
        public TEKUtsavAppPage PageName
        {
            get
            {
                return _pageName;
            }

            set
            {
                _pageName = value;
                OnPropertyChanged();
            }
        }

        public void SetCurrentPage(TEKUtsavAppPage page)
        {
            NavigationService.SetCurrentPage(page);
            this.PageName = page;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public abstract Task OnViewAppearing(object navigationParams = null);
        public abstract Task OnViewDisappearing();
        public void OnPopped(TEKUtsavAppPage page)
        {
            if (ViewModelPopped != null)
            {
                ViewModelPopped.Invoke(this, new ViewModelPoppedEventHandlerArgs(page));
            }
        }
        public event ViewModelPoppedEventHandler ViewModelPopped;
        public abstract void Dispose();
    }

    public delegate void ViewModelPoppedEventHandler(object sender, ViewModelPoppedEventHandlerArgs args);

    public class ViewModelPoppedEventHandlerArgs
    {
        public TEKUtsavAppPage AppPage { get; set; }
        public ViewModelPoppedEventHandlerArgs(TEKUtsavAppPage page)
        {
            AppPage = page;
        }
    }
}
