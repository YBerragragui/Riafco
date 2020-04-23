using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Response;

namespace Riafco.Service.Dataflex.Pro.About.Interface
{
    /// <summary>
    /// The StepParagraphTranslation interface.
    /// </summary>
    public interface IServiceStepParagraphTranslation
    {
        /// <summary>
        /// Create StepParagraphTranslationPivot.
        /// </summary>
        /// <param name="request"> The StepParagraphTranslationRequest Pivot that content StepParagraphTranslationPivot to add.</param>
        /// <returns>The StepParagraphTranslationResponsePivot result with the StepParagraphTranslationPivot added.</returns>
        StepParagraphTranslationResponsePivot CreateStepParagraphTranslation(StepParagraphTranslationRequestPivot request);

        /// <summary>
        /// Create StepParagraphTranslationPivot list.
        /// </summary>
        /// <param name="request"> The StepParagraphTranslationRequest Pivot that content StepParagraphTranslationPivot to add.</param>
        /// <returns>The StepParagraphTranslationResponsePivot result with the StepParagraphTranslationPivot added.</returns>
        StepParagraphTranslationResponsePivot CreateStepParagraphTranslationRange(StepParagraphTranslationRequestPivot request);

        /// <summary>
        /// Update StepParagraphTranslationPivot.
        /// </summary>
        /// <param name="request"> The StepParagraphTranslationRequest Pivot that content StepParagraphTranslationPivot to update.</param>
        void UpdateStepParagraphTranslation(StepParagraphTranslationRequestPivot request);

        /// <summary>
        /// Update StepParagraphTranslationPivot list.
        /// </summary>
        /// <param name="request"> The StepParagraphTranslationRequest Pivot that content StepParagraphTranslationPivot to update.</param>
        void UpdateStepParagraphTranslationRange(StepParagraphTranslationRequestPivot request);

        /// <summary>
        /// Delete StepParagraphTranslationPivot.
        /// </summary>
        /// <param name="request"> The StepParagraphTranslationRequest Pivot that content StepParagraphTranslationPivot to remove.</param>
        void DeleteStepParagraphTranslation(StepParagraphTranslationRequestPivot request);

        /// <summary>
        /// Get StepParagraphTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        StepParagraphTranslationResponsePivot GetAllStepParagraphTranslations();

        /// <summary>
        /// Search StepParagraphTranslation.
        /// </summary>
        /// <param name="request"> The StepParagraphTranslationRequest Pivot that content StepParagraphTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        StepParagraphTranslationResponsePivot FindStepParagraphTranslations(StepParagraphTranslationRequestPivot request);

    }
}