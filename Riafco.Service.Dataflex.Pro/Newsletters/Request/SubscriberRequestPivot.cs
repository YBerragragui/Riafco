using Riafco.Service.Dataflex.Pro.Newsletters.Data;
using Riafco.Service.Dataflex.Pro.Newsletters.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Request
{
    /// <summary>
    /// Gets or Sets The  Subscriber request class.
    /// </summary>
    public class SubscriberRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  SubscriberPivot requested.
        /// </summary>
        public SubscriberPivot SubscriberPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find SubscriberEnum.
        /// </summary>
        public FindSubscriberPivot FindSubscriberPivot { get; set; }
    }
}