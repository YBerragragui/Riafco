using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;
using System;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.About.Request{
/// <summary>
/// Gets or Sets The  Step request class.
/// </summary>
public class StepRequestPivot{
/// <summary>
/// Gets or Sets The  StepPivot requested.
/// </summary>
public StepPivot StepPivot { get; set; }

/// <summary>
/// Gets or Sets The  Find StepEnum.
/// </summary>
public FindStepPivot FindStepPivot { get; set; }
}
}