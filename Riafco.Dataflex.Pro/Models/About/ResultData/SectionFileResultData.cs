using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Riafco.Dataflex.Pro.Models.About.ResultData
{
    /// <summary>
    /// The SectionFileResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class SectionFileResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets SectionFileDtoList.
        /// </summary>
        [DataMember]
        public List<SectionFileItemData> SectionFileDtoList { get; set; }

        /// <summary>
        /// Gets or sets SectionFileDto.
        /// </summary>
        [DataMember]
        public SectionFileItemData SectionFileDto { get; set; }
    }
}