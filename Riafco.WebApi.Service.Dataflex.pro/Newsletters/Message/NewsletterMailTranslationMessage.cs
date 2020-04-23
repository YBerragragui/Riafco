using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Message
{
    /// <summary>
    ///    The NewsletterMailTranslation message class.
    /// </summary>
    [DataContract]
    public class NewsletterMailTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  NewsletterMailTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<NewsletterMailTranslationDto> NewsletterMailTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMailTranslationDto.
        /// </summary>
        [DataMember]
        public NewsletterMailTranslationDto NewsletterMailTranslationDto { get; set; }
    }
}