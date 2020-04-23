using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Request
{
    /// <summary>
    /// The SectionParagraphTraslation request class.
    /// </summary>
    [DataContract]
    public class SectionParagraphTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The SectionParagraphTraslationDto requested.
        /// </summary>
        [DataMember]
        public SectionParagraphTranslationDto SectionParagraphTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets SectionParagraphTranslationDtoList requested.
        /// </summary>
        [DataMember]
        public List<SectionParagraphTranslationDto> SectionParagraphTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets FindSectionParagraphTranslationDto.
        /// </summary>
        [DataMember]
        public FindSectionParagraphTranslationDto FindSectionParagraphTranslationDto { get; set; }
    }
}