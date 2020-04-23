using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.ResultData
{
    /// <summary>
    /// The AuthorResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class AuthorResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets AuthorDtoList
        /// </summary>
        [DataMember]
        public List<AuthorItemData> AuthorDtoList { get; set; }

        /// <summary>
        /// Gets or sets AuthorDto
        /// </summary>
        [DataMember]
        public AuthorItemData AuthorDto { get; set; }
    }
}