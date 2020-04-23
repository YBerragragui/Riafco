using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Request;using Riafco.Service.Dataflex.Pro.About.Response;

namespace Riafco.Service.Dataflex.Pro.About.Interface{
/// <summary>
/// The StepParagraph interface.
/// </summary>
public interface IServiceStepParagraph{
/// <summary>
/// Create StepParagraphPivot.
/// </summary>
/// <param name="stepParagraphRequestPivot"> The StepParagraphRequest Pivot that content StepParagraphPivot to add.</param>
/// <returns>The StepParagraphResponsePivot result with the StepParagraphPivot added.</returns>
StepParagraphResponsePivot CreateStepParagraph(StepParagraphRequestPivot stepParagraphRequestPivot);

/// <summary>
/// Update StepParagraphPivot.
/// </summary>
/// <param name="stepParagraphRequestPivot"> The StepParagraphRequest Pivot that content StepParagraphPivot to update.</param>
void UpdateStepParagraph(StepParagraphRequestPivot stepParagraphRequestPivot);

/// <summary>
/// Delete StepParagraphPivot.
/// </summary>
/// <param name="stepParagraphRequestPivot"> The StepParagraphRequest Pivot that content StepParagraphPivot to remove.</param>
void DeleteStepParagraph(StepParagraphRequestPivot stepParagraphRequestPivot);

/// <summary>
/// Get StepParagraph list
/// </summary>
/// <returns>Response result.</returns>
StepParagraphResponsePivot GetAllStepParagraph();

/// <summary>
/// Search StepParagraph.
/// </summary>
/// <param name="stepParagraphRequestPivot"> The StepParagraphRequest Pivot that content StepParagraphPivot to remove.</param>
/// <returns>Response Result.</returns>
StepParagraphResponsePivot FindStepParagraph(StepParagraphRequestPivot stepParagraphRequestPivot);

}
}