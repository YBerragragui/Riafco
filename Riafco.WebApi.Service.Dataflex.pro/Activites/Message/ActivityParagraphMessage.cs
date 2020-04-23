using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Message
{
    /// <summary>
    /// The ActivityParagraphMessage class.
    /// </summary>
    [DataContract]
    public class ActivityParagraphMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  ActivityParagraphDtoList.
        /// </summary>
        [DataMember]
        public List<ActivityParagraphDto> ActivityParagraphDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityParagraphDto.
        /// </summary>
        [DataMember]
        public ActivityParagraphDto ActivityParagraphDto { get; set; }
    }
}