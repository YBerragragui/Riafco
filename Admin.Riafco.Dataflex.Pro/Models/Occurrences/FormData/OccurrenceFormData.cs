using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.Occurrences.FormData
{
    /// <summary>
    /// The OccurrenceFormData class.
    /// </summary>
    public class OccurrenceFormData
    {
        /// <summary>
        /// Get or sets OccurrenceId.
        /// </summary>
        public int OccurrenceId { get; set; }

        /// <summary>
        /// Gets or sets OccurrenceStartDate.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(OccurrenceResources), ErrorMessageResourceName = nameof(OccurrenceResources.RequiredOccurrenceDate))]
        [Display(ResourceType = typeof(OccurrenceResources), Name = nameof(OccurrenceResources.DisplayOccurrenceStartDate))]
        [RegularExpression(@"((0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/([0-9])*)", ErrorMessageResourceType = typeof(OccurrenceResources), ErrorMessageResourceName = nameof(OccurrenceResources.InvalideDate))]
        public string OccurrenceStartDate { get; set; }

        /// <summary>
        /// Gets or sets OccurrenceEndDate.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(OccurrenceResources), ErrorMessageResourceName = nameof(OccurrenceResources.RequiredOccurrenceDate))]
        [Display(ResourceType = typeof(OccurrenceResources), Name = nameof(OccurrenceResources.DisplayOccurrenceEndDate))]
        [RegularExpression(@"((0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/([0-9])*)", ErrorMessageResourceType = typeof(OccurrenceResources), ErrorMessageResourceName = nameof(OccurrenceResources.InvalideDate))]
        public string OccurrenceEndDate { get; set; }

        /// <summary>
        /// Gets or sets OccurrenceLink.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(OccurrenceResources), ErrorMessageResourceName = nameof(OccurrenceResources.RequiredOccurrenceLink))]
        [Display(ResourceType = typeof(OccurrenceResources), Name = nameof(OccurrenceResources.DisplayOccurrenceLink))]
        public string OccurrenceLink { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<OccurrenceTranslationFormData> TranslationsList { get; set; }
    }
}
