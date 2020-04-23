using Riafco.Service.Dataflex.Pro.News.Request;
using Riafco.Service.Dataflex.Pro.News.Response;

namespace Riafco.Service.Dataflex.Pro.News.Interface
{
    /// <summary>
    /// The News interface.
    /// </summary>
    public interface IServiceNews
    {
        /// <summary>
        /// Create NewsPivot.
        /// </summary>
        /// <param name="request"> The NewsRequest Pivot that content NewsPivot to add.</param>
        /// <returns>The NewsResponsePivot result with the NewsPivot added.</returns>
        NewsResponsePivot CreateNews(NewsRequestPivot request);

        /// <summary>
        /// Update NewsPivot.
        /// </summary>
        /// <param name="request"> The NewsRequest Pivot that content NewsPivot to update.</param>
        void UpdateNews(NewsRequestPivot request);

        /// <summary>
        /// Delete NewsPivot.
        /// </summary>
        /// <param name="request"> The NewsRequest Pivot that content NewsPivot to remove.</param>
        void DeleteNews(NewsRequestPivot request);

        /// <summary>
        /// Get News list
        /// </summary>
        /// <returns>Response result.</returns>
        NewsResponsePivot GetAllNews();

        /// <summary>
        /// Search News.
        /// </summary>
        /// <param name="request"> The NewsRequest Pivot that content NewsPivot to remove.</param>
        /// <returns>Response Result.</returns>
        NewsResponsePivot FindNews(NewsRequestPivot request);
    }
}