using Admin.Riafco.Dataflex.Pro.Models.News.FormData;
using Admin.Riafco.Dataflex.Pro.Models.News.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.News.RequestData;
using System;
using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.News.Assembler
{
    /// <summary>
    /// NewsTranslationAssembler
    /// </summary>
    public static class NewsAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static NewsItemData ToItemData(this NewsFormData formData)
        {
            if (formData == null)
            {
                return new NewsItemData();
            }

            NewsItemData itemData = new NewsItemData
            {
                NewsImage = formData.NewsImage?.FileName,
                NewsId = formData.NewsId,
                NewsDate = new DateTime(int.Parse(formData.NewsDate.Split('/')[2]),
                    int.Parse(formData.NewsDate.Split('/')[1]), int.Parse(formData.NewsDate.Split('/')[0]))
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROM DATA TO ITEM DATA.
        /// </summary>
        /// <param name="formData">the form data to convert.</param>
        /// <returns>the item data.</returns>
        public static NewsTranslationItemData ToItemData(this NewsTranslationFormData formData)
        {
            if (formData == null)
            {
                return new NewsTranslationItemData();
            }

            return new NewsTranslationItemData
            {
                NewsSummary = formData.NewsSummary,
                NewsDescription = formData.NewsDescription,
                NewsTitle = formData.NewsTitle,
                TranslationId = formData.TranslationId,
                LanguageId = formData.LanguageId,
                NewsId = formData.NewsId,
            };
        }

        /// <summary>
        /// FROM FROM DATA LIST TO ITEM DATA LIST.
        /// </summary>
        /// <param name="formDataList">the form data lit to convert.</param>
        /// <returns>the item data list.</returns>
        public static List<NewsTranslationItemData> ToItemDataList(this List<NewsTranslationFormData> formDataList)
        {
            List<NewsTranslationItemData> itemDataList = new List<NewsTranslationItemData>();
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
        public static NewsFormData ToFormData(this NewsItemData itemData)
        {
            if (itemData == null)
            {
                return new NewsFormData();
            }

            NewsFormData formData = new NewsFormData
            {
                NewsId = itemData.NewsId,
                NewsDate = itemData.NewsDate.ToString("dd/MM/yyyy")
            };
            return formData;
        }

        /// <summary>
        /// FROM itemData TO FORM DATA.
        /// </summary>
        /// <param name="itemData"></param>
        /// <returns></returns>
        public static NewsTranslationFormData ToFormData(this NewsTranslationItemData itemData)
        {
            if (itemData == null)
            {
                return new NewsTranslationFormData();
            }

            NewsTranslationFormData formData = new NewsTranslationFormData
            {
                NewsSummary = itemData.NewsSummary,
                NewsDescription = itemData.NewsDescription,
                LanguagePrefix = itemData.Language.LanguagePrefix,
                NewsTitle = itemData.NewsTitle,
                TranslationId = itemData.TranslationId,
                LanguageId = itemData.LanguageId ?? 0,
                NewsId = itemData.NewsId ?? 0
            };
            return formData;
        }

        /// <summary>
        /// FROM itemDataList TO NewsTranslationFormDataList
        /// </summary>
        /// <param name="itemDataList">the itemDataList TO CONVERT</param>
        /// <returns>THE NewsTranslationFormData list.</returns>
        public static List<NewsTranslationFormData> ToFormDataList(this List<NewsTranslationItemData> itemDataList)
        {
            List<NewsTranslationFormData> formDataList = new List<NewsTranslationFormData>();
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
        /// <param name="newsFormData"></param>
        /// <returns></returns>
        public static NewsRequestData ToRequestData(this NewsFormData newsFormData)
        {
            if (newsFormData == null)
            {
                return new NewsRequestData();
            }
            return new NewsRequestData
            {
                NewsDto = newsFormData.ToItemData()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUEST DATA
        /// </summary>
        /// <param name="newsTranslationFormData">form data to convert</param>
        /// <returns></returns>
        public static NewsTranslationRequestData ToRequestData(this NewsTranslationFormData newsTranslationFormData)
        {
            if (newsTranslationFormData == null)
            {
                return new NewsTranslationRequestData();
            }

            return new NewsTranslationRequestData
            {
                NewsTranslationDtoList = new List<NewsTranslationItemData>(),
                NewsTranslationDto = newsTranslationFormData.ToItemData(),
            };
        }
        #endregion
    }
}