using Riafco.Dataflex.Pro.Models.Partners.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.Partners.ResultData
{
    /// <summary>
    /// The UserResultData class
    /// </summary>
    [DataContract, Serializable]
    public class PartnerResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets PartnerDtoList
        /// </summary>
        [DataMember]
        public List<PartnerItemData> PartnerDtoList { get; set; }

        /// <summary>
        /// Gets or sets PartnerDto
        /// </summary>
        [DataMember]
        public PartnerItemData PartnerDto { get; set; }
    }
}