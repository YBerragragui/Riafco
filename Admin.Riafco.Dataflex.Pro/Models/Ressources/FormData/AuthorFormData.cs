using System.ComponentModel.DataAnnotations;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData
{
    /// <summary>
    /// The Author dto class.
    /// </summary>
    public class AuthorFormData
    {
        /// <summary>
        /// Gets or Sets The AuthorId.
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Gets or Sets The AuthorFirstName.
        /// </summary>
        [Display(ResourceType = typeof(AuthorResources), Name = nameof(AuthorResources.DisplayFirstName))]
        [Required(ErrorMessageResourceType = typeof(AuthorResources), ErrorMessageResourceName = "RequiredFistName")]
        public string AuthorFirstName { get; set; }

        /// <summary>
        /// Gets or Sets The  AuthorLastName.
        /// </summary>
        [Display(ResourceType = typeof(AuthorResources), Name = nameof(AuthorResources.DisplayLastName))]
        [Required(ErrorMessageResourceType = typeof(AuthorResources), ErrorMessageResourceName = "RequiredLastName")]
        public string AuthorLastName { get; set; }
    }
}