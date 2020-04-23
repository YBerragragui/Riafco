using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Activites.Data;

namespace Riafco.Service.Dataflex.Pro.Activites.Response
{
    /// <summary>
    /// The ActivityFile response class.
    /// </summary>
    public class ActivityFileResponsePivot
    {
        /// <summary>
        /// Gets or Sets The ActivityFilePivotList.
        /// </summary>
        public List<ActivityFilePivot> ActivityFilePivotList { get; set; }

        /// <summary>
        /// Gets or Sets The ActivityFilePivot.
        /// </summary>
        public ActivityFilePivot ActivityFilePivot { get; set; }

    }
}