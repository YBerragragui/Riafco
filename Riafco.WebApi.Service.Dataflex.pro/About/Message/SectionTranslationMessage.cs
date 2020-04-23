using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Message
{
    /// <summary>
    ///    The SectionTranslation message class.
    /// </summary>
    [DataContract]
    public class SectionTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  SectionTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<SectionTranslationDto> SectionTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionTranslationDto.
        /// </summary>
        [DataMember]
        public SectionTranslationDto SectionTranslationDto { get; set; }
    }
}