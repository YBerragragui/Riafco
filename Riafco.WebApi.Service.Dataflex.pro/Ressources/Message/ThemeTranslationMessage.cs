using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Message
{
    /// <summary>
    ///    The ThemeTranslation message class.
    /// </summary>
    [DataContract]
    public class ThemeTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  ThemeTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<ThemeTranslationDto> ThemeTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  ThemeTranslationDto.
        /// </summary>
        [DataMember]
        public ThemeTranslationDto ThemeTranslationDto { get; set; }
    }
}