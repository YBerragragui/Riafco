using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.About.FormData
{
    /// <summary>
    /// The StepParagraphTranslationFormData class.
    /// </summary>
    public class StepParagraphTranslationFormData
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The ParagraphTitle.
        /// </summary>
        [Display(ResourceType = typeof(StepResources), Name = nameof(StepResources.DisplayTitle))]
        [Required(ErrorMessageResourceType = typeof(StepResources), ErrorMessageResourceName = "RequiredParagraphTitle")]
        public string ParagraphTitle { get; set; }

        /// <summary>
        /// Gets or Sets The ParagraphDescription.
        /// </summary>
        [Display(ResourceType = typeof(StepResources), Name = nameof(StepResources.DisplayDescription))]
        [Required(ErrorMessageResourceType = typeof(StepResources), ErrorMessageResourceName = "RequiredParagraphDescription")]
        public string ParagraphDescription { get; set; }

        #region navigation attributes
        /// <summary>
        /// Gets or Sets The LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(StepResources), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The ParagraphId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(StepResources), ErrorMessageResourceName = "RequiredParagraphId")]
        public int? ParagraphId { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }
        #endregion
    }
}