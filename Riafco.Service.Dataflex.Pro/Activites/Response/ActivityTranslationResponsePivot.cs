using Riafco.Service.Dataflex.Pro.Activites.Data;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Activites.Response
{
    /// <summary>
    /// The ActivityTranslation response class.
    /// </summary>
    public class ActivityTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  ActivityTranslationPivotList.
        /// </summary>
        public List<ActivityTranslationPivot> ActivityTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityTranslationPivot.
        /// </summary>
        public ActivityTranslationPivot ActivityTranslationPivot { get; set; }
    }
}