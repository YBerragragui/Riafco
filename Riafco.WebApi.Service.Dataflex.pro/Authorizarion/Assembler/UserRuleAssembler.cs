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
    /// The UserRule assembler class.
    /// </summary>
    public static class UserRuleAssembler
    {
        #region TO DTO
        /// <summary>
        /// From UserRule Pivot To UserRule Dto.
        /// </summary>
        /// <param name="userRulePivot">userRule pivot to assemble.</param>
        /// <returns>UserRuleDto result.</returns>
        public static UserRuleDto ToDto(this UserRulePivot userRulePivot)
        {
            if (userRulePivot == null)
            {
                return new UserRuleDto();
            }
            return new UserRuleDto
            {
                UserRuleStatus = userRulePivot.UserRuleStatus,
                UserRuleId = userRulePivot.UserRuleId,
                User = userRulePivot.User.ToDto(),
                Rule = userRulePivot.Rule.ToDto(),
                UserId = userRulePivot.UserId,
                RuleId = userRulePivot.RuleId
            };
        }

        /// <summary>
        /// From UserRule pivot list to UserRule dto list.
        /// </summary>
        /// <param name="userRulePivotList">userRule pivot liste to assemble.</param>
        /// <returns>UserRuledto result.</returns>
        public static List<UserRuleDto> ToDtoList(this List<UserRulePivot> userRulePivotList)
        {
            return userRulePivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From UserRule dto To UserRule pivot.
        /// </summary>
        /// <param name="userRuleDto">userRule dto to assemble.</param>
        /// <returns>UserRulepivot result.</returns>
        public static UserRulePivot ToPivot(this UserRuleDto userRuleDto)
        {
            if (userRuleDto == null)
            {
                return new UserRulePivot();
            }
            return new UserRulePivot
            {
                UserRuleStatus = userRuleDto.UserRuleStatus,
                UserRuleId = userRuleDto.UserRuleId,
                User = userRuleDto.User.ToPivot(),
                Rule = userRuleDto.Rule.ToPivot(),
                RuleId = userRuleDto.RuleId,
                UserId = userRuleDto.UserId
            };
        }

        /// <summary>
        /// From UserRulepivot list To UserRule pivot list.
        /// </summary>
        /// <param name="userRuleDtoList">userRule dto list to assemble.</param>
        /// <returns>UserRulePivot list result.</returns>
        public static List<UserRulePivot> ToPivotList(this List<UserRuleDto> userRuleDtoList)
        {
            return userRuleDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From UserRule Request to UserRule Request pivot.
        /// </summary>
        /// <param name="userRuleRequest">the request to assemble.</param>
        /// <returns>UserRule Request pivot result.</returns>
        public static UserRuleRequestPivot ToPivot(this UserRuleRequest userRuleRequest)
        {
            return new UserRuleRequestPivot
            {
                FindUserRulePivot = Utility.EnumToEnum<FindUserRuleDto, FindUserRulePivot>(userRuleRequest.FindUserRuleDto),
                UserRulePivotList = userRuleRequest.UserRuleDtoList.ToPivotList(),
                UserRulePivot = userRuleRequest.UserRuleDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From UserRule Response pivot to UserRule Message.
        /// </summary>
        /// <param name="userRuleResponsePivot">userRule Response pivot to assemble.</param>
        /// <returns>UserRule Message result.</returns>
        public static UserRuleMessage ToMessage(this UserRuleResponsePivot userRuleResponsePivot)
        {
            return new UserRuleMessage
            {
                UserRuleDtoList = userRuleResponsePivot?.UserRulePivotList.ToDtoList(),
                UserRuleDto = userRuleResponsePivot?.UserRulePivot.ToDto()
            };
        }
        #endregion
    }
}