using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Dto;
using Riafco.Service.Dataflex.Pro.Contact.Data;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Request;
using Riafco.Service.Dataflex.Pro.Contact.Request;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Message;
using Riafco.Service.Dataflex.Pro.Contact.Response;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Dto.Enum;
using Riafco.Service.Dataflex.Pro.Contact.Data.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;

namespace Riafco.WebApi.Service.Dataflex.pro.Contact.Assembler
{
    /// <summary>
    /// The ContactMessage assembler class.
    /// </summary>
    public static class ContactMessageAssembler
    {
        #region TODTO
        /// <summary>
        ///    From ContactMessage Pivot To ContactMessage Dto.
        /// </summary>
        /// <param name="contactMessagePivot">contactMessage pivot to assemble.</param>
        /// <returns>ContactMessageDto result.</returns>
        public static ContactMessageDto ToDto(this ContactMessagePivot contactMessagePivot)
        {
            if (contactMessagePivot == null)
            {
                return null;
            }
            return new ContactMessageDto()
            {
                ContactMessageId = contactMessagePivot.ContactMessageId,
                ContactMessageFirstName = contactMessagePivot.ContactMessageFirstName,
                ContactMessageLastName = contactMessagePivot.ContactMessageLastName,
                ContactMessageMail = contactMessagePivot.ContactMessageMail,
                ContactMessageSubject = contactMessagePivot.ContactMessageSubject,
                ContactMessageText = contactMessagePivot.ContactMessageText,
                LanguageId = contactMessagePivot.LanguageId,
                Language = contactMessagePivot.Language?.ToDto(),
            };
        }

        /// <summary>
        ///    From ContactMessage pivot list to ContactMessage dto list.
        /// </summary>
        /// <param name="contactMessagePivotList">contactMessage pivot liste to assemble.</param>
        /// <returns>ContactMessagedto result.</returns>
        public static List<ContactMessageDto> ToDtoList(this List<ContactMessagePivot> contactMessagePivotList)
        {
            return contactMessagePivotList?.Select(x => x?.ToDto()).ToList();

        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From ContactMessage dto To ContactMessage pivot.
        /// </summary>
        /// <param name="contactMessageDto">contactMessage dto to assemble.</param>
        /// <returns>ContactMessagepivot result.</returns>
        public static ContactMessagePivot ToPivot(this ContactMessageDto contactMessageDto)
        {
            if (contactMessageDto == null)
            {
                return null;
            }
            return new ContactMessagePivot()
            {
                ContactMessageId = contactMessageDto.ContactMessageId,
                ContactMessageFirstName = contactMessageDto.ContactMessageFirstName,
                ContactMessageLastName = contactMessageDto.ContactMessageLastName,
                ContactMessageMail = contactMessageDto.ContactMessageMail,
                ContactMessageSubject = contactMessageDto.ContactMessageSubject,
                ContactMessageText = contactMessageDto.ContactMessageText,
                LanguageId = contactMessageDto.LanguageId,
                Language = contactMessageDto.Language?.ToPivot(),
            };
        }

        /// <summary>
        ///    From ContactMessagepivot list To ContactMessage pivot list.
        /// </summary>
        /// <param name="contactMessageDtoList">contactMessage dto list to assemble.</param>
        /// <returns>ContactMessagePivot list result.</returns>
        public static List<ContactMessagePivot> ToPivotList(this List<ContactMessageDto> contactMessageDtoList)
        {
            return contactMessageDtoList?.Select(x => x?.ToPivot()).ToList();

        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From ContactMessage Request to ContactMessage Request pivot.
        /// </summary>
        /// <param name="contactMessageRequest"></param>
        /// <returns>ContactMessage Request pivot result.</returns>
        public static ContactMessageRequestPivot ToPivot(this ContactMessageRequest contactMessageRequest)
        {
            return new ContactMessageRequestPivot()
            {
                ContactMessagePivot = contactMessageRequest.ContactMessageDto?.ToPivot(),
                FindContactMessagePivot = Utility.EnumToEnum<FindContactMessageDto, FindContactMessagePivot>(contactMessageRequest.FindContactMessageDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From ContactMessage Response pivot to ContactMessage Message.
        /// </summary>
        /// <param name="contactMessageResponsePivot">ContactMessage Response pivot to assemble.</param>
        /// <returns>ContactMessage Message result.</returns>
        public static ContactMessageMessage ToMessage(this ContactMessageResponsePivot contactMessageResponsePivot)
        {
            if (contactMessageResponsePivot == null)
            {
                return null;
            }
            return new ContactMessageMessage()
            {
                ContactMessageDtoList = contactMessageResponsePivot.ContactMessagePivotList?.ToDtoList(),
                ContactMessageDto = contactMessageResponsePivot.ContactMessagePivot?.ToDto(),
            };
        }

        #endregion

    }
}