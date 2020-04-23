using System.Collections.Generic;
using System.Linq;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.RequestData;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.Assembler
{
    /// <summary>
    /// The PublicationThemeThemeAssembler class.
    /// </summary>
    public static class PublicationThemeThemeAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static PublicationThemeItemData ToItemData(this PublicationThemeFormData formData)
        {
            if (formData == null)
            {
                return new PublicationThemeItemData();
            }

            PublicationThemeItemData itemData = new PublicationThemeItemData
            {
                PublicationThemeId = formData.PublicationThemeId,
                PublicationId = formData.PublicationId,
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
        public static PublicationThemeFormData ToFormData(this PublicationThemeItemData itemData)
        {
            if (itemData == null)
            {
                return new PublicationThemeFormData();
            }

            PublicationThemeFormData formData = new PublicationThemeFormData
            {
                PublicationThemeId = itemData.PublicationThemeId,
                PublicationId = itemData.PublicationId,
                ThemeId = itemData.ThemeId
            };
            return formData;
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemDataList">the itemDataList to convert</param>
        /// <returns>the formdata result</returns>
        public static List<PublicationThemeFormData> ToFormDataList(this List<PublicationThemeItemData> itemDataList)
        {
            return itemDataList?.Select(publicationItemData => publicationItemData.ToFormData()).ToList() ?? new List<PublicationThemeFormData>();
        }

        /// <summary>
        /// From REQUESTDATA To FORMDATA
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public static PublicationThemeFormData ToFormData(this PublicationThemeRequestData requestData)
        {
            if (requestData?.PublicationThemeDto == null)
            {
                return new PublicationThemeFormData();
            }
            return new PublicationThemeFormData
            {
                PublicationThemeId = requestData.PublicationThemeDto.PublicationThemeId,
                PublicationId = requestData.PublicationThemeDto.PublicationId,
                ThemeId = requestData.PublicationThemeDto.ThemeId
            };
        }
        #endregion

        #region REQUEST DATA
        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static PublicationThemeRequestData ToRequestData(this PublicationThemeFormData formData)
        {
            if (formData == null)
            {
                return new PublicationThemeRequestData();
            }
            return new PublicationThemeRequestData
            {
                PublicationThemeDto = formData.ToItemData()
            };
        }
        #endregion
    }
}