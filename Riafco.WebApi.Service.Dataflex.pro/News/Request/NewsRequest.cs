using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.News.Dto;
using Riafco.WebApi.Service.Dataflex.pro.News.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.News.Request
{
    /// <summary>
    /// The News request class.
    /// </summary>
    [DataContract]
    public class NewsRequest
    {
        /// <summary>
        /// Gets or Sets The NewsDto requested.
        /// </summary>
        [DataMember]
        public NewsDto NewsDto { get; set; }

        /// <summary>
        /// Gets or sets The Find NewsDto.
        /// </summary>
        [DataMember]
        public FindNewsDto FindNewsDto { get; set; }
    }
}