
using System.Collections.Generic;
using Riafco.Dataflex.Pro.Models.Activities.ItemData;

namespace Riafco.Dataflex.Pro.Models.Activities.ViewData
{
    /// <summary>
    /// The ParagraphViewData class.
    /// </summary>
    public class ParagraphViewData
    {
        /// <summary>
        /// Gets or sets Paragraph.
        /// </summary>
        public ActivityParagraphItemData Paragraph { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<ActivityParagraphTranslationItemData> TranslationsList { get; set; }
    }
}