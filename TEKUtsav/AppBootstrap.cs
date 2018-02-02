using Autofac;
using TEKUtsav.Infrastructure.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure;
using TEKUtsav.Bootstrapping;
using TEKUtsav.Navigation;

namespace TEKUtsav
{
    public static class AppBootstrap
    {
        public static void Initialize(ContainerBuilder builder)
        {
            BootstrapInfrastructure.Register(builder);
            //BootstrapBusiness.Register(builder);
			BootstrapRal.Register(builder);
			BootstrapPageRegistry.InitializePageRegistry(builder);
            RegisterNavigationService(builder);
            BootstrapViewModels.Register(builder);
        }
       
        private static void RegisterNavigationService(ContainerBuilder builder)
        {
            builder.RegisterType<NavigationService>().SingleInstance().As<INavigationService>();
        }
    }
}
