
using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto
{
    /// <summary>
    /// The Subscriber dto class.
    /// </summary>
    public class SubscriberDto
    {
        /// <summary>
        /// Gets or Sets The  SubscriberId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SubscriberMessageResource), ErrorMessageResourceName = nameof(SubscriberMessageResource.RequiredId))]
        public int SubscriberId { get; set; }

        /// <summary>
        /// Gets or Sets The  SubscriberFirstName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SubscriberMessageResource),ErrorMessageResourceName = nameof(SubscriberMessageResource.RequiredFirstName))]
        public string SubscriberFirstName { get; set; }

        /// <summary>
        /// Gets or Sets The  SubscriberLastName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SubscriberMessageResource), ErrorMessageResourceName = nameof(SubscriberMessageResource.RequiredLastName))]
        public string SubscriberLastName { get; set; }

        /// <summary>
        /// Gets or Sets The  SubscriberEmail.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SubscriberMessageResource),ErrorMessageResourceName = nameof(SubscriberMessageResource.RequiredEmail))]
        [EmailAddress(ErrorMessageResourceType = typeof(SubscriberMessageResource), ErrorMessageResourceName = nameof(SubscriberMessageResource.ValideEmail))]
        public string SubscriberEmail { get; set; }
    }
}