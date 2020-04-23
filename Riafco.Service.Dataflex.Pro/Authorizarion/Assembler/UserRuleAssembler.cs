using Riafco.Entity.Dataflex.Pro.Authorizarion;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Authorizarion.Assembler
{
    /// <summary>
    /// The UserRule assembler class.
    /// </summary>
    public static class UserRuleAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From UserRule To UserRule Pivot.
        /// </summary>
        /// <param name="userRule">userRule TO ASSEMBLE</param>
        /// <returns>UserRulePivot result.</returns>
        public static UserRulePivot ToPivot(this UserRule userRule)
        {
            if (userRule == null)
            {
                return null;
            }
            return new UserRulePivot
            {
                UserRuleStatus = userRule.UserRuleStatus,
                UserRuleId = userRule.UserRuleId,
                User = userRule.User.ToPivot(),
                Rule = userRule.Rule.ToPivot(),
                UserId = userRule.UserId,
                RuleId = userRule.RuleId
            };
        }

        /// <summary>
        /// From UserRule list to UserRule pivot list.
        /// </summary>
        /// <param name="userRuleList">userRuleList to assemble.</param>
        /// <returns>list of UserRulePivot result.</returns>
        public static List<UserRulePivot> ToPivotList(this List<UserRule> userRuleList)
        {
            return userRuleList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From UserRulePivot to UserRule.
        /// </summary>
        /// <param name="userRulePivot">userRulePivot to assemble.</param>
        /// <returns>UserRule result.</returns>
        public static UserRule ToEntity(this UserRulePivot userRulePivot)
        {
            if (userRulePivot == null)
            {
                return null;
            }
            return new UserRule
            {
                UserRuleStatus = userRulePivot.UserRuleStatus,
                UserRuleId = userRulePivot.UserRuleId,
                User = userRulePivot.User.ToEntity(),
                Rule = userRulePivot.Rule.ToEntity(),
                UserId = userRulePivot.UserId,
                RuleId = userRulePivot.RuleId
            };
        }

        /// <summary>
        /// From UserRulePivotList to UserRuleList .
        /// </summary>
        /// <param name="userRulePivotList">UserRulePivotList to assemble.</param>
        /// <returns> list of UserRule result.</returns>
        public static List<UserRule> ToEntityList(this List<UserRulePivot> userRulePivotList)
        {
            return userRulePivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}