using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// The BaseController class.
    /// </summary>
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// The current langue.
        /// </summary>
        public string CurrentLanguageCode { get; set; }

        /// <summary>
        /// Initialize the langue.
        /// </summary>
        /// <param name="requestContext">the request to get the langue.</param>
        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.RouteData.Values["lang"] != null && requestContext.RouteData.Values["lang"] as string != "null")
            {
                CurrentLanguageCode = (string)requestContext.RouteData.Values["lang"];
                if (CurrentLanguageCode != null)
                {
                    try
                    {
                        Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo(CurrentLanguageCode);
                    }
                    catch
                    {
                        Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
                    }
                }
            }
            base.Initialize(requestContext);
        }
    }
}