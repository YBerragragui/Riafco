using Riafco.Framework.Dataflex.pro.Util;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data.Enum;
using Riafco.Service.Dataflex.Pro.Authorizarion.Request;
using Riafco.Service.Dataflex.Pro.Authorizarion.Response;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Message;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Request;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Assembler
{
    /// <summary>
    /// The Rule assembler class.
    /// </summary>
    public static class RuleAssembler
    {
        #region TO DTO
        /// <summary>
        /// From Rule Pivot To Rule Dto.
        /// </summary>
        /// <param name="rulePivot">rule pivot to assemble.</param>
        /// <returns>RuleDto result.</returns>
        public static RuleDto ToDto(this RulePivot rulePivot)
        {
            if (rulePivot == null)
            {
                return null;
            }
            return new RuleDto
            {
                RulePrefix = rulePivot.RulePrefix,
                RuleName = rulePivot.RuleName,
                RuleId = rulePivot.RuleId
            };
        }

        /// <summary>
        /// From Rule pivot list to Rule dto list.
        /// </summary>
        /// <param name="rulePivotList">rule pivot liste to assemble.</param>
        /// <returns>Ruledto result.</returns>
        public static List<RuleDto> ToDtoList(this List<RulePivot> rulePivotList)
        {
            return rulePivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From Rule dto To Rule pivot.
        /// </summary>
        /// <param name="ruleDto">rule dto to assemble.</param>
        /// <returns>Rulepivot result.</returns>
        public static RulePivot ToPivot(this RuleDto ruleDto)
        {
            if (ruleDto == null)
            {
                return null;
            }
            return new RulePivot
            {
                RulePrefix = ruleDto.RulePrefix,
                RuleName = ruleDto.RuleName,
                RuleId = ruleDto.RuleId
            };
        }

        /// <summary>
        /// From Rulepivot list To Rule pivot list.
        /// </summary>
        /// <param name="ruleDtoList">rule dto list to assemble.</param>
        /// <returns>RulePivot list result.</returns>
        public static List<RulePivot> ToPivotList(this List<RuleDto> ruleDtoList)
        {
            return ruleDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From Rule Request to Rule Request pivot.
        /// </summary>
        /// <param name="ruleRequest">the request to assemble.</param>
        /// <returns>Rule Request pivot result.</returns>
        public static RuleRequestPivot ToPivot(this RuleRequest ruleRequest)
        {
            return new RuleRequestPivot
            {
                FindRulePivot = Utility.EnumToEnum<FindRuleDto, FindRulePivot>(ruleRequest.FindRuleDto),
                RulePivot = ruleRequest.RuleDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Rule Response pivot to Rule Message.
        /// </summary>
        /// <param name="ruleResponsePivot">rule Response pivot to assemble.</param>
        /// <returns>Rule Message result.</returns>
        public static RuleMessage ToMessage(this RuleResponsePivot ruleResponsePivot)
        {
            return new RuleMessage
            {
                RuleDtoList = ruleResponsePivot?.RulePivotList.ToDtoList(),
                RuleDto = ruleResponsePivot?.RulePivot.ToDto()
            };
        }
        #endregion
    }
}