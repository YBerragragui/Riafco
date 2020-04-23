using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Request
{
    /// <summary>
    /// The AreaTranslation request class.
    /// </summary>
    [DataContract]
    public class AreaTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The AreaTranslationDto requested.
        /// </summary>
        [DataMember]
        public AreaTranslationDto AreaTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The AreaTranslationDto requested.
        /// </summary>
        [DataMember]
        public List<AreaTranslationDto> AreaTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find AreaTranslationDto.
        /// </summary>
        [DataMember]
        public FindAreaTranslationDto FindAreaTranslationDto { get; set; }
    }
}