using System.Collections.Generic;
using System.Linq;
using Riafco.Dataflex.Pro.Models.Ressources.FormData;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Dataflex.Pro.Models.Ressources.RequestData;

namespace Riafco.Dataflex.Pro.Models.Ressources.Assembler
{
    /// <summary>
    /// The ThemeTranslationAssembler class.
    /// </summary>
    public static class ThemeAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static ThemeItemData ToItemData(this ThemeFormData formData)
        {
            if (formData == null)
            {
                return new ThemeItemData();
            }

            ThemeItemData itemData = new ThemeItemData
            {
                ThemeId = formData.ThemeId
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
        public static ThemeFormData ToFormData(this ThemeItemData itemData)
        {
            if (itemData == null)
            {
                return new ThemeFormData();
            }

            ThemeFormData formData = new ThemeFormData
            {
                ThemeId = itemData.ThemeId
            };
            return formData;
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemDataList">the itemDataList to convert</param>
        /// <returns>the formdata result</returns>
        public static List<ThemeFormData> ToFormDataList(this List<ThemeItemData> itemDataList)
        {
            return itemDataList?.Select(themeItemData => themeItemData.ToFormData()).ToList() ?? new List<ThemeFormData>();
        }

        /// <summary>
        /// From REQUESTDATA To FORMDATA
        /// </summary>
        /// <param name="authorRequestData"></param>
        /// <returns></returns>
        public static ThemeFormData ToFormData(this ThemeRequestData authorRequestData)
        {
            if (authorRequestData?.ThemeDto == null)
            {
                return new ThemeFormData();
            }
            return new ThemeFormData
            {
                ThemeId = authorRequestData.ThemeDto.ThemeId
            };
        }
        #endregion

        #region REQUEST DATA
        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="authorFormData"></param>
        /// <returns></returns>
        public static ThemeRequestData ToRequestData(this ThemeFormData authorFormData)
        {
            if (authorFormData == null)
            {
                return new ThemeRequestData();
            }
            return new ThemeRequestData
            {
                ThemeDto = authorFormData.ToItemData()
            };
        }
        #endregion
    }
}