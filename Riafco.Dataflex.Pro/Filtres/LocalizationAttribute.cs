using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Riafco.Dataflex.Pro.Filtres
{
    /// <summary>
    /// The LocalizationAttribute class.
    /// </summary>
    public class LocalizationAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// The default language.
        /// </summary>
        private readonly string _defaultLanguage;

        /// <summary>
        /// Constructor to set langue.
        /// </summary>
        /// <param name="defaultLanguage">the langue to set.</param>
        public LocalizationAttribute(string defaultLanguage)
        {
            _defaultLanguage = defaultLanguage;
        }

        /// <summary>
        /// Set the langue
        /// </summary>
        /// <param name="filterContext">the filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = (string)filterContext.RouteData.Values["lang"] ?? _defaultLanguage;
            if (!string.IsNullOrEmpty(lang))
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                }
                catch
                {
                    Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
                }
            }
        }
    }
}