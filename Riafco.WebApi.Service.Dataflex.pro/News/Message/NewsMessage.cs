using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.News.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.News.Message
{
    /// <summary>
    /// The News message class.
    /// </summary>
    [DataContract]
    public class NewsMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  NewsDtoList.
        /// </summary>
        [DataMember]
        public List<NewsDto> NewsDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsDto.
        /// </summary>
        [DataMember]
        public NewsDto NewsDto { get; set; }
    }
}