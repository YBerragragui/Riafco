using Riafco.Entity.Dataflex.Pro.Activites;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Activites.Assembler
{
    /// <summary>
    /// The Activity assembler class.
    /// </summary>
    public static class ActivityAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Activity To Activity Pivot.
        /// </summary>
        /// <param name="activity">activity TO ASSEMBLE</param>
        /// <returns>ActivityPivot result.</returns>
        public static ActivityPivot ToPivot(this Activity activity)
        {
            if (activity == null)
            {
                return null;
            }

            return new ActivityPivot
            {
                ActivityImage = activity.ActivityImage,
                ActivityIcon = activity.ActivityIcon,
                ActivityId = activity.ActivityId
            };
        }

        /// <summary>
        /// From Activity list to Activity pivot list.
        /// </summary>
        /// <param name="activityList">activityList to assemble.</param>
        /// <returns>list of ActivityPivot result.</returns>
        public static List<ActivityPivot> ToPivotList(this List<Activity> activityList)
        {
            return activityList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From ActivityPivot to Activity.
        /// </summary>
        /// <param name="activityPivot">activityPivot to assemble.</param>
        /// <returns>Activity result.</returns>
        public static Activity ToEntity(this ActivityPivot activityPivot)
        {
            if (activityPivot == null)
            {
                return null;
            }
            return new Activity
            {
                ActivityImage = activityPivot.ActivityImage,
                ActivityIcon = activityPivot.ActivityIcon,
                ActivityId = activityPivot.ActivityId
            };
        }

        /// <summary>
        /// From ActivityPivotList to ActivityList .
        /// </summary>
        /// <param name="activityPivotList">ActivityPivotList to assemble.</param>
        /// <returns> list of Activity result.</returns>
        public static List<Activity> ToEntityList(this List<ActivityPivot> activityPivotList)
        {
            return activityPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}