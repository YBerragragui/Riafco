using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Occurrences.Request
{
    /// <summary>
    /// The OccurrenceTranslation request class.
    /// </summary>
    [DataContract]
    public class OccurrenceTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The OccurrenceTranslationDto requested.
        /// </summary>
        [DataMember]
        public OccurrenceTranslationDto OccurrenceTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The OccurrenceTranslationDto requested.
        /// </summary>
        [DataMember]
        public List<OccurrenceTranslationDto> OccurrenceTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find OccurrenceTranslationDto.
        /// </summary>
        [DataMember]
        public FindOccurrenceTranslationDto FindOccurrenceTranslationDto { get; set; }
    }
}