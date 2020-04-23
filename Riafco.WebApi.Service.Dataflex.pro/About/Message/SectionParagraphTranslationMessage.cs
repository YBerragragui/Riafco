using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Message
{
    /// <summary>
    /// The SectionParagraphTraslation message class.
    /// </summary>
    [DataContract]
    public class SectionParagraphTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The SectionParagraphTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<SectionParagraphTranslationDto> SectionParagraphTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The SectionParagraphTranslationDto.
        /// </summary>
        [DataMember]
        public SectionParagraphTranslationDto SectionParagraphTranslationDto { get; set; }
    }
}