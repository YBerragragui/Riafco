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
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;

namespace Riafco.WebApi.Service.Dataflex.pro.News.Assembler
{
    /// <summary>
    /// The NewsTranslation assembler class.
    /// </summary>
    public static class NewsTranslationAssembler
    {
        #region TODTO
        /// <summary>
        ///    From NewsTranslation Pivot To NewsTranslation Dto.
        /// </summary>
        /// <param name="NewsTranslationPivot">NewsTranslation pivot to assemble.</param>
        /// <returns>NewsTranslationDto result.</returns>
        public static NewsTranslationDto ToDto(this NewsTranslationPivot NewsTranslationPivot)
        {
            if (NewsTranslationPivot == null)
            {
                return null;
            }
            else
            {
                return new NewsTranslationDto()
                {
                    TranslationId = NewsTranslationPivot.TranslationId,
                    NewsTitle = NewsTranslationPivot.NewsTitle,
                    NewsSummary = NewsTranslationPivot.NewsSummary,
                    NewsDescription = NewsTranslationPivot.NewsDescription,
                    LanguageId = NewsTranslationPivot.LanguageId,
                    Language = NewsTranslationPivot.Language?.ToDto(),
                    NewsId = NewsTranslationPivot.NewsId,
                    News = NewsTranslationPivot.News?.ToDto(),
                };
            }
        }

        /// <summary>
        ///    From NewsTranslation pivot list to NewsTranslation dto list.
        /// </summary>
        /// <param name="NewsTranslationPivotList">NewsTranslation pivot liste to assemble.</param>
        /// <returns>NewsTranslationdto result.</returns>
        public static List<NewsTranslationDto> ToDtoList(this List<NewsTranslationPivot> NewsTranslationPivotList)
        {
            return NewsTranslationPivotList?.Select(x => x?.ToDto()).ToList();

        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From NewsTranslation dto To NewsTranslation pivot.
        /// </summary>
        /// <param name="NewsTranslationDto">NewsTranslation dto to assemble.</param>
        /// <returns>NewsTranslationpivot result.</returns>
        public static NewsTranslationPivot ToPivot(this NewsTranslationDto NewsTranslationDto)
        {
            if (NewsTranslationDto == null)
            {
                return null;
            }
            return new NewsTranslationPivot()
            {
                TranslationId = NewsTranslationDto.TranslationId,
                NewsTitle = NewsTranslationDto.NewsTitle,
                NewsSummary = NewsTranslationDto.NewsSummary,
                NewsDescription = NewsTranslationDto.NewsDescription,
                LanguageId = NewsTranslationDto.LanguageId,
                Language = NewsTranslationDto.Language.ToPivot(),
                NewsId = NewsTranslationDto.NewsId,
                News = NewsTranslationDto.News.ToPivot(),
            };
        }

        /// <summary>
        ///    From NewsTranslationpivot list To NewsTranslation pivot list.
        /// </summary>
        /// <param name="NewsTranslationDtoList">NewsTranslation dto list to assemble.</param>
        /// <returns>NewsTranslationPivot list result.</returns>
        public static List<NewsTranslationPivot> ToPivotList(this List<NewsTranslationDto> NewsTranslationDtoList)
        {
            return NewsTranslationDtoList?.Select(x => x?.ToPivot()).ToList();

        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From NewsTranslation Request to NewsTranslation Request pivot.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>NewsTranslation Request pivot result.</returns>
        public static NewsTranslationRequestPivot ToPivot(this NewsTranslationRequest request)
        {
            return new NewsTranslationRequestPivot()
            {
                NewsTranslationPivot = request.NewsTranslationDto?.ToPivot(),
                NewsTranslationPivotList = request.NewsTranslationDtoList.ToPivotList(),
                FindNewsTranslationPivot = Utility.EnumToEnum<FindNewsTranslationDto, FindNewsTranslationPivot>(request.FindNewsTranslationDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From NewsTranslation Response pivot to NewsTranslation Message.
        /// </summary>
        /// <param name="response">NewsTranslation Response pivot to assemble.</param>
        /// <returns>NewsTranslation Message result.</returns>
        public static NewsTranslationMessage ToMessage(this NewsTranslationResponsePivot response)
        {
            if (response == null)
            {
                return null;
            }
            return new NewsTranslationMessage()
            {
                NewsTranslationDtoList = response.NewsTranslationPivotList.ToDtoList(),
                NewsTranslationDto = response.NewsTranslationPivot.ToDto(),
            };
        }

        #endregion
    }
}