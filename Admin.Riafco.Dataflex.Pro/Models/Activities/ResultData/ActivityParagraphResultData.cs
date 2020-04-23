using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.ResultData
{
    /// <summary>
    /// The ActivityParagraphResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class ActivityParagraphResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets ActivityParagraphDtoList.
        /// </summary>
        [DataMember]
        public List<ActivityParagraphItemData> ActivityParagraphDtoList { get; set; }

        /// <summary>
        /// Gets or sets ActivityParagraphDto.
        /// </summary>
        [DataMember]
        public ActivityParagraphItemData ActivityParagraphDto { get; set; }
    }
}