using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.News.Dto;
using Riafco.WebApi.Service.Dataflex.pro.News.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.News.Request
{
    /// <summary>
    /// The NewsTranslation request class.
    /// </summary>
    [DataContract]
    public class NewsTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The NewsTranslationDto requested.
        /// </summary>
        [DataMember]
        public NewsTranslationDto NewsTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The NewsTranslationDto requested.
        /// </summary>
        [DataMember]
        public List<NewsTranslationDto> NewsTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find NewsTranslationDto.
        /// </summary>
        [DataMember]
        public FindNewsTranslationDto FindNewsTranslationDto { get; set; }
    }
}