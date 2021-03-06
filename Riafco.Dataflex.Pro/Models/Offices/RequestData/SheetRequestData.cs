﻿using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Offices.ItemData;
using Riafco.Dataflex.Pro.Models.Offices.ItemData.Enum;

namespace Riafco.Dataflex.Pro.Models.Offices.RequestData
{
    /// <summary>
    /// The SheetRequestData class.
    /// </summary>
    [DataContract]
    public class SheetRequestData
    {
        /// <summary>
        /// Gets or sets SheetDto.
        /// </summary>
        [DataMember]
        public SheetItemData SheetDto { get; set; }

        /// <summary>
        /// Gets or sets FindSheetDto.
        /// </summary>
        [DataMember]
        public FindSheetItemData FindSheetDto { get; set; }
    }
}