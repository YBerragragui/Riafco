using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.News.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.News.ViewData
{
    /// <summary>
    /// The NewsViewData class.
    /// </summary>
    public class NewsViewData
    {
        /// <summary>
        /// Gets or sets News.
        /// </summary>
        public NewsItemData News { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<NewsTranslationItemData> TranslationsList { get; set; }
    }
}