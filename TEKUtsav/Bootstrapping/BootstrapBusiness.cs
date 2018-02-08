using Autofac;
using TEKUtsav.Business.Impl;
using TEKUtsav.Business.Measurements;
using TEKUtsav.Business.PurchaseOrders;
using TEKUtsav.Business.User;
using TEKUtsav.Business.User.Impl;
//using TEKUtsav.Business.PurchaseOrders.Impl;
using TEKUtsav.Infrastructure.Logging;

namespace TEKUtsav.Bootstrapping
{
    public static class BootstrapBusiness
    {
        public static void Register(ContainerBuilder builder) {
            builder.RegisterType<LoggingBusinessService>().As<ILogger>().SingleInstance();
            builder.RegisterType<UserBusinessService>().As<IUserBusinessService>();
        }
    }
}
