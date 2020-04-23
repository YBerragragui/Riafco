using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Contact.ItemData;
using Riafco.Dataflex.Pro.Models.Contact.ItemData.Enum;

namespace Riafco.Dataflex.Pro.Models.Contact.RequestData
{
    /// <summary>
    /// The Activite request class.
    /// </summary>
    [DataContract]
    public class ContactRequestData
    {
        /// <summary>
        /// Gets or Sets The PartnerDto requested.
        /// </summary>
        [DataMember]
        public ContactItemData ContactDto { get; set; }

        /// <summary>
        /// Gets or sets The Find PartnerDto.
        /// </summary>
        [DataMember]
        public FindContactItemData FindContactDto { get; set; }
    }
}