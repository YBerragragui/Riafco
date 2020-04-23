using Riafco.WebApi.Service.Dataflex.pro.Contact.Request;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Contact.Interface
{
    /// <summary>
    /// The ContactMessage client interface.
    /// </summary>
    public interface IServiceContactMessageClient
    {
        /// <summary>
        /// Add ContactMessage dto.
        /// </summary>
        /// <param name="request"> The ContactMessageRequest that content ContactMessagedto to add.</param>
        /// <returns>The ContactMessageMessagePivot result with the ContactMessagePivot added.</returns>
        ContactMessageMessage CreateContactMessage(ContactMessageRequest request);

        /// <summary>
        /// Delete ContactMessage dto.
        /// </summary>
        /// <param name="request"> The ContactMessageRequest that content ContactMessagedto to remove.</param>
        /// <returns>The ContactMessageMessagePivot result with the ContactMessagePivot removed.</returns>
        ContactMessageMessage DeleteContactMessage(ContactMessageRequest request);

        /// <summary>
        /// Get the list of ContactMessage.
        /// </summary>
        /// <returns>The ContactMessageMessagePivot result with the ContactMessagePivot list.</returns>
        ContactMessageMessage GetAllContactMessages();

        /// <summary>
        /// Find ContactMessage.
        /// </summary>
        /// <returns>The ContactMessageMessagePivot result with the ContactMessagePivot list.</returns>
        ContactMessageMessage FindContactMessages(ContactMessageRequest request);
    }
}