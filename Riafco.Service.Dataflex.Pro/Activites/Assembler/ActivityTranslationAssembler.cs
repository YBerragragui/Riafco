using Riafco.Entity.Dataflex.Pro.Activites;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Activites.Assembler
{
    /// <summary>
    /// The ActivityTranslation assembler class.
    /// </summary>
    public static class ActivityTranslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From ActivityTranslation To ActivityTranslation Pivot.
        /// </summary>
        /// <param name="activityTranslation">activityTranslation TO ASSEMBLE</param>
        /// <returns>ActivityTranslationPivot result.</returns>
        public static ActivityTranslationPivot ToPivot(this ActivityTranslation activityTranslation)
        {
            if (activityTranslation == null)
            {
                return null;
            }
            return new ActivityTranslationPivot
            {
                ActivityIntroduction = activityTranslation.ActivityIntroduction,
                ActivityDescription = activityTranslation.ActivityDescription,
                ActivityTitle = activityTranslation.ActivityTitle,
                Language = activityTranslation.Language.ToPivot(),
                Activity = activityTranslation.Activity.ToPivot(),
                TranslationId = activityTranslation.TranslationId,
                LanguageId = activityTranslation.LanguageId,
                ActivityId = activityTranslation.ActivityId
            };
        }

        /// <summary>
        /// From ActivityTranslation list to ActivityTranslation pivot list.
        /// </summary>
        /// <param name="activityTranslationList">activityTranslationList to assemble.</param>
        /// <returns>list of ActivityTranslationPivot result.</returns>
        public static List<ActivityTranslationPivot> ToPivotList(this List<ActivityTranslation> activityTranslationList)
        {
            return activityTranslationList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From ActivityTranslationPivot to ActivityTranslation.
        /// </summary>
        /// <param name="activityTranslationPivot">activityTranslationPivot to assemble.</param>
        /// <returns>ActivityTranslation result.</returns>
        public static ActivityTranslation ToEntity(this ActivityTranslationPivot activityTranslationPivot)
        {
            if (activityTranslationPivot == null)
            {
                return null;
            }
            return new ActivityTranslation
            {
                ActivityIntroduction = activityTranslationPivot.ActivityIntroduction,
                ActivityDescription = activityTranslationPivot.ActivityDescription,
                Language = activityTranslationPivot.Language.ToEntity(),
                Activity = activityTranslationPivot.Activity.ToEntity(),
                ActivityTitle = activityTranslationPivot.ActivityTitle,
                TranslationId = activityTranslationPivot.TranslationId,
                LanguageId = activityTranslationPivot.LanguageId,
                ActivityId = activityTranslationPivot.ActivityId
            };
        }

        /// <summary>
        /// From ActivityTranslationPivotList to ActivityTranslationList .
        /// </summary>
        /// <param name="activityTranslationPivotList">ActivityTranslationPivotList to assemble.</param>
        /// <returns> list of ActivityTranslation result.</returns>
        public static List<ActivityTranslation> ToEntityList(this List<ActivityTranslationPivot> activityTranslationPivotList)
        {
            return activityTranslationPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}