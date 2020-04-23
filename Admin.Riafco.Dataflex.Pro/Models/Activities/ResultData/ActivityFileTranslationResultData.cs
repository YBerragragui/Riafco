using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.ResultData
{
    /// <summary>
    /// The ActivityFileTranslationResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class ActivityFileTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets ActivityFileTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<ActivityFileTranslationItemData> ActivityFileTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets ActivityParagraphDto.
        /// </summary>
        [DataMember]
        public ActivityFileTranslationItemData ActivityFileTranslationDto { get; set; }
    }
}