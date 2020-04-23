using Riafco.Dataflex.Pro.Models.Occurrences.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.Occurrences.ResultData
{
    /// <summary>
    /// The UserResultData class
    /// </summary>
    [DataContract, Serializable]
    public class OccurrenceResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets OccurrenceDtoList
        /// </summary>
        [DataMember]
        public List<OccurrenceItemData> OccurrenceDtoList { get; set; }

        /// <summary>
        /// Gets or sets OccurrenceDto
        /// </summary>
        [DataMember]
        public OccurrenceItemData OccurrenceDto { get; set; }
    }
}