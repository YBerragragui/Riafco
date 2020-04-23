using Riafco.Entity.Dataflex.Pro.Contact;
using Riafco.Service.Dataflex.Pro.Contact.Data;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;

namespace Riafco.Service.Dataflex.Pro.Contact.Assembler
{
    /// <summary>
    /// The ContactMessage assembler class.
    /// </summary>
    public static class ContactMessageAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From ContactMessage To ContactMessage Pivot.
        /// </summary>
        /// <param name="contactMessage">contactMessage TO ASSEMBLE</param>
        /// <returns>ContactMessagePivot result.</returns>
        public static ContactMessagePivot ToPivot(this ContactMessage contactMessage)
        {
            if (contactMessage == null)
            {
                return null;
            }
            return new ContactMessagePivot
            {
                ContactMessageId = contactMessage.ContactMessageId,
                ContactMessageFirstName = contactMessage.ContactMessageFirstName,
                ContactMessageLastName = contactMessage.ContactMessageLastName,
                ContactMessageMail = contactMessage.ContactMessageMail,
                ContactMessageSubject = contactMessage.ContactMessageSubject,
                ContactMessageText = contactMessage.ContactMessageText,
                LanguageId = contactMessage.LanguageId,
                Language = contactMessage.Language?.ToPivot(),
            };
        }

        /// <summary>
        /// From ContactMessage list to ContactMessage pivot list.
        /// </summary>
        /// <param name="contactMessageList">contactMessageList to assemble.</param>
        /// <returns>list of ContactMessagePivot result.</returns>
        public static List<ContactMessagePivot> ToPivotList(this List<ContactMessage> contactMessageList)
        {
            return contactMessageList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From ContactMessagePivot to ContactMessage.
        /// </summary>
        /// <param name="contactMessagePivot">contactMessagePivot to assemble.</param>
        /// <returns>ContactMessage result.</returns>
        public static ContactMessage ToEntity(this ContactMessagePivot contactMessagePivot)
        {
            if (contactMessagePivot == null)
            {
                return null;
            }
            return new ContactMessage
            {
                ContactMessageId = contactMessagePivot.ContactMessageId,
                ContactMessageFirstName = contactMessagePivot.ContactMessageFirstName,
                ContactMessageLastName = contactMessagePivot.ContactMessageLastName,
                ContactMessageMail = contactMessagePivot.ContactMessageMail,
                ContactMessageSubject = contactMessagePivot.ContactMessageSubject,
                ContactMessageText = contactMessagePivot.ContactMessageText,
                LanguageId = contactMessagePivot.LanguageId,
                Language = contactMessagePivot.Language?.ToEntity(),
            };
        }

        /// <summary>
        /// From ContactMessagePivotList to ContactMessageList .
        /// </summary>
        /// <param name="contactMessagePivotList">ContactMessagePivotList to assemble.</param>
        /// <returns> list of ContactMessage result.</returns>
        public static List<ContactMessage> ToEntityList(this List<ContactMessagePivot> contactMessagePivotList)
        {
            return contactMessagePivotList?.Select(x => x?.ToEntity()).ToList();

        }
        #endregion
    }
}