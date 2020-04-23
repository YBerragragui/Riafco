using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Message
{
    /// <summary>
    ///    The Country message class.
    /// </summary>
    [DataContract]
    public class CountryMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  CountryDtoList.
        /// </summary>
        [DataMember]
        public List<CountryDto> CountryDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryDto.
        /// </summary>
        [DataMember]
        public CountryDto CountryDto { get; set; }
    }
}