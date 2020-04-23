using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Request
{
    /// <summary>
    /// The PublicationTheme request class.
    /// </summary>
    [DataContract]
    public class PublicationThemeRequest
    {
        /// <summary>
        /// Gets or Sets The PublicationThemeDto requested.
        /// </summary>
        [DataMember]
        public PublicationThemeDto PublicationThemeDto { get; set; }

        /// <summary>
        /// Gets or Sets The PublicationThemeDtoList requested.
        /// </summary>
        [DataMember]
        public List<PublicationThemeDto> PublicationThemeDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find PublicationThemeDto.
        /// </summary>
        [DataMember]
        public FindPublicationThemeDto FindPublicationThemeDto { get; set; }
    }
}