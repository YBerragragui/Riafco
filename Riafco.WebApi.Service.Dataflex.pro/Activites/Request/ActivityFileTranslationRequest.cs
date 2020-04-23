using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Request
{
    /// <summary>
    /// The ActivityFileTranslation request class.
    /// </summary>
    [DataContract]
    public class ActivityFileTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The ActivityFileTranslationDto requested.
        /// </summary>
        [DataMember]
        public ActivityFileTranslationDto ActivityFileTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The ActivityFileTranslationDto requested.
        /// </summary>
        [DataMember]
        public List<ActivityFileTranslationDto> ActivityFileTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find ActivityFileTranslationDto.
        /// </summary>
        [DataMember]
        public FindActivityFileTranslationDto FindActivityFileTranslationDto { get; set; }
    }
}