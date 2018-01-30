using Autofac;
using TEKUtsav.Infrastructure.Presentation;
using TEKUtsav.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TEKUtsav;

namespace TEKUtsav
{
	internal class PageRegistry<TPageEnum> : IPageRegistry<TPageEnum>
	{
		private readonly IDictionary<TPageEnum, Type> _applicationPages;
		private readonly IDictionary<TPageEnum, Type> _viewModels;

		public PageRegistry()
		{
			_applicationPages = new Dictionary<TPageEnum, Type>();
			_viewModels = new Dictionary<TPageEnum, Type>();
		}
		public void RegisterPage(TPageEnum page, Type viewType, Type viewModelType)
		{
			this._applicationPages.Add(page, viewType);
			this._viewModels.Add(page, viewModelType);
		}
		public Page GetPage(TPageEnum page, object navigationParams = null)
		{
			var scope = App.Container.BeginLifetimeScope();
			var viewType = GetPageType(page);
			var view = Activator.CreateInstance(viewType) as Page;
			if (view == null)
				throw new NullReferenceException(string.Format("Instance of the view could not be created for page {0}", page));
			var viewModel = GetViewModel(page, scope) as ViewModelBase;
			if (viewModel == null)
				throw new NullReferenceException(string.Format("ViewModel for page {0} has not been found", page));

			EventHandler viewOnAppearing = async delegate (object sender, EventArgs args)
			{
				await viewModel.OnViewAppearing(navigationParams);
			};
			view.Appearing += viewOnAppearing;

			EventHandler viewDisappearing = async delegate (object sender, EventArgs args)
			{
				await viewModel.OnViewDisappearing();
			};
			view.Disappearing += viewDisappearing;

			if (navigationParams != null)
				viewModel.NavigationParameter = navigationParams;

			view.BindingContext = viewModel;
			return view;
		}
		private Type GetPageType(TPageEnum page)
		{
			if (!_applicationPages.ContainsKey(page))
			{
				throw new KeyNotFoundException(string.Format("View not found in the Registry for page {0}", page));
			}
			return _applicationPages[page];
		}
		private ViewModelBase GetViewModel(TPageEnum page, ILifetimeScope scope)
		{
			var vmType = GetViewModelType(page);
			var viewModel = default(ViewModelBase);
			viewModel = scope.Resolve(vmType) as ViewModelBase;
			return viewModel;
		}
		private Type GetViewModelType(TPageEnum page)
		{
			if (!_viewModels.ContainsKey(page))
			{
				throw new KeyNotFoundException(string.Format("ViewModel Type not found in the Registry for ViewModels {0}", page));
			}
			return _viewModels[page];
		}
	}
}
