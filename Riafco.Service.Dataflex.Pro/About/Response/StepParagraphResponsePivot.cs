using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Data;

namespace Riafco.Service.Dataflex.Pro.About.Response
{
    /// <summary>
    /// The StepParagraph response class.
    /// </summary>
    public class StepParagraphResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  StepParagraphPivotList.
        /// </summary>
        public List<StepParagraphPivot> StepParagraphPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  StepParagraphPivot.
        /// </summary>
        public StepParagraphPivot StepParagraphPivot { get; set; }
    }
}