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

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Assembler
{
    /// <summary>
    /// The NewsletterMail assembler class.
    /// </summary>
    public static class NewsletterMailAssembler
    {
        #region TODTO
        /// <summary>
        ///    From NewsletterMail Pivot To NewsletterMail Dto.
        /// </summary>
        /// <param name="newsletterMailPivot">newsletterMail pivot to assemble.</param>
        /// <returns>NewsletterMailDto result.</returns>
        public static NewsletterMailDto ToDto(this NewsletterMailPivot newsletterMailPivot)
        {
            if (newsletterMailPivot == null)
            {
                return null;
            }
            return new NewsletterMailDto()
            {
                NewsletterMailId = newsletterMailPivot.NewsletterMailId,
            };
        }

        /// <summary>
        ///    From NewsletterMail pivot list to NewsletterMail dto list.
        /// </summary>
        /// <param name="newsletterMailPivotList">newsletterMail pivot liste to assemble.</param>
        /// <returns>NewsletterMaildto result.</returns>
        public static List<NewsletterMailDto> ToDtoList(this List<NewsletterMailPivot> newsletterMailPivotList)
        {
            return newsletterMailPivotList?.Select(x => x?.ToDto()).ToList();

        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From NewsletterMail dto To NewsletterMail pivot.
        /// </summary>
        /// <param name="newsletterMailDto">newsletterMail dto to assemble.</param>
        /// <returns>NewsletterMailpivot result.</returns>
        public static NewsletterMailPivot ToPivot(this NewsletterMailDto newsletterMailDto)
        {
            if (newsletterMailDto == null)
            {
                return null;
            }
            else
            {
                return new NewsletterMailPivot()
                {
                    NewsletterMailId = newsletterMailDto.NewsletterMailId,
                };

            }
        }

        /// <summary>
        ///    From NewsletterMailpivot list To NewsletterMail pivot list.
        /// </summary>
        /// <param name="newsletterMailDtoList">newsletterMail dto list to assemble.</param>
        /// <returns>NewsletterMailPivot list result.</returns>
        public static List<NewsletterMailPivot> ToPivotList(this List<NewsletterMailDto> newsletterMailDtoList)
        {
            return newsletterMailDtoList?.Select(x => x?.ToPivot()).ToList();

        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From NewsletterMail Request to NewsletterMail Request pivot.
        /// </summary>
        /// <param name="newsletterMailRequest"></param>
        /// <returns>NewsletterMail Request pivot result.</returns>
        public static NewsletterMailRequestPivot ToPivot(this NewsletterMailRequest newsletterMailRequest)
        {
            return new NewsletterMailRequestPivot()
            {
                NewsletterMailPivot = newsletterMailRequest.NewsletterMailDto?.ToPivot(),
                FindNewsletterMailPivot = Utility.EnumToEnum<FindNewsletterMailDto, FindNewsletterMailPivot>(newsletterMailRequest.FindNewsletterMailDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From NewsletterMail Response pivot to NewsletterMail Message.
        /// </summary>
        /// <param name="newsletterMailResponsePivot">NewsletterMail Response pivot to assemble.</param>
        /// <returns>NewsletterMail Message result.</returns>
        public static NewsletterMailMessage ToMessage(this NewsletterMailResponsePivot newsletterMailResponsePivot)
        {
            if (newsletterMailResponsePivot == null)
            {
                return null;
            }
            return new NewsletterMailMessage()
            {
                NewsletterMailDtoList = newsletterMailResponsePivot.NewsletterMailPivotList?.ToDtoList(),
                NewsletterMailDto = newsletterMailResponsePivot.NewsletterMailPivot?.ToDto(),
            };
        }

        #endregion

    }
}