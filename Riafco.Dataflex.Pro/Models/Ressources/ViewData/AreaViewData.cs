using System.Collections.Generic;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData;

namespace Riafco.Dataflex.Pro.Models.Ressources.ViewData
{
    /// <summary>
    /// The AreaViewData class.
    /// </summary>
    public class AreaViewData
    {
        /// <summary>
        /// Gets or sets Area.
        /// </summary>
        public AreaItemData Area { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<AreaTranslationItemData> TranslationsList { get; set; }
    }
}