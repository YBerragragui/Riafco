using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.Newsletters.FormData
{
    /// <summary>
    /// The NewsletterMailFormData class.
    /// </summary>
    public class NewsletterMailFormData
    {
        /// <summary>
        /// Gets or Sets The  NewsletterMailId.
        /// </summary>
        public int NewsletterMailId { get; set; }

        #region navigation attributes
        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<NewsletterMailTranslationFormData> TranslationsList { get; set; }
        #endregion
    }
}