using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData.Enum;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.Authorization.RequestData
{
    /// <summary>
    /// The UserRule request class.
    /// </summary>
    [DataContract]
    public class UserRuleRequestData
    {
        /// <summary>
        /// Gets or Sets The UserRuleDto requested.
        /// </summary>
        [DataMember]
        public UserRuleItemData UserRuleDto { get; set; }

        /// <summary>
        /// Gets or Sets The UserRuleDto requested.
        /// </summary>
        [DataMember]
        public List<UserRuleItemData> UserRuleDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find UserRuleDtoEnum.
        /// </summary>
        [DataMember]
        public FindUserRuleItemData FindUserRuleDto { get; set; }
    }
}