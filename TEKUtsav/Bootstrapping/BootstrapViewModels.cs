using Autofac;
using TEKUtsav.ViewModels.MasterMenuPage;
using TEKUtsav.ViewModels.HomePage;
using TEKUtsav.ViewModels.PurchaseOrderDetailsPage;
using TEKUtsav.ViewModels.AppListingPage;
using TEKUtsav.ViewModels.MeasurementPage;
using TEKUtsav.ViewModels.AppListingMasterMenuPage;
using TEKUtsav.ViewModels.MultiSelectionPage;
using TEKUtsav.ViewModels.ScannerPage;
using TEKUtsav.ViewModels.RejectPopup;
using TEKUtsav.ViewModels.WorkFlowCompletedPopupPage;
using TEKUtsav.ViewModels.WarehouseApprovalPopup;

using TEKUtsav.ViewModels.LoginPage;
using TEKUtsav.ViewModels.RegistrationPage;

namespace TEKUtsav.Bootstrapping
{
    public static class BootstrapViewModels
    {
        public static void Register(ContainerBuilder builder)
        {
           	builder.RegisterType<LoginPageViewModel>();
            builder.RegisterType<RegistrationPageViewModel>();

			builder.RegisterType<AppListingMasterMenuPageViewModel>();
			builder.RegisterType<MasterMenuPageViewModel>();
            builder.RegisterType<HomePageViewModel>();
			builder.RegisterType<PurchaseOrderDetailsPageViewModel>();
			builder.RegisterType<AppListingPageViewModel>();
			builder.RegisterType<MeasurementPageViewModel>();
			builder.RegisterType<RejectPopupPageViewModel>();
			builder.RegisterType<WorkFlowCompletedPopupPageViewModel>();
			builder.RegisterType<MultiSelectionPageViewModel>();
			builder.RegisterType<WarehouseApprovalPopupViewModel>();
		}
    }
}
