using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.Newsletters.FormData
{
    /// <summary>
    /// The SubscriberFormData class
    /// </summary>
    public class SubscriberFormData
    {
        /// <summary>
        /// Get or sets SubscriberId.
        /// </summary>
        public int SubscriberId { get; set; }

        /// <summary>
        /// Gets or sets SubscriberFirstName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SubscriberResources), ErrorMessageResourceName = nameof(SubscriberResources.RequiredSubscriberFirstName))]
        [Display(ResourceType = typeof(SubscriberResources), Name = nameof(SubscriberResources.DisplaySubscriberFirstName))]
        public string SubscriberFirstName { get; set; }

        /// <summary>
        /// Gets or sets SubscriberLastName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SubscriberResources), ErrorMessageResourceName = nameof(SubscriberResources.RequiredSubscriberLastName))]
        [Display(ResourceType = typeof(SubscriberResources), Name = nameof(SubscriberResources.DisplaySubscriberLastName))]
        public string SubscriberLastName { get; set; }

        /// <summary>
        /// Gets or sets SubscriberLastName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SubscriberResources), ErrorMessageResourceName = nameof(SubscriberResources.RequiredSubscriberEmail))]
        [Display(ResourceType = typeof(SubscriberResources), Name = nameof(SubscriberResources.DisplaySubscriberEmail))]
        [EmailAddress(ErrorMessageResourceType = typeof(SubscriberResources), ErrorMessageResourceName = nameof(SubscriberResources.ValideEmail))]
        public string SubscriberEmail { get; set; }

    }
}
