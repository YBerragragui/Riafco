using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;
using System;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.About.Request
{
    /// <summary>
    /// The StepRequestPivot class.
    /// </summary>
    public class StepRequestPivot
    {
        /// <summary>
        /// Gets or sets StepPivot.
        /// </summary>
        public StepPivot StepPivot { get; set; }

        /// <summary>
        /// Gets or Sets FindStepPivot.
        /// </summary>
        public FindStepPivot FindStepPivot { get; set; }
    }
}