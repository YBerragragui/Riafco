using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.About.ViewData
{
    /// <summary>
    /// The SectionViewData class.
    /// </summary>
    public class SectionViewData
    {
        /// <summary>
        /// Gets or sets Section.
        /// </summary>
        public SectionItemData Section { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<SectionTranslationItemData> TranslationsList { get; set; }
    }
}