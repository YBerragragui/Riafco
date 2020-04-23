using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Request
{
    /// <summary>
    /// The SectionParagraph request class.
    /// </summary>
    [DataContract]
    public class SectionParagraphRequest
    {
        /// <summary>
        /// Gets or Sets The SectionParagraphDto requested.
        /// </summary>
        [DataMember]
        public SectionParagraphDto SectionParagraphDto { get; set; }

        /// <summary>
        /// Gets or sets The Find SectionParagraphDtoEnum.
        /// </summary>
        [DataMember]
        public FindSectionParagraphDto FindSectionParagraphDto { get; set; }
    }
}