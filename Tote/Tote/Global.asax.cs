using System.Web.Mvc;
using System.Web.Routing;
using ToteBiz.Business.Providers;


namespace Tote
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

           
            
        }
    }
}
