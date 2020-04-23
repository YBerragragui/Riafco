using Riafco.Framework.Dataflex.pro.Communication.Messages;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Message
{
    /// <summary>
    /// The Rule message class.
    /// </summary>
    [DataContract]
    public class RuleMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The RuleDtoList.
        /// </summary>
        [DataMember]
        public List<RuleDto> RuleDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  RuleDto.
        /// </summary>
        [DataMember]
        public RuleDto RuleDto { get; set; }
    }
}