using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Activites.Request
{
    /// <summary>
    /// Gets or Sets The  ActivityFileTranslation request class.
    /// </summary>
    public class ActivityFileTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  ActivityFileTranslationPivot requested.
        /// </summary>
        public ActivityFileTranslationPivot ActivityFileTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The ActivityFileTranslationPivotList requested.
        /// </summary>
        public List<ActivityFileTranslationPivot> ActivityFileTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  Find ActivityFileTranslationEnum.
        /// </summary>
        public FindActivityFileTranslationPivot FindActivityFileTranslationPivot { get; set; }
    }
}