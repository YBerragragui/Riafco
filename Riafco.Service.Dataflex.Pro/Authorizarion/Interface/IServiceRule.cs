using Riafco.Service.Dataflex.Pro.Authorizarion.Request;
using Riafco.Service.Dataflex.Pro.Authorizarion.Response;

namespace Riafco.Service.Dataflex.Pro.Authorizarion.Interface
{
    /// <summary>
    /// The Rule interface.
    /// </summary>
    public interface IServiceRule
    {
        /// <summary>
        /// Create RulePivot.
        /// </summary>
        /// <param name="request"> The RuleRequest Pivot that content RulePivot to add.</param>
        /// <returns>The RuleResponsePivot result with the RulePivot added.</returns>
        RuleResponsePivot CreateRule(RuleRequestPivot request);

        /// <summary>
        /// Update RulePivot.
        /// </summary>
        /// <param name="request"> The RuleRequest Pivot that content RulePivot to update.</param>
        void UpdateRule(RuleRequestPivot request);

        /// <summary>
        /// Delete RulePivot.
        /// </summary>
        /// <param name="request"> The RuleRequest Pivot that content RulePivot to remove.</param>
        void DeleteRule(RuleRequestPivot request);

        /// <summary>
        /// Get Rule list
        /// </summary>
        /// <returns>Response result.</returns>
        RuleResponsePivot GetAllRules();

        /// <summary>
        /// Search Rule.
        /// </summary>
        /// <param name="request"> The RuleRequest Pivot that content RulePivot to remove.</param>
        /// <returns>Response Result.</returns>
        RuleResponsePivot FindRules(RuleRequestPivot request);
    }
}