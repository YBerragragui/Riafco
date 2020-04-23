using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Ressources.Data;

namespace Riafco.Service.Dataflex.Pro.Ressources.Response
{
    /// <summary>
    /// The PublicationTranslation response class.
    /// </summary>
    public class PublicationTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  PublicationTranslationPivotList.
        /// </summary>
        public List<PublicationTranslationPivot> PublicationTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationTranslationPivot.
        /// </summary>
        public PublicationTranslationPivot PublicationTranslationPivot { get; set; }
    }
}