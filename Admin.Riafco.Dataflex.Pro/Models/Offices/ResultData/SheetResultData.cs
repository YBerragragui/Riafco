using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.ResultData
{
    /// <summary>
    /// The ActivityParagraphResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class SheetResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets SheetDtoList.
        /// </summary>
        [DataMember]
        public List<SheetItemData> SheetDtoList { get; set; }

        /// <summary>
        /// Gets or sets SheetDto.
        /// </summary>
        [DataMember]
        public SheetItemData SheetDto { get; set; }
    }
}