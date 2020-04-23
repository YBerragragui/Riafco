
using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.ViewData
{
    /// <summary>
    /// The ParagraphsViewData class.
    /// </summary>
    public class ParagraphsViewData
    {
        /// <summary>
        /// Gets or sets Paragraphs
        /// </summary>
        public List<ParagraphViewData> Paragraphs { get; set; }

        /// <summary>
        /// Gets or sets ActivityId.
        /// </summary>
        public int ActivityId { get; set; }
    }
}