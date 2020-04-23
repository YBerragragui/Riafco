using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData.Enum;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.RequestData
{
    /// <summary>
    /// The Activite request class.
    /// </summary>
    [DataContract]
    public class ActivityRequestData
    {
        /// <summary>
        /// Gets or Sets The ActivityDto requested.
        /// </summary>
        [DataMember]
        public ActivityItemData ActivityDto { get; set; }

        /// <summary>
        /// Gets or sets The Find ActivityDto.
        /// </summary>
        [DataMember]
        public FindActivityItemData FindActivityDto { get; set; }
    }
}