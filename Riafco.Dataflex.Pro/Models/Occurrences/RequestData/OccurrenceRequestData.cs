using Riafco.Dataflex.Pro.Models.Occurrences.ItemData;
using Riafco.Dataflex.Pro.Models.Occurrences.ItemData.Enum;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.Occurrences.RequestData
{
    /// <summary>
    /// The Activite request class.
    /// </summary>
    [DataContract]
    public class OccurrenceRequestData
    {
        /// <summary>
        /// Gets or Sets The OccurrenceDto requested.
        /// </summary>
        [DataMember]
        public OccurrenceItemData OccurrenceDto { get; set; }

        /// <summary>
        /// Gets or sets The Find OccurrenceDto.
        /// </summary>
        [DataMember]
        public FindOccurrenceItemData FindOccurrenceDto { get; set; }
    }
}