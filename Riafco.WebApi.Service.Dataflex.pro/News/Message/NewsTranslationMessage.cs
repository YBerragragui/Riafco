using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.News.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.News.Message
{
    /// <summary>
    /// The NewsTranslation message class.
    /// </summary>
    [DataContract]
    public class NewsTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  NewsTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<NewsTranslationDto> NewsTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsTranslationDto.
        /// </summary>
        [DataMember]
        public NewsTranslationDto NewsTranslationDto { get; set; }
    }
}