
using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Dto
{
    /// <summary>
    /// The ActivityFile dto class.
    /// </summary>
    public class ActivityFileDto
    {
        /// <summary>
        /// Gets or Sets The  ActivityFileId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(FileMessageResource), ErrorMessageResourceName = "RequiredFileActivityId")]
        public int ActivityFileId { get; set; }

        #region navigation attributes

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