using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Request
{
    /// <summary>
    /// The PublicationTranslation request class.
    /// </summary>
    [DataContract]
    public class PublicationTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The PublicationTranslationDto requested.
        /// </summary>
        [DataMember]
        public PublicationTranslationDto PublicationTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The PublicationTranslationDto requested.
        /// </summary>
        [DataMember]
        public List<PublicationTranslationDto> PublicationTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find PublicationTranslationDto.
        /// </summary>
        [DataMember]
        public FindPublicationTranslationDto FindPublicationTranslationDto { get; set; }
    }
}