using Admin.Riafco.Dataflex.Pro.Models.Newsletters.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.ItemData.Enum;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.Newsletters.RequestData
{
    /// <summary>
    /// The Activite request class.
    /// </summary>
    [DataContract]
    public class SubscriberRequestData
    {
        /// <summary>
        /// Gets or Sets The SubscriberDto requested.
        /// </summary>
        [DataMember]
        public SubscriberItemData SubscriberDto { get; set; }

        /// <summary>
        /// Gets or sets The Find SubscriberDto.
        /// </summary>
        [DataMember]
        public FindSubscriberItemData FindSubscriberDto { get; set; }
    }
}