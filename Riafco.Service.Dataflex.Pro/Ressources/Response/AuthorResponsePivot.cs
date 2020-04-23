using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Ressources.Data;

namespace Riafco.Service.Dataflex.Pro.Ressources.Response
{
    /// <summary>
    /// The Author response class.
    /// </summary>
    public class AuthorResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  AuthorPivotList.
        /// </summary>
        public List<AuthorPivot> AuthorPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  AuthorPivot.
        /// </summary>
        public AuthorPivot AuthorPivot { get; set; }
    }
}