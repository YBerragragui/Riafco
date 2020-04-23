using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Partners.Message
{
    /// <summary>
    ///    The Partner message class.
    /// </summary>
    [DataContract]
    public class PartnerMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  PartnerDtoList.
        /// </summary>
        [DataMember]
        public List<PartnerDto> PartnerDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  PartnerDto.
        /// </summary>
        [DataMember]
        public PartnerDto PartnerDto { get; set; }
    }
}