using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Newsletters
{
    [Table("newsletter_Subscribers")]
    public class Subscriber
    {
        /// <summary>
        /// Get or Set SubscriberId
        /// </summary>
        [Key]
        public int SubscriberId { get; set; }

        /// <summary>
        /// Get or Set SubscriberFirstName
        /// </summary>
        public string SubscriberFirstName { get; set; }

        /// <summary>
        /// Get or Set SubscriberLastName
        /// </summary>     
        public string SubscriberLastName { get; set; }

        /// <summary>
        /// Get or Set SubscriberEmail
        /// </summary>       
        public string SubscriberEmail { get; set; }
    }
}
