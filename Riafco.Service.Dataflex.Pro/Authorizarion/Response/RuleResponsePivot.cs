using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Authorizarion.Response
{
    /// <summary>
    /// The RuleResponsePivot class.
    /// </summary>
    public class RuleResponsePivot
    {
        /// <summary>
        /// Gets or Sets The RulePivotList.
        /// </summary>
        public List<RulePivot> RulePivotList { get; set; }

        /// <summary>
        /// Gets or Sets The RulePivot.
        /// </summary>
        public RulePivot RulePivot { get; set; }

    }
}