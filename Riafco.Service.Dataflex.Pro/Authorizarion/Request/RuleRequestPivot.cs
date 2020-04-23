using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Authorizarion.Request
{
    /// <summary>
    /// The RuleRequestPivot class.
    /// </summary>
    public class RuleRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  RulePivot requested.
        /// </summary>
        public RulePivot RulePivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find Rule.
        /// </summary>
        public FindRulePivot FindRulePivot { get; set; }
    }
}