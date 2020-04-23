using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Dto
{
/// <summary>
/// The StepParagraph dto class.
/// </summary>
 public class StepParagraphDto
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
public StepDto Step { get; set; }
}
}