using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Request
{
    /// <summary>
    /// The Subscriber request class.
    /// </summary>
    [DataContract]
    public class SubscriberRequest
    {
        /// <summary>
        /// Gets or Sets The SubscriberDto requested.
        /// </summary>
        [DataMember]
        public SubscriberDto SubscriberDto { get; set; }

        /// <summary>
        /// Gets or sets The Find SubscriberDto.
        /// </summary>
        [DataMember]
        public FindSubscriberDto FindSubscriberDto { get; set; }
    }
}