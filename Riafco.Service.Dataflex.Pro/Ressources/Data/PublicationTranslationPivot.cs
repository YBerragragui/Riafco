using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.Ressources.Data
{
    /// <summary>
    /// The PublicationTranslation pivot class.
    /// </summary>
    public class PublicationTranslationPivot
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

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguagePivot Language { get; set; }

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