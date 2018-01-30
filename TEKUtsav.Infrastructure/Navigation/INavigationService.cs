using System.Threading.Tasks;

namespace TEKUtsav.Infrastructure.Navigation
{
    public interface INavigationService
    {
        void NavigateTo(TEKUtsavAppPage page, object navigationParams = null);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
        Task DisplayAlert(string title, string message, string accept);
        void NavigateBack();
        void NavigateBack(TEKUtsavAppPage destinationPage, object navigationParam = null);
        void NavigateToRoot();
        void AfterLoginNavigation(bool hasLabAccess, bool isLabSelected, bool isLastSavedLabActive);
        void SetCurrentPage(TEKUtsavAppPage containerInfoPage);
		void ShowPopup(TEKUtsavAppPage page, object navigationParams = null);
		void ClosePopup();
		void CloseMenu();
		Task NavigateToZxingScanner();
        TEKUtsavAppPage CurrentPage();
		void RemoveScannerPage();
    }
}
