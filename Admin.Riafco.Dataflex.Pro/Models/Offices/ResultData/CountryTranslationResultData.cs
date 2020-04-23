using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.ResultData
{
    /// <summary>
    /// The UserResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class CountryTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets UserResultDataList.
        /// </summary>
        [DataMember]
        public List<CountryTranslationItemData> CountryTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets UserResultData
        /// </summary>
        [DataMember]
        public CountryTranslationItemData CountryTranslationDto { get; set; }
    }
}