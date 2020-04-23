using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Riafco.Dataflex.Pro.Models.About.ResultData
{
    /// <summary>
    /// The SectionFileTranslationResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class SectionFileTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets SectionFileTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<SectionFileTranslationItemData> SectionFileTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets SectionParagraphDto.
        /// </summary>
        [DataMember]
        public SectionFileTranslationItemData SectionFileTranslationDto { get; set; }
    }
}