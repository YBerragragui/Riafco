using Admin.Riafco.Dataflex.Pro.Models.Newsletters.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.Newsletters.Assembler
{
    /// <summary>
    /// SubscriberTranslationAssembler
    /// </summary>
    public static class SubscriberAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static SubscriberItemData ToItemData(this SubscriberFormData formData)
        {
            if (formData == null)
            {
                return new SubscriberItemData();
            }

            SubscriberItemData itemData = new SubscriberItemData
            {
                SubscriberFirstName = formData.SubscriberFirstName,
                SubscriberLastName = formData.SubscriberLastName,
                SubscriberEmail = formData.SubscriberEmail,
                SubscriberId = formData.SubscriberId
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
        public static SubscriberFormData ToFormData(this SubscriberItemData itemData)
        {
            if (itemData == null)
            {
                return new SubscriberFormData();
            }

            SubscriberFormData formData = new SubscriberFormData
            {
                SubscriberId = itemData.SubscriberId,
                SubscriberEmail = itemData.SubscriberEmail,
                SubscriberLastName = itemData.SubscriberLastName,
                SubscriberFirstName = itemData.SubscriberFirstName,
            };
            return formData;
        }
        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="resultData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static SubscriberFormData ToFormData(this SubscriberResultData resultData)
        {
            if (resultData == null)
            {
                return new SubscriberFormData();
            }

            SubscriberFormData formData = new SubscriberFormData
            {
                SubscriberId = resultData.SubscriberDto.SubscriberId,
                SubscriberEmail = resultData.SubscriberDto.SubscriberEmail,
                SubscriberLastName = resultData.SubscriberDto.SubscriberLastName,
                SubscriberFirstName = resultData.SubscriberDto.SubscriberFirstName,
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
        public static SubscriberRequestData ToRequestData(this SubscriberFormData subscriberFormData)
        {
            if (subscriberFormData == null)
            {
                return new SubscriberRequestData();
            }
            return new SubscriberRequestData
            {
                SubscriberDto = subscriberFormData.ToItemData()
            };
        }
        #endregion
    }
}