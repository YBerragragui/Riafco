using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.About.ResultData
{
    /// <summary>
    /// The SectionParagraphTranslationResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class StepParagraphTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets StepParagraphTranslationDto.
        /// </summary>
        [DataMember]
        public StepParagraphTranslationItemData StepParagraphTranslationDto { get; set; }

        /// <summary>
        /// Gets or sets StepParagraphTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<StepParagraphTranslationItemData> StepParagraphTranslationDtoList { get; set; }
    }
}