using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.ResultData
{
    /// <summary>
    /// The ActivityParagraphTranslationResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class ActivityParagraphTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets ActivityParagraphTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<ActivityParagraphTranslationItemData> ActivityParagraphTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets ActivityParagraphTranslationDto.
        /// </summary>
        [DataMember]
        public ActivityParagraphTranslationItemData ActivityParagraphTranslationDto { get; set; }
    }
}