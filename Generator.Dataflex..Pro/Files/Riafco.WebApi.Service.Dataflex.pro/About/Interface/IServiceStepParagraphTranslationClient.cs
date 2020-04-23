using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;using Riafco.WebApi.Service.Dataflex.pro.About.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Interface{
/// <summary>
/// The StepParagraphTranslation client interface.
/// </summary>
public interface IServiceStepParagraphTranslationClient{
/// <summary>
/// Add StepParagraphTranslation dto.
/// </summary>
/// <param name="stepParagraphTranslationRequest"> The StepParagraphTranslationRequest that content StepParagraphTranslationdto to add.</param>
/// <returns>The StepParagraphTranslationMessagePivot result with the StepParagraphTranslationPivot added.</returns>
StepParagraphTranslationMessage CreateStepParagraphTranslation(StepParagraphTranslationRequest stepParagraphTranslationRequest);

/// <summary>
/// Update StepParagraphTranslation dto.
/// </summary>
/// <param name="stepParagraphTranslationRequest"> The StepParagraphTranslationRequest that content StepParagraphTranslationdto to update.</param>
StepParagraphTranslationMessage UpdateStepParagraphTranslation(StepParagraphTranslationRequest stepParagraphTranslationRequest);

/// <summary>
/// Delete StepParagraphTranslation dto.
/// </summary>
/// <param name="stepParagraphTranslationRequest"> The StepParagraphTranslationRequest that content StepParagraphTranslationdto to remove.</param>
/// <returns>The StepParagraphTranslationMessagePivot result with the StepParagraphTranslationPivot removed.</returns>
StepParagraphTranslationMessage DeleteStepParagraphTranslation(StepParagraphTranslationRequest stepParagraphTranslationRequest);

/// <summary>
/// Get the list of StepParagraphTranslation.
/// </summary>
/// <returns>The StepParagraphTranslationMessagePivot result with the StepParagraphTranslationPivot list.</returns>
StepParagraphTranslationMessage GetAllStepParagraphTranslation();

/// <summary>
/// Find StepParagraphTranslation.
/// </summary>
/// <returns>The StepParagraphTranslationMessagePivot result with the StepParagraphTranslationPivot list.</returns>
StepParagraphTranslationMessage FindStepParagraphTranslation(StepParagraphTranslationRequest stepParagraphTranslationRequest);
}
}