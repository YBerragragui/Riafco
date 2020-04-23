using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Request
{
    /// <summary>
    /// The ThemeTranslation request class.
    /// </summary>
    [DataContract]
    public class ThemeTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The ThemeTranslationDto requested.
        /// </summary>
        [DataMember]
        public ThemeTranslationDto ThemeTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The ThemeTranslationDto requested.
        /// </summary>
        [DataMember]
        public List<ThemeTranslationDto> ThemeTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find ThemeTranslationDto.
        /// </summary>
        [DataMember]
        public FindThemeTranslationDto FindThemeTranslationDto { get; set; }
    }
}