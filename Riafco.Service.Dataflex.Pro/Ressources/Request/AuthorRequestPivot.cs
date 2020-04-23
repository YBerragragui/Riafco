using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Ressources.Request
{
    /// <summary>
    /// Gets or Sets The  Author request class.
    /// </summary>
    public class AuthorRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  AuthorPivot requested.
        /// </summary>
        public AuthorPivot AuthorPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find AuthorEnum.
        /// </summary>
        public FindAuthorPivot FindAuthorPivot { get; set; }
    }
}