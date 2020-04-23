using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.RequestData
{
    /// <summary>
    /// The AreaTranslationRequestData class.
    /// </summary>
    [DataContract]
    public class AreaTranslationRequestData
    {
        /// <summary>
        /// Gets or Sets The AreaTranslationDto requested.
        /// </summary>
        [DataMember]
        public AreaTranslationItemData AreaTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The AreaTranslationDtoList requested.
        /// </summary>
        [DataMember]
        public List<AreaTranslationItemData> AreaTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The FindAreaTranslationDto.
        /// </summary>
        [DataMember]
        public FindAreaTranslationItemData FindAreaTranslationDto { get; set; }
    }
}