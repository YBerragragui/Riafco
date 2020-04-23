using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Request
{
    /// <summary>
    /// The ActivityParagraphTraslation request class.
    /// </summary>
    [DataContract]
    public class ActivityParagraphTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The ActivityParagraphTraslationDto requested.
        /// </summary>
        [DataMember]
        public ActivityParagraphTranslationDto ActivityParagraphTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets ActivityParagraphTranslationDtoList requested.
        /// </summary>
        [DataMember]
        public List<ActivityParagraphTranslationDto> ActivityParagraphTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets FindActivityParagraphTranslationDto.
        /// </summary>
        [DataMember]
        public FindActivityParagraphTranslationDto FindActivityParagraphTranslationDto { get; set; }
    }
}