using Riafco.Framework.Dataflex.pro.Communication.Messages;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Message
{
    /// <summary>
    /// The User message class.
    /// </summary>
    [DataContract]
    public class UserMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The UserDtoList.
        /// </summary>
        [DataMember]
        public List<UserDto> UserDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  UserDto.
        /// </summary>
        [DataMember]
        public UserDto UserDto { get; set; }
    }
}