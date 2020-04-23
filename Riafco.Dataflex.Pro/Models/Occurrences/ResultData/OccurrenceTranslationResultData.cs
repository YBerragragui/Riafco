using Riafco.Dataflex.Pro.Models.Occurrences.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.Occurrences.ResultData
{
    /// <summary>
    /// The UserResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class OccurrenceTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets UserResultDataList.
        /// </summary>
        [DataMember]
        public List<OccurrenceTranslationItemData> OccurrenceTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets UserResultData
        /// </summary>
        [DataMember]
        public OccurrenceTranslationItemData OccurrenceTranslationDto { get; set; }
    }
}