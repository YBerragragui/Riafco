using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Interface
{
    /// <summary>
    /// The ActivityFileTranslation client interface.
    /// </summary>
    public interface IServiceActivityFileTranslationClient
    {
        /// <summary>
        /// Create ActivityFileTranslation dto.
        /// </summary>
        /// <param name="activityFileTranslationRequest"> The ActivityFileTranslationRequest that content ActivityFileTranslationdto to add.</param>
        /// <returns>The ActivityFileTranslationMessagePivot result with the ActivityFileTranslationPivot added.</returns>
        ActivityFileTranslationMessage CreateActivityFileTranslation(ActivityFileTranslationRequest activityFileTranslationRequest);

        /// <summary>
        /// Create ActivityFileTranslation dto list.
        /// </summary>
        /// <param name="activityFileTranslationRequest"> The ActivityFileTranslationRequest that content ActivityFileTranslationdto to add.</param>
        /// <returns>The ActivityFileTranslationMessagePivot result with the ActivityFileTranslationPivot added.</returns>
        ActivityFileTranslationMessage CreateActivityFileTranslationRange(ActivityFileTranslationRequest activityFileTranslationRequest);

        /// <summary>
        /// Update ActivityFileTranslation dto.
        /// </summary>
        /// <param name="activityFileTranslationRequest"> The ActivityFileTranslationRequest that content ActivityFileTranslationdto to update.</param>
        ActivityFileTranslationMessage UpdateActivityFileTranslation(ActivityFileTranslationRequest activityFileTranslationRequest);

        /// <summary>
        /// Update ActivityFileTranslation dto lmist
        /// </summary>
        /// <param name="activityFileTranslationRequest"> The ActivityFileTranslationRequest that content ActivityFileTranslationdto to update.</param>
        ActivityFileTranslationMessage UpdateActivityFileTranslationRange(ActivityFileTranslationRequest activityFileTranslationRequest);

        /// <summary>
        /// Delete ActivityFileTranslation dto.
        /// </summary>
        /// <param name="activityFileTranslationRequest"> The ActivityFileTranslationRequest that content ActivityFileTranslationdto to remove.</param>
        /// <returns>The ActivityFileTranslationMessagePivot result with the ActivityFileTranslationPivot removed.</returns>
        ActivityFileTranslationMessage DeleteActivityFileTranslation(ActivityFileTranslationRequest activityFileTranslationRequest);

        /// <summary>
        /// Get the list of ActivityFileTranslation.
        /// </summary>
        /// <returns>The ActivityFileTranslationMessagePivot result with the ActivityFileTranslationPivot list.</returns>
        ActivityFileTranslationMessage GetAllActivityFileTranslations();

        /// <summary>
        /// Find ActivityFileTranslation.
        /// </summary>
        /// <returns>The ActivityFileTranslationMessagePivot result with the ActivityFileTranslationPivot list.</returns>
        ActivityFileTranslationMessage FindActivityFileTranslations(ActivityFileTranslationRequest activityFileTranslationRequest);
    }
}