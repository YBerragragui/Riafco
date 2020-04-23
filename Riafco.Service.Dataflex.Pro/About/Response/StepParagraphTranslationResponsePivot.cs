using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Data;

namespace Riafco.Service.Dataflex.Pro.About.Response
{
    /// <summary>
    /// The StepParagraphTranslationResponsePivot class.
    /// </summary>
    public class StepParagraphTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets StepParagraphTranslationPivotList.
        /// </summary>
        public List<StepParagraphTranslationPivot> StepParagraphTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets StepParagraphTranslationPivot.
        /// </summary>
        public StepParagraphTranslationPivot StepParagraphTranslationPivot { get; set; }
    }
}