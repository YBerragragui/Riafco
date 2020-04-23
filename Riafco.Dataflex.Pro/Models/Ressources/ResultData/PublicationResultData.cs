using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Riafco.Dataflex.Pro.Models.Ressources.ResultData
{
    /// <summary>
    /// The PublicationResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class PublicationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets PublicationDtoList.
        /// </summary>
        [DataMember]
        public List<PublicationItemData> PublicationDtoList { get; set; }

        /// <summary>
        /// Gets or sets PublicationDto.
        /// </summary>
        [DataMember]
        public PublicationItemData PublicationDto { get; set; }
    }
}