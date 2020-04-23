using Riafco.Entity.Dataflex.Pro.Authorizarion;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Authorizarion.Assembler
{
    /// <summary>
    /// The Rule assembler class.
    /// </summary>
    public static class RuleAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Rule To Rule Pivot.
        /// </summary>
        /// <param name="rule">rule TO ASSEMBLE</param>
        /// <returns>RulePivot result.</returns>
        public static RulePivot ToPivot(this Rule rule)
        {
            if (rule == null)
            {
                return null;
            }
            return new RulePivot
            {
                RuleId = rule.RuleId,
                RulePrefix = rule.RulePrefix,
                RuleName = rule.RuleName
            };
        }

        /// <summary>
        /// From Rule list to Rule pivot list.
        /// </summary>
        /// <param name="ruleList">ruleList to assemble.</param>
        /// <returns>list of RulePivot result.</returns>
        public static List<RulePivot> ToPivotList(this List<Rule> ruleList)
        {
            return ruleList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From RulePivot to Rule.
        /// </summary>
        /// <param name="rulePivot">rulePivot to assemble.</param>
        /// <returns>Rule result.</returns>
        public static Rule ToEntity(this RulePivot rulePivot)
        {
            if (rulePivot == null)
            {
                return null;
            }
            return new Rule
            {
                RuleId = rulePivot.RuleId,
                RulePrefix = rulePivot.RulePrefix,
                RuleName = rulePivot.RuleName
            };
        }

        /// <summary>
        /// From RulePivotList to RuleList .
        /// </summary>
        /// <param name="rulePivotList">RulePivotList to assemble.</param>
        /// <returns> list of Rule result.</returns>
        public static List<Rule> ToEntityList(this List<RulePivot> rulePivotList)
        {
            return rulePivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}