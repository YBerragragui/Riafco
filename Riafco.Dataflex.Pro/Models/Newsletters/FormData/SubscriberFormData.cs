

using System.ComponentModel.DataAnnotations;
using Riafco.Dataflex.Pro.GlobalResources;
using Riafco.Dataflex.Pro.GlobalResources.Shared.newsletter;

namespace Riafco.Dataflex.Pro.Models.Newsletters.FormData
{
    /// <summary>
    /// The SubscriberFormData class
    /// </summary>
    public class SubscriberFormData
    {
        /// <summary>
        /// Gets or sets SubscriberFirstName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(NewsletterResources), ErrorMessageResourceName = nameof(NewsletterResources.RequiredFields))]
        public string SubscriberFirstName { get; set; }

        /// <summary>
        /// Gets or sets SubscriberLastName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(NewsletterResources), ErrorMessageResourceName = nameof(NewsletterResources.RequiredFields))]
        public string SubscriberLastName { get; set; }

        /// <summary>
        /// Gets or sets SubscriberLastName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(NewsletterResources), ErrorMessageResourceName = nameof(NewsletterResources.RequiredFields))]
        public string SubscriberEmail { get; set; }
    }
}
