using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Ressources.Data;

namespace Riafco.Service.Dataflex.Pro.Ressources.Response
{
    /// <summary>
    /// The Publication response class.
    /// </summary>
    public class PublicationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  PublicationPivotList.
        /// </summary>
        public List<PublicationPivot> PublicationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationPivot.
        /// </summary>
        public PublicationPivot PublicationPivot { get; set; }
    }
}