using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Offices.ItemData;
using Riafco.Dataflex.Pro.Models.Offices.ItemData.Enum;

namespace Riafco.Dataflex.Pro.Models.Offices.RequestData
{
    /// <summary>
    /// The Countre request class.
    /// </summary>
    [DataContract]
    public class CountryRequestData
    {
        /// <summary>
        /// Gets or Sets The CountryDto requested.
        /// </summary>
        [DataMember]
        public CountryItemData CountryDto { get; set; }

        /// <summary>
        /// Gets or sets The Find CountryDto.
        /// </summary>
        [DataMember]
        public FindCountryItemData FindCountryDto { get; set; }
    }
}