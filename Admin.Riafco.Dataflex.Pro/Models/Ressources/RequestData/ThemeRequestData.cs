using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.RequestData
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