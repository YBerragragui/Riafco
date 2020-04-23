using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Request
{
    /// <summary>
    /// The Section request class.
    /// </summary>
    [DataContract]
    public class SectionRequest
    {
        /// <summary>
        /// Gets or Sets The SectionDto requested.
        /// </summary>
        [DataMember]
        public SectionDto SectionDto { get; set; }

        /// <summary>
        /// Gets or sets The Find SectionDto.
        /// </summary>
        [DataMember]
        public FindSectionDto FindSectionDto { get; set; }
    }
}