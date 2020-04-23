using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Dataflex.Pro.Models.About.ItemData.Enum;

namespace Riafco.Dataflex.Pro.Models.About.RequestData
{
    /// <summary>
    /// The SectionParagraphRequestData class.
    /// </summary>
    [DataContract]
    public class SectionParagraphRequestData
    {
        /// <summary>
        /// Gets or sets SectionParagraphDto.
        /// </summary>
        [DataMember]
        public SectionParagraphItemData SectionParagraphDto { get; set; }

        /// <summary>
        /// Gets or sets FindSectionParagraphDto.
        /// </summary>
        [DataMember]
        public FindSectionParagraphItemData FindSectionParagraphDto { get; set; }
    }
}