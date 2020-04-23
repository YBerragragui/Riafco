using System;
using System.Collections.Generic;
using System.Linq;
using OMS.Socle.Framework.Util;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;
using Riafco.Service.Dataflex.Pro.About.Response;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Assembler
{
/// <summary>
/// The Step assembler class.
/// </summary>
public static class StepAssembler
{
 #region TODTO
 /// <summary>
///    From Step Pivot To Step Dto.
/// </summary>
/// <param name="stepPivot">step pivot to assemble.</param>
/// <returns>StepDto result.</returns>
public static StepDto ToDto(this StepPivot stepPivot)
{
 if(stepPivot == null)
{
 return null;
}
 else 
{
  return new StepDto(){
StepId = stepPivot.StepId,
StepDate = stepPivot.StepDate,
};
}
}

/// <summary>
///    From Step pivot list to Step dto list.
/// </summary>
/// <param name="stepPivotList">step pivot liste to assemble.</param>
/// <returns>Stepdto result.</returns>
public static List<StepDto> ToDtoList(this List<StepPivot> stepPivotList)
{
 return stepPivotList?.Select(x => x?.ToDto()).ToList();

}
 
#endregion

#region TO PIVOT
 /// <summary>
///    From Step dto To Step pivot.
/// </summary>
/// <param name="stepDto">step dto to assemble.</param>
/// <returns>Steppivot result.</returns>
public static StepPivot ToPivot(this StepDto stepDto)
{
 if(stepDto == null)
{
return null; 
}
 else
{
 return new StepPivot(){
StepId = stepDto.StepId,
StepDate = stepDto.StepDate,
};

}
}

/// <summary>
///    From Steppivot list To Step pivot list.
/// </summary>
/// <param name="stepPivotList">step dto list to assemble.</param>
/// <returns>StepPivot list result.</returns>
public static List<StepPivot> ToPivotList(this List<StepDto> stepDtoList)
{
return stepDtoList?.Select(x => x?.ToPivot()).ToList();

}
 
#endregion

#region REQUEST ASSEMBLERT
 /// <summary>
///    From Step Request to Step Request pivot.
/// </summary>
/// <param name="StepRequest"></param>
/// <returns>Step Request pivot result.</returns>
public static StepRequestPivot ToPivot(this StepRequest stepRequest)
{
 return new StepRequestPivot(){
StepPivot = stepRequest.StepDto?.ToPivot(),
 FindStepPivot = Utility.EnumToEnum<FindStepDto, FindStepPivot>(stepRequest.FindStepDto)
};
}
 #endregion

#region MESSAGE ASSEMBLER
 /// <summary>
/// From Step Response pivot to Step Message.
/// </summary>
/// <param name="StepResponse">Step Response pivot to assemble.</param>
/// <returns>Step Message result.</returns>
public static StepMessage ToMessage(this StepResponsePivot stepResponsePivot)
{
 if(stepResponsePivot == null)
{
return null;}else{ return new StepMessage()
{
StepDtoList = stepResponsePivot.StepPivotList?.ToDtoList(),
StepDto = stepResponsePivot.StepPivot?.ToDto(),
};
}
}

 #endregion

}
}