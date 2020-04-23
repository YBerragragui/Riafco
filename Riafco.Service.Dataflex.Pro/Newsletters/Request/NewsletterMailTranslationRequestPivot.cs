using Riafco.Service.Dataflex.Pro.Newsletters.Data;
using Riafco.Service.Dataflex.Pro.Newsletters.Data.Enum;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Request
{
    /// <summary>
    /// Gets or Sets The  NewsletterMailTranslation request class.
    /// </summary>
    public class NewsletterMailTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  NewsletterMailTranslationPivot requested.
        /// </summary>
        public NewsletterMailTranslationPivot NewsletterMailTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMailTranslationPivot requested.
        /// </summary>
        public List<NewsletterMailTranslationPivot> NewsletterMailTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  Find NewsletterMailTranslationEnum.
        /// </summary>
        public FindNewsletterMailTranslationPivot FindNewsletterMailTranslationPivot { get; set; }
    }
}