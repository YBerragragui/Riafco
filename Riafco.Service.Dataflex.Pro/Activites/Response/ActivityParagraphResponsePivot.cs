using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Activites.Data;

namespace Riafco.Service.Dataflex.Pro.Activites.Response
{
    /// <summary>
    /// The ActivityParagraph response class.
    /// </summary>
    public class ActivityParagraphResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  ActivityParagraphPivotList.
        /// </summary>
        public List<ActivityParagraphPivot> ActivityParagraphPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityParagraphPivot.
        /// </summary>
        public ActivityParagraphPivot ActivityParagraphPivot { get; set; }
    }
}