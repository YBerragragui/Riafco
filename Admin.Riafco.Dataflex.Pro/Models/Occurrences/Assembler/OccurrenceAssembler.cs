using Admin.Riafco.Dataflex.Pro.Models.Occurrences.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Occurrences.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Occurrences.RequestData;
using System;
using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.Occurrences.Assembler
{
    /// <summary>
    /// OccurrenceTranslationAssembler
    /// </summary>
    public static class OccurrenceAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static OccurrenceItemData ToItemData(this OccurrenceFormData formData)
        {
            if (formData == null)
            {
                return new OccurrenceItemData();
            }

            OccurrenceItemData itemData = new OccurrenceItemData
            {
                OccurrenceStartDate = new DateTime(int.Parse(formData.OccurrenceStartDate.Split('/')[2]),
                    int.Parse(formData.OccurrenceStartDate.Split('/')[1]),
                    int.Parse(formData.OccurrenceStartDate.Split('/')[0])),
                OccurrenceEndDate = new DateTime(int.Parse(formData.OccurrenceEndDate.Split('/')[2]),
                    int.Parse(formData.OccurrenceEndDate.Split('/')[1]),
                    int.Parse(formData.OccurrenceEndDate.Split('/')[0])),
                OccurrenceLink = formData.OccurrenceLink,
                OccurrenceId = formData.OccurrenceId
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROM DATA TO ITEM DATA.
        /// </summary>
        /// <param name="formData">the form data to convert.</param>
        /// <returns>the item data.</returns>
        public static OccurrenceTranslationItemData ToItemData(this OccurrenceTranslationFormData formData)
        {
            if (formData == null)
            {
                return new OccurrenceTranslationItemData();
            }

            return new OccurrenceTranslationItemData
            {
                OccurrenceDescription = formData.OccurrenceDescription,
                OccurrenceTitle = formData.OccurrenceTitle,
                TranslationId = formData.TranslationId,
                LanguageId = formData.LanguageId,
                OccurrenceId = formData.OccurrenceId
            };
        }

        /// <summary>
        /// FROM FROM DATA LIST TO ITEM DATA LIST.
        /// </summary>
        /// <param name="formDataList">the form data lit to convert.</param>
        /// <returns>the item data list.</returns>
        public static List<OccurrenceTranslationItemData> ToItemDataList(this List<OccurrenceTranslationFormData> formDataList)
        {
            List<OccurrenceTranslationItemData> itemDataList = new List<OccurrenceTranslationItemData>();
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
        public static OccurrenceFormData ToFormData(this OccurrenceItemData itemData)
        {
            if (itemData == null)
            {
                return new OccurrenceFormData();
            }

            OccurrenceFormData formData = new OccurrenceFormData
            {
                OccurrenceStartDate = itemData.OccurrenceStartDate.ToString("dd/MM/yyyy"),
                OccurrenceEndDate = itemData.OccurrenceEndDate.ToString("dd/MM/yyyy"),
                OccurrenceLink = itemData.OccurrenceLink,
                OccurrenceId = itemData.OccurrenceId
            };
            return formData;
        }

        /// <summary>
        /// FROM itemData TO FORM DATA.
        /// </summary>
        /// <param name="itemData"></param>
        /// <returns></returns>
        public static OccurrenceTranslationFormData ToFormData(this OccurrenceTranslationItemData itemData)
        {
            if (itemData == null)
            {
                return new OccurrenceTranslationFormData();
            }

            OccurrenceTranslationFormData formData = new OccurrenceTranslationFormData
            {
                OccurrenceDescription = itemData.OccurrenceDescription,
                LanguagePrefix = itemData.Language.LanguagePrefix,
                OccurrenceTitle = itemData.OccurrenceTitle,
                OccurrenceId = itemData.OccurrenceId ?? 0,
                TranslationId = itemData.TranslationId,
                LanguageId = itemData.LanguageId ?? 0
            };
            return formData;
        }

        /// <summary>
        /// FROM itemDataList TO OccurrenceTranslationFormDataList
        /// </summary>
        /// <param name="itemDataList">the itemDataList TO CONVERT</param>
        /// <returns>THE OccurrenceTranslationFormData list.</returns>
        public static List<OccurrenceTranslationFormData> ToFormDataList(this List<OccurrenceTranslationItemData> itemDataList)
        {
            List<OccurrenceTranslationFormData> formDataList = new List<OccurrenceTranslationFormData>();
            foreach (var itemData in itemDataList)
            {
                formDataList.Add(itemData.ToFormData());
            }
            return formDataList;
        }
        #endregion

        #region TO REQUEST DATA

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="occurrenceFormData"></param>
        /// <returns></returns>
        public static OccurrenceRequestData ToRequestData(this OccurrenceFormData occurrenceFormData)
        {
            if (occurrenceFormData == null)
            {
                return new OccurrenceRequestData();
            }
            return new OccurrenceRequestData
            {
                OccurrenceDto = occurrenceFormData.ToItemData()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUEST DATA
        /// </summary>
        /// <param name="occurrenceTranslationFormData">form data to convert</param>
        /// <returns></returns>
        public static OccurrenceTranslationRequestData ToRequestData(this OccurrenceTranslationFormData occurrenceTranslationFormData)
        {
            if (occurrenceTranslationFormData == null)
            {
                return new OccurrenceTranslationRequestData();
            }

            return new OccurrenceTranslationRequestData
            {
                OccurrenceTranslationDtoList = new List<OccurrenceTranslationItemData>(),
                OccurrenceTranslationDto = occurrenceTranslationFormData.ToItemData()
            };
        }
        #endregion
    }
}