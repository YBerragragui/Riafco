using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.Newsletters.ItemData
{
    /// <summary>
    /// The NewsletterMailTranslationItemData class.
    /// </summary>
    public class NewsletterMailTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMailSource.
        /// </summary>
        public string  NewsletterMailSource { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMailSubject.
        /// </summary>
        public string NewsletterMailSubject { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  NewsletterMailId.
        /// </summary>
        public int? NewsletterMailId { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMail.
        /// </summary>
        public NewsletterMailItemData NewsletterMail { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageItemData Language { get; set; }
        #endregion
    }
}