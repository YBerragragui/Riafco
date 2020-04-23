using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Activites.Request
{
    /// <summary>
    /// Gets or Sets The  ActivityTranslation request class.
    /// </summary>
    public class ActivityTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The ActivityTranslationPivot requested.
        /// </summary>
        public ActivityTranslationPivot ActivityTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The ActivityTranslationPivotList requested.
        /// </summary>
        public List<ActivityTranslationPivot> ActivityTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The FindActivityTranslationPivot.
        /// </summary>
        public FindActivityTranslationPivot FindActivityTranslationPivot { get; set; }
    }
}