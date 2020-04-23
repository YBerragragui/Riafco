using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.Newsletters.ResultData
{
    /// <summary>
    /// The NewsletterMailResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class NewsletterMailResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets NewsletterMailDtoList.
        /// </summary>
        [DataMember]
        public List<NewsletterMailItemData> NewsletterMailDtoList { get; set; }

        /// <summary>
        /// Gets or sets NewsletterMailDto.
        /// </summary>
        [DataMember]
        public NewsletterMailItemData NewsletterMailDto { get; set; }
    }
}