using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData.Enum;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.About.RequestData
{
    /// <summary>
    /// The ActiviteTraduction request class.
    /// </summary>
    [DataContract]
    public class SectionTranslationRequestData
    {
        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public SectionTranslationItemData SectionTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public List<SectionTranslationItemData> SectionTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find ActiviteTraductionDtoEnum.
        /// </summary>
        [DataMember]
        public FindSectionTranslationItemData FindSectionTranslationDto { get; set; }
    }
}