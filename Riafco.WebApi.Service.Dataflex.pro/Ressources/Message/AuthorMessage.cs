using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Message
{
    /// <summary>
    /// The Author message class.
    /// </summary>
    [DataContract]
    public class AuthorMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  AuthorDtoList.
        /// </summary>
        [DataMember]
        public List<AuthorDto> AuthorDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  AuthorDto.
        /// </summary>
        [DataMember]
        public AuthorDto AuthorDto { get; set; }
    }
}