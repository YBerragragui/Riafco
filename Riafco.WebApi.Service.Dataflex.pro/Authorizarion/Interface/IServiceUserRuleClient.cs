using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Message;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Request;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Interface
{
    /// <summary>
    /// The UserRule client interface.
    /// </summary>
    public interface IServiceUserRuleClient
    {
        /// <summary>
        /// Create UserRule dto.
        /// </summary>
        /// <param name="request"> The UserRuleRequest that content UserRuledto to add.</param>
        /// <returns>The UserRuleMessagePivot result with the UserRulePivot to add.</returns>
        UserRuleMessage CreateUserRule(UserRuleRequest request);

        /// <summary>
        /// Update UserRule dto.
        /// </summary>
        /// <param name="request"> The UserRuleRequest that content UserRuledto to update.</param>
        UserRuleMessage UpdateUserRule(UserRuleRequest request);

        /// <summary>
        /// Update UserRule dto.
        /// </summary>
        /// <param name="request"> The UserRuleRequest that content UserRuledto to update.</param>
        UserRuleMessage UpdateUserRuleRange(UserRuleRequest request);

        /// <summary>
        /// Delete UserRule dto.
        /// </summary>
        /// <param name="request"> The UserRuleRequest that content UserRuledto to remove.</param>
        /// <returns>The UserRuleMessagePivot result with the UserRulePivot removed.</returns>
        UserRuleMessage DeleteUserRule(UserRuleRequest request);

        /// <summary>
        /// Get the list of UserRule.
        /// </summary>
        /// <returns>The UserRuleMessagePivot result with the UserRulePivot list.</returns>
        UserRuleMessage GetAllUserRules();

        /// <summary>
        /// Find UserRule.
        /// </summary>
        /// <returns>The UserRuleMessagePivot result with the UserRulePivot list.</returns>
        UserRuleMessage FindUserRules(UserRuleRequest request);
    }
}