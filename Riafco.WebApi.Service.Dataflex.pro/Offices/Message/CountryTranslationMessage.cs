using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Message
{
    /// <summary>
    ///    The CountryTranslation message class.
    /// </summary>
    [DataContract]
    public class CountryTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  CountryTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<CountryTranslationDto> CountryTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryTranslationDto.
        /// </summary>
        [DataMember]
        public CountryTranslationDto CountryTranslationDto { get; set; }
    }
}