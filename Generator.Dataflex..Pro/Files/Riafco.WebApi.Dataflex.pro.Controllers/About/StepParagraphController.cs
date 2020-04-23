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
/// The StepParagraph web api controller.
/// </summary>
public class StepParagraphController : ApiController{
/// <summary>
/// The StepParagraph service client instance.
/// </summary>
private readonly IServiceStepParagraphClient serviceStepParagraphClient;

/// <summary>
/// Set the IServiceStepParagraphClient instane with injected instance.
/// </summary>
/// <param name="injectedServiceStepParagraphClient">injected instance</param>
public StepParagraphController(IServiceStepParagraphClient injectedServiceStepParagraphClient)
{
 this.serviceStepParagraphClient = injectedServiceStepParagraphClient;
}
/// <summary>
/// Create new StepParagraph
/// </summary>
/// <returns>StepParagraph message.</returns>
[Route("CreateStepParagraph")]
public IHttpActionResult CreateStepParagraph(StepParagraphRequest request)
{
 StepParagraphMessage message = serviceStepParagraphClient.CreateStepParagraph(request);
return Json(message); 
}

/// <summary>
/// Change StepParagraph informations.
/// </summary>
/// <returns>StepParagraph message.</returns>
[Route("UpdateStepParagraph")]
public IHttpActionResult UpdateStepParagraph(StepParagraphRequest request)
{
 StepParagraphMessage message = serviceStepParagraphClient.UpdateStepParagraph(request);
return Json(message); 
}

/// <summary>
/// Delete StepParagraph
/// </summary>
/// <returns>StepParagraph message.</returns>
[Route("RemoveStepParagraph")]
public IHttpActionResult DeleteStepParagraph(StepParagraphRequest request)
{
 StepParagraphMessage message = serviceStepParagraphClient.DeleteStepParagraph(request);
return Json(message); 
}

/// <summary>
/// Get list of StepParagraph
/// </summary>
/// <returns>StepParagraph message.</returns>
[Route("GetStepParagraphs")]
public IHttpActionResult GetAllStepParagraph()
{
 StepParagraphMessage message = serviceStepParagraphClient.GetAllStepParagraph();
return Json(message); 
}

/// <summary>
/// Find StepParagraph
/// </summary>
/// <returns>StepParagraph message.</returns>
[Route("FindStepParagraph")]
public IHttpActionResult FindStepParagraph(StepParagraphRequest request)
{
 StepParagraphMessage message = serviceStepParagraphClient.FindStepParagraph(request);
return Json(message); 
}

}
}