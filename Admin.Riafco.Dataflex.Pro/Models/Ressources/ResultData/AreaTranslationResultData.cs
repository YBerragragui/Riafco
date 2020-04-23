using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.ResultData
{
    /// <summary>
    /// The AreaTranslationResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class AreaTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets AreaTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<AreaTranslationItemData> AreaTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets AreaTranslationDto.
        /// </summary>
        [DataMember]
        public AreaTranslationItemData AreaTranslationDto { get; set; }
    }
}