using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Message
{
    /// <summary>
    ///    The Sheet message class.
    /// </summary>
    [DataContract]
    public class SheetMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  SheetDtoList.
        /// </summary>
        [DataMember]
        public List<SheetDto> SheetDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  SheetDto.
        /// </summary>
        [DataMember]
        public SheetDto SheetDto { get; set; }
    }
}