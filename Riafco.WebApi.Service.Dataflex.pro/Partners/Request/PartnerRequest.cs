using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Partners.Request
{
    /// <summary>
    /// The Partner request class.
    /// </summary>
    [DataContract]
    public class PartnerRequest
    {
        /// <summary>
        /// Gets or Sets The PartnerDto requested.
        /// </summary>
        [DataMember]
        public PartnerDto PartnerDto { get; set; }

        /// <summary>
        /// Gets or sets The Find PartnerDto.
        /// </summary>
        [DataMember]
        public FindPartnerDto FindPartnerDto { get; set; }
    }
}