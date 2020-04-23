using Riafco.Entity.Dataflex.Pro.News;
using Riafco.Service.Dataflex.Pro.News.Data;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;

namespace Riafco.Service.Dataflex.Pro.News.Assembler
{
    /// <summary>
    /// The newsTranslation assembler class.
    /// </summary>
    public static class NewsTranslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From newsTranslation To newsTranslation Pivot.
        /// </summary>
        /// <param name="newsTranslation">newsTranslation TO ASSEMBLE</param>
        /// <returns>newsTranslationPivot result.</returns>
        public static NewsTranslationPivot ToPivot(this NewsTranslation newsTranslation)
        {
            if (newsTranslation == null)
            {
                return null;
            }
            return new NewsTranslationPivot
            {
                TranslationId = newsTranslation.TranslationId,
                NewsTitle = newsTranslation.NewsTitle,
                NewsSummary = newsTranslation.NewsSummary,
                NewsDescription = newsTranslation.NewsDescription,
                LanguageId = newsTranslation.LanguageId,
                Language = newsTranslation.Language.ToPivot(),
                NewsId = newsTranslation.NewsId,
                News = newsTranslation.News.ToPivot(),
            };
        }

        /// <summary>
        /// From newsTranslation list to newsTranslation pivot list.
        /// </summary>
        /// <param name="newsTranslationList">newsTranslationList to assemble.</param>
        /// <returns>list of newsTranslationPivot result.</returns>
        public static List<NewsTranslationPivot> ToPivotList(this List<NewsTranslation> newsTranslationList)
        {
            return newsTranslationList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From newsTranslationPivot to newsTranslation.
        /// </summary>
        /// <param name="newsTranslationPivot">newsTranslationPivot to assemble.</param>
        /// <returns>newsTranslation result.</returns>
        public static NewsTranslation ToEntity(this NewsTranslationPivot newsTranslationPivot)
        {
            if (newsTranslationPivot == null)
            {
                return null;
            }
            return new NewsTranslation()
            {
                TranslationId = newsTranslationPivot.TranslationId,
                NewsTitle = newsTranslationPivot.NewsTitle,
                NewsSummary = newsTranslationPivot.NewsSummary,
                NewsDescription = newsTranslationPivot.NewsDescription,
                LanguageId = newsTranslationPivot.LanguageId,
                Language = newsTranslationPivot.Language.ToEntity(),
                NewsId = newsTranslationPivot.NewsId,
                News = newsTranslationPivot.News.ToEntity(),
            };
        }

        /// <summary>
        /// From newsTranslationPivotList to newsTranslationList .
        /// </summary>
        /// <param name="newsTranslationPivotList">newsTranslationPivotList to assemble.</param>
        /// <returns> list of newsTranslation result.</returns>
        public static List<NewsTranslation> ToEntityList(this List<NewsTranslationPivot> newsTranslationPivotList)
        {
            return newsTranslationPivotList?.Select(x => x.ToEntity()).ToList();

        }
        #endregion
    }
}