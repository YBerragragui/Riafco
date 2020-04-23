using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.ResultData
{
    /// <summary>
    /// The UserResultData class
    /// </summary>
    [DataContract, Serializable]
    public class CountryResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets CountryDtoList
        /// </summary>
        [DataMember]
        public List<CountryItemData> CountryDtoList { get; set; }

        /// <summary>
        /// Gets or sets CountryDto
        /// </summary>
        [DataMember]
        public CountryItemData CountryDto { get; set; }
    }
}