using Riafco.Entity.Dataflex.Pro.Activites;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Activites.Assembler
{
    /// <summary>
    /// The ActivityParagraph assembler class.
    /// </summary>
    public static class ActivityParagraphAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From ActivityParagraph To ActivityParagraph Pivot.
        /// </summary>
        /// <param name="activityParagraph">activityParagraph TO ASSEMBLE</param>
        /// <returns>ActivityParagraphPivot result.</returns>
        public static ActivityParagraphPivot ToPivot(this ActivityParagraph activityParagraph)
        {
            if (activityParagraph == null)
            {
                return null;
            }
            return new ActivityParagraphPivot
            {
                ParagraphImage = activityParagraph.ParagraphImage,
                Activity = activityParagraph.Activity?.ToPivot(),
                ParagraphId = activityParagraph.ParagraphId,
                ActivityId = activityParagraph.ActivityId
            };
        }

        /// <summary>
        /// From ActivityParagraph list to ActivityParagraph pivot list.
        /// </summary>
        /// <param name="activityParagraphList">activityParagraphList to assemble.</param>
        /// <returns>list of ActivityParagraphPivot result.</returns>
        public static List<ActivityParagraphPivot> ToPivotList(this List<ActivityParagraph> activityParagraphList)
        {
            return activityParagraphList?.Select(x => x?.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From ActivityParagraphPivot to ActivityParagraph.
        /// </summary>
        /// <param name="activityParagraphPivot">activityParagraphPivot to assemble.</param>
        /// <returns>ActivityParagraph result.</returns>
        public static ActivityParagraph ToEntity(this ActivityParagraphPivot activityParagraphPivot)
        {
            if (activityParagraphPivot == null)
            {
                return null;
            }
            return new ActivityParagraph
            {
                Activity = activityParagraphPivot.Activity?.ToEntity(),
                ParagraphImage = activityParagraphPivot.ParagraphImage,
                ParagraphId = activityParagraphPivot.ParagraphId,
                ActivityId = activityParagraphPivot.ActivityId
            };
        }

        /// <summary>
        /// From ActivityParagraphPivotList to ActivityParagraphList .
        /// </summary>
        /// <param name="activityParagraphPivotList">ActivityParagraphPivotList to assemble.</param>
        /// <returns> list of ActivityParagraph result.</returns>
        public static List<ActivityParagraph> ToEntityList(this List<ActivityParagraphPivot> activityParagraphPivotList)
        {
            return activityParagraphPivotList?.Select(x => x?.ToEntity()).ToList();
        }
        #endregion
    }
}