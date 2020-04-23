using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Request
{
    /// <summary>
    /// The NewsletterMailTranslation request class.
    /// </summary>
    [DataContract]
    public class NewsletterMailTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The NewsletterMailTranslationDto requested.
        /// </summary>
        [DataMember]
        public NewsletterMailTranslationDto NewsletterMailTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The NewsletterMailTranslationDto requested.
        /// </summary>
        [DataMember]
        public List<NewsletterMailTranslationDto> NewsletterMailTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find NewsletterMailTranslationDto.
        /// </summary>
        [DataMember]
        public FindNewsletterMailTranslationDto FindNewsletterMailTranslationDto { get; set; }
    }
}