using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Riafco.Dataflex.Pro.Models.Ressources.ResultData
{
    /// <summary>
    /// The ThemeResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class ThemeResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets ThemeDtoList.
        /// </summary>
        [DataMember]
        public List<ThemeItemData> ThemeDtoList { get; set; }

        /// <summary>
        /// Gets or sets ThemeDto.
        /// </summary>
        [DataMember]
        public ThemeItemData ThemeDto { get; set; }
    }
}