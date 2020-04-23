using Riafco.Entity.Dataflex.Pro.Languages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Ressources
{
    /// <summary>
    /// The PublicationTranslation class.
    /// </summary>
    [Table("Ressource_PublicationTranslations")]
    public class PublicationTranslation
    {
        /// <summary>
        /// Gets or sets PublicationTranslationId.
        /// </summary>
        [Key]
        public int PublicationTranslationId { get; set; }

        /// <summary>
        /// Gets or sets PublicationTitle.
        /// </summary>
        public string PublicationTitle { get; set; }

        /// <summary>
        /// Gets or sets PublicationSummary.
        /// </summary>
        public string PublicationSummary { get; set; }

        /// <summary>
        /// Gets or sets PublicationFile.
        /// </summary>
        public string PublicationFile { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or sets LanguageId.
        /// </summary>
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets Language.
        /// </summary>
        public virtual Language Language { get; set; }

        /// <summary>
        /// Gets or sets PublicationId.
        /// </summary>
        [ForeignKey("Publication")]
        public int? PublicationId { get; set; }

        /// <summary>
        /// Gets or sets Publication.
        /// </summary>
        public virtual Publication Publication { get; set; }

        #endregion
    }
}
