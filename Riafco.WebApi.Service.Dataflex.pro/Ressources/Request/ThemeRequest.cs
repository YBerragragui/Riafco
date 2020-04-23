using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Request
{
    /// <summary>
    /// The Theme request class.
    /// </summary>
    [DataContract]
    public class ThemeRequest
    {
        /// <summary>
        /// Gets or Sets The ThemeDto requested.
        /// </summary>
        [DataMember]
        public ThemeDto ThemeDto { get; set; }

        /// <summary>
        /// Gets or sets The Find ThemeDto.
        /// </summary>
        [DataMember]
        public FindThemeDto FindThemeDto { get; set; }
    }
}