using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Response;

namespace Riafco.Service.Dataflex.Pro.Activites.Interface
{
    /// <summary>
    /// The ActivityParagraph interface.
    /// </summary>
    public interface IServiceActivityParagraph
    {
        /// <summary>
        /// Create ActivityParagraphPivot.
        /// </summary>
        /// <param name="request"> The ActivityParagraphRequest Pivot that content ActivityParagraphPivot to add.</param>
        /// <returns>The ActivityParagraphResponsePivot result with the ActivityParagraphPivot added.</returns>
        ActivityParagraphResponsePivot CreateActivityParagraph(ActivityParagraphRequestPivot request);

        /// <summary>
        /// Update ActivityParagraphPivot.
        /// </summary>
        /// <param name="request"> The ActivityParagraphRequest Pivot that content ActivityParagraphPivot to update.</param>
        void UpdateActivityParagraph(ActivityParagraphRequestPivot request);

        /// <summary>
        /// Delete ActivityParagraphPivot.
        /// </summary>
        /// <param name="request"> The ActivityParagraphRequest Pivot that content ActivityParagraphPivot to remove.</param>
        void DeleteActivityParagraph(ActivityParagraphRequestPivot request);

        /// <summary>
        /// Get ActivityParagraph list
        /// </summary>
        /// <returns>Response result.</returns>
        ActivityParagraphResponsePivot GetAllActivityParagraphs();

        /// <summary>
        /// Search ActivityParagraph.
        /// </summary>
        /// <param name="request"> The ActivityParagraphRequest Pivot that content ActivityParagraphPivot to remove.</param>
        /// <returns>Response Result.</returns>
        ActivityParagraphResponsePivot FindActivityParagraphs(ActivityParagraphRequestPivot request);
    }
}