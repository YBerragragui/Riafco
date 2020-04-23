using Admin.Riafco.Dataflex.Pro.Models.Activities.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.RequestData;
using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.Assembler
{
    /// <summary>
    /// The ActivityParagraphAssembler class.
    /// </summary>
    public static class ActivityParagraphAssembler
    {
        /// <summary>
        /// From ActivityParagraphTranslationFormData to ActivityParagraphTranslationItemData.
        /// </summary>
        /// <param name="activityParagraphFormDataList">activityParagraphFormDataList to convert.</param>
        /// <returns>ActivityParagraphTranslationItemData list</returns>
        public static List<ActivityParagraphTranslationItemData> ToItemDataList(this List<ActivityParagraphTranslationFormData> activityParagraphFormDataList)
        {
            if (activityParagraphFormDataList == null)
            {
                return new List<ActivityParagraphTranslationItemData>();
            }

            List<ActivityParagraphTranslationItemData> activityParagraphTranslationItemDataList = new List<ActivityParagraphTranslationItemData>();
            foreach (var activityParagraphFormData in activityParagraphFormDataList)
            {
                activityParagraphTranslationItemDataList.Add(new ActivityParagraphTranslationItemData
                {
                    ParagraphDescription = activityParagraphFormData.ParagraphDescription,
                    ParagraphTitle = activityParagraphFormData.ParagraphTitle,
                    TranslationId = activityParagraphFormData.TranslationId,
                    ParagraphId = activityParagraphFormData.ParagraphId,
                    LanguageId = activityParagraphFormData.LanguageId
                });
            }
            return activityParagraphTranslationItemDataList;
        }

        public static ActivityParagraphItemData ToItemData(this ActivityParagraphFormData activityParagraphFormData)
        {
            if (activityParagraphFormData == null)
            {
                return new ActivityParagraphItemData();
            }
            return new ActivityParagraphItemData
            {
                TranslationItemDataList = activityParagraphFormData.TranslationsList.ToItemDataList(),
                ParagraphImage = activityParagraphFormData.ParagraphImage?.FileName,
                ParagraphId = activityParagraphFormData.ParagraphId,
                ActivityId = activityParagraphFormData.ActivityId
            };
        }

        /// <summary>
        /// From ActivityParagraphFormData to ActivityParagraphRequestData
        /// </summary>
        /// <param name="activityParagraphFormData"></param>
        /// <returns></returns>
        public static ActivityParagraphRequestData ToRequestData(this ActivityParagraphFormData activityParagraphFormData)
        {
            if (activityParagraphFormData == null)
            {
                return new ActivityParagraphRequestData();
            }
            return new ActivityParagraphRequestData
            {
                ActivityParagraphDto = activityParagraphFormData.ToItemData()
            };
        }
    }
}