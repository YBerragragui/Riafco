using Riafco.Service.Dataflex.Pro.News.Data;
using Riafco.Service.Dataflex.Pro.News.Data.Enum;
using System;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.News.Request
{
    /// <summary>
    /// Gets or Sets The  NewsTranslation request class.
    /// </summary>
    public class NewsTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  NewsTranslationPivot requested.
        /// </summary>
        public NewsTranslationPivot NewsTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsTranslationPivot requested.
        /// </summary>
        public List<NewsTranslationPivot> NewsTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  Find NewsTranslationEnum.
        /// </summary>
        public FindNewsTranslationPivot FindNewsTranslationPivot { get; set; }
    }
}