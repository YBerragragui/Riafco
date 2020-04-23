using Riafco.Dataflex.Pro.GlobalResources;
using Riafco.Dataflex.Pro.GlobalResources.Publications;
using System.ComponentModel.DataAnnotations;

namespace Riafco.Dataflex.Pro.Models.Ressources.FormData
{
    /// <summary>
    /// The FilterFormData cless.
    /// </summary>
    public class FilterFormData
    {
        /// <summary>
        /// Gets or Sets The AreaId.
        /// </summary>
        [Display(ResourceType = typeof(PublicationResources), Name = nameof(PublicationResources.DisplayArea))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationResources), ErrorMessageResourceName = "RequiredId")]
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or Sets The AuthorId.
        /// </summary>
        [Display(ResourceType = typeof(PublicationResources), Name = nameof(PublicationResources.DisplayAuthor))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationResources), ErrorMessageResourceName = "RequiredId")]
        public int AuthorId { get; set; }

        /// <summary>
        /// Gets or Sets The ThemeId.
        /// </summary>
        [Display(ResourceType = typeof(PublicationResources), Name = nameof(PublicationResources.DisplayTheme))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationResources), ErrorMessageResourceName = "RequiredId")]
        public int ThemeId { get; set; }

        /// <summary>
        /// Gets or sets RessourceDate.
        /// </summary>
        [Display(ResourceType = typeof(PublicationResources), Name = nameof(PublicationResources.DisplayDate))]
        public string PublicationDate { get; set; }
    }
}