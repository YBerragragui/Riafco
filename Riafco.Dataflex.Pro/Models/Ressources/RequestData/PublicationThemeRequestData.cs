using System.Runtime.Serialization;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData.Enum;

namespace Riafco.Dataflex.Pro.Models.Ressources.RequestData
{
    /// <summary>
    /// The PublicationThemeRequestData class.
    /// </summary>
    [DataContract]
    public class PublicationThemeRequestData
    {
        /// <summary>
        /// Gets or Sets The PublicationThemeDto requested.
        /// </summary>
        [DataMember]
        public PublicationThemeItemData PublicationThemeDto { get; set; }

        /// <summary>
        /// Gets or sets The FindPublicationThemeDto.
        /// </summary>
        [DataMember]
        public FindPublicationThemeItemData FindPublicationThemeDto { get; set; }
    }
}