using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.FormData
{
    /// <summary>
    /// The ActivityFileTranslationFormData class.
    /// </summary>
    public class CreateActivityFileTranslationFormData
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The ActivityFileSource.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(FileResources), ErrorMessageResourceName = "RequiredActivityFileSource")]
        [Display(ResourceType = typeof(FileResources), Name = nameof(FileResources.DisplayActivityFileSource))]
        public HttpPostedFileBase ActivityFileSource { get; set; }
        public string ActivityFileSourceValue { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityFileText.
        /// </summary>
        [Display(ResourceType = typeof(FileResources), Name = nameof(FileResources.DisplayActivityFileText))]
        [Required(ErrorMessageResourceType = typeof(FileResources), ErrorMessageResourceName = "RequiredActivityFileText")]
        public string ActivityFileText { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The ActivityFileId.
        /// </summary>
        public int? ActivityFileId { get; set; }

        /// <summary>
        /// Gets or Sets The LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(FileResources), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }

        #endregion
    }
}