using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Request
{
    /// <summary>
    /// The NewsletterMail request class.
    /// </summary>
    [DataContract]
    public class NewsletterMailRequest
    {
        /// <summary>
        /// Gets or Sets The NewsletterMailDto requested.
        /// </summary>
        [DataMember]
        public NewsletterMailDto NewsletterMailDto { get; set; }

        /// <summary>
        /// Gets or sets The Find NewsletterMailDto.
        /// </summary>
        [DataMember]
        public FindNewsletterMailDto FindNewsletterMailDto { get; set; }
    }
}