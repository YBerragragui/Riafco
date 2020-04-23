
using System.Collections.Generic;
using Riafco.Dataflex.Pro.Models.Newsletters.ItemData;

namespace Riafco.Dataflex.Pro.Models.Newsletters.ViewData
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