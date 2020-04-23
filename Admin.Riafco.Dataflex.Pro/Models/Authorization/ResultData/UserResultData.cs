using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.Authorization.ResultData
{
    /// <summary>
    /// The UserResultData class
    /// </summary>
    [DataContract(), Serializable()]
    public class UserResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets UserResultDataList
        /// </summary>
        [DataMember]
        public List<UserItemData> UserDtoList { get; set; }

        /// <summary>
        /// Gets or sets UserResultData
        /// </summary>
        [DataMember]
        public UserItemData UserDto { get; set; }
    }
}