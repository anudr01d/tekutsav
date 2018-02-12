using Autofac;
using TEKUtsav.Business.Impl;
using TEKUtsav.Business.Measurements;
using TEKUtsav.Business.PurchaseOrders;
using TEKUtsav.Business.User;
using TEKUtsav.Business.User.Impl;
//using TEKUtsav.Business.PurchaseOrders.Impl;
using TEKUtsav.Infrastructure.Logging;
using TEKUtsav.Business.EventService;
using TEKUtsav.Business.EventService.Impl;

namespace TEKUtsav.Bootstrapping
{
    public static class BootstrapBusiness
    {
        public static void Register(ContainerBuilder builder) {
            builder.RegisterType<LoggingBusinessService>().As<ILogger>().SingleInstance();
            builder.RegisterType<UserBusinessService>().As<IUserBusinessService>();
            builder.RegisterType<EventBusinessService>().As<IEventBusinessService>();
        }
    }
}
