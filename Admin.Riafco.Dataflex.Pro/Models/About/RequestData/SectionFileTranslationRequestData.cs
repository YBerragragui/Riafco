using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.About.RequestData
{
    /// <summary>
    /// The SectionFileTranslationRequestData class.
    /// </summary>
    public class SectionFileTranslationRequestData
    {
        /// <summary>
        /// Gets or sets SectionFileTranslationDto.
        /// </summary>
        [DataMember]
        public SectionFileTranslationItemData SectionFileTranslationDto { get; set; }

        /// <summary>
        /// Gets or sets SectionFileTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<SectionFileTranslationItemData> SectionFileTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find FindSectionFileTranslationDto.
        /// </summary>
        [DataMember]
        public FindSectionFileTranslationItemData FindSectionFileTranslationDto { get; set; }
    }
}