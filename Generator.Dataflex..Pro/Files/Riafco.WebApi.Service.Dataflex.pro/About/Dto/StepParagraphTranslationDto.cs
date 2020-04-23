using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Dto
{
/// <summary>
/// The StepParagraphTranslation dto class.
/// </summary>
 public class StepParagraphTranslationDto
{
 /// <summary>
/// Gets or Sets The  TranslationId.
/// </summary>
public int TranslationId { get; set; }

/// <summary>
/// Gets or Sets The  ParagraphTitle.
/// </summary>
public string ParagraphTitle { get; set; }

/// <summary>
/// Gets or Sets The  ParagraphDescription.
/// </summary>
public string ParagraphDescription { get; set; }

/// <summary>
/// Gets or Sets The  LanguageId.
/// </summary>
public int LanguageId { get; set; }

/// <summary>
/// Gets or Sets The  Language.
/// </summary>
public LanguageDto Language { get; set; }
/// <summary>
/// Gets or Sets The  ParagraphId.
/// </summary>
public int ParagraphId { get; set; }

/// <summary>
/// Gets or Sets The  StepParagraph.
/// </summary>
public StepParagraphDto StepParagraph { get; set; }
}
}