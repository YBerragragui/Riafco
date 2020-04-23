using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Message
{
    /// <summary>
    /// The ActivityParagraphTraslation message class.
    /// </summary>
    [DataContract]
    public class ActivityParagraphTranslationMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The ActivityParagraphTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<ActivityParagraphTranslationDto> ActivityParagraphTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The ActivityParagraphTranslationDto.
        /// </summary>
        [DataMember]
        public ActivityParagraphTranslationDto ActivityParagraphTranslationDto { get; set; }
    }
}