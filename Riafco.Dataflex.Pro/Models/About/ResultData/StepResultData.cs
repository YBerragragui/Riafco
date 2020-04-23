using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.About.ResultData
{
    /// <summary>
    /// The UserResultData class
    /// </summary>
    [DataContract, Serializable]
    public class StepResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets StepDtoList.
        /// </summary>
        [DataMember]
        public List<StepItemData> StepDtoList { get; set; }

        /// <summary>
        /// Gets or sets StepDto.
        /// </summary>
        [DataMember]
        public StepItemData StepDto { get; set; }
    }
}