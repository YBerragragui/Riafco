using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Message
{
    /// <summary>
    ///    The NewsletterMail message class.
    /// </summary>
    [DataContract]
    public class NewsletterMailMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  NewsletterMailDtoList.
        /// </summary>
        [DataMember]
        public List<NewsletterMailDto> NewsletterMailDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMailDto.
        /// </summary>
        [DataMember]
        public NewsletterMailDto NewsletterMailDto { get; set; }
    }
}