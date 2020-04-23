using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.About.ViewData
{
    /// <summary>
    /// The StepParagraphViewData class.
    /// </summary>
    public class StepParagraphViewData
    {
        /// <summary>
        /// Gets or sets StepParagraphItemData.
        /// </summary>
        public StepParagraphItemData Paragraph { get; set; }

        /// <summary>
        /// Gets or sets Translations.
        /// </summary>
        public List<StepParagraphTranslationItemData> Translations { get; set; }
    }
}