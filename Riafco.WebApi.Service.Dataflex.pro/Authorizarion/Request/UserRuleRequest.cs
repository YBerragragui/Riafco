using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto.Enum;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Request
{
    /// <summary>
    /// The UserRule request class.
    /// </summary>
    [DataContract]
    public class UserRuleRequest
    {
        /// <summary>
        /// Gets or Sets The UserRuleDto requested.
        /// </summary>
        [DataMember]
        public UserRuleDto UserRuleDto { get; set; }

        /// <summary>
        /// Gets or Sets The UserRuleDto requested.
        /// </summary>
        [DataMember]
        public List<UserRuleDto> UserRuleDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find UserRuleDto.
        /// </summary>
        [DataMember]
        public FindUserRuleDto FindUserRuleDto { get; set; }
    }
}