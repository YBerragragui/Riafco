using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Riafco.Dataflex.Pro
{
    /// <summary>
    /// The MvcApplication class.
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// The start application methode.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
