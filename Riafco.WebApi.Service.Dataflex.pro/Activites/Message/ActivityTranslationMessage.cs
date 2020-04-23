using Riafco.Framework.Dataflex.pro.Communication.Messages;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Message
{
    /// <summary>
    /// The ActivityTranslation message class.
    /// </summary>
    [DataContract]
    public class ActivityTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The ActivityTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<ActivityTranslationDto> ActivityTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityTranslationDto.
        /// </summary>
        [DataMember]
        public ActivityTranslationDto ActivityTranslationDto { get; set; }
    }
}