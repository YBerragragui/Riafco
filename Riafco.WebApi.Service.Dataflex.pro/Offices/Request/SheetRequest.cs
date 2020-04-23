using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Request
{
    /// <summary>
    /// The Sheet request class.
    /// </summary>
    [DataContract]
    public class SheetRequest
    {
        /// <summary>
        /// Gets or Sets The SheetDto requested.
        /// </summary>
        [DataMember]
        public SheetDto SheetDto { get; set; }

        /// <summary>
        /// Gets or sets The Find SheetDto.
        /// </summary>
        [DataMember]
        public FindSheetDto FindSheetDto { get; set; }
    }
}