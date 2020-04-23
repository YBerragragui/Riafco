using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Riafco.Dataflex.Pro.Models.Activities.ItemData.Enum;

namespace Riafco.Dataflex.Pro.Models.Activities.RequestData
{
    /// <summary>
    /// The ActivityFileTranslationRequestData class.
    /// </summary>
    public class ActivityFileTranslationRequestData
    {
        /// <summary>
        /// Gets or sets ActivityFileTranslationDto.
        /// </summary>
        [DataMember]
        public ActivityFileTranslationItemData ActivityFileTranslationDto { get; set; }

        /// <summary>
        /// Gets or sets ActivityFileTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<ActivityFileTranslationItemData> ActivityFileTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find FindActivityFileTranslationDto.
        /// </summary>
        [DataMember]
        public FindActivityFileTranslationItemData FindActivityFileTranslationDto { get; set; }
    }
}