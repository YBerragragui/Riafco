using System.Web.Mvc;
using System.Web.Routing;

namespace Riafco.Dataflex.Pro.Helpers
{
    /// <summary>
    /// The LanguageHelper class.
    /// </summary>
    public static class LanguageHelper
    {
        /// <summary>
        /// The links toi switch langue.
        /// </summary>
        /// <param name="url">the url of the page.</param>
        /// <param name="name">the langue name.</param>
        /// <param name="routeData">the data roote.</param>
        /// <param name="lang">the langue to set.</param>
        /// <returns></returns>
        public static MvcHtmlString LangSwitcher(this UrlHelper url, string name, RouteData routeData, string lang)
        {
            var liTag = new TagBuilder("li");
            var aTag = new TagBuilder("a");
            var routeValueDictionary = new RouteValueDictionary(routeData.Values);
            if (routeValueDictionary.ContainsKey("lang"))
            {
                if (routeData.Values["lang"] as string == lang)
                {
                    liTag.AddCssClass("active");
                }
                else
                {
                    routeValueDictionary["lang"] = lang;
                }
            }
            aTag.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
            aTag.SetInnerText(name);
            liTag.InnerHtml = aTag.ToString();
            return new MvcHtmlString(liTag.ToString());
        }
    }
}