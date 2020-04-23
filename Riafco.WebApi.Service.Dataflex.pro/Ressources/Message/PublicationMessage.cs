using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Message
{
    /// <summary>
    /// The Publication message class.
    /// </summary>
    [DataContract]
    public class PublicationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  PublicationDtoList.
        /// </summary>
        [DataMember]
        public List<PublicationDto> PublicationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationDto.
        /// </summary>
        [DataMember]
        public PublicationDto PublicationDto { get; set; }
    }
}