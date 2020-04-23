using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.ResultData
{
    /// <summary>
    /// The ThemeTranslationResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class ThemeTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets ThemeTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<ThemeTranslationItemData> ThemeTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets ThemeTranslationDto.
        /// </summary>
        [DataMember]
        public ThemeTranslationItemData ThemeTranslationDto { get; set; }
    }
}