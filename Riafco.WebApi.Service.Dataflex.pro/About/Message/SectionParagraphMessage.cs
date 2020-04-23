using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Message
{
    /// <summary>
    /// The SectionParagraphMessage class.
    /// </summary>
    [DataContract]
    public class SectionParagraphMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  SectionParagraphDtoList.
        /// </summary>
        [DataMember]
        public List<SectionParagraphDto> SectionParagraphDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionParagraphDto.
        /// </summary>
        [DataMember]
        public SectionParagraphDto SectionParagraphDto { get; set; }
    }
}