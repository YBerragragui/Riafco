using Riafco.Service.Dataflex.Pro.Contact.Data;
using Riafco.Service.Dataflex.Pro.Contact.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Contact.Request
{
    /// <summary>
    /// Gets or Sets The  ContactMessage request class.
    /// </summary>
    public class ContactMessageRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  ContactMessagePivot requested.
        /// </summary>
        public ContactMessagePivot ContactMessagePivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find ContactMessageEnum.
        /// </summary>
        public FindContactMessagePivot FindContactMessagePivot { get; set; }
    }
}