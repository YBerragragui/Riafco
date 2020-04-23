using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Interface
{
    /// <summary>
    /// The StepParagraphTranslation client interface.
    /// </summary>
    public interface IServiceStepParagraphTranslationClient
    {
        /// <summary>
        /// Add StepParagraphTranslation dto.
        /// </summary>
        /// <param name="request"> The StepParagraphTranslationRequest that content StepParagraphTranslationdto to add.</param>
        /// <returns>The StepParagraphTranslationMessagePivot result with the StepParagraphTranslationPivot added.</returns>
        StepParagraphTranslationMessage CreateStepParagraphTranslation(StepParagraphTranslationRequest request);

        /// <summary>
        /// Add StepParagraphTranslation dto list.
        /// </summary>
        /// <param name="request"> The StepParagraphTranslationRequest that content StepParagraphTranslationdto to add.</param>
        /// <returns>The StepParagraphTranslationMessagePivot result with the StepParagraphTranslationPivot added.</returns>
        StepParagraphTranslationMessage CreateStepParagraphTranslationRange(StepParagraphTranslationRequest request);

        /// <summary>
        /// Update StepParagraphTranslation dto.
        /// </summary>
        /// <param name="request"> The StepParagraphTranslationRequest that content StepParagraphTranslationdto to update.</param>
        StepParagraphTranslationMessage UpdateStepParagraphTranslation(StepParagraphTranslationRequest request);

        /// <summary>
        /// Update StepParagraphTranslation dto list.
        /// </summary>
        /// <param name="request"> The StepParagraphTranslationRequest that content StepParagraphTranslationdto to update.</param>
        StepParagraphTranslationMessage UpdateStepParagraphTranslationRange(StepParagraphTranslationRequest request);

        /// <summary>
        /// Delete StepParagraphTranslation dto.
        /// </summary>
        /// <param name="request"> The StepParagraphTranslationRequest that content StepParagraphTranslationdto to remove.</param>
        /// <returns>The StepParagraphTranslationMessagePivot result with the StepParagraphTranslationPivot removed.</returns>
        StepParagraphTranslationMessage DeleteStepParagraphTranslation(StepParagraphTranslationRequest request);

        /// <summary>
        /// Get the list of StepParagraphTranslation.
        /// </summary>
        /// <returns>The StepParagraphTranslationMessagePivot result with the StepParagraphTranslationPivot list.</returns>
        StepParagraphTranslationMessage GetAllStepParagraphTranslations();

        /// <summary>
        /// Find StepParagraphTranslation.
        /// </summary>
        /// <returns>The StepParagraphTranslationMessagePivot result with the StepParagraphTranslationPivot list.</returns>
        StepParagraphTranslationMessage FindStepParagraphTranslations(StepParagraphTranslationRequest request);
    }
}