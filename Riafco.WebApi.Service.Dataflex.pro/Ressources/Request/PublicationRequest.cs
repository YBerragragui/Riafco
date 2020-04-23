using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Request
{
    /// <summary>
    /// The Publication request class.
    /// </summary>
    [DataContract]
    public class PublicationRequest
    {
        /// <summary>
        /// Gets or Sets The PublicationDto requested.
        /// </summary>
        [DataMember]
        public PublicationDto PublicationDto { get; set; }

        /// <summary>
        /// Gets or sets The Find PublicationDto.
        /// </summary>
        [DataMember]
        public FindPublicationDto FindPublicationDto { get; set; }
    }
}