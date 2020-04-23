using Riafco.Service.Dataflex.Pro.Contact.Request;
using Riafco.Service.Dataflex.Pro.Contact.Response;

namespace Riafco.Service.Dataflex.Pro.Contact.Interface
{
    /// <summary>
    /// The ContactMessage interface.
    /// </summary>
    public interface IServiceContactMessage
    {
        /// <summary>
        /// Create ContactMessagePivot.
        /// </summary>
        /// <param name="request"> The ContactMessageRequest Pivot that content ContactMessagePivot to add.</param>
        /// <returns>The ContactMessageResponsePivot result with the ContactMessagePivot added.</returns>
        ContactMessageResponsePivot CreateContactMessage(ContactMessageRequestPivot request);

        /// <summary>
        /// Delete ContactMessagePivot.
        /// </summary>
        /// <param name="request"> The ContactMessageRequest Pivot that content ContactMessagePivot to remove.</param>
        void DeleteContactMessage(ContactMessageRequestPivot request);

        /// <summary>
        /// Get ContactMessage list
        /// </summary>
        /// <returns>Response result.</returns>
        ContactMessageResponsePivot GetAllContactMessages();

        /// <summary>
        /// Search ContactMessage.
        /// </summary>
        /// <param name="request"> The ContactMessageRequest Pivot that content ContactMessagePivot to remove.</param>
        /// <returns>Response Result.</returns>
        ContactMessageResponsePivot FindContactMessages(ContactMessageRequestPivot request);

    }
}