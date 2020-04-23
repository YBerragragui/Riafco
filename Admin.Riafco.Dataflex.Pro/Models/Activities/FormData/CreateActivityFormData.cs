using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.FormData
{
    /// <summary>
    /// The CreateActivityFormData class
    /// </summary>
    public class CreateActivityFormData
    {
        /// <summary>
        /// Get or sets ActivityId.
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Gets or sets ActivityIcon.
        /// </summary>
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(ActivityResources), Name = nameof(ActivityResources.DisplayActivityIcon))]
        [Required(ErrorMessageResourceType = typeof(ActivityResources), ErrorMessageResourceName = nameof(ActivityResources.RequiredActivityIcon))]
        public HttpPostedFileBase ActivityIcon { get; set; }
        public string ActivityIconSource { get; set; }

        /// <summary>
        /// Gets or sets ActivityImage.
        /// </summary>
        [Display(ResourceType = typeof(ActivityResources), Name = nameof(ActivityResources.DisplayActivityImage))]
        [Required(ErrorMessageResourceType = typeof(ActivityResources), ErrorMessageResourceName = nameof(ActivityResources.RequiredActivityImage))]
        public HttpPostedFileBase ActivityImage { get; set; }
        public string ActivityImageSource { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<ActivityTranslationFormData> TranslationsList { get; set; }
    }
}
