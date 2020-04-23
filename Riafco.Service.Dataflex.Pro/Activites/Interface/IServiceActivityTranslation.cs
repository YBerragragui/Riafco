using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Response;

namespace Riafco.Service.Dataflex.Pro.Activites.Interface
{
    /// <summary>
    /// The ActivityTranslation interface.
    /// </summary>
    public interface IServiceActivityTranslation
    {
        /// <summary>
        /// Create ActivityTranslationPivot.
        /// </summary>
        /// <param name="request"> The ActivityTranslationRequest Pivot that content ActivityTranslationPivot to add.</param>
        /// <returns>The ActivityTranslationResponsePivot result with the ActivityTranslationPivot added.</returns>
        ActivityTranslationResponsePivot CreateActivityTranslation(ActivityTranslationRequestPivot request);

        /// <summary>
        /// Create range ActivityTranslationPivot.
        /// </summary>
        /// <param name="request"> The ActivityTranslationRequest Pivot that content ActivityTranslationPivot to add.</param>
        /// <returns>The ActivityTranslationResponsePivot result with the ActivityTranslationPivot added.</returns>
        ActivityTranslationResponsePivot CreateActivityTranslationRange(ActivityTranslationRequestPivot request);

        /// <summary>
        /// Update ActivityTranslationPivot.
        /// </summary>
        /// <param name="request"> The ActivityTranslationRequest Pivot that content ActivityTranslationPivot to update.</param>
        void UpdateActivityTranslation(ActivityTranslationRequestPivot request);

        /// <summary>
        /// Update ActivityTranslationPivot.
        /// </summary>
        /// <param name="request"> The ActivityTranslationRequest Pivot that content ActivityTranslationPivot to update.</param>
        void UpdateActivityTranslationRange(ActivityTranslationRequestPivot request);

        /// <summary>
        /// Delete ActivityTranslationPivot.
        /// </summary>
        /// <param name="request"> The ActivityTranslationRequest Pivot that content ActivityTranslationPivot to remove.</param>
        void DeleteActivityTranslation(ActivityTranslationRequestPivot request);

        /// <summary>
        /// Get ActivityTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        ActivityTranslationResponsePivot GetAllActivityTranslations();

        /// <summary>
        /// Search ActivityTranslation.
        /// </summary>
        /// <param name="request"> The ActivityTranslationRequest Pivot that content ActivityTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        ActivityTranslationResponsePivot FindActivityTranslations(ActivityTranslationRequestPivot request);
    }
}