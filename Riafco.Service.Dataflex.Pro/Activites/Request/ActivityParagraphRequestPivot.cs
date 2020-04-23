using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Activites.Request
{
    /// <summary>
    /// Gets or Sets The  ActivityParagraph request class.
    /// </summary>
    public class ActivityParagraphRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  ActivityParagraphPivot requested.
        /// </summary>
        public ActivityParagraphPivot ActivityParagraphPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find ActivityParagraphEnum.
        /// </summary>
        public FindActivityParagraphPivot FindActivityParagraphPivot { get; set; }
    }
}