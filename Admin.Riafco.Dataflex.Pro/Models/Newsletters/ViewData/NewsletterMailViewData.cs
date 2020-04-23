
using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.Newsletters.ViewData
{
    /// <summary>
    /// The NewsletterMailViewData class.
    /// </summary>
    public class NewsletterMailViewData
    {
        /// <summary>
        /// Gets or sets NewsletterMail.
        /// </summary>
        public NewsletterMailItemData NewsletterMail { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<NewsletterMailTranslationItemData> TranslationsList { get; set; }
    }
}