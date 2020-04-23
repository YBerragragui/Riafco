using Admin.Riafco.Dataflex.Pro.Models.Activities.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.RequestData;
using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.Assembler
{
    /// <summary>
    /// The ActivityParagraphAssembler class.
    /// </summary>
    public static class ActivityFileAssembler
    {
        /// <summary>
        /// From ActivityFileFormData from ActivityFileItemData.
        /// </summary>
        /// <param name="activityFileFormData">the activityFileFormData to convert.</param>
        /// <returns>ActivityFileItemData result.</returns>
        public static ActivityFileItemData ToItemData(this CreateActivityFileFormData activityFileFormData)
        {
            if (activityFileFormData == null)
            {
                return new ActivityFileItemData();
            }
            return new ActivityFileItemData
            {
                ActivityFileId = activityFileFormData.ActivityFileId,
                ActivityId = activityFileFormData.ActivityId
            };
        }

        /// <summary>
        /// From ActivityFileFormData from ActivityFileItemData.
        /// </summary>
        /// <param name="activityFileFormData">the activityFileFormData to convert.</param>
        /// <returns>ActivityFileItemData result.</returns>
        public static ActivityFileItemData ToItemData(this UpdateActivityFileFormData activityFileFormData)
        {
            if (activityFileFormData == null)
            {
                return new ActivityFileItemData();
            }
            return new ActivityFileItemData
            {
                ActivityFileId = activityFileFormData.ActivityFileId,
                ActivityId = activityFileFormData.ActivityId
            };
        }

        /// <summary>
        /// From ActivityFileTranslationFormDataList to ActivityFileTranslationItemDataList.
        /// </summary>
        /// <param name="activityFileFormDataList">The activityFileFormDataList to convert.</param>
        /// <returns>ActivityFileTranslationItemDataList</returns>
        public static List<ActivityFileTranslationItemData> ToItemDataList(this List<CreateActivityFileTranslationFormData> activityFileFormDataList)
        {
            if (activityFileFormDataList == null)
            {
                return new List<ActivityFileTranslationItemData>();
            }

            List<ActivityFileTranslationItemData> activityFileTranslationItemDataList = new List<ActivityFileTranslationItemData>();
            foreach (var activityParagraphFormData in activityFileFormDataList)
            {
                activityFileTranslationItemDataList.Add(new ActivityFileTranslationItemData
                {
                    ActivityFileSource = activityParagraphFormData.ActivityFileSource?.FileName,
                    ActivityFileText = activityParagraphFormData.ActivityFileText,
                    ActivityFileId = activityParagraphFormData.ActivityFileId,
                    TranslationId = activityParagraphFormData.TranslationId,
                    LanguageId = activityParagraphFormData.LanguageId
                });
            }
            return activityFileTranslationItemDataList;
        }


        /// <summary>
        /// From ActivityFileTranslationFormDataList to ActivityFileTranslationItemDataList.
        /// </summary>
        /// <param name="activityFileFormDataList">The activityFileFormDataList to convert.</param>
        /// <returns>ActivityFileTranslationItemDataList</returns>
        public static List<ActivityFileTranslationItemData> ToItemDataList(this List<UpdateActivityFileTranslationFormData> activityFileFormDataList)
        {
            if (activityFileFormDataList == null)
            {
                return new List<ActivityFileTranslationItemData>();
            }

            List<ActivityFileTranslationItemData> activityFileTranslationItemDataList = new List<ActivityFileTranslationItemData>();
            foreach (var activityParagraphFormData in activityFileFormDataList)
            {
                activityFileTranslationItemDataList.Add(new ActivityFileTranslationItemData
                {
                    ActivityFileSource = activityParagraphFormData.ActivityFileSource?.FileName,
                    ActivityFileText = activityParagraphFormData.ActivityFileText,
                    ActivityFileId = activityParagraphFormData.ActivityFileId,
                    TranslationId = activityParagraphFormData.TranslationId,
                    LanguageId = activityParagraphFormData.LanguageId
                });
            }
            return activityFileTranslationItemDataList;
        }

        /// <summary>
        /// From ActivityParagraphFormData to ActivityParagraphRequestData
        /// </summary>
        /// <param name="activityFileFormData">the activityFileFormData to convert.</param>
        /// <returns>the ActivityFileRequestData result.</returns>
        public static ActivityFileRequestData ToRequestData(this CreateActivityFileFormData activityFileFormData)
        {
            if (activityFileFormData == null)
            {
                return new ActivityFileRequestData();
            }
            return new ActivityFileRequestData
            {
                ActivityFileDto = activityFileFormData.ToItemData()
            };
        }


        /// <summary>
        /// From ActivityParagraphFormData to ActivityParagraphRequestData
        /// </summary>
        /// <param name="activityFileFormData">the activityFileFormData to convert.</param>
        /// <returns>the ActivityFileRequestData result.</returns>
        public static ActivityFileRequestData ToRequestData(this UpdateActivityFileFormData activityFileFormData)
        {
            if (activityFileFormData == null)
            {
                return new ActivityFileRequestData();
            }
            return new ActivityFileRequestData
            {
                ActivityFileDto = activityFileFormData.ToItemData()
            };
        }
    }
}