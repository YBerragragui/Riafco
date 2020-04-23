using System.Collections.Generic;

namespace Riafco.Dataflex.Pro.Models.Ressources.ViewData
{
    /// <summary>
    /// The PublicationsViewData class.
    /// </summary>
    public class PublicationsThemeViewData
    {
        /// <summary>
        /// Gets or sets Publications.
        /// </summary>
        public List<PublicationThemeViewData> PublicationThemes { get; set; }

        /// <summary>
        /// Gets or sets PublicationId.
        /// </summary>
        public int PublicationId { get; set; }
    }
}