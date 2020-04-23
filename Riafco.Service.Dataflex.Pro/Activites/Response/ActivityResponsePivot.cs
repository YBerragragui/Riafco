using Riafco.Service.Dataflex.Pro.Activites.Data;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Activites.Response
{
    /// <summary>
    /// The Activity response class.
    /// </summary>
    public class ActivityResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  ActivityPivotList.
        /// </summary>
        public List<ActivityPivot> ActivityPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityPivot.
        /// </summary>
        public ActivityPivot ActivityPivot { get; set; }
    }
}