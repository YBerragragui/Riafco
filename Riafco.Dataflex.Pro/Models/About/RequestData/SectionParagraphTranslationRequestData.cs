using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Dataflex.Pro.Models.About.ItemData.Enum;

namespace Riafco.Dataflex.Pro.Models.About.RequestData
{
    /// <summary>
    /// The SectionParagraphTranslationRequestData class.
    /// </summary>
    [DataContract]
    public class SectionParagraphTranslationRequestData
    {
        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public SectionParagraphTranslationItemData SectionParagraphTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public List<SectionParagraphTranslationItemData> SectionParagraphTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find ActiviteTraductionDtoEnum.
        /// </summary>
        [DataMember]
        public FindSectionParagraphTranslationItemData FindSectionParagraphTranslationDto { get; set; }
    }
}