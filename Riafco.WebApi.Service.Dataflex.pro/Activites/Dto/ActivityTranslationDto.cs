using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;
using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Dto
{
    /// <summary>
    /// The ActivityTranslation dto class.
    /// </summary>
    public class ActivityTranslationDto
    {
        /// <summary>
        /// Gets or Sets The  TraductionId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ActivityMessageResource), ErrorMessageResourceName = "RequiredTranslateId")]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityTitle.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ActivityMessageResource), ErrorMessageResourceName = "RequiredTitle")]
        public string ActivityTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityIntroduction.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ActivityMessageResource), ErrorMessageResourceName = "RequiredIntroduction")]
        public string ActivityIntroduction { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityDescription.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ActivityMessageResource), ErrorMessageResourceName = "RequiredDescription")]
        public string ActivityDescription { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ActivityMessageResource), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageDto Language { get; set; }
        /// <summary>
        /// Gets or Sets The  ActivityId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ActivityMessageResource), ErrorMessageResourceName = "RequiredActivityId")]
        public int? ActivityId { get; set; }

        /// <summary>
        /// Gets or Sets The  Activity.
        /// </summary>
        public ActivityDto Activity { get; set; }

        #endregion
    }
}