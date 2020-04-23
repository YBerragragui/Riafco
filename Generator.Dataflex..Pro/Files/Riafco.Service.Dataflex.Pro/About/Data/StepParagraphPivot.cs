using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Data;

namespace Riafco.Service.Dataflex.Pro.About.Data
{
 /// <summary>
/// The StepParagraph pivot class.
/// </summary>
public class StepParagraphPivot
{
 /// <summary>
/// Gets or Sets The  ParagraphId.
/// </summary>
public int ParagraphId { get; set; } 

/// <summary>
/// Gets or Sets The  StepId.
/// </summary>
public int StepId { get; set; } 

/// <summary>
/// Gets or Sets The  Step.
/// </summary>
public StepPivot Step { get; set; } 

 }
}