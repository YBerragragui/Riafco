using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;

namespace Riafco.Service.Dataflex.Pro.Ressources.Interface
{
    /// <summary>
    /// The Author interface.
    /// </summary>
    public interface IServiceAuthor
    {
        /// <summary>
        /// Create AuthorPivot.
        /// </summary>
        /// <param name="request"> The AuthorRequest Pivot that content AuthorPivot to add.</param>
        /// <returns>The AuthorResponsePivot result with the AuthorPivot added.</returns>
        AuthorResponsePivot CreateAuthor(AuthorRequestPivot request);

        /// <summary>
        /// Update AuthorPivot.
        /// </summary>
        /// <param name="request"> The AuthorRequest Pivot that content AuthorPivot to update.</param>
        void UpdateAuthor(AuthorRequestPivot request);

        /// <summary>
        /// Delete AuthorPivot.
        /// </summary>
        /// <param name="request"> The AuthorRequest Pivot that content AuthorPivot to remove.</param>
        void DeleteAuthor(AuthorRequestPivot request);

        /// <summary>
        /// Get Author list
        /// </summary>
        /// <returns>Response result.</returns>
        AuthorResponsePivot GetAllAuthors();

        /// <summary>
        /// Search Author.
        /// </summary>
        /// <param name="request"> The AuthorRequest Pivot that content AuthorPivot to remove.</param>
        /// <returns>Response Result.</returns>
        AuthorResponsePivot FindAuthors(AuthorRequestPivot request);
    }
}