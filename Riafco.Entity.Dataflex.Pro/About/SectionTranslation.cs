using Riafco.Entity.Dataflex.Pro.Languages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.About
{
    /// <summary>
    /// The AboutSection class
    /// </summary>
    [Table("about_SectionTranslations")]
    public class SectionTranslation
    {
        /// <summary>
        /// Gets or gets TraductionId.
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets SectionTitle
        /// </summary>
        public string SectionTitle { get; set; }

        /// <summary>
        /// Gets or sets SectionDesciption.
        /// </summary>
        public string SectionDesciption  { get; set; }

        #region Navigation properties
        /// <summary>
        /// Gets sets LangueId.
        /// </summary>
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets Langue.
        /// </summary>
        public virtual Language Language { get; set; }

        /// <summary>
        /// Gets or sets NewsId.
        /// </summary>
        [ForeignKey("Section")]
        public int? SectionId { get; set; }

        /// <summary>
        /// Gets sets or News.
        /// </summary>
        public virtual Section Section { get; set; }
        #endregion
    }
}
