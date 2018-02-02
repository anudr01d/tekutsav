using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using ZXing.Net.Mobile.Forms;
using TEKUtsav.Views.MasterMenuPage;
using TEKUtsav.ViewModels.MasterMenuPage;
using TEKUtsav.ViewModels.BaseViewModel;
using TEKUtsav.ViewModels.AppListingMasterMenuPage;
using TEKUtsav.Views.AppListingMasterMenuPage;

namespace TEKUtsav.Navigation
{
	public class NavigationService : INavigationService
	{
		private readonly IPageRegistry<TEKUtsavAppPage> _pageRegistry;
		private TEKUtsavAppPage _currentPage;
		private Color origPageBgColor;
		private Color origContentBgColor;
		private bool LogisticsUser = false;

		public NavigationService(IPageRegistry<TEKUtsavAppPage> pageRegistry)
		{
			if (pageRegistry == null) throw new ArgumentNullException("pageRegistry");
			_pageRegistry = pageRegistry;
		}

		private Page SetLoginPage()
		{
			return _pageRegistry.GetPage(TEKUtsavAppPage.LoginPage);
		}

        private Page SetRegistrationPage()
        {
            return _pageRegistry.GetPage(TEKUtsavAppPage.RegistrationPage);
        }

		private MasterDetailPage SetMasterDetailPage(object navigationParams)
		{
			var rootPage = new MasterDetailPage();
			Page detailPage;
			detailPage = _pageRegistry.GetPage(TEKUtsavAppPage.HomePage) as Views.HomePage.HomePage;
			var masterPage = _pageRegistry.GetPage(TEKUtsavAppPage.MasterMenuPage) as MasterMenuPage;
			if (masterPage == null) throw new NullReferenceException("MasterMenuPage not found in PageRegistry");

			rootPage.IsPresentedChanged += (object sender, EventArgs e) =>
			{
				if (Device.RuntimePlatform == Device.iOS)
				{
					if (rootPage.IsPresented)
					{
						var currentPage = (Views.HomePage.HomePage)((NavigationPage)rootPage.Detail).CurrentPage;
						origPageBgColor = currentPage.BackgroundColor;
						origContentBgColor = currentPage.Content.BackgroundColor;
						currentPage.BackgroundColor = Color.Black;
						currentPage.Content.FadeTo(0.5);
						if (currentPage.Content.BackgroundColor == Color.Default)
						{
							currentPage.Content.BackgroundColor = Color.White;
						}
					}
					else
					{
						var currentPage = (Views.HomePage.HomePage)((NavigationPage)rootPage.Detail).CurrentPage;
						currentPage.BackgroundColor = origPageBgColor;
						currentPage.Content.BackgroundColor = origContentBgColor;
						currentPage.Content.FadeTo(1.0);
					}
				}
			};


			masterPage.Title = "Menu";
			var masterPageViewModel = masterPage.BindingContext as MasterMenuPageViewModel;
			if (masterPageViewModel == null) throw new NullReferenceException("MasterMenuPageViewModel not set for MasterMenuPage");
			masterPageViewModel.MenuItemSelectionChanged = (requestedPage) =>
			{
				//Do not navigate to the same page
				if (_currentPage != requestedPage)
				{
					NavigateTo(requestedPage);
				}
				rootPage.IsPresented = false;
			};

			rootPage.Master = masterPage;

			Device.OnPlatform(
			Android: () =>
			{
				rootPage.IsGestureEnabled = true;
			},
				iOS: () =>
			{
				rootPage.IsGestureEnabled = false;
			});

			var navigationPage = new NavigationPage(detailPage)
			{
				BarBackgroundColor = Xamarin.Forms.Color.FromHex("#fff"),
				BarTextColor = Xamarin.Forms.Color.FromHex("#990000")
			};
			rootPage.Detail = navigationPage;

			return rootPage;
		}

		private MasterDetailPage SetAppListingMasterDetailPage()
		{
			var rootPage = new MasterDetailPage();

			var detailPage = _pageRegistry.GetPage(TEKUtsavAppPage.AppListingPage) as Views.AppListingPage.AppListingPage;

			var masterPage = _pageRegistry.GetPage(TEKUtsavAppPage.AppListingMasterMenuPage) as AppListingMasterMenuPage;
			if (masterPage == null) throw new NullReferenceException("MasterMenuPage not found in PageRegistry");


			rootPage.IsPresentedChanged += (object sender, EventArgs e) =>
			{
				if (Device.RuntimePlatform == Device.iOS)
				{
					if (rootPage.IsPresented)
					{
						var currentPage = (Views.AppListingPage.AppListingPage)((NavigationPage)rootPage.Detail).CurrentPage;
						origPageBgColor = currentPage.BackgroundColor;
						origContentBgColor = currentPage.Content.BackgroundColor;
						currentPage.BackgroundColor = Color.Black;
						currentPage.Content.FadeTo(0.5);
						if (currentPage.Content.BackgroundColor == Color.Default)
						{
							currentPage.Content.BackgroundColor = Color.White;
						}
					}
					else
					{
						var currentPage = (Views.AppListingPage.AppListingPage)((NavigationPage)rootPage.Detail).CurrentPage;
						currentPage.BackgroundColor = origPageBgColor;
						currentPage.Content.BackgroundColor = origContentBgColor;
						currentPage.Content.FadeTo(1.0);
					}
				}
			};

			masterPage.Title = "Menu";
			var masterPageViewModel = masterPage.BindingContext as AppListingMasterMenuPageViewModel;
			if (masterPageViewModel == null) throw new NullReferenceException("MasterMenuPageViewModel not set for MasterMenuPage");
			masterPageViewModel.MenuItemSelectionChanged = (requestedPage) =>
			{
				//Do not navigate to the same page
				if(_currentPage != requestedPage)
					{
						NavigateTo(requestedPage);
					}
					rootPage.IsPresented = false;
				};

				rootPage.Master = masterPage;

				Device.OnPlatform(
				Android: () =>
				{
					rootPage.IsGestureEnabled = true;
				},
					iOS: () =>
				{
					rootPage.IsGestureEnabled = false;
				}
				);

				var navigationPage = new NavigationPage(detailPage)
				{
					BarBackgroundColor = Xamarin.Forms.Color.FromHex("#fff"),
					BarTextColor = Xamarin.Forms.Color.FromHex("#990000")
				};
			rootPage.Detail = navigationPage;

			return rootPage;
		}



