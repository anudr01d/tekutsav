using Autofac;
//using TEKUtsav.Business.ContainerConditions;
//using TEKUtsav.Business.ContainerConditions.Impl;
using TEKUtsav.Business.Impl;
using TEKUtsav.Business.Measurements;
//using TEKUtsav.Business.Measurements.Impl;
using TEKUtsav.Business.PurchaseOrders;
//using TEKUtsav.Business.PurchaseOrders.Impl;
using TEKUtsav.Infrastructure.Logging;

namespace TEKUtsav.Bootstrapping
{
    public static class BootstrapBusiness
    {
        public static void Register(ContainerBuilder builder) {
            builder.RegisterType<LoggingBusinessService>().As<ILogger>().SingleInstance();
			//builder.RegisterType<PurchaseOrdersBusinessService>().As<IPurchaseOrdersBusinessService>();
			//builder.RegisterType<MeasurementsBusinessService>().As<IMeasurementsBusinessService>();
        }
    }
}
