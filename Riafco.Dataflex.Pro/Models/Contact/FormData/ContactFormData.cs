using Riafco.Dataflex.Pro.GlobalResources.Contact;
using System.ComponentModel.DataAnnotations;

namespace Riafco.Dataflex.Pro.Models.Contact.FormData
{
    /// <summary>
    /// The PartnerFormData class.
    /// </summary>
    public class ContactFormData
    {
        /// <summary>
        /// Gets or sets ContactMessageFullName.
        /// </summary>
        [Display(Name = "DisplayFullName", ResourceType = typeof(ContactResources))]
        [Required(ErrorMessageResourceType = typeof(ContactResources), ErrorMessageResourceName = "RequiredField")]
        public string ContactMessageFullName { get; set; }

        /// <summary>
        /// Gets or sets ContactMessageMail.
        /// </summary>
        [Display(Name = "DisplayMail", ResourceType = typeof(ContactResources))]
        [Required(ErrorMessageResourceType = typeof(ContactResources), ErrorMessageResourceName = "RequiredField")]
        [EmailAddress(ErrorMessageResourceType = typeof(ContactResources), ErrorMessageResourceName = "InvalidMail")]
        public string ContactMessageMail { get; set; }

        /// <summary>
        /// Gets or sets ContactMessageSubject.
        /// </summary>
        [Display(Name = "DisplaySubject", ResourceType = typeof(ContactResources))]
        [Required(ErrorMessageResourceType = typeof(ContactResources), ErrorMessageResourceName = "RequiredField")]
        public string ContactMessageSubject { get; set; }

        /// <summary>
        /// Gets or sets ContactMessageText.
        /// </summary>
        [Display(Name = "DisplayMessage", ResourceType = typeof(ContactResources))]
        [Required(ErrorMessageResourceType = typeof(ContactResources), ErrorMessageResourceName = "RequiredField")]
        public string ContactMessageText { get; set; }
    }
}
