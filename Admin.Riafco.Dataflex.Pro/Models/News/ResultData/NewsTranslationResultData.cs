using Admin.Riafco.Dataflex.Pro.Models.News.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.News.ResultData
{
    /// <summary>
    /// The UserResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class NewsTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets UserResultDataList.
        /// </summary>
        [DataMember]
        public List<NewsTranslationItemData> NewsTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets UserResultData
        /// </summary>
        [DataMember]
        public NewsTranslationItemData NewsTranslationDto { get; set; }
    }
}