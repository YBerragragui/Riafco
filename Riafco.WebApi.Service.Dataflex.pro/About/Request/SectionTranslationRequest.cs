using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Request
{
    /// <summary>
    /// The SectionTranslation request class.
    /// </summary>
    [DataContract]
    public class SectionTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The SectionTranslationDto requested.
        /// </summary>
        [DataMember]
        public SectionTranslationDto SectionTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The SectionTranslationDtoList requested.
        /// </summary>
        [DataMember]
        public List<SectionTranslationDto> SectionTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find SectionTranslationDto.
        /// </summary>
        [DataMember]
        public FindSectionTranslationDto FindSectionTranslationDto { get; set; }
    }
}