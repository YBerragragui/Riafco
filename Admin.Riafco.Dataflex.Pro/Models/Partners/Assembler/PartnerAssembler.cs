using Admin.Riafco.Dataflex.Pro.Models.Partners.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Partners.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Partners.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Partners.ResultData;
using Riafco.Framework.Dataflex.pro.Util;

namespace Admin.Riafco.Dataflex.Pro.Models.Partners.Assembler
{
    /// <summary>
    /// PartnerTranslationAssembler
    /// </summary>
    public static class PartnerAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static PartnerItemData ToItemData(this PartnerFormData formData)
        {
            if (formData == null)
            {
                return new PartnerItemData();
            }

            PartnerItemData itemData = new PartnerItemData
            {
                PartnerPosition = formData.PartnerPosition,
                PartnerLink = formData.PartnerLink,
                PartnerName = formData.PartnerName,
                PartnerImage = formData.PartnerImage?.FileName,
                PartnerId = formData.PartnerId
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
        public static PartnerFormData ToFormData(this PartnerItemData itemData)
        {
            if (itemData == null)
            {
                return new PartnerFormData();
            }

            PartnerFormData formData = new PartnerFormData
            {
                PartnerId = itemData.PartnerId,
                PartnerPosition = itemData.PartnerPosition,
                PartnerLink = itemData.PartnerLink,
                PartnerName = itemData.PartnerName,
            };
            return formData;
        }
        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="resultData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static PartnerFormData ToFormData(this PartnerResultData resultData)
        {
            if (resultData == null)
            {
                return new PartnerFormData();
            }

            PartnerFormData formData = new PartnerFormData
            {
                PartnerId = resultData.PartnerDto.PartnerId,
                PartnerPosition = resultData.PartnerDto.PartnerPosition,
                PartnerLink = resultData.PartnerDto.PartnerLink,
                PartnerName = resultData.PartnerDto.PartnerName,
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
        public static PartnerRequestData ToRequestData(this PartnerFormData subscriberFormData)
        {
            if (subscriberFormData == null)
            {
                return new PartnerRequestData();
            }
            return new PartnerRequestData
            {
                PartnerDto = subscriberFormData.ToItemData()
            };
        }
        #endregion
    }
}