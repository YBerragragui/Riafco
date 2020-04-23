using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.About.ViewData
{
    /// <summary>
    /// The StepViewData class.
    /// </summary>
    public class StepViewData
    {
        /// <summary>
        /// Gets or sets Step.
        /// </summary>
        public StepItemData Step { get; set; }

        /// <summary>
        /// Gets or sets Paragraphs.
        /// </summary>
        public StepParagraphsViewData Paragraphs { get; set; }
    }
}