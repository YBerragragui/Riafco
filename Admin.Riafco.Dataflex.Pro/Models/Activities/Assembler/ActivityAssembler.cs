using System.Collections.Generic;
using System.Linq;
using Admin.Riafco.Dataflex.Pro.Models.Activities.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.RequestData;
using Riafco.Framework.Dataflex.pro.Util;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.Assembler
{
    /// <summary>
    /// ActivityTranslationAssembler
    /// </summary>
    public static class ActivityAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static ActivityItemData ToItemData(this CreateActivityFormData formData)
        {
            if (formData == null)
            {
                return new ActivityItemData();
            }

            ActivityItemData itemData = new ActivityItemData
            {
                ActivityImage = formData.ActivityImage?.FileName,
                ActivityIcon = formData.ActivityIcon?.FileName,
                ActivityId = formData.ActivityId
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static ActivityItemData ToItemData(this UpdateActivityFormData formData)
        {
            if (formData == null)
            {
                return new ActivityItemData();
            }

            ActivityItemData itemData = new ActivityItemData
            {
                ActivityImage = formData.ActivityImage?.FileName,
                ActivityIcon = formData.ActivityIcon?.FileName,
                ActivityId = formData.ActivityId
            };
            return itemData;
        }

        /// <summary>
        /// FROM FROM DATA TO ITEM DATA.
        /// </summary>
        /// <param name="formData">the form data to convert.</param>
        /// <returns>the item data.</returns>
        public static ActivityTranslationItemData ToItemData(this ActivityTranslationFormData formData)
        {
            if (formData == null)
            {
                return new ActivityTranslationItemData();
            }

            return new ActivityTranslationItemData
            {
                ActivityIntroduction = formData.ActivityIntroduction,
                ActivityDescription = formData.ActivityDescription,
                ActivityTitle = formData.ActivityTitle,
                TranslationId = formData.TranslationId,
                LanguageId = formData.LanguageId,
                ActivityId = formData.ActivityId
            };
        }

        /// <summary>
        /// FROM FROM DATA LIST TO ITEM DATA LIST.
        /// </summary>
        /// <param name="formDataList">the form data lit to convert.</param>
        /// <returns>the item data list.</returns>
        public static List<ActivityTranslationItemData> ToItemDataList(this List<ActivityTranslationFormData> formDataList)
        {
            return formDataList?.Select(formData => formData.ToItemData()).ToList() ?? new List<ActivityTranslationItemData>();
        }
        #endregion

        #region TO FORM DATA
        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static CreateActivityFormData ToCreateFormData(this ActivityItemData itemData)
        {
            if (itemData == null) { return new CreateActivityFormData(); }
            CreateActivityFormData formData = new CreateActivityFormData { ActivityId = itemData.ActivityId };
            return formData;
        }

        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static UpdateActivityFormData ToUpdateFormData(this ActivityItemData itemData)
        {
            if (itemData == null) { return new UpdateActivityFormData(); }
            UpdateActivityFormData formData = new UpdateActivityFormData { ActivityId = itemData.ActivityId };
            return formData;
        }

        /// <summary>
        /// FROM itemData TO FORM DATA.
        /// </summary>
        /// <param name="itemData"></param>
        /// <returns></returns>
        public static ActivityTranslationFormData ToFormData(this ActivityTranslationItemData itemData)
        {
            if (itemData == null) { return new ActivityTranslationFormData(); }
            ActivityTranslationFormData formData = new ActivityTranslationFormData
            {
                ActivityIntroduction = itemData.ActivityIntroduction,
                ActivityDescription = itemData.ActivityDescription,
                LanguagePrefix = itemData.Language.LanguagePrefix,
                ActivityTitle = itemData.ActivityTitle,
                TranslationId = itemData.TranslationId,
                LanguageId = itemData.LanguageId ?? 0,
                ActivityId = itemData.ActivityId ?? 0
            };
            return formData;
        }

        /// <summary>
        /// FROM itemDataList TO ActivityTranslationFormDataList
        /// </summary>
        /// <param name="itemDataList">the itemDataList TO CONVERT</param>
        /// <returns>THE ActivityTranslationFormData list.</returns>
        public static List<ActivityTranslationFormData> ToFormDataList(this List<ActivityTranslationItemData> itemDataList)
        {
            List<ActivityTranslationFormData> formDataList = new List<ActivityTranslationFormData>();
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
        /// <param name="activityFormData"></param>
        /// <returns></returns>
        public static ActivityRequestData ToRequestData(this CreateActivityFormData activityFormData)
        {
            if (activityFormData == null)
            {
                return new ActivityRequestData();
            }
            return new ActivityRequestData
            {
                ActivityDto = activityFormData.ToItemData()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="activityFormData"></param>
        /// <returns></returns>
        public static ActivityRequestData ToRequestData(this UpdateActivityFormData activityFormData)
        {
            if (activityFormData == null)
            {
                return new ActivityRequestData();
            }
            return new ActivityRequestData
            {
                ActivityDto = activityFormData.ToItemData()
            };
        }

        /// <summary>
        /// From FORMDATA To REQUEST DATA
        /// </summary>
        /// <param name="activityTranslationFormData">form data to convert</param>
        /// <returns></returns>
        public static ActivityTranslationRequestData ToRequestData(this ActivityTranslationFormData activityTranslationFormData)
        {
            if (activityTranslationFormData == null)
            {
                return new ActivityTranslationRequestData();
            }

            return new ActivityTranslationRequestData
            {
                ActivityTranslationDtoList = new List<ActivityTranslationItemData>(),
                ActivityTranslationDto = activityTranslationFormData.ToItemData(),
            };
        }

        /// <summary>
        /// From FORMDATA To REQUEST DATA
        /// </summary>
        /// <param name="translationList">form data to convert</param>
        /// <returns></returns>
        public static ActivityTranslationRequestData ToRequestData(this List<ActivityTranslationFormData> translationList)
        {
            if (translationList == null)
            {
                return new ActivityTranslationRequestData();
            }

            return new ActivityTranslationRequestData
            {
                ActivityTranslationDtoList = translationList.ToItemDataList(),
                ActivityTranslationDto = new ActivityTranslationItemData()
            };
        }
        #endregion
    }
}