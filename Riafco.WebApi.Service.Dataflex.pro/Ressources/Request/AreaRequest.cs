using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Request
{
    /// <summary>
    /// The Area request class.
    /// </summary>
    [DataContract]
    public class AreaRequest
    {
        /// <summary>
        /// Gets or Sets The AreaDto requested.
        /// </summary>
        [DataMember]
        public AreaDto AreaDto { get; set; }

        /// <summary>
        /// Gets or sets The Find AreaDto.
        /// </summary>
        [DataMember]
        public FindAreaDto FindAreaDto { get; set; }
    }
}