		public void CloseMenu()
		{
			var masterDetail = (MasterDetailPage)Application.Current.MainPage;
			masterDetail.IsPresented = false;
		}

		public void NavigateTo(TEKUtsavAppPage page, object navigationParams = null)
		{

			if (page == TEKUtsavAppPage.LoginPage)
			{
				_currentPage = page;
				Application.Current.MainPage = SetLoginPage();
				return;
			}

            if (page == TEKUtsavAppPage.RegistrationPage)
            {
                _currentPage = page;
                Application.Current.MainPage = SetRegistrationPage();
                return;
            }

			if (page == TEKUtsavAppPage.AppListingMasterMenuPage)
			{
				_currentPage = page;
				Application.Current.MainPage = SetAppListingMasterDetailPage();
				return;
			}

			if (page == TEKUtsavAppPage.MasterMenuPage)
			{
				_currentPage = page;
				Application.Current.MainPage = SetMasterDetailPage(navigationParams);
				return;
			}

            if (page != TEKUtsavAppPage.LoginPage && page != TEKUtsavAppPage.RegistrationPage && page != TEKUtsavAppPage.MasterMenuPage && page != TEKUtsavAppPage.AppListingMasterMenuPage)
			{
				if (!(Application.Current.MainPage is MasterDetailPage))
				{
					Application.Current.MainPage = SetMasterDetailPage(navigationParams);
					_currentPage = TEKUtsavAppPage.MasterMenuPage;
				}
				var masterDetail = (MasterDetailPage)Application.Current.MainPage;
				if (_currentPage == page) return;

				var requestedPage = _pageRegistry.GetPage(page, navigationParams);
				var navigationPage = masterDetail.Detail as NavigationPage;
				if (navigationPage != null)
				{
					navigationPage.Popped += delegate (object sender, NavigationEventArgs args)
					{
						var vm = sender as ViewModelBase;
						if (vm != null)
						{
							vm.OnPopped(page);
						}
					};
				}
				masterDetail.Detail.Navigation.PushAsync(requestedPage, true);
			}
		}

		public void AfterLoginNavigation(bool hasLabAccess, bool isLabSelected, bool isLastSavedLabActive)
		{
			NavigateTo(TEKUtsavAppPage.MasterMenuPage);
		}
		public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
		{
			return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
		}

		public Task DisplayAlert(string title, string message, string accept)
		{
			return Application.Current.MainPage.DisplayAlert(title, message, accept);
		}
		public void NavigateBack()
		{
			var masterDetail = (MasterDetailPage)Application.Current.MainPage;
			if (masterDetail != null) masterDetail.Detail.Navigation.PopAsync();
		}
		public void NavigateBack(TEKUtsavAppPage destinationPage, object navigationParam = null)
		{
			var masterDetail = (MasterDetailPage)Application.Current.MainPage;
			if (masterDetail != null)
			{
				var pages = masterDetail.Detail.Navigation.NavigationStack;

				var pagesToRemove = new List<Page>();

				var totPages = (masterDetail.Detail.Navigation.NavigationStack.Count - 1);

				for (int i = totPages; i > 0; i--)
				{
					var page = masterDetail.Detail.Navigation.NavigationStack[i];
					var vm = page.BindingContext as ViewModelBase;
					if (null != vm && !vm.PageName.Equals(destinationPage))
					{
						vm.Dispose();
						masterDetail.Detail.Navigation.RemovePage(page);
					}
					else
					{
						if (null != navigationParam)
						{
							vm.NavigationParameter = navigationParam;
							break;
						}
					}
				}
			}
		}
        public void NavigateToRoot()
        {
            var masterDetail = (MasterDetailPage)Application.Current.MainPage;
            if (masterDetail != null) masterDetail.Detail.Navigation.PopToRootAsync();
        }

		public void ShowPopup(TEKUtsavAppPage page, object navigationParams = null)
		{
			var requestedPage = (PopupPage)_pageRegistry.GetPage(page, navigationParams);
			var masterDetail = (MasterDetailPage)Application.Current.MainPage;
			if (masterDetail != null)
			{
				if (!PopupNavigation.PopupStack.Any())
				{
					masterDetail.Detail.Navigation.PushPopupAsync(requestedPage);
				}
			}
		}

		public void ClosePopup()
		{
			PopupNavigation.PopAsync();
		}

        public void SetCurrentPage(TEKUtsavAppPage page)
        {
            _currentPage = page;
        }

        public TEKUtsavAppPage CurrentPage()
        {
            return _currentPage;
        }
	}
}
