using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.Presentation;
using TEKUtsav.ViewModels.AppListingPage;
//using TEKUtsav.ViewModels.ContainerConditionsPage;
using TEKUtsav.ViewModels.HomePage;
using TEKUtsav.ViewModels.LogisticsApprovalPopup;
//using TEKUtsav.ViewModels.LogisticsContainerConditionsPage;
using TEKUtsav.ViewModels.LogisticsHomePage;
using TEKUtsav.ViewModels.LogisticsIncompleteWorkflow;
using TEKUtsav.ViewModels.LogisticsMeasurementPage;
using TEKUtsav.ViewModels.LogisticsPurchaseOrderDetailsPage;
using TEKUtsav.ViewModels.MeasurementPage;
using TEKUtsav.ViewModels.MultiSelectionPage;
using TEKUtsav.ViewModels.PurchaseOrderDetailsPage;
using TEKUtsav.ViewModels.RejectPopup;
using TEKUtsav.ViewModels.ScanCompletedPage;
using TEKUtsav.ViewModels.ScannerPage;
using TEKUtsav.ViewModels.WarehouseApprovalPopup;
using TEKUtsav.ViewModels.WorkFlowCompletedPopupPage;
using TEKUtsav.Views.AppListingMasterMenuPage;
using TEKUtsav.Views.AppListingPage;
//using TEKUtsav.Views.ContainerConditionsPage;
using TEKUtsav.Views.HomePage;
using TEKUtsav.Views.LoginPage;
using TEKUtsav.Views.LogisticsApprovalPopup;
//using TEKUtsav.Views.LogisticsContainerConditionsPage;
using TEKUtsav.Views.LogisticsHomePage;
using TEKUtsav.Views.LogisticsIncompleteWorkflow;
using TEKUtsav.Views.LogisticsMeasurementPage;
using TEKUtsav.Views.LogisticsPurchaseOrderDetailsPage;
using TEKUtsav.Views.LogisticsScanCompletedPage;
using TEKUtsav.Views.MasterMenuPage;
using TEKUtsav.Views.MeasurementPage;
using TEKUtsav.Views.MultiSelectionPage;
using TEKUtsav.Views.PurchaseOrderDetailsPage;
using TEKUtsav.Views.RejectPopupPage;
using TEKUtsav.Views.ScanCompletedPage;
using TEKUtsav.Views.ScannerPage;
using TEKUtsav.Views.WarehouseApprovalPopup;
using TEKUtsav.Views.WorkFlowCompletedPopupPage;
using TEKUtsav.ViewModels.AppListingMasterMenuPage;
using TEKUtsav.ViewModels.LoginPage;
using TEKUtsav.ViewModels.MasterMenuPage;
using TEKUtsav;

namespace TEKUtsav.Bootstrapping
{
    public static class BootstrapPageRegistry
    {
        public static void InitializePageRegistry(ContainerBuilder builder)
        {
            var registry = new PageRegistry<TEKUtsavAppPage>();

			registry.RegisterPage(TEKUtsavAppPage.LoginPage, typeof(LoginPage), typeof(LoginPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.AppListingMasterMenuPage, typeof(AppListingMasterMenuPage), typeof(AppListingMasterMenuPageViewModel));
            registry.RegisterPage(TEKUtsavAppPage.MasterMenuPage, typeof(MasterMenuPage), typeof(MasterMenuPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.AppListingPage, typeof(AppListingPage), typeof(AppListingPageViewModel));
            registry.RegisterPage(TEKUtsavAppPage.HomePage, typeof(HomePage), typeof(HomePageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.PurchaseOrderDetails, typeof(PurchaseOrderDetailsPage), typeof(PurchaseOrderDetailsPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.MeasurementPage, typeof(MeasurementPage), typeof(MeasurementPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.ScanCompletedPage, typeof(ScanCompletedPage), typeof(ScanCompletedPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.ScannerPage, typeof(ScannerPage), typeof(ScannerPageViewModel));
			//registry.RegisterPage(TEKUtsavAppPage.ContainerConditionsPage, typeof(ContainerConditionsPage), typeof(ContainerConditionsPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.MultiSelectionPage, typeof(MultiSelectionPage), typeof(MultiSelectionPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.RejectPopupPage, typeof(RejectPopupPage), typeof(RejectPopupPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.WorkFlowCompletedPopupPage, typeof(WorkFlowCompletedPopupPage), typeof(WorkFlowCompletedPopupPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.WarehouseApprovalPopupPage, typeof(WarehouseApprovalPopupPage), typeof(WarehouseApprovalPopupViewModel));

			registry.RegisterPage(TEKUtsavAppPage.LogisticsHomePage, typeof(LogisticsHomePage), typeof(LogisticsHomePageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.LogisticsPurchaseOrderDetails, typeof(LogisticsPurchaseOrderDetailsPage), typeof(LogisticsPurchaseOrderDetailsPageViewModel));
			//registry.RegisterPage(TEKUtsavAppPage.LogisticsContainerConditionsPage, typeof(LogisticsContainerConditionsPage), typeof(LogisticsContainerConditionsPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.LogisticsMeasurementPage, typeof(LogisticsMeasurementPage), typeof(LogisticsMeasurementPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.LogisticsScanCompletedPage, typeof(LogisticsScanCompletedPage), typeof(LogisticsScanCompletedPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.LogisticsIncompleteWorkflow, typeof(LogisticsIncompleteWorkflow), typeof(LogisticsIncompleteWorkflowViewModel));
			registry.RegisterPage(TEKUtsavAppPage.LogisticsApprovalPopup, typeof(LogisticsApprovalPopup), typeof(LogisticsApprovalPopupViewModel));

			builder.RegisterInstance(registry).SingleInstance().As<IPageRegistry<TEKUtsavAppPage>>();
        }
    }
}
