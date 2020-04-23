using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Interface
{
    /// <summary>
    /// The Author client interface.
    /// </summary>
    public interface IServiceAuthorClient
    {
        /// <summary>
        /// Create Author dto.
        /// </summary>
        /// <param name="request"> The AuthorRequest that content Authordto to add.</param>
        /// <returns>The AuthorMessagePivot result with the AuthorPivot added.</returns>
        AuthorMessage CreateAuthor(AuthorRequest request);

        /// <summary>
        /// Update Author dto.
        /// </summary>
        /// <param name="request"> The AuthorRequest that content Authordto to update.</param>
        AuthorMessage UpdateAuthor(AuthorRequest request);

        /// <summary>
        /// Delete Author dto.
        /// </summary>
        /// <param name="request"> The AuthorRequest that content Authordto to remove.</param>
        /// <returns>The AuthorMessagePivot result with the AuthorPivot removed.</returns>
        AuthorMessage DeleteAuthor(AuthorRequest request);

        /// <summary>
        /// Get the list of Authors.
        /// </summary>
        /// <returns>The AuthorMessagePivot result with the AuthorPivot list.</returns>
        AuthorMessage GetAllAuthors();

        /// <summary>
        /// Find Authors.
        /// </summary>
        /// <returns>The AuthorMessagePivot result with the AuthorPivot list.</returns>
        AuthorMessage FindAuthors(AuthorRequest request);
    }
}