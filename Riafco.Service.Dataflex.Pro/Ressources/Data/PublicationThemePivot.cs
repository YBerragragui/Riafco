namespace Riafco.Service.Dataflex.Pro.Ressources.Data
{
    /// <summary>
    /// The PublicationTheme pivot class.
    /// </summary>
    public class PublicationThemePivot
    {
        /// <summary>
        /// Gets or Sets The PublicationThemeId.
        /// </summary>
        public int PublicationThemeId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  ThemeId.
        /// </summary>
        public int? ThemeId { get; set; }

        /// <summary>
        /// Gets or Sets The  Theme.
        /// </summary>
        public ThemePivot Theme { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationId.
        /// </summary>
        public int? PublicationId { get; set; }

        /// <summary>
        /// Gets or Sets The  Publication.
        /// </summary>
        public PublicationPivot Publication { get; set; }

        #endregion
    }
}