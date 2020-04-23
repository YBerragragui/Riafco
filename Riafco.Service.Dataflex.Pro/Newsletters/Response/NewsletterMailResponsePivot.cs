using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Newsletters.Data;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Response
{
    /// <summary>
    /// The NewsletterMail response class.
    /// </summary>
    public class NewsletterMailResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  NewsletterMailPivotList.
        /// </summary>
        public List<NewsletterMailPivot> NewsletterMailPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMailPivot.
        /// </summary>
        public NewsletterMailPivot NewsletterMailPivot { get; set; }
    }
}