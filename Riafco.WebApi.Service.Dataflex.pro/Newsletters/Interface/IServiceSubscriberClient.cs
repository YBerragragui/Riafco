using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Request;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Interface
{
    /// <summary>
    /// The Subscriber client interface.
    /// </summary>
    public interface IServiceSubscriberClient
    {
        /// <summary>
        /// Add Subscriber dto.
        /// </summary>
        /// <param name="request"> The SubscriberRequest that content Subscriberdto to add.</param>
        /// <returns>The SubscriberMessagePivot result with the SubscriberPivot added.</returns>
        SubscriberMessage CreateSubscriber(SubscriberRequest request);

        /// <summary>
        /// Update Subscriber dto.
        /// </summary>
        /// <param name="request"> The SubscriberRequest that content Subscriberdto to update.</param>
        SubscriberMessage UpdateSubscriber(SubscriberRequest request);

        /// <summary>
        /// Delete Subscriber dto.
        /// </summary>
        /// <param name="request"> The SubscriberRequest that content Subscriberdto to remove.</param>
        /// <returns>The SubscriberMessagePivot result with the SubscriberPivot removed.</returns>
        SubscriberMessage DeleteSubscriber(SubscriberRequest request);

        /// <summary>
        /// Get the list of Subscriber.
        /// </summary>
        /// <returns>The SubscriberMessagePivot result with the SubscriberPivot list.</returns>
        SubscriberMessage GetAllSubscribers();

        /// <summary>
        /// Find Subscriber.
        /// </summary>
        /// <returns>The SubscriberMessagePivot result with the SubscriberPivot list.</returns>
        SubscriberMessage FindSubscribers(SubscriberRequest request);
    }
}