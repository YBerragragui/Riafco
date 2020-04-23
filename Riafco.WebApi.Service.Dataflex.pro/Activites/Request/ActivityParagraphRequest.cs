using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Request
{
    /// <summary>
    /// The ActivityParagraph request class.
    /// </summary>
    [DataContract]
    public class ActivityParagraphRequest
    {
        /// <summary>
        /// Gets or Sets The ActivityParagraphDto requested.
        /// </summary>
        [DataMember]
        public ActivityParagraphDto ActivityParagraphDto { get; set; }

        /// <summary>
        /// Gets or sets The Find ActivityParagraphDtoEnum.
        /// </summary>
        [DataMember]
        public FindActivityParagraphDto FindActivityParagraphDto { get; set; }
    }
}