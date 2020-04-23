using Riafco.Dataflex.Pro.Models.Settings.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.Settings.ResultData
{
    /// <summary>
    /// The UserResultData class
    /// </summary>
    [DataContract(), Serializable()]
    public class LanguageResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets UserResultDataList
        /// </summary>
        [DataMember]
        public List<LanguageItemData> LanguageDtoList { get; set; }

        /// <summary>
        /// Gets or sets UserResultData
        /// </summary>
        [DataMember]
        public LanguageItemData LanguageDto { get; set; }
    }
}