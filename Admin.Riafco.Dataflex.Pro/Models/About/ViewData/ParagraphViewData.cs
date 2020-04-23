
using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.About.ViewData
{
    /// <summary>
    /// The ParagraphViewData class.
    /// </summary>
    public class ParagraphViewData
    {
        /// <summary>
        /// Gets or sets Paragraph.
        /// </summary>
        public SectionParagraphItemData Paragraph { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<SectionParagraphTranslationItemData> TranslationsList { get; set; }
    }
}