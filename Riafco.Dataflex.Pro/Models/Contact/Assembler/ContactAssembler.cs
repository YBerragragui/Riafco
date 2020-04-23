using Riafco.Dataflex.Pro.Models.Contact.FormData;
using Riafco.Dataflex.Pro.Models.Contact.ItemData;
using Riafco.Dataflex.Pro.Models.Contact.RequestData;
using Riafco.Dataflex.Pro.Models.Contact.ResultData;

namespace Riafco.Dataflex.Pro.Models.Contact.Assembler
{
    /// <summary>
    /// PartnerTranslationAssembler
    /// </summary>
    public static class ContactAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static ContactItemData ToItemData(this ContactFormData formData)
        {
            if (formData == null)
            {
                return new ContactItemData();
            }

            ContactItemData itemData = new ContactItemData
            {
                ContactMessageFirstName = formData.ContactMessageFullName,
                ContactMessageLastName = formData.ContactMessageFullName,
                ContactMessageMail = formData.ContactMessageMail,
                ContactMessageSubject = formData.ContactMessageSubject,
                ContactMessageText = formData.ContactMessageText,
            };
            return itemData;
        }
        #endregion

        #region TO FORM DATA
        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static ContactFormData ToFormData(this ContactItemData itemData)
        {
            if (itemData == null)
            {
                return new ContactFormData();
            }

            ContactFormData formData = new ContactFormData
            {
                ContactMessageFullName = itemData.ContactMessageFirstName,
                ContactMessageSubject = itemData.ContactMessageSubject,
                ContactMessageText = itemData.ContactMessageText,
                ContactMessageMail = itemData.ContactMessageMail
            };
            return formData;
        }
        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="resultData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static ContactFormData ToFormData(this ContactResultData resultData)
        {
            if (resultData == null)
            {
                return new ContactFormData();
            }

            ContactFormData formData = new ContactFormData
            {
                ContactMessageText = resultData.ContactrDto.ContactMessageText,
                ContactMessageMail = resultData.ContactrDto.ContactMessageMail,
                ContactMessageSubject = resultData.ContactrDto.ContactMessageSubject,
                ContactMessageFullName = resultData.ContactrDto.ContactMessageFirstName
            };
            return formData;
        }
        #endregion

        #region REQUEST DATA

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="subscriberFormData"></param>
        /// <returns></returns>
        public static ContactRequestData ToRequestData(this ContactFormData subscriberFormData)
        {
            if (subscriberFormData == null)
            {
                return new ContactRequestData();
            }
            return new ContactRequestData
            {
                ContactDto = subscriberFormData.ToItemData()
            };
        }
        #endregion
    }
}