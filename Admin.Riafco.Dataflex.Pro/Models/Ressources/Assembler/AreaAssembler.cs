using System.Collections.Generic;
using System.Linq;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.RequestData;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.Assembler
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

        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static AreaTranslationItemData ToItemData(this AreaTranslationFormData formData)
        {
            if (formData == null)
            {
                return new AreaTranslationItemData();
            }

            AreaTranslationItemData itemData = new AreaTranslationItemData
            {
                TranslationId = formData.TranslationId,
                LanguageId = formData.LanguageId,
                AreaName = formData.AreaName,
                AreaId = formData.AreaId
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formDataList">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static List<AreaTranslationItemData> ToItemDataList(this List<AreaTranslationFormData> formDataList)
        {
            return formDataList?.Select(formData => formData.ToItemData()).ToList() ?? new List<AreaTranslationItemData>();
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
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static AreaTranslationFormData ToFormData(this AreaTranslationItemData itemData)
        {
            if (itemData == null)
            {
                return new AreaTranslationFormData();
            }

            AreaTranslationFormData formData = new AreaTranslationFormData
            {
                LanguagePrefix = itemData.Language.LanguagePrefix,
                TranslationId = itemData.TranslationId,
                LanguageId = itemData.LanguageId,
                AreaName = itemData.AreaName,
                AreaId = itemData.AreaId
            };
            return formData;
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemDataList">the itemDataList to convert</param>
        /// <returns>the formdata result</returns>
        public static List<AreaTranslationFormData> ToFormDataList(this List<AreaTranslationItemData> itemDataList)
        {
            return itemDataList?.Select(themeTranslationItemData => themeTranslationItemData.ToFormData()).ToList() ?? new List<AreaTranslationFormData>();
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

        /// <summary>
        /// From REQUESTDATA To FORMDATA
        /// </summary>
        /// <param name="authorRequestData"></param>
        /// <returns></returns>
        public static AreaTranslationFormData ToFormData(this AreaTranslationRequestData authorRequestData)
        {
            if (authorRequestData?.AreaTranslationDto == null)
            {
                return new AreaTranslationFormData();
            }
            return new AreaTranslationFormData
            {
                TranslationId = authorRequestData.AreaTranslationDto.TranslationId,
                LanguageId = authorRequestData.AreaTranslationDto.LanguageId,
                AreaName = authorRequestData.AreaTranslationDto.AreaName,
                AreaId = authorRequestData.AreaTranslationDto.AreaId
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

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="authorFormData"></param>
        /// <returns></returns>
        public static AreaTranslationRequestData ToRequestData(this AreaTranslationFormData authorFormData)
        {
            if (authorFormData == null)
            {
                return new AreaTranslationRequestData();
            }
            return new AreaTranslationRequestData
            {
                AreaTranslationDto = authorFormData.ToItemData(),
                AreaTranslationDtoList = new List<AreaTranslationItemData>()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="themeTranslationFormDataList">The authorFormDataList to assemble</param>
        /// <returns></returns>
        public static AreaTranslationRequestData ToRequestData(this List<AreaTranslationFormData> themeTranslationFormDataList)
        {
            if (themeTranslationFormDataList == null)
            {
                return new AreaTranslationRequestData();
            }
            return new AreaTranslationRequestData
            {
                AreaTranslationDto = new AreaTranslationItemData(),
                AreaTranslationDtoList = themeTranslationFormDataList.ToItemDataList()
            };
        }
        #endregion
    }
}