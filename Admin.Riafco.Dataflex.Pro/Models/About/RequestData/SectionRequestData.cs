using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData.Enum;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.About.RequestData
{
    /// <summary>
    /// The Activite request class.
    /// </summary>
    [DataContract]
    public class SectionRequestData
    {
        /// <summary>
        /// Gets or Sets The SectionDto requested.
        /// </summary>
        [DataMember]
        public SectionItemData SectionDto { get; set; }

        /// <summary>
        /// Gets or sets The Find SectionDto.
        /// </summary>
        [DataMember]
        public FindSectionItemData FindSectionDto { get; set; }
    }
}