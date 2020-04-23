using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.News.Dto;
using Riafco.Service.Dataflex.Pro.News.Data;
using Riafco.WebApi.Service.Dataflex.pro.News.Request;
using Riafco.Service.Dataflex.Pro.News.Request;
using Riafco.WebApi.Service.Dataflex.pro.News.Message;
using Riafco.Service.Dataflex.Pro.News.Response;
using Riafco.WebApi.Service.Dataflex.pro.News.Dto.Enum;
using Riafco.Service.Dataflex.Pro.News.Data.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.News.Assembler
{
    /// <summary>
    /// The News assembler class.
    /// </summary>
    public static class NewsAssembler
    {
        #region TODTO
        /// <summary>
        /// From News Pivot To News Dto.
        /// </summary>
        /// <param name="newsPivot">news pivot to assemble.</param>
        /// <returns>NewsDto result.</returns>
        public static NewsDto ToDto(this NewsPivot newsPivot)
        {
            if (newsPivot == null)
            {
                return null;
            }
            return new NewsDto
            {
                NewsId = newsPivot.NewsId,
                NewsImage = newsPivot.NewsImage,
                NewsDate = newsPivot.NewsDate,
            };
        }

        /// <summary>
        /// From News pivot list to News dto list.
        /// </summary>
        /// <param name="newsPivotList">news pivot liste to assemble.</param>
        /// <returns>Newsdto result.</returns>
        public static List<NewsDto> ToDtoList(this List<NewsPivot> newsPivotList)
        {
            return newsPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From News dto To News pivot.
        /// </summary>
        /// <param name="newsDto">news dto to assemble.</param>
        /// <returns>Newspivot result.</returns>
        public static NewsPivot ToPivot(this NewsDto newsDto)
        {
            if (newsDto == null)
            {
                return null;
            }
            return new NewsPivot()
            {
                NewsId = newsDto.NewsId,
                NewsImage = newsDto.NewsImage,
                NewsDate = newsDto.NewsDate,
            };
        }

        /// <summary>
        ///    From Newspivot list To News pivot list.
        /// </summary>
        /// <param name="newsDtoList">news dto list to assemble.</param>
        /// <returns>NewsPivot list result.</returns>
        public static List<NewsPivot> ToPivotList(this List<NewsDto> newsDtoList)
        {
            return newsDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From News Request to News Request pivot.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>News Request pivot result.</returns>
        public static NewsRequestPivot ToPivot(this NewsRequest request)
        {
            return new NewsRequestPivot()
            {
                NewsPivot = request.NewsDto?.ToPivot(),
                FindNewsPivot = Utility.EnumToEnum<FindNewsDto, FindNewsPivot>(request.FindNewsDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From News Response pivot to News Message.
        /// </summary>
        /// <param name="response">News Response pivot to assemble.</param>
        /// <returns>News Message result.</returns>
        public static NewsMessage ToMessage(this NewsResponsePivot response)
        {
            if (response == null)
            {
                return null;
            }
            return new NewsMessage()
            {
                NewsDtoList = response.NewsPivotList?.ToDtoList(),
                NewsDto = response.NewsPivot?.ToDto(),
            };
        }
        #endregion
    }
}