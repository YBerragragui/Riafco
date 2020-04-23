using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.RequestData
{
    /// <summary>
    /// The ActivityFileRequestData class.
    /// </summary>
    [DataContract]
    public class ActivityFileRequestData
    {
        /// <summary>
        /// Gets or sets ActivityParagraphDto.
        /// </summary>
        [DataMember]
        public ActivityFileItemData ActivityFileDto { get; set; }

        /// <summary>
        /// Gets or sets The Find ActivityFileDto.
        /// </summary>
        [DataMember]
        public FindActivityFileItemData FindActivityFileDto { get; set; }
    }
}