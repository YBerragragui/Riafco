using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Message
{
    /// <summary>
    ///    The SectionFile message class.
    /// </summary>
    [DataContract]
    public class SectionFileMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  SectionFileDtoList.
        /// </summary>
        [DataMember]
        public List<SectionFileDto> SectionFileDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFileDto.
        /// </summary>
        [DataMember]
        public SectionFileDto SectionFileDto { get; set; }
    }
}