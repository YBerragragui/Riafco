using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.About.ResultData
{
    /// <summary>
    /// The UserResultData class
    /// </summary>
    [DataContract, Serializable]
    public class SectionResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets SectionDtoList
        /// </summary>
        [DataMember]
        public List<SectionItemData> SectionDtoList { get; set; }

        /// <summary>
        /// Gets or sets SectionDto
        /// </summary>
        [DataMember]
        public SectionItemData SectionDto { get; set; }
    }
}