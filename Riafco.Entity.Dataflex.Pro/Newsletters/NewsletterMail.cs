using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riafco.Entity.Dataflex.Pro.Newsletters
{
    /// <summary>
    /// The NewsletterMail Class
    /// </summary>
    [Table("newsletter_NewsletterMails")]
    public class NewsletterMail
    {
        /// <summary>
        /// Set & Get NewsletterMailId
        /// </summary>
        [Key]
        public int NewsletterMailId { get; set; }
    }
}
