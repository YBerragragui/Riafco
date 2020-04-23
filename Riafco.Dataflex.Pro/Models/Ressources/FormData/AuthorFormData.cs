using Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Riafco.Dataflex.Pro.Models.Ressources.FormData
{
    /// <summary>
    /// The Author dto class.
    /// </summary>
    public class AuthorFormData
    {
        /// <summary>
        /// Gets or Sets The AuthorId.
        /// </summary>
        [Display(ResourceType = typeof(AuthorResources), Name = nameof(AuthorResources.DisplayLastName))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(AuthorResources), ErrorMessageResourceName = "RequiredId")]
        public int AuthorId { get; set; }
    }
}