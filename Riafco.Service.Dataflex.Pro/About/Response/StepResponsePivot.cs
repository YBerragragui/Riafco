using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Data;

namespace Riafco.Service.Dataflex.Pro.About.Response
{
    /// <summary>
    /// The StepResponsePivot class.
    /// </summary>
    public class StepResponsePivot
    {
        /// <summary>
        /// Gets or Sets StepPivot.
        /// </summary>
        public StepPivot StepPivot { get; set; }

        /// <summary>
        /// Gets or Sets StepPivotList.
        /// </summary>
        public List<StepPivot> StepPivotList { get; set; }
    }
}