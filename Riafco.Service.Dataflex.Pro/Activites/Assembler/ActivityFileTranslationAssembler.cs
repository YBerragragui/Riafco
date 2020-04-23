using Riafco.Entity.Dataflex.Pro.Activites;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;

namespace Riafco.Service.Dataflex.Pro.Activites.Assembler
{
    /// <summary>
    /// The ActivityFileTranslation assembler class.
    /// </summary>
    public static class ActivityFileTranslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From ActivityFileTranslation To ActivityFileTranslation Pivot.
        /// </summary>
        /// <param name="activityFileTranslation">activityFileTranslation TO ASSEMBLE</param>
        /// <returns>ActivityFileTranslationPivot result.</returns>
        public static ActivityFileTranslationPivot ToPivot(this ActivityFileTranslation activityFileTranslation)
        {
            if (activityFileTranslation == null)
            {
                return null;
            }
            return new ActivityFileTranslationPivot
            {
                ActivityFileSource = activityFileTranslation.ActivityFileSource,
                ActivityFile = activityFileTranslation.ActivityFile?.ToPivot(),
                ActivityFileText = activityFileTranslation.ActivityFileText,
                ActivityFileId = activityFileTranslation.ActivityFileId,
                Language = activityFileTranslation.Language?.ToPivot(),
                TranslationId = activityFileTranslation.TranslationId,
                LanguageId = activityFileTranslation.LanguageId
            };
        }

        /// <summary>
        /// From ActivityFileTranslation list to ActivityFileTranslation pivot list.
        /// </summary>
        /// <param name="activityFileTranslationList">activityFileTranslationList to assemble.</param>
        /// <returns>list of ActivityFileTranslationPivot result.</returns>
        public static List<ActivityFileTranslationPivot> ToPivotList(this List<ActivityFileTranslation> activityFileTranslationList)
        {
            return activityFileTranslationList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From ActivityFileTranslationPivot to ActivityFileTranslation.
        /// </summary>
        /// <param name="activityFileTranslationPivot">activityFileTranslationPivot to assemble.</param>
        /// <returns>ActivityFileTranslation result.</returns>
        public static ActivityFileTranslation ToEntity(this ActivityFileTranslationPivot activityFileTranslationPivot)
        {
            if (activityFileTranslationPivot == null)
            {
                return null;
            }
            return new ActivityFileTranslation
            {
                ActivityFile = activityFileTranslationPivot.ActivityFile?.ToEntity(),
                ActivityFileSource = activityFileTranslationPivot.ActivityFileSource,
                ActivityFileText = activityFileTranslationPivot.ActivityFileText,
                ActivityFileId = activityFileTranslationPivot.ActivityFileId,
                Language = activityFileTranslationPivot.Language?.ToEntity(),
                TranslationId = activityFileTranslationPivot.TranslationId,
                LanguageId = activityFileTranslationPivot.LanguageId
            };
        }

        /// <summary>
        /// From ActivityFileTranslationPivotList to ActivityFileTranslationList.
        /// </summary>
        /// <param name="activityFileTranslationPivotList">ActivityFileTranslationPivotList to assemble.</param>
        /// <returns> list of ActivityFileTranslation result.</returns>
        public static List<ActivityFileTranslation> ToEntityList(this List<ActivityFileTranslationPivot> activityFileTranslationPivotList)
        {
            return activityFileTranslationPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}