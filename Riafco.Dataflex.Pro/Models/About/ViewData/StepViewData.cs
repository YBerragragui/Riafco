using Riafco.Dataflex.Pro.Models.About.ItemData;
using System.Collections.Generic;

namespace Riafco.Dataflex.Pro.Models.About.ViewData
{
    /// <summary>
    /// The SectionViewData class.
    /// </summary>
    public class StepViewData
    {
        /// <summary>
        /// Gets or sets Section.
        /// </summary>
        public StepItemData Step { get; set; }

        /// <summary>
        /// Gets or sets ParagraphsItemData.
        /// </summary>
        public List<StepParagraphItemData> ParagraphsItemData { get; set; }
    }
}