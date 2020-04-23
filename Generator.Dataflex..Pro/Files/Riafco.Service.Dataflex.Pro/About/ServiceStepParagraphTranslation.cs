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
/// The StepParagraphTranslation service class.
/// </summary>
public class ServiceStepParagraphTranslation : IServiceStepParagraphTranslation{
/// <summary>
/// The UnitOfWork instance.
/// </summary>
private IUnitOfWork UnitOfWork;

#region contructors
/// <summary>
/// Constructor to create instance of the UnitOfWork.
/// </summary>
/// <param name="injectedUnitOfWork">the injected UnitOfWork to instance UnitOfWork attribute.</param>
public ServiceStepParagraphTranslation(IUnitOfWork injectedUnitOfWork)
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
/// Create new StepParagraphTranslation.
/// </summary>
/// <param name="stepParagraphTranslationRequestPivot">The StepParagraphTranslation Request Pivot to add.</param>
/// <returns>StepParagraphTranslation Response Pivot created.</returns>
public StepParagraphTranslationResponsePivot CreateStepParagraphTranslation(StepParagraphTranslationRequestPivot stepParagraphTranslationRequestPivot)
{
 if(stepParagraphTranslationRequestPivot == null)
{
 throw new Exception("The request pivot is null.");
}
StepParagraphTranslation stepParagraphTranslation = stepParagraphTranslationRequestPivot.StepParagraphTranslationPivot.ToStepParagraphTranslation();
UnitOfWork.StepParagraphTranslationRepository.Insert(stepParagraphTranslation);
UnitOfWork.Save();
return new StepParagraphTranslationResponsePivot()
{
 StepParagraphTranslationPivot = stepParagraphTranslation.ToPivot()
};
}

/// <summary>
/// Change StepParagraphTranslation values.
/// </summary>
/// <param name="stepParagraphTranslationRequestPivot">The StepParagraphTranslation Request Pivot to change.</param>
public void UpdateStepParagraphTranslation(StepParagraphTranslationRequestPivot stepParagraphTranslationRequestPivot)
{
 if(stepParagraphTranslationRequestPivot == null)
{
 throw new Exception("The request pivot is null.");
}
StepParagraphTranslation stepParagraphTranslation = UnitOfWork.StepParagraphTranslationRepository.GetByID(stepParagraphTranslationRequestPivot.StepParagraphTranslationPivot.TranslationId);
UnitOfWork.StepParagraphTranslationRepository.DetachObject(stepParagraphTranslation);
UnitOfWork.StepParagraphTranslationRepository.Update(stepParagraphTranslationRequestPivot.StepParagraphTranslationPivot.ToStepParagraphTranslation());
UnitOfWork.Save();

}

/// <summary>
/// Remove StepParagraphTranslation.
/// </summary>
/// <param name="stepParagraphTranslationRequestPivot">The StepParagraphTranslation Request Pivot to remove.</param>
public void DeleteStepParagraphTranslation(StepParagraphTranslationRequestPivot stepParagraphTranslationRequestPivot)
{
 if(stepParagraphTranslationRequestPivot == null)
{
 throw new Exception("The request pivot is null.");
}
StepParagraphTranslation stepParagraphTranslation = UnitOfWork.StepParagraphTranslationRepository.GetByID(stepParagraphTranslationRequestPivot.StepParagraphTranslationPivot.TranslationId);
stepParagraphTranslation.Deleted = true;
UnitOfWork.Save();

}

/// <summary>
/// Get the list of the StepParagraphTranslation.
/// </summary>
/// <returns>StepParagraphTranslation Response Pivot response.</returns>
public StepParagraphTranslationResponsePivot GetAllStepParagraphTranslation()
{
 return new StepParagraphTranslationResponsePivot()
{
 StepParagraphTranslationPivotList = UnitOfWork.StepParagraphTranslationRepository.Get().ToList().ToPivotList() };

}

/// <summary>
/// Search StepParagraphTranslation by id.
/// </summary>
/// <param name="stepParagraphTranslationRequestPivot">The StepParagraphTranslation Request Pivot to retrive.</param>
/// <returns>StepParagraphTranslation Response Pivot response.</returns>
public StepParagraphTranslationResponsePivot FindStepParagraphTranslation(StepParagraphTranslationRequestPivot stepParagraphTranslationRequestPivot){
 if(stepParagraphTranslationRequestPivot == null)
{
 throw new Exception("The request pivot is null.");
}
List<StepParagraphTranslationPivot> results = new List<StepParagraphTranslationPivot>();
StepParagraphTranslationPivot result = new StepParagraphTranslationPivot();
switch (stepParagraphTranslationRequestPivot.FindStepParagraphTranslationPivot)
{
case FindStepParagraphTranslationPivot.StepParagraphTranslationId:
result = UnitOfWork.StepParagraphTranslationRepository.GetById(stepParagraphTranslationRequestPivot.StepParagraphTranslationPivot.TranslationId)?.ToPivot();
break;
}
return new StepParagraphTranslationResponsePivot()
{
StepParagraphTranslationPivotList = results,
StepParagraphTranslationPivot = result
};
}
#endregion

}
}