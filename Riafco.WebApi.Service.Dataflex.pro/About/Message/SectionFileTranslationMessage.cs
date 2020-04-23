using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Message
{
    /// <summary>
    ///    The SectionFileTranslation message class.
    /// </summary>
    [DataContract]
    public class SectionFileTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  SectionFileTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<SectionFileTranslationDto> SectionFileTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFileTranslationDto.
        /// </summary>
        [DataMember]
        public SectionFileTranslationDto SectionFileTranslationDto { get; set; }
    }
}