using Autofac;
using TEKUtsav.ViewModels.MasterMenuPage;
using TEKUtsav.ViewModels.HomePage;
using TEKUtsav.ViewModels.PurchaseOrderDetailsPage;
using TEKUtsav.ViewModels.MeasurementPage;
using TEKUtsav.ViewModels.MultiSelectionPage;
using TEKUtsav.ViewModels.RejectPopup;
using TEKUtsav.ViewModels.WorkFlowCompletedPopupPage;
using TEKUtsav.ViewModels.WarehouseApprovalPopup;

using TEKUtsav.ViewModels.LoginPage;
using TEKUtsav.ViewModels.RegistrationPage;
using TEKUtsav.ViewModels.NotificationsPage;
using TEKUtsav.ViewModels.VotingPage;
using TEKUtsav.ViewModels.AdminSettingsPage;
using TEKUtsav.ViewModels.SingleSelectionPage;
using TEKUtsav.ViewModels.EventSchedulePage;
using TEKUtsav.ViewModels.ContactDetailsPage;

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
            builder.RegisterType<SingleSelectionPageViewModel>();
            builder.RegisterType<EventSchedulePageViewModel>();
            builder.RegisterType<ContactDetailsPageViewModel>();


			builder.RegisterType<MasterMenuPageViewModel>();
            builder.RegisterType<HomePageViewModel>();
			builder.RegisterType<PurchaseOrderDetailsPageViewModel>();
			builder.RegisterType<MeasurementPageViewModel>();
			builder.RegisterType<RejectPopupPageViewModel>();
			builder.RegisterType<WorkFlowCompletedPopupPageViewModel>();
			builder.RegisterType<MultiSelectionPageViewModel>();
			builder.RegisterType<WarehouseApprovalPopupViewModel>();
		}
    }
}
