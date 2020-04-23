using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.RequestData
{
    /// <summary>
    /// The ActivityParagraphTranslationRequestData class.
    /// </summary>
    [DataContract]
    public class ActivityParagraphTranslationRequestData
    {
        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public ActivityParagraphTranslationItemData ActivityParagraphTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public List<ActivityParagraphTranslationItemData> ActivityParagraphTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find ActiviteTraductionDtoEnum.
        /// </summary>
        [DataMember]
        public FindActivityParagraphTranslationItemData FindActivityParagraphTranslationDto { get; set; }
    }
}