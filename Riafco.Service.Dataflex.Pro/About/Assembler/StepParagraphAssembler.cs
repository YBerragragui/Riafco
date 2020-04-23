using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Entity.Dataflex.Pro;
using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.About.Assembler;

namespace Riafco.Service.Dataflex.Pro.About.Assembler
{
    /// <summary>
    /// The StepParagraph assembler class.
    /// </summary>
    public static class StepParagraphAssembler
    {
        #region TO PIVOT 

        /// <summary>
        /// From StepParagraph To StepParagraph Pivot.
        /// </summary>
        /// <param name="stepParagraph">stepParagraph TO ASSEMBLE</param>
        /// <returns>StepParagraphPivot result.</returns>
        public static StepParagraphPivot ToPivot(this StepParagraph stepParagraph)
        {
            if (stepParagraph == null)
            {
                return null;
            }
            return new StepParagraphPivot()
            {
                ParagraphId = stepParagraph.ParagraphId,
                StepId = stepParagraph.StepId,
                Step = stepParagraph.Step.ToPivot(),
            };
        }

        /// <summary>
        /// From StepParagraph list to StepParagraph pivot list.
        /// </summary>
        /// <param name="stepParagraphList">stepParagraphList to assemble.</param>
        /// <returns>list of StepParagraphPivot result.</returns>
        public static List<StepParagraphPivot> ToPivotList(this List<StepParagraph> stepParagraphList)
        {
            return stepParagraphList?.Select(x => x.ToPivot()).ToList();

        }

        #endregion

        #region TO ENTITY 

        /// <summary>
        /// From StepParagraphPivot to StepParagraph.
        /// </summary>
        /// <param name="stepParagraphPivot">stepParagraphPivot to assemble.</param>
        /// <returns>StepParagraph result.</returns>
        public static StepParagraph ToEntity(this StepParagraphPivot stepParagraphPivot)
        {
            if (stepParagraphPivot == null)
            {
                return null;
            }
            return new StepParagraph
            {
                ParagraphId = stepParagraphPivot.ParagraphId,
                StepId = stepParagraphPivot.StepId,
                Step = stepParagraphPivot.Step.ToEntity()
            };
        }

        /// <summary>
        /// From StepParagraphPivotList to StepParagraphList .
        /// </summary>
        /// <param name="stepParagraphPivotList">StepParagraphPivotList to assemble.</param>
        /// <returns> list of StepParagraph result.</returns>
        public static List<StepParagraph> ToEntityList(this List<StepParagraphPivot> stepParagraphPivotList)
        {
            return stepParagraphPivotList?.Select(x => x.ToEntity()).ToList();
        }

        #endregion
    }
}