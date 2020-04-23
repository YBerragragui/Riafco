using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;using Riafco.WebApi.Service.Dataflex.pro.About.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Interface{
/// <summary>
/// The Step client interface.
/// </summary>
public interface IServiceStepClient{
/// <summary>
/// Add Step dto.
/// </summary>
/// <param name="stepRequest"> The StepRequest that content Stepdto to add.</param>
/// <returns>The StepMessagePivot result with the StepPivot added.</returns>
StepMessage CreateStep(StepRequest stepRequest);

/// <summary>
/// Update Step dto.
/// </summary>
/// <param name="stepRequest"> The StepRequest that content Stepdto to update.</param>
StepMessage UpdateStep(StepRequest stepRequest);

/// <summary>
/// Delete Step dto.
/// </summary>
/// <param name="stepRequest"> The StepRequest that content Stepdto to remove.</param>
/// <returns>The StepMessagePivot result with the StepPivot removed.</returns>
StepMessage DeleteStep(StepRequest stepRequest);

/// <summary>
/// Get the list of Step.
/// </summary>
/// <returns>The StepMessagePivot result with the StepPivot list.</returns>
StepMessage GetAllStep();

/// <summary>
/// Find Step.
/// </summary>
/// <returns>The StepMessagePivot result with the StepPivot list.</returns>
StepMessage FindStep(StepRequest stepRequest);
}
}