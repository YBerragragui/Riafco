using Riafco.Dataflex.Pro.Models.News.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.News.ResultData
{
    /// <summary>
    /// The UserResultData class
    /// </summary>
    [DataContract, Serializable]
    public class NewsResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets UserResultDataList
        /// </summary>
        [DataMember]
        public List<NewsItemData> NewsDtoList { get; set; }

        /// <summary>
        /// Gets or sets UserResultData
        /// </summary>
        [DataMember]
        public NewsItemData NewsDto { get; set; }
    }
}