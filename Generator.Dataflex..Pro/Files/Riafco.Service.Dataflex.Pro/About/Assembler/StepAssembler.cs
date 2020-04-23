using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Entity.Dataflex.Pro;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.About.Assembler
{
 /// <summary>
/// The Step assembler class.
/// </summary>
public static class StepAssembler
{
 #region TO PIVOT 
/// <summary>
/// From Step To Step Pivot.
/// </summary>
/// <param name="step">step TO ASSEMBLE</param>
/// <returns>StepPivot result.</returns>
public static StepPivot ToPivot(this Step step)
{
if(step == null)
{
 return null; 
}
return new StepPivot()
{
StepId = step.StepId,
StepDate = step.StepDate,
};
}

/// <summary>
/// From Step list to Step pivot list.
/// </summary>
/// <param name="stepList">stepList to assemble.</param>
/// <returns>list of StepPivot result.</returns>
public static List<StepPivot> ToPivotList(this List<Step> stepList)
{
return stepList?.Select(x => x.ToPivot()).ToList();

}
 #endregion


#region TO ENTITY 
/// <summary>
/// From StepPivot to Step.
/// </summary>
/// <param name="stepPivot">stepPivot to assemble.</param>
/// <returns>Step result.</returns>
public static Step ToStep(this StepPivot stepPivot)
{
if(stepPivot == null)
{
 return null;
}
return new Step(){
StepId = stepPivot.StepId,
StepDate = stepPivot.StepDate,
};
}

/// <summary>
/// From StepPivotList to StepList .
/// </summary>
/// <param name="stepPivotList">StepPivotList to assemble.</param>
/// <returns> list of Step result.</returns>
public static List<Step> ToStepList(this List<StepPivot> stepPivotList)
{
return stepPivotList?.Select(x => x?.ToStep()).ToList();

}
 #endregion
 }
}