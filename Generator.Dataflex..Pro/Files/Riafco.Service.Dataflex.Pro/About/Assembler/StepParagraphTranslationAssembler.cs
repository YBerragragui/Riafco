using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Entity.Dataflex.Pro;
using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;
using Riafco.Service.Dataflex.Pro.About.Assembler;

namespace Riafco.Service.Dataflex.Pro.About.Assembler
{
 /// <summary>
/// The StepParagraphTranslation assembler class.
/// </summary>
public static class StepParagraphTranslationAssembler
{
 #region TO PIVOT 
/// <summary>
/// From StepParagraphTranslation To StepParagraphTranslation Pivot.
/// </summary>
/// <param name="stepParagraphTranslation">stepParagraphTranslation TO ASSEMBLE</param>
/// <returns>StepParagraphTranslationPivot result.</returns>
public static StepParagraphTranslationPivot ToPivot(this StepParagraphTranslation stepParagraphTranslation)
{
if(stepParagraphTranslation == null)
{
 return null; 
}
return new StepParagraphTranslationPivot()
{
TranslationId = stepParagraphTranslation.TranslationId,
ParagraphTitle = stepParagraphTranslation.ParagraphTitle,
ParagraphDescription = stepParagraphTranslation.ParagraphDescription,
LanguageId = stepParagraphTranslation.LanguageId.Value,
Language = stepParagraphTranslation.Language?.ToPivot(),
ParagraphId = stepParagraphTranslation.ParagraphId.Value,
StepParagraph = stepParagraphTranslation.StepParagraph?.ToPivot(),
};
}

/// <summary>
/// From StepParagraphTranslation list to StepParagraphTranslation pivot list.
/// </summary>
/// <param name="stepParagraphTranslationList">stepParagraphTranslationList to assemble.</param>
/// <returns>list of StepParagraphTranslationPivot result.</returns>
public static List<StepParagraphTranslationPivot> ToPivotList(this List<StepParagraphTranslation> stepParagraphTranslationList)
{
return stepParagraphTranslationList?.Select(x => x.ToPivot()).ToList();

}
 #endregion


#region TO ENTITY 
/// <summary>
/// From StepParagraphTranslationPivot to StepParagraphTranslation.
/// </summary>
/// <param name="stepParagraphTranslationPivot">stepParagraphTranslationPivot to assemble.</param>
/// <returns>StepParagraphTranslation result.</returns>
public static StepParagraphTranslation ToStepParagraphTranslation(this StepParagraphTranslationPivot stepParagraphTranslationPivot)
{
if(stepParagraphTranslationPivot == null)
{
 return null;
}
return new StepParagraphTranslation(){
TranslationId = stepParagraphTranslationPivot.TranslationId,
ParagraphTitle = stepParagraphTranslationPivot.ParagraphTitle,
ParagraphDescription = stepParagraphTranslationPivot.ParagraphDescription,
LanguageId = stepParagraphTranslationPivot.LanguageId,
Language = stepParagraphTranslationPivot.Language?.ToLanguage(),
ParagraphId = stepParagraphTranslationPivot.ParagraphId,
StepParagraph = stepParagraphTranslationPivot.StepParagraph?.ToStepParagraph(),
};
}

/// <summary>
/// From StepParagraphTranslationPivotList to StepParagraphTranslationList .
/// </summary>
/// <param name="stepParagraphTranslationPivotList">StepParagraphTranslationPivotList to assemble.</param>
/// <returns> list of StepParagraphTranslation result.</returns>
public static List<StepParagraphTranslation> ToStepParagraphTranslationList(this List<StepParagraphTranslationPivot> stepParagraphTranslationPivotList)
{
return stepParagraphTranslationPivotList?.Select(x => x?.ToStepParagraphTranslation()).ToList();

}
 #endregion
 }
}