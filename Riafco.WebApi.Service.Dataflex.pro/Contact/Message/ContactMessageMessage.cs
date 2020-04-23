using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Contact.Message
{
    /// <summary>
    ///    The ContactMessage message class.
    /// </summary>
    [DataContract]
    public class ContactMessageMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  ContactMessageDtoList.
        /// </summary>
        [DataMember]
        public List<ContactMessageDto> ContactMessageDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  ContactMessageDto.
        /// </summary>
        [DataMember]
        public ContactMessageDto ContactMessageDto { get; set; }
    }
}