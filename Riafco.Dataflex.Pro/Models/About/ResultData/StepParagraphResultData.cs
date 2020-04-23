using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.About.ResultData
{
    /// <summary>
    /// The SectionParagraphResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class StepParagraphResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets StepParagraphDto.
        /// </summary>
        [DataMember]
        public StepParagraphItemData StepParagraphDto { get; set; }

        /// <summary>
        /// Gets or sets StepParagraphDtoList.
        /// </summary>
        [DataMember]
        public List<StepParagraphItemData> StepParagraphDtoList { get; set; }
    }
}