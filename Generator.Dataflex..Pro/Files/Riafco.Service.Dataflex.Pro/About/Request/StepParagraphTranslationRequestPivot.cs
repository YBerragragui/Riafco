using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;
using System;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.About.Request{
/// <summary>
/// Gets or Sets The  StepParagraphTranslation request class.
/// </summary>
public class StepParagraphTranslationRequestPivot{
/// <summary>
/// Gets or Sets The  StepParagraphTranslationPivot requested.
/// </summary>
public StepParagraphTranslationPivot StepParagraphTranslationPivot { get; set; }

/// <summary>
/// Gets or Sets The  Find StepParagraphTranslationEnum.
/// </summary>
public FindStepParagraphTranslationPivot FindStepParagraphTranslationPivot { get; set; }
}
}