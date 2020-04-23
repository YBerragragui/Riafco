using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Activites.Data;

namespace Riafco.Service.Dataflex.Pro.Activites.Response
{
    /// <summary>
    /// The ActivityFileTranslation response class.
    /// </summary>
    public class ActivityFileTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  ActivityFileTranslationPivotList.
        /// </summary>
        public List<ActivityFileTranslationPivot> ActivityFileTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityFileTranslationPivot.
        /// </summary>
        public ActivityFileTranslationPivot ActivityFileTranslationPivot { get; set; }

    }
}