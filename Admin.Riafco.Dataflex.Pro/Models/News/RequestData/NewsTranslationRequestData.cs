using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.News.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.News.ItemData.Enum;
using System.Runtime.Serialization;

namespace Admin.Riafco.Dataflex.Pro.Models.News.RequestData

{
    /// <summary>
    /// The TraductionNews request class.
    /// </summary>
    [DataContract]
    public class NewsTranslationRequestData
    {
        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public NewsTranslationItemData NewsTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The ActiviteTraductionDto requested.
        /// </summary>
        [DataMember]
        public List<NewsTranslationItemData> NewsTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find ActiviteTraductionDtoEnum.
        /// </summary>
        [DataMember]
        public FindNewsTranslationItemData FindNewsTranslationDto { get; set; }
    }
}