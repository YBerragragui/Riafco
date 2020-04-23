using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.RequestData
{
    /// <summary>
    /// The AreaRequest class.
    /// </summary>
    [DataContract]
    public class AreaRequestData
    {
        /// <summary>
        /// Gets or Sets The AreaDto requested.
        /// </summary>
        [DataMember]
        public AreaItemData AreaDto { get; set; }

        /// <summary>
        /// Gets or sets The FindAreaDto.
        /// </summary>
        [DataMember]
        public FindAreaItemData FindAreaDto { get; set; }
    }
}