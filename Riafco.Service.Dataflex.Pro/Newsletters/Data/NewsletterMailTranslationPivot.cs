using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Data
{
    /// <summary>
    /// The NewsletterMailTranslation pivot class.
    /// </summary>
    public class NewsletterMailTranslationPivot
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMailSource.
        /// </summary>
        public string NewsletterMailSource { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMailSubject.
        /// </summary>
        public string NewsletterMailSubject { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or Sets The  NewsletterMailId.
        /// </summary>
        public int? NewsletterMailId { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMail.
        /// </summary>
        public NewsletterMailPivot NewsletterMail { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguagePivot Language { get; set; }
        #endregion
    }
}