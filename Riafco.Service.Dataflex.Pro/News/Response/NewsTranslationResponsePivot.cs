using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.News.Data;

namespace Riafco.Service.Dataflex.Pro.News.Response
{
    /// <summary>
    /// The NewsTranslation response class.
    /// </summary>
    public class NewsTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  NewsTranslationPivotList.
        /// </summary>
        public List<NewsTranslationPivot> NewsTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsTranslationPivot.
        /// </summary>
        public NewsTranslationPivot NewsTranslationPivot { get; set; }

    }
}