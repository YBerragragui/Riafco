using Riafco.Service.Dataflex.Pro.Newsletters.Request;
using Riafco.Service.Dataflex.Pro.Newsletters.Response;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Interface
{
    /// <summary>
    /// The Subscriber interface.
    /// </summary>
    public interface IServiceSubscriber
    {
        /// <summary>
        /// Create SubscriberPivot.
        /// </summary>
        /// <param name="request"> The SubscriberRequest Pivot that content SubscriberPivot to add.</param>
        /// <returns>The SubscriberResponsePivot result with the SubscriberPivot added.</returns>
        SubscriberResponsePivot CreateSubscriber(SubscriberRequestPivot request);

        /// <summary>
        /// Update SubscriberPivot.
        /// </summary>
        /// <param name="request"> The SubscriberRequest Pivot that content SubscriberPivot to update.</param>
        void UpdateSubscriber(SubscriberRequestPivot request);

        /// <summary>
        /// Delete SubscriberPivot.
        /// </summary>
        /// <param name="request"> The SubscriberRequest Pivot that content SubscriberPivot to remove.</param>
        void DeleteSubscriber(SubscriberRequestPivot request);

        /// <summary>
        /// Get Subscriber list
        /// </summary>
        /// <returns>Response result.</returns>
        SubscriberResponsePivot GetAllSubscribers();

        /// <summary>
        /// Search Subscriber.
        /// </summary>
        /// <param name="request"> The SubscriberRequest Pivot that content SubscriberPivot to remove.</param>
        /// <returns>Response Result.</returns>
        SubscriberResponsePivot FindSubscribers(SubscriberRequestPivot request);

    }
}