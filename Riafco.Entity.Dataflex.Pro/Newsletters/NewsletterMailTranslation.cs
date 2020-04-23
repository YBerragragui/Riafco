using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Riafco.Entity.Dataflex.Pro.Languages;

namespace Riafco.Entity.Dataflex.Pro.Newsletters
{
    /// <summary>
    /// The NewsletterMailTranslation Class
    /// </summary>
    [Table("newsletter_NewsletterMailTranslations")]
    public class NewsletterMailTranslation
    {
        /// <summary>
        /// Set & Get TranslationId
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Set & Get NewsletterMailSource
        /// </summary>
        public string NewsletterMailSource { get; set; }

        /// <summary>
        /// Set & Get NewsletterMailSubject
        /// </summary>
        public string NewsletterMailSubject { get; set; }

        #region NAVIGATION PROPERTIES
        /// <summary>
        /// Gets or sets NewsletterMailId
        /// </summary>
        [ForeignKey("NewsletterMail")]
        public int? NewsletterMailId { get; set; }

        /// <summary>
        /// Gets or sets NewsletterMail
        /// </summary>
        public virtual NewsletterMail NewsletterMail { get; set; }

        /// <summary>
        /// Gets or sets LanguageId
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
