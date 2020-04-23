using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.Settings.ResultData
{
    /// <summary>
    /// The RuleResultData class
    /// </summary>
    [DataContract(), Serializable()]
    public class RuleResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets RuleResultDataList
        /// </summary>
        [DataMember]
        public List<RuleItemData> RuleDtoList { get; set; }

        /// <summary>
        /// Gets or sets RuleResultData
        /// </summary>
        [DataMember]
        public RuleItemData RuleDto { get; set; }
    }
}