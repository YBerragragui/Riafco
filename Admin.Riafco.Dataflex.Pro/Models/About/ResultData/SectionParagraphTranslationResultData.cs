using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.About.ResultData
{
    /// <summary>
    /// The SectionParagraphTranslationResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class SectionParagraphTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets SectionParagraphTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<SectionParagraphTranslationItemData> SectionParagraphTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets SectionParagraphTranslationDto.
        /// </summary>
        [DataMember]
        public SectionParagraphTranslationItemData SectionParagraphTranslationDto { get; set; }
    }
}