using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto;
using Riafco.Service.Dataflex.Pro.Newsletters.Data;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Request;
using Riafco.Service.Dataflex.Pro.Newsletters.Request;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Message;
using Riafco.Service.Dataflex.Pro.Newsletters.Response;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto.Enum;
using Riafco.Service.Dataflex.Pro.Newsletters.Data.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Assembler
{
    /// <summary>
    /// The NewsletterMailTranslation assembler class.
    /// </summary>
    public static class NewsletterMailTranslationAssembler
    {
        #region TODTO
        /// <summary>
        ///    From NewsletterMailTranslation Pivot To NewsletterMailTranslation Dto.
        /// </summary>
        /// <param name="newsletterMailTranslationPivot">newsletterMailTranslation pivot to assemble.</param>
        /// <returns>NewsletterMailTranslationDto result.</returns>
        public static NewsletterMailTranslationDto ToDto(this NewsletterMailTranslationPivot newsletterMailTranslationPivot)
        {
            if (newsletterMailTranslationPivot == null)
            {
                return null;
            }
            return new NewsletterMailTranslationDto()
            {
                TranslationId = newsletterMailTranslationPivot.TranslationId,
                NewsletterMailSource = newsletterMailTranslationPivot.NewsletterMailSource,
                NewsletterMailSubject = newsletterMailTranslationPivot.NewsletterMailSubject,
                NewsletterMailId = newsletterMailTranslationPivot.NewsletterMailId,
                NewsletterMail = newsletterMailTranslationPivot.NewsletterMail?.ToDto(),
                LanguageId = newsletterMailTranslationPivot.LanguageId,
                Language = newsletterMailTranslationPivot.Language?.ToDto(),
            };
        }

        /// <summary>
        ///    From NewsletterMailTranslation pivot list to NewsletterMailTranslation dto list.
        /// </summary>
        /// <param name="newsletterMailTranslationPivotList">newsletterMailTranslation pivot liste to assemble.</param>
        /// <returns>NewsletterMailTranslationdto result.</returns>
        public static List<NewsletterMailTranslationDto> ToDtoList(this List<NewsletterMailTranslationPivot> newsletterMailTranslationPivotList)
        {
            return newsletterMailTranslationPivotList?.Select(x => x?.ToDto()).ToList();

        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From NewsletterMailTranslation dto To NewsletterMailTranslation pivot.
        /// </summary>
        /// <param name="newsletterMailTranslationDto">newsletterMailTranslation dto to assemble.</param>
        /// <returns>NewsletterMailTranslationpivot result.</returns>
        public static NewsletterMailTranslationPivot ToPivot(this NewsletterMailTranslationDto newsletterMailTranslationDto)
        {
            if (newsletterMailTranslationDto == null)
            {
                return null;
            }
            return new NewsletterMailTranslationPivot()
            {
                TranslationId = newsletterMailTranslationDto.TranslationId,
                NewsletterMailSource = newsletterMailTranslationDto.NewsletterMailSource,
                NewsletterMailSubject = newsletterMailTranslationDto.NewsletterMailSubject,
                NewsletterMailId = newsletterMailTranslationDto.NewsletterMailId,
                NewsletterMail = newsletterMailTranslationDto.NewsletterMail?.ToPivot(),
                LanguageId = newsletterMailTranslationDto.LanguageId,
                Language = newsletterMailTranslationDto.Language?.ToPivot(),
            };
        }

        /// <summary>
        ///    From NewsletterMailTranslationpivot list To NewsletterMailTranslation pivot list.
        /// </summary>
        /// <param name="newsletterMailTranslationDtoList">newsletterMailTranslation dto list to assemble.</param>
        /// <returns>NewsletterMailTranslationPivot list result.</returns>
        public static List<NewsletterMailTranslationPivot> ToPivotList(this List<NewsletterMailTranslationDto> newsletterMailTranslationDtoList)
        {
            return newsletterMailTranslationDtoList?.Select(x => x?.ToPivot()).ToList();

        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From NewsletterMailTranslation Request to NewsletterMailTranslation Request pivot.
        /// </summary>
        /// <param name="newsletterMailTranslationRequest"></param>
        /// <returns>NewsletterMailTranslation Request pivot result.</returns>
        public static NewsletterMailTranslationRequestPivot ToPivot(this NewsletterMailTranslationRequest newsletterMailTranslationRequest)
        {
            return new NewsletterMailTranslationRequestPivot()
            {
                NewsletterMailTranslationPivot = newsletterMailTranslationRequest.NewsletterMailTranslationDto?.ToPivot(),
                NewsletterMailTranslationPivotList = newsletterMailTranslationRequest.NewsletterMailTranslationDtoList?.ToPivotList(),
                FindNewsletterMailTranslationPivot = Utility.EnumToEnum<FindNewsletterMailTranslationDto, FindNewsletterMailTranslationPivot>(newsletterMailTranslationRequest.FindNewsletterMailTranslationDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From NewsletterMailTranslation Response pivot to NewsletterMailTranslation Message.
        /// </summary>
        /// <param name="newsletterMailTranslationResponsePivot">NewsletterMailTranslation Response pivot to assemble.</param>
        /// <returns>NewsletterMailTranslation Message result.</returns>
        public static NewsletterMailTranslationMessage ToMessage(this NewsletterMailTranslationResponsePivot newsletterMailTranslationResponsePivot)
        {
            if (newsletterMailTranslationResponsePivot == null)
            {
                return null;
            }
            return new NewsletterMailTranslationMessage()
            {
                NewsletterMailTranslationDtoList = newsletterMailTranslationResponsePivot.NewsletterMailTranslationPivotList?.ToDtoList(),
                NewsletterMailTranslationDto = newsletterMailTranslationResponsePivot.NewsletterMailTranslationPivot?.ToDto(),
            };
        }

        #endregion
    }
}