using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Newsletters.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;

namespace Riafco.Dataflex.Pro.Models.Newsletters.ResultData
{
    /// <summary>
    /// The NewsletterMailTranslationResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class NewsletterMailTranslationResultData : BaseResultData
    {
        /// <summary>
        /// Gets or sets NewsletterMailTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<NewsletterMailTranslationItemData> NewsletterMailTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets ActivityParagraphDto.
        /// </summary>
        [DataMember]
        public NewsletterMailTranslationItemData NewsletterMailTranslationDto { get; set; }
    }
}