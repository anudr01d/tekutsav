using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.Presentation;
using TEKUtsav.ViewModels.HomePage;
using TEKUtsav.ViewModels.MeasurementPage;

using TEKUtsav.ViewModels.MultiSelectionPage;
using TEKUtsav.ViewModels.PurchaseOrderDetailsPage;
using TEKUtsav.ViewModels.RejectPopup;
using TEKUtsav.ViewModels.WarehouseApprovalPopup;
using TEKUtsav.ViewModels.WorkFlowCompletedPopupPage;
using TEKUtsav.Views.HomePage;

using TEKUtsav.Views.MasterMenuPage;
using TEKUtsav.Views.MeasurementPage;
using TEKUtsav.Views.MultiSelectionPage;
using TEKUtsav.Views.PurchaseOrderDetailsPage;
using TEKUtsav.Views.RejectPopupPage;
using TEKUtsav.Views.WarehouseApprovalPopup;
using TEKUtsav.Views.WorkFlowCompletedPopupPage;
using TEKUtsav.ViewModels.MasterMenuPage;

using TEKUtsav.ViewModels.LoginPage;
using TEKUtsav.ViewModels.RegistrationPage;
using TEKUtsav.ViewModels.NotificationsPage;

using TEKUtsav.Views.LoginPage;
using TEKUtsav.Views.RegistrationPage;
using TEKUtsav.Views.NotificationsPage;
using TEKUtsav.Views.VotingPage;
using TEKUtsav.ViewModels.VotingPage;
using TEKUtsav.Views.AdminSettingsPage;
using TEKUtsav.ViewModels.AdminSettingsPage;

namespace TEKUtsav.Bootstrapping
{
    public static class BootstrapPageRegistry
    {
        public static void InitializePageRegistry(ContainerBuilder builder)
        {
            var registry = new PageRegistry<TEKUtsavAppPage>();

			registry.RegisterPage(TEKUtsavAppPage.LoginPage, typeof(LoginPage), typeof(LoginPageViewModel));
            registry.RegisterPage(TEKUtsavAppPage.RegistrationPage, typeof(RegistrationPage), typeof(RegistrationPageViewModel));
            registry.RegisterPage(TEKUtsavAppPage.NotificationsPage, typeof(NotificationsPage), typeof(NotificationsPageViewModel));
            registry.RegisterPage(TEKUtsavAppPage.VotingPage, typeof(VotingPage), typeof(VotingPageViewModel));
            registry.RegisterPage(TEKUtsavAppPage.AdminSettingsPage, typeof(AdminSettingsPage), typeof(AdminSettingsPageViewModel));


            registry.RegisterPage(TEKUtsavAppPage.MasterMenuPage, typeof(MasterMenuPage), typeof(MasterMenuPageViewModel));
            registry.RegisterPage(TEKUtsavAppPage.HomePage, typeof(HomePage), typeof(HomePageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.PurchaseOrderDetails, typeof(PurchaseOrderDetailsPage), typeof(PurchaseOrderDetailsPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.MeasurementPage, typeof(MeasurementPage), typeof(MeasurementPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.MultiSelectionPage, typeof(MultiSelectionPage), typeof(MultiSelectionPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.RejectPopupPage, typeof(RejectPopupPage), typeof(RejectPopupPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.WorkFlowCompletedPopupPage, typeof(WorkFlowCompletedPopupPage), typeof(WorkFlowCompletedPopupPageViewModel));
			registry.RegisterPage(TEKUtsavAppPage.WarehouseApprovalPopupPage, typeof(WarehouseApprovalPopupPage), typeof(WarehouseApprovalPopupViewModel));

			builder.RegisterInstance(registry).SingleInstance().As<IPageRegistry<TEKUtsavAppPage>>();
        }
    }
}
