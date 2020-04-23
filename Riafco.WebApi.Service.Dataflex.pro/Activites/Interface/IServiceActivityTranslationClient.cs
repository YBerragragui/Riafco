using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Interface
{
    /// <summary>
    /// The ActivityTranslation client interface.
    /// </summary>
    public interface IServiceActivityTranslationClient
    {
        /// <summary>
        /// Create ActivityTranslation dto.
        /// </summary>
        /// <param name="request"> The ActivityTranslationRequest that content ActivityTranslationdto to add.</param>
        /// <returns>The ActivityTranslationMessagePivot result with the ActivityTranslationPivot to add.</returns>
        ActivityTranslationMessage CreateActivityTranslation(ActivityTranslationRequest request);

        /// <summary>
        /// Create ActivityTranslation dto list.
        /// </summary>
        /// <param name="request"> The ActivityTranslationRequest that content ActivityTranslationdto to add.</param>
        /// <returns>The ActivityTranslationMessagePivot result with the ActivityTranslationPivot to add.</returns>
        ActivityTranslationMessage CreateActivityTranslationRange(ActivityTranslationRequest request);

        /// <summary>
        /// Update ActivityTranslation dto.
        /// </summary>
        /// <param name="request"> The ActivityTranslationRequest that content ActivityTranslationdto to update.</param>
        ActivityTranslationMessage UpdateActivityTranslation(ActivityTranslationRequest request);

        /// <summary>
        /// Update ActivityTranslation dto list.
        /// </summary>
        /// <param name="request"> The ActivityTranslationRequest that content ActivityTranslationdto to update.</param>
        ActivityTranslationMessage UpdateActivityTranslationRange(ActivityTranslationRequest request);

        /// <summary>
        /// Delete ActivityTranslation dto.
        /// </summary>
        /// <param name="request"> The ActivityTranslationRequest that content ActivityTranslationdto to remove.</param>
        /// <returns>The ActivityTranslationMessagePivot result with the ActivityTranslationPivot removed.</returns>
        ActivityTranslationMessage DeleteActivityTranslation(ActivityTranslationRequest request);

        /// <summary>
        /// Get the list of ActivityTranslation.
        /// </summary>
        /// <returns>The ActivityTranslationMessagePivot result with the ActivityTranslationPivot list.</returns>
        ActivityTranslationMessage GetAllActivityTranslations();

        /// <summary>
        /// Find ActivityTranslation.
        /// </summary>
        /// <returns>The ActivityTranslationMessagePivot result with the ActivityTranslationPivot list.</returns>
        ActivityTranslationMessage FindActivityTranslations(ActivityTranslationRequest request);
    }
}