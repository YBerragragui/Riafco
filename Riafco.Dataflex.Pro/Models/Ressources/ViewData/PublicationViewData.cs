using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using System.Collections.Generic;

namespace Riafco.Dataflex.Pro.Models.Ressources.ViewData
{
    /// <summary>
    /// The PublicationViewData class.
    /// </summary>
    public class PublicationViewData
    {
        /// <summary>
        /// Gets or sets Publication.
        /// </summary>
        public PublicationItemData Publication { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<PublicationTranslationItemData> TranslationsList { get; set; }

        /// <summary>
        /// Gets or sets ThemesViewData.
        /// </summary>
        public ThemesViewData ThemesViewData { get; set; }
    }
}