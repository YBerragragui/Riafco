using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.RequestData
{
    /// <summary>
    /// The CountreTraduction request class.
    /// </summary>
    [DataContract]
    public class CountryTranslationRequestData
    {
        /// <summary>
        /// Gets or Sets The CountreTraductionDto requested.
        /// </summary>
        [DataMember]
        public CountryTranslationItemData CountryTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The CountreTraductionDto requested.
        /// </summary>
        [DataMember]
        public List<CountryTranslationItemData> CountryTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find CountreTraductionDtoEnum.
        /// </summary>
        [DataMember]
        public FindCountryTranslationItemData FindCountryTranslationDto { get; set; }
    }
}