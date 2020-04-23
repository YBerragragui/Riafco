using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.RequestData
{
    /// <summary>
    /// The PublicationRequest class.
    /// </summary>
    [DataContract]
    public class PublicationTranslationRequestData
    {
        /// <summary>
        /// Gets or Sets The PublicationTranslationDto requested.
        /// </summary>
        [DataMember]
        public PublicationTranslationItemData PublicationTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The PublicationTranslationDtoList requested.
        /// </summary>
        [DataMember]
        public List<PublicationTranslationItemData> PublicationTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The FindPublicationTranslationDto.
        /// </summary>
        [DataMember]
        public FindPublicationTranslationItemData FindPublicationTranslationDto { get; set; }
    }
}