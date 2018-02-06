using Autofac;
using TEKUtsav.ViewModels.MasterMenuPage;
using TEKUtsav.ViewModels.HomePage;
using TEKUtsav.ViewModels.PurchaseOrderDetailsPage;
using TEKUtsav.ViewModels.AppListingPage;
using TEKUtsav.ViewModels.MeasurementPage;
using TEKUtsav.ViewModels.AppListingMasterMenuPage;
using TEKUtsav.ViewModels.MultiSelectionPage;
using TEKUtsav.ViewModels.RejectPopup;
using TEKUtsav.ViewModels.WorkFlowCompletedPopupPage;
using TEKUtsav.ViewModels.WarehouseApprovalPopup;

using TEKUtsav.ViewModels.LoginPage;
using TEKUtsav.ViewModels.RegistrationPage;
using TEKUtsav.ViewModels.NotificationsPage;
using TEKUtsav.ViewModels.VotingPage;
using TEKUtsav.ViewModels.AdminSettingsPage;

namespace TEKUtsav.Bootstrapping
{
    public static class BootstrapViewModels
    {
        public static void Register(ContainerBuilder builder)
        {
           	builder.RegisterType<LoginPageViewModel>();
            builder.RegisterType<RegistrationPageViewModel>();
            builder.RegisterType<NotificationsPageViewModel>();
            builder.RegisterType<VotingPageViewModel>();
            builder.RegisterType<AdminSettingsPageViewModel>();

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
