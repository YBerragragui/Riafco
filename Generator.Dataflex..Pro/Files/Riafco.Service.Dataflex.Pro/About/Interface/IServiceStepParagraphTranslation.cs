using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Request;using Riafco.Service.Dataflex.Pro.About.Response;

namespace Riafco.Service.Dataflex.Pro.About.Interface{
/// <summary>
/// The StepParagraphTranslation interface.
/// </summary>
public interface IServiceStepParagraphTranslation{
/// <summary>
/// Create StepParagraphTranslationPivot.
/// </summary>
/// <param name="stepParagraphTranslationRequestPivot"> The StepParagraphTranslationRequest Pivot that content StepParagraphTranslationPivot to add.</param>
/// <returns>The StepParagraphTranslationResponsePivot result with the StepParagraphTranslationPivot added.</returns>
StepParagraphTranslationResponsePivot CreateStepParagraphTranslation(StepParagraphTranslationRequestPivot stepParagraphTranslationRequestPivot);

/// <summary>
/// Update StepParagraphTranslationPivot.
/// </summary>
/// <param name="stepParagraphTranslationRequestPivot"> The StepParagraphTranslationRequest Pivot that content StepParagraphTranslationPivot to update.</param>
void UpdateStepParagraphTranslation(StepParagraphTranslationRequestPivot stepParagraphTranslationRequestPivot);

/// <summary>
/// Delete StepParagraphTranslationPivot.
/// </summary>
/// <param name="stepParagraphTranslationRequestPivot"> The StepParagraphTranslationRequest Pivot that content StepParagraphTranslationPivot to remove.</param>
void DeleteStepParagraphTranslation(StepParagraphTranslationRequestPivot stepParagraphTranslationRequestPivot);

/// <summary>
/// Get StepParagraphTranslation list
/// </summary>
/// <returns>Response result.</returns>
StepParagraphTranslationResponsePivot GetAllStepParagraphTranslation();

/// <summary>
/// Search StepParagraphTranslation.
/// </summary>
/// <param name="stepParagraphTranslationRequestPivot"> The StepParagraphTranslationRequest Pivot that content StepParagraphTranslationPivot to remove.</param>
/// <returns>Response Result.</returns>
StepParagraphTranslationResponsePivot FindStepParagraphTranslation(StepParagraphTranslationRequestPivot stepParagraphTranslationRequestPivot);

}
}