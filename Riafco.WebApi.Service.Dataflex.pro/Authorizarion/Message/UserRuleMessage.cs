using Riafco.Framework.Dataflex.pro.Communication.Messages;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Message
{
    /// <summary>
    /// The UserRule message class.
    /// </summary>
    [DataContract]
    public class UserRuleMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The UserRuleDtoList.
        /// </summary>
        [DataMember]
        public List<UserRuleDto> UserRuleDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  UserRuleDto.
        /// </summary>
        [DataMember]
        public UserRuleDto UserRuleDto { get; set; }
    }
}