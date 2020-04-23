using Riafco.WebApi.Service.Dataflex.pro.News.Request;
using Riafco.WebApi.Service.Dataflex.pro.News.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.News.Interface
{
    /// <summary>
    /// The NewsTranslation client interface.
    /// </summary>
    public interface IServiceNewsTranslationClient
    {
        /// <summary>
        /// Add NewsTranslation dto.
        /// </summary>
        /// <param name="request"> The NewsTranslationRequest that content NewsTranslationdto to add.</param>
        /// <returns>The NewsTranslationMessagePivot result with the NewsTranslationPivot added.</returns>
        NewsTranslationMessage CreateNewsTranslation(NewsTranslationRequest request);

        /// <summary>
        /// Add NewsTranslation dto.
        /// </summary>
        /// <param name="request"> The NewsTranslationRequest that content NewsTranslationdto to add.</param>
        /// <returns>The NewsTranslationMessagePivot result with the NewsTranslationPivot added.</returns>
        NewsTranslationMessage CreateNewsTranslationRange(NewsTranslationRequest request);

        /// <summary>
        /// Update NewsTranslation dto.
        /// </summary>
        /// <param name="request"> The NewsTranslationRequest that content NewsTranslationdto to update.</param>
        NewsTranslationMessage UpdateNewsTranslation(NewsTranslationRequest request);

        /// <summary>
        /// Update NewsTranslation dto.
        /// </summary>
        /// <param name="request"> The NewsTranslationRequest that content NewsTranslationdto to update.</param>
        NewsTranslationMessage UpdateNewsTranslationRange(NewsTranslationRequest request);

        /// <summary>
        /// Delete NewsTranslation dto.
        /// </summary>
        /// <param name="request"> The NewsTranslationRequest that content NewsTranslationdto to remove.</param>
        /// <returns>The NewsTranslationMessagePivot result with the NewsTranslationPivot removed.</returns>
        NewsTranslationMessage DeleteNewsTranslation(NewsTranslationRequest request);

        /// <summary>
        /// Get the list of NewsTranslation.
        /// </summary>
        /// <returns>The NewsTranslationMessagePivot result with the NewsTranslationPivot list.</returns>
        NewsTranslationMessage GetAllNewsTranslation();

        /// <summary>
        /// Find NewsTranslation.
        /// </summary>
        /// <returns>The NewsTranslationMessagePivot result with the NewsTranslationPivot list.</returns>
        NewsTranslationMessage FindNewsTranslation(NewsTranslationRequest request);
    }
}