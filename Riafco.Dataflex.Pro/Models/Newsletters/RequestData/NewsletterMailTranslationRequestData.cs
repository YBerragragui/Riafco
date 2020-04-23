using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Newsletters.ItemData;
using Riafco.Dataflex.Pro.Models.Newsletters.ItemData.Enum;

namespace Riafco.Dataflex.Pro.Models.Newsletters.RequestData
{
    /// <summary>
    /// The NewsletterMailTranslationRequestData class.
    /// </summary>
    public class NewsletterMailTranslationRequestData
    {
        /// <summary>
        /// Gets or sets NewsletterMailTranslationDto.
        /// </summary>
        [DataMember]
        public NewsletterMailTranslationItemData NewsletterMailTranslationDto { get; set; }

        /// <summary>
        /// Gets or sets NewsletterMailTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<NewsletterMailTranslationItemData> NewsletterMailTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find FindNewsletterMailTranslationDto.
        /// </summary>
        [DataMember]
        public FindNewsletterMailTranslationItemData FindNewsletterMailTranslationDto { get; set; }
    }
}