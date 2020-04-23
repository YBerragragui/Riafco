using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Occurrences.Message
{
    /// <summary>
    ///    The Occurrence message class.
    /// </summary>
    [DataContract]
    public class OccurrenceMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  OccurrenceDtoList.
        /// </summary>
        [DataMember]
        public List<OccurrenceDto> OccurrenceDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrenceDto.
        /// </summary>
        [DataMember]
        public OccurrenceDto OccurrenceDto { get; set; }
    }
}