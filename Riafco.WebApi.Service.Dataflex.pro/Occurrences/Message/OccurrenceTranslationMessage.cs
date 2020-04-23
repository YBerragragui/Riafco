using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Occurrences.Message
{
    /// <summary>
    ///    The OccurrenceTranslation message class.
    /// </summary>
    [DataContract]
    public class OccurrenceTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  OccurrenceTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<OccurrenceTranslationDto> OccurrenceTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrenceTranslationDto.
        /// </summary>
        [DataMember]
        public OccurrenceTranslationDto OccurrenceTranslationDto { get; set; }
    }
}