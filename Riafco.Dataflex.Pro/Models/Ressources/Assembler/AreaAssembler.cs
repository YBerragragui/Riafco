using System.Collections.Generic;
using System.Linq;
using Riafco.Dataflex.Pro.Models.Ressources.FormData;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Dataflex.Pro.Models.Ressources.RequestData;

namespace Riafco.Dataflex.Pro.Models.Ressources.Assembler
{
    /// <summary>
    /// The AreaTranslationAssembler class.
    /// </summary>
    public static class AreaAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static AreaItemData ToItemData(this AreaFormData formData)
        {
            if (formData == null)
            {
                return new AreaItemData();
            }

            AreaItemData itemData = new AreaItemData
            {
                AreaId = formData.AreaId
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
        public static AreaFormData ToFormData(this AreaItemData itemData)
        {
            if (itemData == null)
            {
                return new AreaFormData();
            }

            AreaFormData formData = new AreaFormData
            {
                AreaId = itemData.AreaId
            };
            return formData;
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemDataList">the itemDataList to convert</param>
        /// <returns>the formdata result</returns>
        public static List<AreaFormData> ToFormDataList(this List<AreaItemData> itemDataList)
        {
            return itemDataList?.Select(themeItemData => themeItemData.ToFormData()).ToList() ?? new List<AreaFormData>();
        }

        /// <summary>
        /// From REQUESTDATA To FORMDATA
        /// </summary>
        /// <param name="authorRequestData"></param>
        /// <returns></returns>
        public static AreaFormData ToFormData(this AreaRequestData authorRequestData)
        {
            if (authorRequestData?.AreaDto == null)
            {
                return new AreaFormData();
            }
            return new AreaFormData
            {
                AreaId = authorRequestData.AreaDto.AreaId
            };
        }
        #endregion

        #region REQUEST DATA
        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="authorFormData"></param>
        /// <returns></returns>
        public static AreaRequestData ToRequestData(this AreaFormData authorFormData)
        {
            if (authorFormData == null)
            {
                return new AreaRequestData();
            }
            return new AreaRequestData
            {
                AreaDto = authorFormData.ToItemData()
            };
        }
        #endregion
    }
}