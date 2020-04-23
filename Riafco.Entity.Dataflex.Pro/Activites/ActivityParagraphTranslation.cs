
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Riafco.Entity.Dataflex.Pro.Languages;

namespace Riafco.Entity.Dataflex.Pro.Activites
{
    /// <summary>
    /// The ActivityParagraphTraslation class.
    /// </summary>
    [Table("act_ParagraphTranslations")]
    public class ActivityParagraphTranslation
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
        /// Gets or sets ActiviteId.
        /// </summary>
        [ForeignKey("ActivityParagraph")]
        public int? ParagraphId { get; set; }

        /// <summary>
        /// Gets or sets activity.
        /// </summary>
        public virtual ActivityParagraph ActivityParagraph { get; set; }

        #endregion
    }
}
