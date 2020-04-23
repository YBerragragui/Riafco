using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Interface
{
    /// <summary>
    /// The ActivityParagraph client interface.
    /// </summary>
    public interface IServiceActivityParagraphClient
    {
        /// <summary>
        /// Create ActivityParagraph dto.
        /// </summary>
        /// <param name="request"> The ActivityParagraphRequest that content ActivityParagraphdto to add.</param>
        /// <returns>The ActivityParagraphMessagePivot result with the ActivityParagraphPivot added.</returns>
        ActivityParagraphMessage CreateActivityParagraph(ActivityParagraphRequest request);

        /// <summary>
        /// Update ActivityParagraph dto.
        /// </summary>
        /// <param name="request"> The ActivityParagraphRequest that content ActivityParagraphdto to update.</param>
        ActivityParagraphMessage UpdateActivityParagraph(ActivityParagraphRequest request);

        /// <summary>
        /// Delete ActivityParagraph dto.
        /// </summary>
        /// <param name="request"> The ActivityParagraphRequest that content ActivityParagraphdto to remove.</param>
        /// <returns>The ActivityParagraphMessagePivot result with the ActivityParagraphPivot removed.</returns>
        ActivityParagraphMessage DeleteActivityParagraph(ActivityParagraphRequest request);

        /// <summary>
        /// Get the list of ActivityParagraph.
        /// </summary>
        /// <returns>The ActivityParagraphMessagePivot result with the ActivityParagraphPivot list.</returns>
        ActivityParagraphMessage GetAllActivityParagraphs();

        /// <summary>
        /// Find ActivityParagraph.
        /// </summary>
        /// <returns>The ActivityParagraphMessagePivot result with the ActivityParagraphPivot list.</returns>
        ActivityParagraphMessage FindActivityParagraphs(ActivityParagraphRequest request);
    }
}