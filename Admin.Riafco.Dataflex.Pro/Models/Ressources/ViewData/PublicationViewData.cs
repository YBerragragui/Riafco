using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.ViewData
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
    }
}