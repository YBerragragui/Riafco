using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Contact.Data;

namespace Riafco.Service.Dataflex.Pro.Contact.Response
{
    /// <summary>
    /// The ContactMessage response class.
    /// </summary>
    public class ContactMessageResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  ContactMessagePivotList.
        /// </summary>
        public List<ContactMessagePivot> ContactMessagePivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  ContactMessagePivot.
        /// </summary>
        public ContactMessagePivot ContactMessagePivot { get; set; }

    }
}