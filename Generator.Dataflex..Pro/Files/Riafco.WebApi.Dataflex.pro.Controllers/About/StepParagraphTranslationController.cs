using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Riafco.WebApi.Service.Dataflex.pro.About.Interface;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;

namespace Riafco.WebApi.Dataflex.pro.Controllers{
/// <summary>
/// The StepParagraphTranslation web api controller.
/// </summary>
public class StepParagraphTranslationController : ApiController{
/// <summary>
/// The StepParagraphTranslation service client instance.
/// </summary>
private readonly IServiceStepParagraphTranslationClient serviceStepParagraphTranslationClient;

/// <summary>
/// Set the IServiceStepParagraphTranslationClient instane with injected instance.
/// </summary>
/// <param name="injectedServiceStepParagraphTranslationClient">injected instance</param>
public StepParagraphTranslationController(IServiceStepParagraphTranslationClient injectedServiceStepParagraphTranslationClient)
{
 this.serviceStepParagraphTranslationClient = injectedServiceStepParagraphTranslationClient;
}
/// <summary>
/// Create new StepParagraphTranslation
/// </summary>
/// <returns>StepParagraphTranslation message.</returns>
[Route("CreateStepParagraphTranslation")]
public IHttpActionResult CreateStepParagraphTranslation(StepParagraphTranslationRequest request)
{
 StepParagraphTranslationMessage message = serviceStepParagraphTranslationClient.CreateStepParagraphTranslation(request);
return Json(message); 
}

/// <summary>
/// Change StepParagraphTranslation informations.
/// </summary>
/// <returns>StepParagraphTranslation message.</returns>
[Route("UpdateStepParagraphTranslation")]
public IHttpActionResult UpdateStepParagraphTranslation(StepParagraphTranslationRequest request)
{
 StepParagraphTranslationMessage message = serviceStepParagraphTranslationClient.UpdateStepParagraphTranslation(request);
return Json(message); 
}

/// <summary>
/// Delete StepParagraphTranslation
/// </summary>
/// <returns>StepParagraphTranslation message.</returns>
[Route("RemoveStepParagraphTranslation")]
public IHttpActionResult DeleteStepParagraphTranslation(StepParagraphTranslationRequest request)
{
 StepParagraphTranslationMessage message = serviceStepParagraphTranslationClient.DeleteStepParagraphTranslation(request);
return Json(message); 
}

/// <summary>
/// Get list of StepParagraphTranslation
/// </summary>
/// <returns>StepParagraphTranslation message.</returns>
[Route("GetStepParagraphTranslations")]
public IHttpActionResult GetAllStepParagraphTranslation()
{
 StepParagraphTranslationMessage message = serviceStepParagraphTranslationClient.GetAllStepParagraphTranslation();
return Json(message); 
}

/// <summary>
/// Find StepParagraphTranslation
/// </summary>
/// <returns>StepParagraphTranslation message.</returns>
[Route("FindStepParagraphTranslation")]
public IHttpActionResult FindStepParagraphTranslation(StepParagraphTranslationRequest request)
{
 StepParagraphTranslationMessage message = serviceStepParagraphTranslationClient.FindStepParagraphTranslation(request);
return Json(message); 
}

}
}