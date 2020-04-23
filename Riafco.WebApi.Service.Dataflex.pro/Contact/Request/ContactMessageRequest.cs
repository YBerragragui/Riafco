using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Contact.Request
{
    /// <summary>
    /// The ContactMessage request class.
    /// </summary>
    [DataContract]
    public class ContactMessageRequest
    {
        /// <summary>
        /// Gets or Sets The ContactMessageDto requested.
        /// </summary>
        [DataMember]
        public ContactMessageDto ContactMessageDto { get; set; }

        /// <summary>
        /// Gets or sets The Find ContactMessageDto.
        /// </summary>
        [DataMember]
        public FindContactMessageDto FindContactMessageDto { get; set; }
    }
}