using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData
{
    /// <summary>
    /// The CreatePublicationFormData class.
    /// </summary>
    public class CreatePublicationFormData
    {
        /// <summary>
        /// Gets or Sets The  PublicationImage.
        /// </summary>
        [Display(ResourceType = typeof(PublicationResources), Name = nameof(PublicationResources.DisplayImage))]
        public HttpPostedFileBase PublicationImage { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationDate.
        /// </summary>
        [Display(ResourceType = typeof(PublicationResources), Name = nameof(PublicationResources.DisplayPublicationDate))]
        [Required(ErrorMessageResourceType = typeof(PublicationResources), ErrorMessageResourceName = "RequiredPublicationDate")]
        public string PublicationDate { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  AreaId.
        /// </summary>
        [Display(ResourceType = typeof(PublicationResources), Name = nameof(PublicationResources.DisplayArea))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationResources), ErrorMessageResourceName = "RequiredPublicationArea")]
        [Required(ErrorMessageResourceType = typeof(PublicationResources), AllowEmptyStrings = false, ErrorMessageResourceName = "RequiredPublicationArea")]
        public int? AreaId { get; set; }

        /// <summary>
        /// Gets or Sets The AuthorId.
        /// </summary>
        [Display(ResourceType = typeof(PublicationResources), Name = nameof(PublicationResources.DisplayAuthor))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationResources), ErrorMessageResourceName = "RequiredPublicationAuthor")]
        [Required(ErrorMessageResourceType = typeof(PublicationResources), AllowEmptyStrings = false, ErrorMessageResourceName = "RequiredPublicationAuthor")]
        public int? AuthorId { get; set; }

        /// <summary>
        /// Get or set TranslationsList.
        /// </summary>
        public List<CreatePublicationTranslationFormData> TranslationsList { get; set; }

        #endregion
    }
}