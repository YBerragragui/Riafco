using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Ressources.Request
{
    /// <summary>
    /// Gets or Sets The  Publication request class.
    /// </summary>
    public class PublicationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  PublicationPivot requested.
        /// </summary>
        public PublicationPivot PublicationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The Find PublicationEnum.
        /// </summary>
        public FindPublicationPivot FindPublicationPivot { get; set; }
    }
}