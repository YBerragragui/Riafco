using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.FormData
{
    /// <summary>
    /// The ActivityTranslationFormData class.
    /// </summary>
    public class ActivityTranslationFormData
    {
        /// <summary>
        /// Gets or sets TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets ActivityId.
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Gets or sets LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ActivityResources), ErrorMessageResourceName = nameof(ActivityResources.RequiredField))]
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets ActivityTitle.
        /// </summary>
        [Display(ResourceType = typeof(ActivityResources), Name = nameof(ActivityResources.DisplayActivityTitle))]
        [Required(ErrorMessageResourceType = typeof(ActivityResources), ErrorMessageResourceName = nameof(ActivityResources.RequiredActivityTitle))]
        public string ActivityTitle { get; set; }

        /// <summary>
        /// Gets or sets ActivityIntroduction.
        /// </summary>
        [Display(ResourceType = typeof(ActivityResources), Name = nameof(ActivityResources.DisplayActivityIntroduction))]
        [Required(ErrorMessageResourceType = typeof(ActivityResources), ErrorMessageResourceName = nameof(ActivityResources.RequiredActivityIntroduction))]
        public string ActivityIntroduction { get; set; }

        /// <summary>
        /// Gets or sets ActivityDescription.
        /// </summary>
        [Display(ResourceType = typeof(ActivityResources), Name = nameof(ActivityResources.DisplayActivityDescription))]
        [Required(ErrorMessageResourceType = typeof(ActivityResources), ErrorMessageResourceName = nameof(ActivityResources.RequiredActivityDescription))]
        public string ActivityDescription { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }
    }
}
