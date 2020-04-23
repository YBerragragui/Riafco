using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Message;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Request;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Interface
{
    /// <summary>
    /// The Rule client interface.
    /// </summary>
    public interface IServiceRuleClient
    {
        /// <summary>
        /// Create Rule dto.
        /// </summary>
        /// <param name="ruleRequest"> The RuleRequest that content Ruledto to add.</param>
        /// <returns>The RuleMessagePivot result with the RulePivot to add.</returns>
        RuleMessage CreateRule(RuleRequest request);

        /// <summary>
        /// Update Rule dto.
        /// </summary>
        /// <param name="ruleRequest"> The RuleRequest that content Ruledto to update.</param>
        RuleMessage UpdateRule(RuleRequest request);

        /// <summary>
        /// Delete Rule dto.
        /// </summary>
        /// <param name="ruleRequest"> The RuleRequest that content Ruledto to remove.</param>
        /// <returns>The RuleMessagePivot result with the RulePivot removed.</returns>
        RuleMessage DeleteRule(RuleRequest request);

        /// <summary>
        /// Get the list of Rule.
        /// </summary>
        /// <returns>The RuleMessagePivot result with the RulePivot list.</returns>
        RuleMessage GetAllRules();

        /// <summary>
        /// Find Rule.
        /// </summary>
        /// <returns>The RuleMessagePivot result with the RulePivot list.</returns>
        RuleMessage FindRules(RuleRequest request);
    }
}