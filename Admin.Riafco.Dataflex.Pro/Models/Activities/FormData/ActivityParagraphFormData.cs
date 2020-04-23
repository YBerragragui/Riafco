
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.FormData
{
    /// <summary>
    /// The ActivityParagraphFormData class.
    /// </summary>
    public class ActivityParagraphFormData
    {
        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        public int ParagraphId { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphImage.
        /// </summary>
        [Display(ResourceType = typeof(ActivityParagraphResources), Name = nameof(ActivityParagraphResources.DisplayParagraphImage))]
        public HttpPostedFileBase ParagraphImage { get; set; }

        #region navigation proportises

        /// <summary>
        /// Gets or Sets The ActivityId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ActivityParagraphResources), ErrorMessageResourceName = "RequiredActivityId")]
        public int? ActivityId { get; set; }

        /// <summary>
        /// Gets or sets TranslationItemDataList.
        /// </summary>
        public List<ActivityParagraphTranslationFormData> TranslationsList { get; set; }

        #endregion
    }
}