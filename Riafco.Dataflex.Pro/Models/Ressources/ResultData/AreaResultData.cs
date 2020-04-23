using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Riafco.Dataflex.Pro.Models.Ressources.ResultData
{
    /// <summary>
    /// The AuthorResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class AreaResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets AreaDtoList.
        /// </summary>
        [DataMember]
        public List<AreaItemData> AreaDtoList { get; set; }

        /// <summary>
        /// Gets or sets AreaDto.
        /// </summary>
        [DataMember]
        public AreaItemData AreaDto { get; set; }
    }
}