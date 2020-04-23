using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.Authorization.ResultData
{
    /// <summary>
    /// The RuleResultData class
    /// </summary>
    [DataContract(), Serializable()]
    public class UserRuleResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets RuleResultDataList
        /// </summary>
        [DataMember]
        public List<UserRuleItemData> UserRuleDtoList { get; set; }

        /// <summary>
        /// Gets or sets RuleResultData
        /// </summary>
        [DataMember]
        public UserRuleItemData UserRuleDto { get; set; }
    }
}