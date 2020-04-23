using System.Web.Mvc;
using Riafco.Dataflex.Pro.Filtres;

namespace Riafco.Dataflex.Pro
{
    /// <summary>
    /// The FilterConfig class.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Set the langue to fr.
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LocalizationAttribute("fr"), 0);
        }
    }
}