using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Newsletters.ItemData;
using Riafco.Dataflex.Pro.Models.Newsletters.ItemData.Enum;

namespace Riafco.Dataflex.Pro.Models.Newsletters.RequestData
{
    /// <summary>
    /// The NewsletterMailRequestData class.
    /// </summary>
    [DataContract]
    public class NewsletterMailRequestData
    {
        /// <summary>
        /// Gets or sets ActivityParagraphDto.
        /// </summary>
        [DataMember]
        public NewsletterMailItemData NewsletterMailDto { get; set; }

        /// <summary>
        /// Gets or sets The Find NewsletterMailDto.
        /// </summary>
        [DataMember]
        public FindNewsletterMailItemData FindNewsletterMailDto { get; set; }
    }
}