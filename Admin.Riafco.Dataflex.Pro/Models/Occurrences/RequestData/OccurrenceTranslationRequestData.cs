using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.Occurrences.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Occurrences.ItemData.Enum;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.Occurrences.RequestData
{
    /// <summary>
    /// The ActiviteTraduction request class.
    /// </summary>
    [DataContract]
    public class OccurrenceTranslationRequestData
    {
        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public OccurrenceTranslationItemData OccurrenceTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public List<OccurrenceTranslationItemData> OccurrenceTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find ActiviteTraductionDtoEnum.
        /// </summary>
        [DataMember]
        public FindOccurrenceTranslationItemData FindOccurrenceTranslationDto { get; set; }
    }
}