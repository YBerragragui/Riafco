using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Occurrences.Request
{
    /// <summary>
    /// The Occurrence request class.
    /// </summary>
    [DataContract]
    public class OccurrenceRequest
    {
        /// <summary>
        /// Gets or Sets The OccurrenceDto requested.
        /// </summary>
        [DataMember]
        public OccurrenceDto OccurrenceDto { get; set; }

        /// <summary>
        /// Gets or sets The Find OccurrenceDto.
        /// </summary>
        [DataMember]
        public FindOccurrenceDto FindOccurrenceDto { get; set; }
    }
}