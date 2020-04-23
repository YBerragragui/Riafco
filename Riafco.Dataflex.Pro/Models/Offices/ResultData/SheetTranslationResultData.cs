using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Offices.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Riafco.Dataflex.Pro.Models.Offices.ResultData
{
    /// <summary>
    /// The SheetTranslationResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class SheetTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets SheetTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<SheetTranslationItemData> SheetTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets SheetTranslationDto.
        /// </summary>
        [DataMember]
        public SheetTranslationItemData SheetTranslationDto { get; set; }
    }
}