using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.About.ResultData
{
    /// <summary>
    /// The UserResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class SectionTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets UserResultDataList.
        /// </summary>
        [DataMember]
        public List<SectionTranslationItemData> SectionTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets UserResultData
        /// </summary>
        [DataMember]
        public SectionTranslationItemData SectionTranslationDto { get; set; }
    }
}