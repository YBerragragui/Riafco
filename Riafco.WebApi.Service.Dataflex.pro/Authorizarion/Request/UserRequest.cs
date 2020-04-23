using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto.Enum;
using System.Runtime.Serialization;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Request
{
    /// <summary>
    /// The User request class.
    /// </summary>
    [DataContract]
    public class UserRequest
    {
        /// <summary>
        /// Gets or Sets The UserDto requested.
        /// </summary>
        [DataMember]
        public UserDto UserDto { get; set; }

        /// <summary>
        /// Gets or sets The Find UserDto.
        /// </summary>
        [DataMember]
        public FindUserDto FindUserDto { get; set; }
    }
}