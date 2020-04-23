using Admin.Riafco.Dataflex.Pro.Models.Newsletters.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.Newsletters.ResultData
{
    /// <summary>
    /// The UserResultData class
    /// </summary>
    [DataContract, Serializable]
    public class SubscriberResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets SubscriberDtoList
        /// </summary>
        [DataMember]
        public List<SubscriberItemData> SubscriberDtoList { get; set; }

        /// <summary>
        /// Gets or sets SubscriberDto
        /// </summary>
        [DataMember]
        public SubscriberItemData SubscriberDto { get; set; }
    }
}