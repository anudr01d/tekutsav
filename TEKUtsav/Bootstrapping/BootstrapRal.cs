using Autofac;
using TEKUtsav.Ral.PurchaseOrders;
using TEKUtsav.Ral.CloudUtils;
using TEKUtsav.Ral.CloudUtils.Impl;
using TEKUtsav.Ral.PurchaseOrders.Impl;
using TEKUtsav.Ral.Impl;
using TEKUtsav.Ral;
using TEKUtsav.Ral.Impl.User;
using TEKUtsav.Ral.User;
using TEKUtsav.Ral.Impl.EventRestApi;
using TEKUtsav.Ral.EventApi;
using TEKUtsav.Ral.Impl.NotificationRestApi;
using TEKUtsav.Ral.NotificationApi;

namespace TEKUtsav.Bootstrapping
{
    public static class BootstrapRal
    {
        public static void Register(ContainerBuilder builder) {
			builder.RegisterType<CloudService>().As<ICloudService>();
			builder.RegisterType<AzureClient>().As<IAzureClient>();
			builder.RegisterType<PurchaseOrdersRestApi>().As<IPurchaseOrdersRestApi>();

            builder.RegisterType<UserRestApi>().As<IUserRestApi>();
            builder.RegisterType<EventRestApi>().As<IEventRestApi>();
            builder.RegisterType<NotificationRestApi>().As<INotificationRestApi>();

        }
    }
}
