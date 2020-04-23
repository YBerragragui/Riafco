using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.RequestData;
using Riafco.Framework.Dataflex.pro.Util;

namespace Admin.Riafco.Dataflex.Pro.Models.Newsletters.Assembler
{
    /// <summary>
    /// NewsletterMailTranslationAssembler
    /// </summary>
    public static class NewsletterMailAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static NewsletterMailItemData ToItemData(this NewsletterMailFormData formData)
        {
            if (formData == null)
            {
                return new NewsletterMailItemData();
            }

            NewsletterMailItemData itemData = new NewsletterMailItemData
            {
                NewsletterMailId = formData.NewsletterMailId
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROM DATA TO ITEM DATA.
        /// </summary>
        /// <param name="formData">the form data to convert.</param>
        /// <returns>the item data.</returns>
        public static NewsletterMailTranslationItemData ToItemData(this NewsletterMailTranslationFormData formData)
        {
            if (formData == null)
            {
                return new NewsletterMailTranslationItemData();
            }

            return new NewsletterMailTranslationItemData
            {
                NewsletterMailSubject= formData.NewsletterMailSubject,
                NewsletterMailSource = formData.NewsletterMailSource?.FileName,
                TranslationId = formData.TranslationId,
                LanguageId = formData.LanguageId,
                NewsletterMailId = formData.NewsletterMailId,
            };
        }

        /// <summary>
        /// FROM FROM DATA LIST TO ITEM DATA LIST.
        /// </summary>
        /// <param name="formDataList">the form data lit to convert.</param>
        /// <returns>the item data list.</returns>
        public static List<NewsletterMailTranslationItemData> ToItemDataList(this List<NewsletterMailTranslationFormData> formDataList)
        {
            List<NewsletterMailTranslationItemData> itemDataList = new List<NewsletterMailTranslationItemData>();
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
        public static NewsletterMailFormData ToFormData(this NewsletterMailItemData itemData)
        {
            if (itemData == null)
            {
                return new NewsletterMailFormData();
            }

            NewsletterMailFormData formData = new NewsletterMailFormData
            {
                NewsletterMailId = itemData.NewsletterMailId,
            };
            return formData;
        }

        /// <summary>
        /// FROM itemData TO FORM DATA.
        /// </summary>
        /// <param name="itemData"></param>
        /// <returns></returns>
        public static NewsletterMailTranslationFormData ToFormData(this NewsletterMailTranslationItemData itemData)
        {
            if (itemData == null)
            {
                return new NewsletterMailTranslationFormData();
            }

            NewsletterMailTranslationFormData formData = new NewsletterMailTranslationFormData
            {
                NewsletterMailSubject = itemData.NewsletterMailSubject,
                LanguagePrefix = itemData.Language.LanguagePrefix,
                TranslationId = itemData.TranslationId,
                LanguageId = itemData.LanguageId ?? 0,
                NewsletterMailId = itemData.NewsletterMailId ?? 0,
            };
            return formData;
        }

        /// <summary>
        /// FROM itemDataList TO NewsletterMailTranslationFormDataList
        /// </summary>
        /// <param name="itemDataList">the itemDataList TO CONVERT</param>
        /// <returns>THE NewsletterMailTranslationFormData list.</returns>
        public static List<NewsletterMailTranslationFormData> ToFormDataList(this List<NewsletterMailTranslationItemData> itemDataList)
        {
            List<NewsletterMailTranslationFormData> formDataList = new List<NewsletterMailTranslationFormData>();
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
        /// <param name="newsletterMailFormData"></param>
        /// <returns></returns>
        public static NewsletterMailRequestData ToRequestData(this NewsletterMailFormData newsletterMailFormData)
        {
            if (newsletterMailFormData == null)
            {
                return new NewsletterMailRequestData();
            }
            return new NewsletterMailRequestData
            {
                NewsletterMailDto = newsletterMailFormData.ToItemData()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUEST DATA
        /// </summary>
        /// <param name="newsletterMailTranslationFormData">form data to convert</param>
        /// <returns></returns>
        public static NewsletterMailTranslationRequestData ToRequestData(this NewsletterMailTranslationFormData newsletterMailTranslationFormData)
        {
            if (newsletterMailTranslationFormData == null)
            {
                return new NewsletterMailTranslationRequestData();
            }

            return new NewsletterMailTranslationRequestData
            {
                NewsletterMailTranslationDtoList = new List<NewsletterMailTranslationItemData>(),
                NewsletterMailTranslationDto = newsletterMailTranslationFormData.ToItemData(),
            };
        }
        #endregion
    }
}