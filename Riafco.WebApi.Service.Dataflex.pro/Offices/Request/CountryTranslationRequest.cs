using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Request
{
    /// <summary>
    /// The CountryTranslation request class.
    /// </summary>
    [DataContract]
    public class CountryTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The CountryTranslationDto requested.
        /// </summary>
        [DataMember]
        public CountryTranslationDto CountryTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The CountryTranslationDtoList requested.
        /// </summary>
        [DataMember]
        public List<CountryTranslationDto> CountryTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find CountryTranslationDto.
        /// </summary>
        [DataMember]
        public FindCountryTranslationDto FindCountryTranslationDto { get; set; }
    }
}