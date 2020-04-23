using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;
using System;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.About.Request{
/// <summary>
/// Gets or Sets The  StepParagraph request class.
/// </summary>
public class StepParagraphRequestPivot{
/// <summary>
/// Gets or Sets The  StepParagraphPivot requested.
/// </summary>
public StepParagraphPivot StepParagraphPivot { get; set; }

/// <summary>
/// Gets or Sets The  Find StepParagraphEnum.
/// </summary>
public FindStepParagraphPivot FindStepParagraphPivot { get; set; }
}
}