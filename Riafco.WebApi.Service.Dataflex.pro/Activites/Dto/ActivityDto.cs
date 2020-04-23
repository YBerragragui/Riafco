using Riafco.WebApi.Service.Dataflex.pro.Activites.Ressource;
using System.ComponentModel.DataAnnotations;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Dto
{
    /// <summary>
    /// The Activity dto class.
    /// </summary>
    public class ActivityDto
    {
        /// <summary>
        /// Gets or Sets The  ActivityId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ActivityMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int ActivityId { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityIcon.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ActivityMessageResource), ErrorMessageResourceName = "RequiredIcon")]
        public string ActivityIcon { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityImage.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ActivityMessageResource), ErrorMessageResourceName = "RequiredImage")]
        public string ActivityImage { get; set; }
    }
}