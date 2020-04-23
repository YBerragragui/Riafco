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
/// The Step service class.
/// </summary>
public class ServiceStep : IServiceStep{
/// <summary>
/// The UnitOfWork instance.
/// </summary>
private IUnitOfWork UnitOfWork;

#region contructors
/// <summary>
/// Constructor to create instance of the UnitOfWork.
/// </summary>
/// <param name="injectedUnitOfWork">the injected UnitOfWork to instance UnitOfWork attribute.</param>
public ServiceStep(IUnitOfWork injectedUnitOfWork)
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
/// Create new Step.
/// </summary>
/// <param name="stepRequestPivot">The Step Request Pivot to add.</param>
/// <returns>Step Response Pivot created.</returns>
public StepResponsePivot CreateStep(StepRequestPivot stepRequestPivot)
{
 if(stepRequestPivot == null)
{
 throw new Exception("The request pivot is null.");
}
Step step = stepRequestPivot.StepPivot.ToStep();
UnitOfWork.StepRepository.Insert(step);
UnitOfWork.Save();
return new StepResponsePivot()
{
 StepPivot = step.ToPivot()
};
}

/// <summary>
/// Change Step values.
/// </summary>
/// <param name="stepRequestPivot">The Step Request Pivot to change.</param>
public void UpdateStep(StepRequestPivot stepRequestPivot)
{
 if(stepRequestPivot == null)
{
 throw new Exception("The request pivot is null.");
}
Step step = UnitOfWork.StepRepository.GetByID(stepRequestPivot.StepPivot.StepId);
UnitOfWork.StepRepository.DetachObject(step);
UnitOfWork.StepRepository.Update(stepRequestPivot.StepPivot.ToStep());
UnitOfWork.Save();

}

/// <summary>
/// Remove Step.
/// </summary>
/// <param name="stepRequestPivot">The Step Request Pivot to remove.</param>
public void DeleteStep(StepRequestPivot stepRequestPivot)
{
 if(stepRequestPivot == null)
{
 throw new Exception("The request pivot is null.");
}
Step step = UnitOfWork.StepRepository.GetByID(stepRequestPivot.StepPivot.StepId);
step.Deleted = true;
UnitOfWork.Save();

}

/// <summary>
/// Get the list of the Step.
/// </summary>
/// <returns>Step Response Pivot response.</returns>
public StepResponsePivot GetAllStep()
{
 return new StepResponsePivot()
{
 StepPivotList = UnitOfWork.StepRepository.Get().ToList().ToPivotList() };

}

/// <summary>
/// Search Step by id.
/// </summary>
/// <param name="stepRequestPivot">The Step Request Pivot to retrive.</param>
/// <returns>Step Response Pivot response.</returns>
public StepResponsePivot FindStep(StepRequestPivot stepRequestPivot){
 if(stepRequestPivot == null)
{
 throw new Exception("The request pivot is null.");
}
List<StepPivot> results = new List<StepPivot>();
StepPivot result = new StepPivot();
switch (stepRequestPivot.FindStepPivot)
{
case FindStepPivot.StepId:
result = UnitOfWork.StepRepository.GetById(stepRequestPivot.StepPivot.StepId)?.ToPivot();
break;
}
return new StepResponsePivot()
{
StepPivotList = results,
StepPivot = result
};
}
#endregion

}
}