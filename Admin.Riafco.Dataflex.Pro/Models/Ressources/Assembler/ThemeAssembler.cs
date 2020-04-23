using System.Collections.Generic;
using System.Linq;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.RequestData;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.Assembler
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

        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static ThemeTranslationItemData ToItemData(this ThemeTranslationFormData formData)
        {
            if (formData == null)
            {
                return new ThemeTranslationItemData();
            }

            ThemeTranslationItemData itemData = new ThemeTranslationItemData
            {
                TranslationId = formData.TranslationId,
                LanguageId = formData.LanguageId,
                ThemeName = formData.ThemeName,
                ThemeId = formData.ThemeId
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formDataList">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static List<ThemeTranslationItemData> ToItemDataList(this List<ThemeTranslationFormData> formDataList)
        {
            return formDataList?.Select(formData => formData.ToItemData()).ToList() ?? new List<ThemeTranslationItemData>();
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
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static ThemeTranslationFormData ToFormData(this ThemeTranslationItemData itemData)
        {
            if (itemData == null)
            {
                return new ThemeTranslationFormData();
            }

            ThemeTranslationFormData formData = new ThemeTranslationFormData
            {
                LanguagePrefix = itemData.Language.LanguagePrefix,
                TranslationId = itemData.TranslationId,
                LanguageId = itemData.LanguageId,
                ThemeName = itemData.ThemeName,
                ThemeId = itemData.ThemeId,
            };
            return formData;
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemDataList">the itemDataList to convert</param>
        /// <returns>the formdata result</returns>
        public static List<ThemeTranslationFormData> ToFormDataList(this List<ThemeTranslationItemData> itemDataList)
        {
            return itemDataList?.Select(themeTranslationItemData => themeTranslationItemData.ToFormData()).ToList() ?? new List<ThemeTranslationFormData>();
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

        /// <summary>
        /// From REQUESTDATA To FORMDATA
        /// </summary>
        /// <param name="authorRequestData"></param>
        /// <returns></returns>
        public static ThemeTranslationFormData ToFormData(this ThemeTranslationRequestData authorRequestData)
        {
            if (authorRequestData?.ThemeTranslationDto == null)
            {
                return new ThemeTranslationFormData();
            }
            return new ThemeTranslationFormData
            {
                TranslationId = authorRequestData.ThemeTranslationDto.TranslationId,
                LanguageId = authorRequestData.ThemeTranslationDto.LanguageId,
                ThemeName = authorRequestData.ThemeTranslationDto.ThemeName,
                ThemeId = authorRequestData.ThemeTranslationDto.ThemeId
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

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="authorFormData"></param>
        /// <returns></returns>
        public static ThemeTranslationRequestData ToRequestData(this ThemeTranslationFormData authorFormData)
        {
            if (authorFormData == null)
            {
                return new ThemeTranslationRequestData();
            }
            return new ThemeTranslationRequestData
            {
                ThemeTranslationDto = authorFormData.ToItemData(),
                ThemeTranslationDtoList = new List<ThemeTranslationItemData>()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="themeTranslationFormDataList">The authorFormDataList to assemble</param>
        /// <returns></returns>
        public static ThemeTranslationRequestData ToRequestData(this List<ThemeTranslationFormData> themeTranslationFormDataList)
        {
            if (themeTranslationFormDataList == null)
            {
                return new ThemeTranslationRequestData();
            }
            return new ThemeTranslationRequestData
            {
                ThemeTranslationDto = new ThemeTranslationItemData(),
                ThemeTranslationDtoList = themeTranslationFormDataList.ToItemDataList()
            };
        }
        #endregion
    }
}