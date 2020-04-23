
using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.ViewData
{
    /// <summary>
    /// The SheetViewData class.
    /// </summary>
    public class SheetViewData
    {
        /// <summary>
        /// Gets or sets Sheet.
        /// </summary>
        public SheetItemData Sheet { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<SheetTranslationItemData> TranslationsList { get; set; }
    }
}