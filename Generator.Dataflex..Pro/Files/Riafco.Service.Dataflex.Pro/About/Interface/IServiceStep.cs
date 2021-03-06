using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Request;using Riafco.Service.Dataflex.Pro.About.Response;

namespace Riafco.Service.Dataflex.Pro.About.Interface{
/// <summary>
/// The Step interface.
/// </summary>
public interface IServiceStep{
/// <summary>
/// Create StepPivot.
/// </summary>
/// <param name="stepRequestPivot"> The StepRequest Pivot that content StepPivot to add.</param>
/// <returns>The StepResponsePivot result with the StepPivot added.</returns>
StepResponsePivot CreateStep(StepRequestPivot stepRequestPivot);

/// <summary>
/// Update StepPivot.
/// </summary>
/// <param name="stepRequestPivot"> The StepRequest Pivot that content StepPivot to update.</param>
void UpdateStep(StepRequestPivot stepRequestPivot);

/// <summary>
/// Delete StepPivot.
/// </summary>
/// <param name="stepRequestPivot"> The StepRequest Pivot that content StepPivot to remove.</param>
void DeleteStep(StepRequestPivot stepRequestPivot);

/// <summary>
/// Get Step list
/// </summary>
/// <returns>Response result.</returns>
StepResponsePivot GetAllStep();

/// <summary>
/// Search Step.
/// </summary>
/// <param name="stepRequestPivot"> The StepRequest Pivot that content StepPivot to remove.</param>
/// <returns>Response Result.</returns>
StepResponsePivot FindStep(StepRequestPivot stepRequestPivot);

}
}