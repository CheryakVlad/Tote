using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Modules;
using Tote.Util;
using ToteBiz.Business.Providers;
using Ninject;
using Ninject.Web.Mvc;

namespace Tote
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            App_Start.AutoMapperConfig.Initialize();

            NinjectModule navigationModule = new NinjectRegistration();            
            NinjectModule serviceModule = new ModuleProvider();
            var kernel = new StandardKernel(navigationModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
