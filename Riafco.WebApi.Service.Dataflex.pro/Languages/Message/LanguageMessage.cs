using Riafco.Framework.Dataflex.pro.Communication.Messages;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.WebApi.Service.Dataflex.pro.Languages.Message
{
    /// <summary>
    /// The Language message class.
    /// </summary>
    [DataContract]
    public class LanguageMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The LanguageDtoList.
        /// </summary>
        [DataMember]
        public List<LanguageDto> LanguageDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageDto.
        /// </summary>
        [DataMember]
        public LanguageDto LanguageDto { get; set; }
    }
}