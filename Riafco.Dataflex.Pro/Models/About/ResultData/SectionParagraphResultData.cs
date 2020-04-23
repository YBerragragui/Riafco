using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Riafco.Dataflex.Pro.Models.About.ResultData
{
    /// <summary>
    /// The SectionParagraphResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class SectionParagraphResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets SectionParagraphDtoList.
        /// </summary>
        [DataMember]
        public List<SectionParagraphItemData> SectionParagraphDtoList { get; set; }

        /// <summary>
        /// Gets or sets SectionParagraphDto.
        /// </summary>
        [DataMember]
        public SectionParagraphItemData SectionParagraphDto { get; set; }
    }
}