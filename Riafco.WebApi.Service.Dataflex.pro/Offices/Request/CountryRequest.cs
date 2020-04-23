using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Request
{
    /// <summary>
    /// The Country request class.
    /// </summary>
    [DataContract]
    public class CountryRequest
    {
        /// <summary>
        /// Gets or Sets The CountryDto requested.
        /// </summary>
        [DataMember]
        public CountryDto CountryDto { get; set; }

        /// <summary>
        /// Gets or sets The Find CountryDto.
        /// </summary>
        [DataMember]
        public FindCountryDto FindCountryDto { get; set; }
    }
}