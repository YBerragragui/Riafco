using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.Settings.FormData
{
    /// <summary>
    /// The Langue dto class.
    /// </summary>
    public class UpdateLanguageFormData
    {
        /// <summary>
        /// Gets or Sets The LangueId.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(LanguageResources), ErrorMessageResourceName = "RequiredId")]
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguePrefix
        /// </summary>
        [Display(ResourceType = typeof(LanguageResources), Name = "DisplayLanguagePrefix")]
        [Required(ErrorMessageResourceType = typeof(LanguageResources), ErrorMessageResourceName = "RequiredLanguagePrefix")]
        public string LanguagePrefix { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguePicture.
        /// </summary>
        [Display(ResourceType = typeof(LanguageResources), Name = "DisplayLanguagePicture")]
        public HttpPostedFileBase LanguagePicture { get; set; }
    }
}