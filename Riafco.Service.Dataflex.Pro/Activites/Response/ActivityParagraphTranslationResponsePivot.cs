using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Activites.Data;

namespace Riafco.Service.Dataflex.Pro.Activites.Response
{
    /// <summary>
    /// The ActivityParagraphTraslation response class.
    /// </summary>
    public class ActivityParagraphTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  ActivityParagraphTranslationPivotList.
        /// </summary>
        public List<ActivityParagraphTranslationPivot> ActivityParagraphTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The ActivityParagraphTranslationPivot.
        /// </summary>
        public ActivityParagraphTranslationPivot ActivityParagraphTranslationPivot { get; set; }

    }
}