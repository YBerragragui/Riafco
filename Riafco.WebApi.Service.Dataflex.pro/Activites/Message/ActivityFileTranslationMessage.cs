using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Message
{
    /// <summary>
    ///    The ActivityFileTranslation message class.
    /// </summary>
    [DataContract]
    public class ActivityFileTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  ActivityFileTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<ActivityFileTranslationDto> ActivityFileTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityFileTranslationDto.
        /// </summary>
        [DataMember]
        public ActivityFileTranslationDto ActivityFileTranslationDto { get; set; }
    }
}