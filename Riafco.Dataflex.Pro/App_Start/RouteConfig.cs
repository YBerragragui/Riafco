using System.Web.Mvc;
using System.Web.Routing;

namespace Riafco.Dataflex.Pro
{
    /// <summary>
    /// The RouteConfig class.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Register all routes.
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Language",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = @"fr|en" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, lang = "fr" }
            );
        }
    }
}
