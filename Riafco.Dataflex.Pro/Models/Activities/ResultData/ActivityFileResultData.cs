using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Riafco.Dataflex.Pro.Models.Activities.ResultData
{
    /// <summary>
    /// The ActivityFileResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class ActivityFileResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets ActivityFileDtoList.
        /// </summary>
        [DataMember]
        public List<ActivityFileItemData> ActivityFileDtoList { get; set; }

        /// <summary>
        /// Gets or sets ActivityFileDto.
        /// </summary>
        [DataMember]
        public ActivityFileItemData ActivityFileDto { get; set; }
    }
}