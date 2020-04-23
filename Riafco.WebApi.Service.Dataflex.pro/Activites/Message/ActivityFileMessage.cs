using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Message
{
    /// <summary>
    ///    The ActivityFile message class.
    /// </summary>
    [DataContract]
    public class ActivityFileMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  ActivityFileDtoList.
        /// </summary>
        [DataMember]
        public List<ActivityFileDto> ActivityFileDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityFileDto.
        /// </summary>
        [DataMember]
        public ActivityFileDto ActivityFileDto { get; set; }
    }
}