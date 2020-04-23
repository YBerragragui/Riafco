using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Ressources.Request
{
    /// <summary>
    /// Gets or Sets The  PublicationTheme request class.
    /// </summary>
    public class PublicationThemeRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  PublicationThemePivot requested.
        /// </summary>
        public PublicationThemePivot PublicationThemePivot { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationThemePivotList requested.
        /// </summary>
        public List<PublicationThemePivot> PublicationThemePivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  Find PublicationThemeEnum.
        /// </summary>
        public FindPublicationThemePivot FindPublicationThemePivot { get; set; }
    }
}