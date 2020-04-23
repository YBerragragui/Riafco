using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Newsletters.Data;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Response
{
    /// <summary>
    /// The Subscriber response class.
    /// </summary>
    public class SubscriberResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  SubscriberPivotList.
        /// </summary>
        public List<SubscriberPivot> SubscriberPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  SubscriberPivot.
        /// </summary>
        public SubscriberPivot SubscriberPivot { get; set; }
    }
}