using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData.Enum;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.Activities.RequestData
{
    /// <summary>
    /// The ActiviteTraduction request class.
    /// </summary>
    [DataContract]
    public class ActivityTranslationRequestData
    {
        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public ActivityTranslationItemData ActivityTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public List<ActivityTranslationItemData> ActivityTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find ActiviteTraductionDtoEnum.
        /// </summary>
        [DataMember]
        public FindActivityTranslationItemData FindActivityTranslationDto { get; set; }
    }
}