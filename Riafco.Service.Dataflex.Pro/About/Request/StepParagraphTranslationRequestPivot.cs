using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;
using System;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.About.Request
{
    /// <summary>
    /// The StepParagraphTranslationRequestPivot class.
    /// </summary>
    public class StepParagraphTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets StepParagraphTranslationPivot.
        /// </summary>
        public StepParagraphTranslationPivot StepParagraphTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets StepParagraphTranslationPivotList.
        /// </summary>
        public List<StepParagraphTranslationPivot> StepParagraphTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets FindStepParagraphTranslationPivot.
        /// </summary>
        public FindStepParagraphTranslationPivot FindStepParagraphTranslationPivot { get; set; }
    }
}