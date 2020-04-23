using Riafco.Dataflex.Pro.Models.Partners.ItemData;
using Riafco.Dataflex.Pro.Models.Partners.ItemData.Enum;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.Partners.RequestData
{
    /// <summary>
    /// The Activite request class.
    /// </summary>
    [DataContract]
    public class PartnerRequestData
    {
        /// <summary>
        /// Gets or Sets The PartnerDto requested.
        /// </summary>
        [DataMember]
        public PartnerItemData PartnerDto { get; set; }

        /// <summary>
        /// Gets or sets The Find PartnerDto.
        /// </summary>
        [DataMember]
        public FindPartnerItemData FindPartnerDto { get; set; }
    }
}