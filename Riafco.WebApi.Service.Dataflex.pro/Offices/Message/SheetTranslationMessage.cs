using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Message
{
    /// <summary>
    ///    The SheetTranslation message class.
    /// </summary>
    [DataContract]
    public class SheetTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  SheetTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<SheetTranslationDto> SheetTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  SheetTranslationDto.
        /// </summary>
        [DataMember]
        public SheetTranslationDto SheetTranslationDto { get; set; }
    }
}