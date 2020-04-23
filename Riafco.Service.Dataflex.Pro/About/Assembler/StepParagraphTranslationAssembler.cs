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
            if (stepParagraphTranslation == null)
            {
                return null;
            }
            return new StepParagraphTranslationPivot
            {
                ParagraphDescription = stepParagraphTranslation.ParagraphDescription,
                StepParagraph = stepParagraphTranslation.StepParagraph.ToPivot(),
                ParagraphTitle = stepParagraphTranslation.ParagraphTitle,
                Language = stepParagraphTranslation.Language.ToPivot(),
                TranslationId = stepParagraphTranslation.TranslationId,
                ParagraphId = stepParagraphTranslation.ParagraphId,
                LanguageId = stepParagraphTranslation.LanguageId
            };
        }

        /// <summary>
        /// From StepParagraphTranslation list to StepParagraphTranslation pivot list.
        /// </summary>
        /// <param name="stepParagraphTranslationList">stepParagraphTranslationList to assemble.</param>
        /// <returns>list of StepParagraphTranslationPivot result.</returns>
        public static List<StepParagraphTranslationPivot> ToPivotList(
            this List<StepParagraphTranslation> stepParagraphTranslationList)
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
        public static StepParagraphTranslation ToEntity(
            this StepParagraphTranslationPivot stepParagraphTranslationPivot)
        {
            if (stepParagraphTranslationPivot == null)
            {
                return null;
            }
            return new StepParagraphTranslation
            {
                ParagraphDescription = stepParagraphTranslationPivot.ParagraphDescription,
                StepParagraph = stepParagraphTranslationPivot.StepParagraph.ToEntity(),
                ParagraphTitle = stepParagraphTranslationPivot.ParagraphTitle,
                Language = stepParagraphTranslationPivot.Language.ToEntity(),
                TranslationId = stepParagraphTranslationPivot.TranslationId,
                ParagraphId = stepParagraphTranslationPivot.ParagraphId,
                LanguageId = stepParagraphTranslationPivot.LanguageId
            };
        }

        /// <summary>
        /// From StepParagraphTranslationPivotList to StepParagraphTranslationList .
        /// </summary>
        /// <param name="stepParagraphTranslationPivotList">StepParagraphTranslationPivotList to assemble.</param>
        /// <returns> list of StepParagraphTranslation result.</returns>
        public static List<StepParagraphTranslation> ToEntityList(
            this List<StepParagraphTranslationPivot> stepParagraphTranslationPivotList)
        {
            return stepParagraphTranslationPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}