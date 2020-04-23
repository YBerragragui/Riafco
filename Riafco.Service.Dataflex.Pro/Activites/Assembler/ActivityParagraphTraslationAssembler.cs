using Riafco.Entity.Dataflex.Pro.Activites;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;

namespace Riafco.Service.Dataflex.Pro.Activites.Assembler
{
    /// <summary>
    /// The ActivityParagraphTraslation assembler class.
    /// </summary>
    public static class ActivityParagraphTraslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From ActivityParagraphTraslation To ActivityParagraphTraslation Pivot.
        /// </summary>
        /// <param name="activityParagraphTraslation">activityParagraphTraslation TO ASSEMBLE</param>
        /// <returns>ActivityParagraphTranslationPivot result.</returns>
        public static ActivityParagraphTranslationPivot ToPivot(this ActivityParagraphTranslation activityParagraphTraslation)
        {
            if (activityParagraphTraslation == null)
            {
                return null;
            }
            return new ActivityParagraphTranslationPivot
            {
                ActivityParagraph = activityParagraphTraslation.ActivityParagraph?.ToPivot(),
                ParagraphDescription = activityParagraphTraslation.ParagraphDescription,
                ParagraphTitle = activityParagraphTraslation.ParagraphTitle,
                Language = activityParagraphTraslation.Language?.ToPivot(),
                TranslationId = activityParagraphTraslation.TranslationId,
                ParagraphId = activityParagraphTraslation.ParagraphId,
                LanguageId = activityParagraphTraslation.LanguageId
            };
        }

        /// <summary>
        /// From ActivityParagraphTraslation list to ActivityParagraphTraslation pivot list.
        /// </summary>
        /// <param name="activityParagraphTraslationList">activityParagraphTraslationList to assemble.</param>
        /// <returns>list of ActivityParagraphTranslationPivot result.</returns>
        public static List<ActivityParagraphTranslationPivot> ToPivotList(this List<ActivityParagraphTranslation> activityParagraphTraslationList)
        {
            return activityParagraphTraslationList?.Select(x => x?.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From ActivityParagraphTranslationPivot to ActivityParagraphTraslation.
        /// </summary>
        /// <param name="activityParagraphTraslationPivot">activityParagraphTraslationPivot to assemble.</param>
        /// <returns>ActivityParagraphTraslation result.</returns>
        public static ActivityParagraphTranslation ToEntity(this ActivityParagraphTranslationPivot activityParagraphTraslationPivot)
        {
            if (activityParagraphTraslationPivot == null)
            {
                return null;
            }
            return new ActivityParagraphTranslation
            {
                ActivityParagraph = activityParagraphTraslationPivot.ActivityParagraph?.ToEntity(),
                ParagraphDescription = activityParagraphTraslationPivot.ParagraphDescription,
                Language = activityParagraphTraslationPivot.Language?.ToEntity(),
                ParagraphTitle = activityParagraphTraslationPivot.ParagraphTitle,
                TranslationId = activityParagraphTraslationPivot.TranslationId,
                ParagraphId = activityParagraphTraslationPivot.ParagraphId,
                LanguageId = activityParagraphTraslationPivot.LanguageId
            };
        }

        /// <summary>
        /// From ActivityParagraphTranslationPivotList to ActivityParagraphTraslationList .
        /// </summary>
        /// <param name="activityParagraphTraslationPivotList">ActivityParagraphTranslationPivotList to assemble.</param>
        /// <returns> list of ActivityParagraphTraslation result.</returns>
        public static List<ActivityParagraphTranslation> ToEntityList(this List<ActivityParagraphTranslationPivot> activityParagraphTraslationPivotList)
        {
            return activityParagraphTraslationPivotList?.Select(x => x?.ToEntity()).ToList();
        }
        #endregion
    }
}