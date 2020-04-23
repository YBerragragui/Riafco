using Riafco.Entity.Dataflex.Pro.Languages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Occurrences
{
    /// <summary>
    /// The OccurrenceTraduction class
    /// </summary>
    [Table("occu_OccurrenceTranslations")]
    public class OccurrenceTranslation
    {
        /// <summary>
        /// Gets or sets TraductionId
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets EventTitle
        /// </summary>
        public string OccurrenceTitle { get; set; }

        /// <summary>
        /// Gets or sets EventDescription
        /// </summary>
        public string OccurrenceDescription { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or sets EventId
        /// </summary>
        [ForeignKey("Occurrence")]
        public int? OccurrenceId { get; set; }

        /// <summary>
        /// Gets or sets Evenet
        /// </summary>
        public virtual Occurrence Occurrence { get; set; }

        /// <summary>
        /// Gets or sets LangueId
        /// </summary>
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets Language
        /// </summary>
        public virtual Language Language { get; set; }
        #endregion
    }
}
