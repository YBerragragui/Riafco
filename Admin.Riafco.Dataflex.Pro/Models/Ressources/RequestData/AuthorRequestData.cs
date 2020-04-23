using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.RequestData
{
    /// <summary>
    /// The AuthorRequestData class.
    /// </summary>
    [DataContract]
    public class AuthorRequestData
    {
        /// <summary>
        /// Gets or Sets The AuthorDto requested.
        /// </summary>
        [DataMember]
        public AuthorItemData AuthorDto { get; set; }

        /// <summary>
        /// Gets or sets The FindAuthorDto.
        /// </summary>
        [DataMember]
        public FindAuthorItemData FindAuthorDto { get; set; }
    }
}