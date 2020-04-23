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
/// The StepParagraphTranslation service client class.
/// </summary>
public class ServiceStepParagraphTranslationClient : IServiceStepParagraphTranslationClient{
/// <summary>
/// The StepParagraphTranslation service instance.
/// </summary>
private readonly IServiceStepParagraphTranslation serviceStepParagraphTranslation;

/// <summary>
/// Set the StepParagraphTranslation instane with injected instance.
/// </summary>
/// <param name="injectedServiceStepParagraphTranslation">injected instance</param>
public ServiceStepParagraphTranslationClient(IServiceStepParagraphTranslation injectedServiceStepParagraphTranslation)
{
 serviceStepParagraphTranslation = injectedServiceStepParagraphTranslation;
}
/// <summary>
/// Add new StepParagraphTranslation
/// </summary>
/// <param name="request">stepParagraphTranslation request.</param>
/// <returns>StepParagraphTranslation message.</returns>
public StepParagraphTranslationMessage CreateStepParagraphTranslation(StepParagraphTranslationRequest request)
{
 StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
try
{
message = serviceStepParagraphTranslation.CreateStepParagraphTranslation(request.ToPivot()).ToMessage();
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
/// Change StepParagraphTranslation informations.
/// </summary>
/// <param name="request">stepParagraphTranslation request.</param>
/// <returns>StepParagraphTranslation message.</returns>
public StepParagraphTranslationMessage UpdateStepParagraphTranslation(StepParagraphTranslationRequest request)
{
 StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
try
{
 serviceStepParagraphTranslation.UpdateStepParagraphTranslation(request.ToPivot());
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
/// Delete StepParagraphTranslation
/// </summary>
/// <param name="request">stepParagraphTranslation request.</param>
/// <returns>StepParagraphTranslation message.</returns>
public StepParagraphTranslationMessage DeleteStepParagraphTranslation(StepParagraphTranslationRequest request)
{
  StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
try
{
 serviceStepParagraphTranslation.DeleteStepParagraphTranslation(request.ToPivot());
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
/// Get list of StepParagraphTranslation
/// </summary>
/// <returns>StepParagraphTranslation message.</returns>
public StepParagraphTranslationMessage GetAllStepParagraphTranslation()
{
  StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
try
{
 message = serviceStepParagraphTranslation.GetAllStepParagraphTranslation().ToMessage();
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
/// Search StepParagraphTranslation
/// </summary>
/// <param name="request">stepParagraphTranslation request.</param>
/// <returns>StepParagraphTranslation message.</returns>
public StepParagraphTranslationMessage FindStepParagraphTranslation(StepParagraphTranslationRequest request)
{
 StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
try
{
 message = serviceStepParagraphTranslation.FindStepParagraphTranslation(request.ToPivot()).ToMessage();
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