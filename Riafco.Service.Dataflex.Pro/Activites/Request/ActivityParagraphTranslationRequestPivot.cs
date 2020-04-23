using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Activites.Request
{
    /// <summary>
    /// Gets or Sets The  ActivityParagraphTraslation request class.
    /// </summary>
    public class ActivityParagraphTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The ActivityParagraphTranslationPivot requested.
        /// </summary>
        public ActivityParagraphTranslationPivot ActivityParagraphTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The ActivityParagraphTranslationPivotList requested.
        /// </summary>
        public List<ActivityParagraphTranslationPivot> ActivityParagraphTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The FindActivityParagraphTranslationPivot.
        /// </summary>
        public FindActivityParagraphTranslationPivot FindActivityParagraphTranslationPivot { get; set; }
    }
}