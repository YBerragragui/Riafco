using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Dto
{
    /// <summary>
    /// The ActivityParagraph dto class.
    /// </summary>
    public class ActivityParagraphDto
    {
        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ParagraphMessageResource), ErrorMessageResourceName = "RequiredParagraphId")]
        public int ParagraphId { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphImage.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ParagraphMessageResource), ErrorMessageResourceName = "RequiredParagraphImage")]
        public string ParagraphImage { get; set; }

        #region navigation proportises

        /// <summary>
        /// Gets or Sets The  ActivityId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ParagraphMessageResource), ErrorMessageResourceName = "RequiredActivityId")]
        public int? ActivityId { get; set; }

        /// <summary>
        /// Gets or Sets The  Activity.
        /// </summary>
        public ActivityDto Activity { get; set; }

        #endregion
    }
}