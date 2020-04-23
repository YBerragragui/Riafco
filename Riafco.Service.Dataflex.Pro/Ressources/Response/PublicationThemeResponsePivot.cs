using Riafco.Service.Dataflex.Pro.Ressources.Data;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Ressources.Response
{
    /// <summary>
    /// The PublicationTheme response class.
    /// </summary>
    public class PublicationThemeResponsePivot
    {
        #region publication theme

        /// <summary>
        /// Gets or Sets The  PublicationThemePivot.
        /// </summary>
        public PublicationThemePivot PublicationThemePivot { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationThemePivotList.
        /// </summary>
        public List<PublicationThemePivot> PublicationThemePivotList { get; set; }

        #endregion

        #region publication translation

        /// <summary>
        /// Gets or sets PublicationTranslationPivotList.
        /// </summary>
        public List<PublicationTranslationPivot> PublicationTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or sets PublicationTranslationPivot.
        /// </summary>
        public PublicationTranslationPivot PublicationTranslationPivot { get; set; }

        #endregion

        #region theme translations

        /// <summary>
        /// Gets or sets ThemeTranslationPivot.
        /// </summary>
        public ThemeTranslationPivot ThemeTranslationPivot { get; set; }

        /// <summary>
        /// Gets or sets ThemeTranslationPivotList.
        /// </summary>
        public List<ThemeTranslationPivot> ThemeTranslationPivotList { get; set; }

        #endregion
    }
}