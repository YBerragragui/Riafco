using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Request
{
    /// <summary>
    /// The SheetTranslation request class.
    /// </summary>
    [DataContract]
    public class SheetTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The SheetTranslationDto requested.
        /// </summary>
        [DataMember]
        public SheetTranslationDto SheetTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The SheetTranslationDto requested.
        /// </summary>
        [DataMember]
        public List<SheetTranslationDto> SheetTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find SheetTranslationDto.
        /// </summary>
        [DataMember]
        public FindSheetTranslationDto FindSheetTranslationDto { get; set; }
    }
}