using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Response;
using Riafco.Service.Dataflex.Pro.About.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.About.Assembler;
using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.About{
/// <summary>
/// The StepParagraph service class.
/// </summary>
public class ServiceStepParagraph : IServiceStepParagraph{
/// <summary>
/// The UnitOfWork instance.
/// </summary>
private IUnitOfWork UnitOfWork;

#region contructors
/// <summary>
/// Constructor to create instance of the UnitOfWork.
/// </summary>
/// <param name="injectedUnitOfWork">the injected UnitOfWork to instance UnitOfWork attribute.</param>
public ServiceStepParagraph(IUnitOfWork injectedUnitOfWork)
{
 if(injectedUnitOfWork == null){
 throw new ArgumentNullException("unitOfWork");
}else
{
 UnitOfWork = injectedUnitOfWork;
}
}
#endregion

#region public methods
/// <summary>
/// Create new StepParagraph.
/// </summary>
/// <param name="stepParagraphRequestPivot">The StepParagraph Request Pivot to add.</param>
/// <returns>StepParagraph Response Pivot created.</returns>
public StepParagraphResponsePivot CreateStepParagraph(StepParagraphRequestPivot stepParagraphRequestPivot)
{
 if(stepParagraphRequestPivot == null)
{
 throw new Exception("The request pivot is null.");
}
StepParagraph stepParagraph = stepParagraphRequestPivot.StepParagraphPivot.ToStepParagraph();
UnitOfWork.StepParagraphRepository.Insert(stepParagraph);
UnitOfWork.Save();
return new StepParagraphResponsePivot()
{
 StepParagraphPivot = stepParagraph.ToPivot()
};
}

/// <summary>
/// Change StepParagraph values.
/// </summary>
/// <param name="stepParagraphRequestPivot">The StepParagraph Request Pivot to change.</param>
public void UpdateStepParagraph(StepParagraphRequestPivot stepParagraphRequestPivot)
{
 if(stepParagraphRequestPivot == null)
{
 throw new Exception("The request pivot is null.");
}
StepParagraph stepParagraph = UnitOfWork.StepParagraphRepository.GetByID(stepParagraphRequestPivot.StepParagraphPivot.ParagraphId);
UnitOfWork.StepParagraphRepository.DetachObject(stepParagraph);
UnitOfWork.StepParagraphRepository.Update(stepParagraphRequestPivot.StepParagraphPivot.ToStepParagraph());
UnitOfWork.Save();

}

/// <summary>
/// Remove StepParagraph.
/// </summary>
/// <param name="stepParagraphRequestPivot">The StepParagraph Request Pivot to remove.</param>
public void DeleteStepParagraph(StepParagraphRequestPivot stepParagraphRequestPivot)
{
 if(stepParagraphRequestPivot == null)
{
 throw new Exception("The request pivot is null.");
}
StepParagraph stepParagraph = UnitOfWork.StepParagraphRepository.GetByID(stepParagraphRequestPivot.StepParagraphPivot.ParagraphId);
stepParagraph.Deleted = true;
UnitOfWork.Save();

}

/// <summary>
/// Get the list of the StepParagraph.
/// </summary>
/// <returns>StepParagraph Response Pivot response.</returns>
public StepParagraphResponsePivot GetAllStepParagraph()
{
 return new StepParagraphResponsePivot()
{
 StepParagraphPivotList = UnitOfWork.StepParagraphRepository.Get().ToList().ToPivotList() };

}

/// <summary>
/// Search StepParagraph by id.
/// </summary>
/// <param name="stepParagraphRequestPivot">The StepParagraph Request Pivot to retrive.</param>
/// <returns>StepParagraph Response Pivot response.</returns>
public StepParagraphResponsePivot FindStepParagraph(StepParagraphRequestPivot stepParagraphRequestPivot){
 if(stepParagraphRequestPivot == null)
{
 throw new Exception("The request pivot is null.");
}
List<StepParagraphPivot> results = new List<StepParagraphPivot>();
StepParagraphPivot result = new StepParagraphPivot();
switch (stepParagraphRequestPivot.FindStepParagraphPivot)
{
case FindStepParagraphPivot.StepParagraphId:
result = UnitOfWork.StepParagraphRepository.GetById(stepParagraphRequestPivot.StepParagraphPivot.ParagraphId)?.ToPivot();
break;
}
return new StepParagraphResponsePivot()
{
StepParagraphPivotList = results,
StepParagraphPivot = result
};
}
#endregion

}
}