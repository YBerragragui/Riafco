using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData.Enum;

namespace Riafco.Dataflex.Pro.Models.Ressources.RequestData
{
    /// <summary>
    /// The ThemeRequest class.
    /// </summary>
    [DataContract]
    public class ThemeRequestData
    {
        /// <summary>
        /// Gets or Sets The ThemeDto requested.
        /// </summary>
        [DataMember]
        public ThemeItemData ThemeDto { get; set; }

        /// <summary>
        /// Gets or sets The FindThemeDto.
        /// </summary>
        [DataMember]
        public FindThemeItemData FindThemeDto { get; set; }
    }
}