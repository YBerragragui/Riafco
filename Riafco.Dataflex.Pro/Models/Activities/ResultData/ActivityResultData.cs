using Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.Activities.ResultData
{
    /// <summary>
    /// The UserResultData class
    /// </summary>
    [DataContract, Serializable]
    public class ActivityResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets ActivityDtoList
        /// </summary>
        [DataMember]
        public List<ActivityItemData> ActivityDtoList { get; set; }

        /// <summary>
        /// Gets or sets ActivityDto
        /// </summary>
        [DataMember]
        public ActivityItemData ActivityDto { get; set; }
    }
}