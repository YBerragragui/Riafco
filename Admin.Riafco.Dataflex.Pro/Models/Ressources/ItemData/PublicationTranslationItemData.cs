using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData
{
    /// <summary>
    /// The PublicationTranslationItemData class.
    /// </summary>
    public class PublicationTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The  PublicationTranslationId.
        /// </summary>
        public int PublicationTranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The PublicationTitle.
        /// </summary>
        public string PublicationTitle { get; set; }

        /// <summary>
        /// Gets or Sets The PublicationSummary.
        /// </summary>
        public string PublicationSummary { get; set; }

        /// <summary>
        /// Gets or sets PublicationFile.
        /// </summary>
        public string PublicationFile { get; set; }

        #region private attributes

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageItemData Language { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationId.
        /// </summary>
        public int? PublicationId { get; set; }

        /// <summary>
        /// Gets or Sets The  Publication.
        /// </summary>
        public PublicationItemData Publication { get; set; }

        #endregion
    }
}