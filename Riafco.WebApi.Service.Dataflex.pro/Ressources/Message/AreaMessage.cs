using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Message
{
    /// <summary>
    ///    The Area message class.
    /// </summary>
    [DataContract]
    public class AreaMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  AreaDtoList.
        /// </summary>
        [DataMember]
        public List<AreaDto> AreaDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  AreaDto.
        /// </summary>
        [DataMember]
        public AreaDto AreaDto { get; set; }
    }
}