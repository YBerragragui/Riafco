using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Message
{
    /// <summary>
    /// The AreaTranslation message class.
    /// </summary>
    [DataContract]
    public class AreaTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  AreaTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<AreaTranslationDto> AreaTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  AreaTranslationDto.
        /// </summary>
        [DataMember]
        public AreaTranslationDto AreaTranslationDto { get; set; }
    }
}