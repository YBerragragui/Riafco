using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Request
{
    /// <summary>
    /// The SectionFileTranslation request class.
    /// </summary>
    [DataContract]
    public class SectionFileTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The SectionFileTranslationDto requested.
        /// </summary>
        [DataMember]
        public SectionFileTranslationDto SectionFileTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The SectionFileTranslationDto requested.
        /// </summary>
        [DataMember]
        public List<SectionFileTranslationDto> SectionFileTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find SectionFileTranslationDto.
        /// </summary>
        [DataMember]
        public FindSectionFileTranslationDto FindSectionFileTranslationDto { get; set; }
    }
}