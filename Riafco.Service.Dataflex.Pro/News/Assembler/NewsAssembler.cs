using Riafco.Service.Dataflex.Pro.News.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.News.Assembler
{
    /// <summary>
    /// The News assembler class.
    /// </summary>
    public static class NewsAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From News To News Pivot.
        /// </summary>
        /// <param name="news">news TO ASSEMBLE</param>
        /// <returns>NewsPivot result.</returns>
        public static NewsPivot ToPivot(this Entity.Dataflex.Pro.News.News news)
        {
            if (news == null)
            {
                return null;
            }
            return new NewsPivot
            {
                NewsId = news.NewsId,
                NewsImage = news.NewsImage,
                NewsDate = news.NewsDate
            };
        }

        /// <summary>
        /// From News list to News pivot list.
        /// </summary>
        /// <param name="newsList">newsList to assemble.</param>
        /// <returns>list of NewsPivot result.</returns>
        public static List<NewsPivot> ToPivotList(this List<Entity.Dataflex.Pro.News.News> newsList)
        {
            return newsList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From NewsPivot to News.
        /// </summary>
        /// <param name="newsPivot">newsPivot to assemble.</param>
        /// <returns>News result.</returns>
        public static Entity.Dataflex.Pro.News.News ToEntity(this NewsPivot newsPivot)
        {
            if (newsPivot == null)
            {
                return null;
            }
            return new Entity.Dataflex.Pro.News.News
            {
                NewsId = newsPivot.NewsId,
                NewsImage = newsPivot.NewsImage,
                NewsDate = newsPivot.NewsDate
            };
        }

        /// <summary>
        /// From NewsPivotList to NewsList .
        /// </summary>
        /// <param name="newsPivotList">NewsPivotList to assemble.</param>
        /// <returns> list of News result.</returns>
        public static List<Entity.Dataflex.Pro.News.News> ToEntityList(this List<NewsPivot> newsPivotList)
        {
            return newsPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}