using System.Web.Mvc;
using System.Web.Routing;

namespace SitecoreDev.Web
{
  public class MvcApplication : Sitecore.Web.Application
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      RouteConfig.RegisterRoutes(RouteTable.Routes);
    }
  }
}
