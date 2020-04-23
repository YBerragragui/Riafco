using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;
using Riafco.Service.Dataflex.Pro.About;
using Riafco.WebApi.Service.Dataflex.pro.About.Interface;
using Riafco.WebApi.Service.Dataflex.pro.About.Assembler;
using Riafco.Service.Dataflex.Pro.About.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About{
/// <summary>
/// The Step service client class.
/// </summary>
public class ServiceStepClient : IServiceStepClient{
/// <summary>
/// The Step service instance.
/// </summary>
private readonly IServiceStep serviceStep;

/// <summary>
/// Set the Step instane with injected instance.
/// </summary>
/// <param name="injectedServiceStep">injected instance</param>
public ServiceStepClient(IServiceStep injectedServiceStep)
{
 serviceStep = injectedServiceStep;
}
/// <summary>
/// Add new Step
/// </summary>
/// <param name="request">step request.</param>
/// <returns>Step message.</returns>
public StepMessage CreateStep(StepRequest request)
{
 StepMessage message = new StepMessage();
try
{
message = serviceStep.CreateStep(request.ToPivot()).ToMessage();
message.OperationSuccess = true;
}
catch(Exception e)
{
 message.ErrorType = ErrorType.TechnicalError;
 message.ErrorMessage = e.Message;
}
return message; 
}

/// <summary>
/// Change Step informations.
/// </summary>
/// <param name="request">step request.</param>
/// <returns>Step message.</returns>
public StepMessage UpdateStep(StepRequest request)
{
 StepMessage message = new StepMessage();
try
{
 serviceStep.UpdateStep(request.ToPivot());
message.OperationSuccess = true;
}
catch(Exception e)
{
 message.ErrorType = ErrorType.TechnicalError;
 message.ErrorMessage = e.Message;
}
return message; 
}

/// <summary>
/// Delete Step
/// </summary>
/// <param name="request">step request.</param>
/// <returns>Step message.</returns>
public StepMessage DeleteStep(StepRequest request)
{
  StepMessage message = new StepMessage();
try
{
 serviceStep.DeleteStep(request.ToPivot());
message.OperationSuccess = true;
}
catch(Exception e)
{
 message.ErrorType = ErrorType.TechnicalError;
 message.ErrorMessage = e.Message;
}
return message; 
}

/// <summary>
/// Get list of Step
/// </summary>
/// <returns>Step message.</returns>
public StepMessage GetAllStep()
{
  StepMessage message = new StepMessage();
try
{
 message = serviceStep.GetAllStep().ToMessage();
message.OperationSuccess = true;
}
catch(Exception e)
{
 message.ErrorType = ErrorType.TechnicalError;
 message.ErrorMessage = e.Message;
}
return message; 
}

/// <summary>
/// Search Step
/// </summary>
/// <param name="request">step request.</param>
/// <returns>Step message.</returns>
public StepMessage FindStep(StepRequest request)
{
 StepMessage message = new StepMessage();
try
{
 message = serviceStep.FindStep(request.ToPivot()).ToMessage();
message.OperationSuccess = true;
}
catch(Exception e)
{
 message.ErrorType = ErrorType.TechnicalError;
 message.ErrorMessage = e.Message;
}
return message; 
}

}
}