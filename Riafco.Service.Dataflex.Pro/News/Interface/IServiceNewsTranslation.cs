using Riafco.Service.Dataflex.Pro.News.Request;
using Riafco.Service.Dataflex.Pro.News.Response;

namespace Riafco.Service.Dataflex.Pro.News.Interface
{
    /// <summary>
    /// The NewsTranslation interface.
    /// </summary>
    public interface IServiceNewsTranslation
    {
        /// <summary>
        /// Create NewsTranslationPivot.
        /// </summary>
        /// <param name="request"> The NewsTranslationRequest Pivot that content NewsTranslationPivot to add.</param>
        /// <returns>The NewsTranslationResponsePivot result with the NewsTranslationPivot added.</returns>
        NewsTranslationResponsePivot CreateNewsTranslation(NewsTranslationRequestPivot request);

        /// <summary>
        /// Create NewsTranslationPivot.
        /// </summary>
        /// <param name="request"> The NewsTranslationRequest Pivot that content NewsTranslationPivot to add.</param>
        /// <returns>The NewsTranslationResponsePivot result with the NewsTranslationPivot added.</returns>
        NewsTranslationResponsePivot CreateNewsTranslationRange(NewsTranslationRequestPivot request);

        /// <summary>
        /// Update NewsTranslationPivot.
        /// </summary>
        /// <param name="request"> The NewsTranslationRequest Pivot that content NewsTranslationPivot to update.</param>
        void UpdateNewsTranslation(NewsTranslationRequestPivot request);

        /// <summary>
        /// Update NewsTranslationPivot.
        /// </summary>
        /// <param name="request"> The NewsTranslationRequest Pivot that content NewsTranslationPivot to update.</param>
        void UpdateNewsTranslationRange(NewsTranslationRequestPivot request);

        /// <summary>
        /// Delete NewsTranslationPivot.
        /// </summary>
        /// <param name="request"> The NewsTranslationRequest Pivot that content NewsTranslationPivot to remove.</param>
        void DeleteNewsTranslation(NewsTranslationRequestPivot request);

        /// <summary>
        /// Get NewsTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        NewsTranslationResponsePivot GetAllNewsTranslation();

        /// <summary>
        /// Search NewsTranslation.
        /// </summary>
        /// <param name="request"> The NewsTranslationRequest Pivot that content NewsTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        NewsTranslationResponsePivot FindNewsTranslation(NewsTranslationRequestPivot request);
    }
}