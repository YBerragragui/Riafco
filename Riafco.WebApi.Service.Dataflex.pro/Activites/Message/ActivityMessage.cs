using Riafco.Framework.Dataflex.pro.Communication.Messages;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Message
{
    /// <summary>
    /// The Activity message class.
    /// </summary>
    [DataContract]
    public class ActivityMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The ActivityDtoList.
        /// </summary>
        [DataMember]
        public List<ActivityDto> ActivityDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityDto.
        /// </summary>
        [DataMember]
        public ActivityDto ActivityDto { get; set; }
    }
}