using Riafco.Service.Dataflex.Pro.Authorizarion.Request;
using Riafco.Service.Dataflex.Pro.Authorizarion.Response;

namespace Riafco.Service.Dataflex.Pro.Authorizarion.Interface
{
    /// <summary>
    /// The UserRule interface.
    /// </summary>
    public interface IServiceUserRule
    {
        /// <summary>
        /// Create UserRulePivot.
        /// </summary>
        /// <param name="request"> The UserRuleRequest Pivot that content UserRulePivot to add.</param>
        /// <returns>The UserRuleResponsePivot result with the UserRulePivot added.</returns>
        UserRuleResponsePivot CreateUserRule(UserRuleRequestPivot request);

        /// <summary>
        /// Update UserRulePivot.
        /// </summary>
        /// <param name="request"> The UserRuleRequest Pivot that content UserRulePivot to update.</param>
        void UpdateUserRule(UserRuleRequestPivot request);

        /// <summary>
        /// Update UserRulePivot.
        /// </summary>
        /// <param name="request"> The UserRuleRequest Pivot that content UserRulePivot to update.</param>
        void UpdateUserRuleRange(UserRuleRequestPivot request);

        /// <summary>
        /// Delete UserRulePivot.
        /// </summary>
        /// <param name="request"> The UserRuleRequest Pivot that content UserRulePivot to remove.</param>
        void DeleteUserRule(UserRuleRequestPivot request);

        /// <summary>
        /// Get UserRule list
        /// </summary>
        /// <returns>Response result.</returns>
        UserRuleResponsePivot GetAllUserRules();

        /// <summary>
        /// Search UserRule.
        /// </summary>
        /// <param name="request"> The UserRuleRequest Pivot that content UserRulePivot to remove.</param>
        /// <returns>Response Result.</returns>
        UserRuleResponsePivot FindUserRules(UserRuleRequestPivot request);
    }
}