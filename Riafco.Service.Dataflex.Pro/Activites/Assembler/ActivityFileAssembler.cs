using Riafco.Entity.Dataflex.Pro.Activites;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Activites.Assembler
{
    /// <summary>
    /// The ActivityFile assembler class.
    /// </summary>
    public static class ActivityFileAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From ActivityFile To ActivityFile Pivot.
        /// </summary>
        /// <param name="activityFile">activityFile TO ASSEMBLE</param>
        /// <returns>ActivityFilePivot result.</returns>
        public static ActivityFilePivot ToPivot(this ActivityFile activityFile)
        {
            if (activityFile == null)
            {
                return null;
            }
            return new ActivityFilePivot
            {
                ActivityFileId = activityFile.ActivityFileId,
                Activity = activityFile.Activity.ToPivot(),
                ActivityId = activityFile.ActivityId
            };
        }

        /// <summary>
        /// From ActivityFile list to ActivityFile pivot list.
        /// </summary>
        /// <param name="activityFileList">activityFileList to assemble.</param>
        /// <returns>list of ActivityFilePivot result.</returns>
        public static List<ActivityFilePivot> ToPivotList(this List<ActivityFile> activityFileList)
        {
            return activityFileList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From ActivityFilePivot to ActivityFile.
        /// </summary>
        /// <param name="activityFilePivot">activityFilePivot to assemble.</param>
        /// <returns>ActivityFile result.</returns>
        public static ActivityFile ToEntity(this ActivityFilePivot activityFilePivot)
        {
            if (activityFilePivot == null)
            {
                return null;
            }
            return new ActivityFile
            {
                ActivityFileId = activityFilePivot.ActivityFileId,
                Activity = activityFilePivot.Activity?.ToEntity(),
                ActivityId = activityFilePivot.ActivityId
            };
        }

        /// <summary>
        /// From ActivityFilePivotList to ActivityFileList .
        /// </summary>
        /// <param name="activityFilePivotList">ActivityFilePivotList to assemble.</param>
        /// <returns>List of ActivityFile result.</returns>
        public static List<ActivityFile> ToEntityList(this List<ActivityFilePivot> activityFilePivotList)
        {
            return activityFilePivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}