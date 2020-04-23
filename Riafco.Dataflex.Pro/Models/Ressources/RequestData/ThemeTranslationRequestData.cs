using System.Collections.Generic;
using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData.Enum;

namespace Riafco.Dataflex.Pro.Models.Ressources.RequestData
{
    /// <summary>
    /// The ThemeRequest class.
    /// </summary>
    [DataContract]
    public class ThemeTranslationRequestData
    {
        /// <summary>
        /// Gets or Sets The ThemeTranslationDto requested.
        /// </summary>
        [DataMember]
        public ThemeTranslationItemData ThemeTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The ThemeTranslationDtoList requested.
        /// </summary>
        [DataMember]
        public List<ThemeTranslationItemData> ThemeTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The FindThemeTranslationDto.
        /// </summary>
        [DataMember]
        public FindThemeTranslationItemData FindThemeTranslationDto { get; set; }
    }
}