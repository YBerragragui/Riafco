using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Contact.ItemData;

namespace Riafco.Dataflex.Pro.Models.Contact.ResultData
{
    /// <summary>
    /// The UserResultData class
    /// </summary>
    [DataContract, Serializable]
    public class ContactResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets PartnerDtoList
        /// </summary>
        [DataMember]
        public List<ContactItemData> ContactDtoList { get; set; }

        /// <summary>
        /// Gets or sets PartnerDto
        /// </summary>
        [DataMember]
        public ContactItemData ContactrDto { get; set; }
    }
}