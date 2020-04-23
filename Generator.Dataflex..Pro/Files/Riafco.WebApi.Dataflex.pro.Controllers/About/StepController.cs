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
/// The Step web api controller.
/// </summary>
public class StepController : ApiController{
/// <summary>
/// The Step service client instance.
/// </summary>
private readonly IServiceStepClient serviceStepClient;

/// <summary>
/// Set the IServiceStepClient instane with injected instance.
/// </summary>
/// <param name="injectedServiceStepClient">injected instance</param>
public StepController(IServiceStepClient injectedServiceStepClient)
{
 this.serviceStepClient = injectedServiceStepClient;
}
/// <summary>
/// Create new Step
/// </summary>
/// <returns>Step message.</returns>
[Route("CreateStep")]
public IHttpActionResult CreateStep(StepRequest request)
{
 StepMessage message = serviceStepClient.CreateStep(request);
return Json(message); 
}

/// <summary>
/// Change Step informations.
/// </summary>
/// <returns>Step message.</returns>
[Route("UpdateStep")]
public IHttpActionResult UpdateStep(StepRequest request)
{
 StepMessage message = serviceStepClient.UpdateStep(request);
return Json(message); 
}

/// <summary>
/// Delete Step
/// </summary>
/// <returns>Step message.</returns>
[Route("RemoveStep")]
public IHttpActionResult DeleteStep(StepRequest request)
{
 StepMessage message = serviceStepClient.DeleteStep(request);
return Json(message); 
}

/// <summary>
/// Get list of Step
/// </summary>
/// <returns>Step message.</returns>
[Route("GetSteps")]
public IHttpActionResult GetAllStep()
{
 StepMessage message = serviceStepClient.GetAllStep();
return Json(message); 
}

/// <summary>
/// Find Step
/// </summary>
/// <returns>Step message.</returns>
[Route("FindStep")]
public IHttpActionResult FindStep(StepRequest request)
{
 StepMessage message = serviceStepClient.FindStep(request);
return Json(message); 
}

}
}