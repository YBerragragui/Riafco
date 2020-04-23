using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.RequestData
{
    /// <summary>
    /// The ActivityParagraphRequestData class.
    /// </summary>
    [DataContract]
    public class ActivityParagraphRequestData
    {
        /// <summary>
        /// Gets or sets ActivityParagraphDto.
        /// </summary>
        [DataMember]
        public ActivityParagraphItemData ActivityParagraphDto { get; set; }

        /// <summary>
        /// Gets or sets FindActivityParagraphDto.
        /// </summary>
        [DataMember]
        public FindActivityParagraphItemData FindActivityParagraphDto { get; set; }
    }
}