using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto.Enum;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Request
{
    /// <summary>
    /// The ActivityTranslation request class.
    /// </summary>
    [DataContract]
    public class ActivityTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The ActivityTranslationDto requested.
        /// </summary>
        [DataMember]
        public ActivityTranslationDto ActivityTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The ActivityTranslationDto requested.
        /// </summary>
        [DataMember]
        public List<ActivityTranslationDto> ActivityTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The FindActivityTranslationDto.
        /// </summary>
        [DataMember]
        public FindActivityTranslationDto FindActivityTranslationDto { get; set; }
    }
}