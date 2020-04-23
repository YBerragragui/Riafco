namespace Riafco.Dataflex.Pro.Models.Ressources.ItemData
{
    /// <summary>
    /// The PublicationThemeItemData class.
    /// </summary>
    public class PublicationThemeItemData
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
        /// Gets or Sets ThemeTranslation.
        /// </summary>
        public ThemeTranslationItemData ThemeTranslation { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationId.
        /// </summary>
        public int? PublicationId { get; set; }

        /// <summary>
        /// Gets or Sets PublicationTranslation.
        /// </summary>
        public PublicationTranslationItemData PublicationTranslation { get; set; }

        #endregion
    }
}