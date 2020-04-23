using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;using Riafco.WebApi.Service.Dataflex.pro.About.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Interface{
/// <summary>
/// The StepParagraph client interface.
/// </summary>
public interface IServiceStepParagraphClient{
/// <summary>
/// Add StepParagraph dto.
/// </summary>
/// <param name="stepParagraphRequest"> The StepParagraphRequest that content StepParagraphdto to add.</param>
/// <returns>The StepParagraphMessagePivot result with the StepParagraphPivot added.</returns>
StepParagraphMessage CreateStepParagraph(StepParagraphRequest stepParagraphRequest);

/// <summary>
/// Update StepParagraph dto.
/// </summary>
/// <param name="stepParagraphRequest"> The StepParagraphRequest that content StepParagraphdto to update.</param>
StepParagraphMessage UpdateStepParagraph(StepParagraphRequest stepParagraphRequest);

/// <summary>
/// Delete StepParagraph dto.
/// </summary>
/// <param name="stepParagraphRequest"> The StepParagraphRequest that content StepParagraphdto to remove.</param>
/// <returns>The StepParagraphMessagePivot result with the StepParagraphPivot removed.</returns>
StepParagraphMessage DeleteStepParagraph(StepParagraphRequest stepParagraphRequest);

/// <summary>
/// Get the list of StepParagraph.
/// </summary>
/// <returns>The StepParagraphMessagePivot result with the StepParagraphPivot list.</returns>
StepParagraphMessage GetAllStepParagraph();

/// <summary>
/// Find StepParagraph.
/// </summary>
/// <returns>The StepParagraphMessagePivot result with the StepParagraphPivot list.</returns>
StepParagraphMessage FindStepParagraph(StepParagraphRequest stepParagraphRequest);
}
}