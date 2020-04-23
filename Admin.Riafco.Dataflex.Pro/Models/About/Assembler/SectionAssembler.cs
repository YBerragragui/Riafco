using Admin.Riafco.Dataflex.Pro.Models.About.FormData;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.About.RequestData;
using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.About.Assembler
{
    /// <summary>
    /// SectionTranslationAssembler
    /// </summary>
    public static class SectionAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static SectionItemData ToItemData(this SectionFormData formData)
        {
            if (formData == null)
            {
                return new SectionItemData();
            }

            SectionItemData itemData = new SectionItemData
            {
                SectionImage = formData.SectionImage?.FileName,
                SectionId = formData.SectionId
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROM DATA TO ITEM DATA.
        /// </summary>
        /// <param name="formData">the form data to convert.</param>
        /// <returns>the item data.</returns>
        public static SectionTranslationItemData ToItemData(this SectionTranslationFormData formData)
        {
            if (formData == null)
            {
                return new SectionTranslationItemData();
            }

            return new SectionTranslationItemData
            {
                SectionDesciption = formData.SectionDesciption,
                TranslationId = formData.TranslationId,
                SectionTitle = formData.SectionTitle,
                LanguageId = formData.LanguageId,
                SectionId = formData.SectionId
            };
        }

        /// <summary>
        /// FROM FROM DATA LIST TO ITEM DATA LIST.
        /// </summary>
        /// <param name="formDataList">the form data lit to convert.</param>
        /// <returns>the item data list.</returns>
        public static List<SectionTranslationItemData> ToItemDataList(this List<SectionTranslationFormData> formDataList)
        {
            List<SectionTranslationItemData> itemDataList = new List<SectionTranslationItemData>();
            foreach (var formData in formDataList)
            {
                itemDataList.Add(formData.ToItemData());
            }
            return itemDataList;
        }
        #endregion

        #region TO FORM DATA
        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static SectionFormData ToFormData(this SectionItemData itemData)
        {
            if (itemData == null)
            {
                return new SectionFormData();
            }

            SectionFormData formData = new SectionFormData
            {
                SectionId = itemData.SectionId
            };
            return formData;
        }

        /// <summary>
        /// FROM itemData TO FORM DATA.
        /// </summary>
        /// <param name="itemData"></param>
        /// <returns></returns>
        public static SectionTranslationFormData ToFormData(this SectionTranslationItemData itemData)
        {
            if (itemData == null)
            {
                return new SectionTranslationFormData();
            }

            SectionTranslationFormData formData = new SectionTranslationFormData
            {
                LanguagePrefix = itemData.Language.LanguagePrefix,
                SectionDesciption = itemData.SectionDesciption,
                TranslationId = itemData.TranslationId,
                LanguageId = itemData.LanguageId ?? 0,
                SectionTitle = itemData.SectionTitle,
                SectionId = itemData.SectionId ?? 0
            };
            return formData;
        }

        /// <summary>
        /// FROM itemDataList TO SectionTranslationFormDataList
        /// </summary>
        /// <param name="itemDataList">the itemDataList TO CONVERT</param>
        /// <returns>THE SectionTranslationFormData list.</returns>
        public static List<SectionTranslationFormData> ToFormDataList(this List<SectionTranslationItemData> itemDataList)
        {
            List<SectionTranslationFormData> formDataList = new List<SectionTranslationFormData>();
            foreach (var itemData in itemDataList)
            {
                formDataList.Add(itemData.ToFormData());
            }
            return formDataList;
        }
        #endregion

        #region REQUEST DATA

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="sectionFormData"></param>
        /// <returns></returns>
        public static SectionRequestData ToRequestData(this SectionFormData sectionFormData)
        {
            if (sectionFormData == null)
            {
                return new SectionRequestData();
            }
            return new SectionRequestData
            {
                SectionDto = sectionFormData.ToItemData()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUEST DATA
        /// </summary>
        /// <param name="sectionTranslationFormData">form data to convert</param>
        /// <returns></returns>
        public static SectionTranslationRequestData ToRequestData(this SectionTranslationFormData sectionTranslationFormData)
        {
            if (sectionTranslationFormData == null)
            {
                return new SectionTranslationRequestData();
            }

            return new SectionTranslationRequestData
            {
                SectionTranslationDtoList = new List<SectionTranslationItemData>(),
                SectionTranslationDto = sectionTranslationFormData.ToItemData()
            };
        }
        #endregion
    }
}