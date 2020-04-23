using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.RequestData
{
    /// <summary>
    /// The SheetTranslationRequestData class.
    /// </summary>
    [DataContract]
    public class SheetTranslationRequestData
    {
        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public SheetTranslationItemData SheetTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public List<SheetTranslationItemData> SheetTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find ActiviteTraductionDtoEnum.
        /// </summary>
        [DataMember]
        public FindSheetTranslationItemData FindSheetTranslationDto { get; set; }
    }
}