using Riafco.Service.Dataflex.Pro.Newsletters.Data;
using Riafco.Service.Dataflex.Pro.Newsletters.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Request
{
    /// <summary>
    /// Gets or Sets The  NewsletterMail request class.
    /// </summary>
    public class NewsletterMailRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  NewsletterMailPivot requested.
        /// </summary>
        public NewsletterMailPivot NewsletterMailPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find NewsletterMailEnum.
        /// </summary>
        public FindNewsletterMailPivot FindNewsletterMailPivot { get; set; }
    }
}