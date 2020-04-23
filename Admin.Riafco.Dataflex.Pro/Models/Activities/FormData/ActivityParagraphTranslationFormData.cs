using System.ComponentModel.DataAnnotations;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.FormData
{
    /// <summary>
    /// The ActivityParagraphTranslationFormData class.
    /// </summary>
    public class ActivityParagraphTranslationFormData
    {
        /// <summary>
        /// Gets or Sets The TraslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphTitle.
        /// </summary>
        [Display(ResourceType = typeof(ActivityParagraphResources), Name = nameof(ActivityParagraphResources.DisplayParagraphTitle))]
        [Required(ErrorMessageResourceType = typeof(ActivityParagraphResources), ErrorMessageResourceName = "RequiredParagraphTitle")]
        public string ParagraphTitle { get; set; }

        /// <summary>
        /// Gets or Sets The ParagraphDescription.
        /// </summary>
        [Display(ResourceType = typeof(ActivityParagraphResources), Name = nameof(ActivityParagraphResources.DisplayParagraphDescription))]
        [Required(ErrorMessageResourceType = typeof(ActivityParagraphResources), ErrorMessageResourceName = "RequiredParagraphDescription")]
        public string ParagraphDescription { get; set; }

        /// <summary>
        /// Gets or Sets The LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ActivityParagraphResources), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ActivityParagraphResources), ErrorMessageResourceName = "RequiredParagraphId")]
        public int? ParagraphId { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }
    }
}