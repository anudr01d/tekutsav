using Autofac;
using TEKUtsav.ViewModels.MasterMenuPage;
using TEKUtsav.ViewModels.LoginPage;
using TEKUtsav.ViewModels.HomePage;
using TEKUtsav.ViewModels.PurchaseOrderDetailsPage;
using TEKUtsav.ViewModels.AppListingPage;
using TEKUtsav.ViewModels.MeasurementPage;
using TEKUtsav.ViewModels.AppListingMasterMenuPage;
using TEKUtsav.ViewModels.ScanCompletedPage;
using TEKUtsav.ViewModels.MultiSelectionPage;
using TEKUtsav.ViewModels.ScannerPage;
using TEKUtsav.ViewModels.RejectPopup;
using TEKUtsav.ViewModels.WorkFlowCompletedPopupPage;
using TEKUtsav.ViewModels.LogisticsHomePage;
using TEKUtsav.ViewModels.LogisticsPurchaseOrderDetailsPage;
using TEKUtsav.ViewModels.LogisticsMeasurementPage;
using TEKUtsav.ViewModels.LogisticsIncompleteWorkflow;
using TEKUtsav.ViewModels.LogisticsApprovalPopup;
using TEKUtsav.ViewModels.WarehouseApprovalPopup;

namespace TEKUtsav.Bootstrapping
{
    public static class BootstrapViewModels
    {
        public static void Register(ContainerBuilder builder)
        {
           	builder.RegisterType<LoginPageViewModel>();
			builder.RegisterType<AppListingMasterMenuPageViewModel>();
			builder.RegisterType<MasterMenuPageViewModel>();
            builder.RegisterType<HomePageViewModel>();
			builder.RegisterType<PurchaseOrderDetailsPageViewModel>();
			builder.RegisterType<AppListingPageViewModel>();
			builder.RegisterType<MeasurementPageViewModel>();
			builder.RegisterType<ScannerPageViewModel>();
			builder.RegisterType<ScanCompletedPageViewModel>();
			builder.RegisterType<RejectPopupPageViewModel>();
			builder.RegisterType<WorkFlowCompletedPopupPageViewModel>();
			builder.RegisterType<MultiSelectionPageViewModel>();
			builder.RegisterType<WarehouseApprovalPopupViewModel>();
			builder.RegisterType<LogisticsHomePageViewModel>();
			builder.RegisterType<LogisticsPurchaseOrderDetailsPageViewModel>();
			builder.RegisterType<LogisticsMeasurementPageViewModel>();
			builder.RegisterType<LogisticsScanCompletedPageViewModel>();
			builder.RegisterType<LogisticsIncompleteWorkflowViewModel>();
			builder.RegisterType<LogisticsApprovalPopupViewModel>();
		}
    }
}
