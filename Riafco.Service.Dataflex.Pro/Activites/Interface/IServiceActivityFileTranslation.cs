using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Response;

namespace Riafco.Service.Dataflex.Pro.Activites.Interface
{
    /// <summary>
    /// The ActivityFileTranslation interface.
    /// </summary>
    public interface IServiceActivityFileTranslation
    {
        /// <summary>
        /// Create ActivityFileTranslationPivot.
        /// </summary>
        /// <param name="request"> The ActivityFileTranslationRequest Pivot that content ActivityFileTranslationPivot to add.</param>
        /// <returns>The ActivityFileTranslationResponsePivot result with the ActivityFileTranslationPivot added.</returns>
        ActivityFileTranslationResponsePivot CreateActivityFileTranslation(ActivityFileTranslationRequestPivot request);

        /// <summary>
        /// Create ActivityFileTranslationPivot Range.
        /// </summary>
        /// <param name="request"> The ActivityFileTranslationRequest Pivot that content ActivityFileTranslationPivotList to create.</param>
        /// <returns>The ActivityFileTranslationResponsePivot result with the ActivityFileTranslationPivot added.</returns>
        ActivityFileTranslationResponsePivot CreateActivityFileTranslationRange(ActivityFileTranslationRequestPivot request);

        /// <summary>
        /// Update ActivityFileTranslationPivot.
        /// </summary>
        /// <param name="request"> The ActivityFileTranslationRequest Pivot that content ActivityFileTranslationPivot to update.</param>
        void UpdateActivityFileTranslation(ActivityFileTranslationRequestPivot request);

        /// <summary>
        /// Update ActivityFileTranslationPivot.
        /// </summary>
        /// <param name="request"> The ActivityFileTranslationRequest Pivot that content ActivityFileTranslationPivotList to update.</param>
        void UpdateActivityFileTranslationRange(ActivityFileTranslationRequestPivot request);

        /// <summary>
        /// Delete ActivityFileTranslationPivot.
        /// </summary>
        /// <param name="request"> The ActivityFileTranslationRequest Pivot that content ActivityFileTranslationPivot to remove.</param>
        void DeleteActivityFileTranslation(ActivityFileTranslationRequestPivot request);

        /// <summary>
        /// Get ActivityFileTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        ActivityFileTranslationResponsePivot GetAllActivityFileTranslations();

        /// <summary>
        /// Search ActivityFileTranslation.
        /// </summary>
        /// <param name="request"> The ActivityFileTranslationRequest Pivot that content ActivityFileTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        ActivityFileTranslationResponsePivot FindActivityFileTranslations(ActivityFileTranslationRequestPivot request);

    }
}