using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Riafco.Entity.Dataflex.Pro.Languages;

namespace Riafco.Entity.Dataflex.Pro.About
{
    /// <summary>
    /// The SectionParagraphTraslation class.
    /// </summary>
    [Table("about_SectionParagraphTranslations")]
    public class SectionParagraphTranslation
    {
        /// <summary>
        /// Gets or sets TranslationId
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Get or sets ParagraphTitle.
        /// </summary>
        public string ParagraphTitle { get; set; }

        /// <summary>
        /// Get or sets ParagraphDescription.
        /// </summary>
        public string ParagraphDescription { get; set; }

        #region navigation proportises

        /// <summary>
        /// Gets or sets LangueId
        /// </summary>
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets Langue
        /// </summary>
        public virtual Language Language { get; set; }

        /// <summary>
        /// Gets or sets ParagraphId.
        /// </summary>
        [ForeignKey("SectionParagraph")]
        public int? ParagraphId { get; set; }

        /// <summary>
        /// Gets or sets section.
        /// </summary>
        public virtual SectionParagraph SectionParagraph { get; set; }

        #endregion
    }
}
