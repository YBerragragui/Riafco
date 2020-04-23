using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData
{
    /// <summary>
    /// The UpdatePublicationTranslationFormData class.
    /// </summary>
    public class UpdatePublicationTranslationFormData
    {
        /// <summary>
        /// Gets or Sets The  PublicationTranslationId.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(PublicationResources), ErrorMessageResourceName = "RequiredPublicationId")]
        public int PublicationTranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The PublicationTitle.
        /// </summary>
        [Display(ResourceType = typeof(PublicationResources), Name = nameof(PublicationResources.DisplayPublicationTitle))]
        [Required(ErrorMessageResourceType = typeof(PublicationResources), ErrorMessageResourceName = "RequiredPublicationTitle")]
        public string PublicationTitle { get; set; }

        /// <summary>
        /// Gets or Sets The PublicationSummary.
        /// </summary>
        [Display(ResourceType = typeof(PublicationResources), Name = nameof(PublicationResources.DisplayPublicationSummary))]
        [Required(ErrorMessageResourceType = typeof(PublicationResources), ErrorMessageResourceName = "RequiredPublicationSummary")]
        public string PublicationSummary { get; set; }

        /// <summary>
        /// Gets or sets PublicationFile.
        /// </summary>
        [Display(ResourceType = typeof(PublicationResources), Name = nameof(PublicationResources.DisplayPublicationSummary))]
        public HttpPostedFileBase PublicationFile { get; set; }
        public string PublicationFileSource { get; set; }

        #region NAVIGATION ATTRIBUTTES.

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationResources), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The PublicationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationResources), ErrorMessageResourceName = "RequiredPublicationId")]
        public int? PublicationId { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }

        #endregion
    }
}