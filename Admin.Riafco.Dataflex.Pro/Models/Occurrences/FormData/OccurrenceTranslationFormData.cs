using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.Occurrences.FormData
{
    /// <summary>
    /// The OccurrenceTranslationFormData class.
    /// </summary>
    public class OccurrenceTranslationFormData
    {
        /// <summary>
        /// Gets or sets TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets OccurrenceId.
        /// </summary>
        public int OccurrenceId { get; set; }

        /// <summary>
        /// Gets or sets LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(OccurrenceResources), ErrorMessageResourceName = nameof(OccurrenceResources.RequiredField))]
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets OccurrenceTitle.
        /// </summary>
        [Display(ResourceType = typeof(OccurrenceResources), Name = nameof(OccurrenceResources.DisplayOccurrenceTitle))]
        [Required(ErrorMessageResourceType = typeof(OccurrenceResources), ErrorMessageResourceName = nameof(OccurrenceResources.RequiredOccurrenceTitle))]
        public string OccurrenceTitle { get; set; }

        /// <summary>
        /// Gets or sets OccurrenceDescription.
        /// </summary>
        [Display(ResourceType = typeof(OccurrenceResources), Name = nameof(OccurrenceResources.DisplayOccurrenceDescription))]
        [MaxLength(150, ErrorMessageResourceType = typeof(OccurrenceResources), ErrorMessageResourceName = nameof(OccurrenceResources.MaxLength))]
        [Required(ErrorMessageResourceType = typeof(OccurrenceResources), ErrorMessageResourceName = nameof(OccurrenceResources.RequiredOccurrenceDescription))]
        public string OccurrenceDescription { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }
    }
}
