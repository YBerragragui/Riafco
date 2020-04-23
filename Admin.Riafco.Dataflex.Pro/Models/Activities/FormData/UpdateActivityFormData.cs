using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.FormData
{
    /// <summary>
    /// The ActivityFormData class
    /// </summary>
    public class UpdateActivityFormData
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
        public HttpPostedFileBase ActivityIcon { get; set; }
        public string ActivityIconSource { get; set; }

        /// <summary>
        /// Gets or sets ActivityImage.
        /// </summary>
        [Display(ResourceType = typeof(ActivityResources), Name = nameof(ActivityResources.DisplayActivityImage))]
        public HttpPostedFileBase ActivityImage { get; set; }
        public string ActivityImageSource { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<ActivityTranslationFormData> TranslationsList { get; set; }
    }
}
