using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.ResultData
{
    /// <summary>
    /// The UserResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class ActivityTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets UserResultDataList.
        /// </summary>
        [DataMember]
        public List<ActivityTranslationItemData> ActivityTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets UserResultData
        /// </summary>
        [DataMember]
        public ActivityTranslationItemData ActivityTranslationDto { get; set; }
    }
}