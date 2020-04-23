using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Newsletters.Data;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Response
{
    /// <summary>
    /// The NewsletterMailTranslation response class.
    /// </summary>
    public class NewsletterMailTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  NewsletterMailTranslationPivotList.
        /// </summary>
        public List<NewsletterMailTranslationPivot> NewsletterMailTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMailTranslationPivot.
        /// </summary>
        public NewsletterMailTranslationPivot NewsletterMailTranslationPivot { get; set; }
    }
}