using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.About.RequestData
{
    /// <summary>
    /// The SectionFileRequestData class.
    /// </summary>
    [DataContract]
    public class SectionFileRequestData
    {
        /// <summary>
        /// Gets or sets SectionParagraphDto.
        /// </summary>
        [DataMember]
        public SectionFileItemData SectionFileDto { get; set; }

        /// <summary>
        /// Gets or sets The Find SectionFileDto.
        /// </summary>
        [DataMember]
        public FindSectionFileItemData FindSectionFileDto { get; set; }
    }
}