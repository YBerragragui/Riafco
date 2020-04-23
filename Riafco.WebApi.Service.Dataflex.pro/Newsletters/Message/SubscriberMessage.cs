using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Message
{
    /// <summary>
    ///    The Subscriber message class.
    /// </summary>
    [DataContract]
    public class SubscriberMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  SubscriberDtoList.
        /// </summary>
        [DataMember]
        public List<SubscriberDto> SubscriberDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  SubscriberDto.
        /// </summary>
        [DataMember]
        public SubscriberDto SubscriberDto { get; set; }
    }
}