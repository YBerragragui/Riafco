using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Message
{
    /// <summary>
    ///    The Section message class.
    /// </summary>
    [DataContract]
    public class SectionMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  SectionDtoList.
        /// </summary>
        [DataMember]
        public List<SectionDto> SectionDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionDto.
        /// </summary>
        [DataMember]
        public SectionDto SectionDto { get; set; }
    }
}