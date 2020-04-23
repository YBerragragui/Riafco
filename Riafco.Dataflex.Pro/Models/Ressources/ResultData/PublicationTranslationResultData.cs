using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Riafco.Dataflex.Pro.Models.Ressources.ResultData
{
    /// <summary>
    /// The PublicationTranslationResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class PublicationTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets PublicationTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<PublicationTranslationItemData> PublicationTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets PublicationTranslationDto.
        /// </summary>
        [DataMember]
        public PublicationTranslationItemData PublicationTranslationDto { get; set; }
    }
}