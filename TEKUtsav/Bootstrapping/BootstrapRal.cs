using Autofac;
using TEKUtsav.Ral.PurchaseOrders;
using TEKUtsav.Ral.CloudUtils;
using TEKUtsav.Ral.CloudUtils.Impl;
using TEKUtsav.Ral.PurchaseOrders.Impl;
using TEKUtsav.Ral.ContainerConditions;
using TEKUtsav.Ral.ContainerConditions.Impl;
using TEKUtsav.Ral.Measurements.Impl;
using TEKUtsav.Ral.Measurements;
using TEKUtsav.Ral.Impl;
using TEKUtsav.Ral;

namespace TEKUtsav.Bootstrapping
{
    public static class BootstrapRal
    {
        public static void Register(ContainerBuilder builder) {
			builder.RegisterType<CloudService>().As<ICloudService>();
			builder.RegisterType<AzureClient>().As<IAzureClient>();
			builder.RegisterType<PurchaseOrdersRestApi>().As<IPurchaseOrdersRestApi>();
			builder.RegisterType<ContainerConditionsRestApi>().As<IContainerConditionsRestApi>();
			builder.RegisterType<MeasurementsRestApi>().As<IMeasurementsRestApi>();
        }
    }
}
