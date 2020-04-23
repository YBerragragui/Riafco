using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Message
{
    /// <summary>
    /// The PublicationTranslation message class.
    /// </summary>
    [DataContract]
    public class PublicationTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  PublicationTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<PublicationTranslationDto> PublicationTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationTranslationDto.
        /// </summary>
        [DataMember]
        public PublicationTranslationDto PublicationTranslationDto { get; set; }
    }
}