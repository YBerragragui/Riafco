using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Ressources.Request
{
    /// <summary>
    /// Gets or Sets The PublicationTranslation request class.
    /// </summary>
    public class PublicationTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  PublicationTranslationPivot requested.
        /// </summary>
        public PublicationTranslationPivot PublicationTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The PublicationTranslationPivotList requested.
        /// </summary>
        public List<PublicationTranslationPivot> PublicationTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  Find PublicationTranslationEnum.
        /// </summary>
        public FindPublicationTranslationPivot FindPublicationTranslationPivot { get; set; }
    }
}