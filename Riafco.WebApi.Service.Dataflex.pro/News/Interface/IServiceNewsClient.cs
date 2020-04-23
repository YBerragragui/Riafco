using Riafco.WebApi.Service.Dataflex.pro.News.Request;
using Riafco.WebApi.Service.Dataflex.pro.News.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.News.Interface
{
    /// <summary>
    /// The News client interface.
    /// </summary>
    public interface IServiceNewsClient
    {
        /// <summary>
        /// Add News dto.
        /// </summary>
        /// <param name="request"> The NewsRequest that content Newsdto to add.</param>
        /// <returns>The NewsMessagePivot result with the NewsPivot added.</returns>
        NewsMessage CreateNews(NewsRequest request);

        /// <summary>
        /// Update News dto.
        /// </summary>
        /// <param name="request"> The NewsRequest that content Newsdto to update.</param>
        NewsMessage UpdateNews(NewsRequest request);

        /// <summary>
        /// Delete News dto.
        /// </summary>
        /// <param name="request"> The NewsRequest that content Newsdto to remove.</param>
        /// <returns>The NewsMessagePivot result with the NewsPivot removed.</returns>
        NewsMessage DeleteNews(NewsRequest request);

        /// <summary>
        /// Get the list of News.
        /// </summary>
        /// <returns>The NewsMessagePivot result with the NewsPivot list.</returns>
        NewsMessage GetAllNews();

        /// <summary>
        /// Find News.
        /// </summary>
        /// <returns>The NewsMessagePivot result with the NewsPivot list.</returns>
        NewsMessage FindNews(NewsRequest request);
    }
}