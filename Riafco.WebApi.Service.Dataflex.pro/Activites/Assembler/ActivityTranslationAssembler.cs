using Riafco.Framework.Dataflex.pro.Util;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;
using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Response;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Assembler
{
    /// <summary>
    /// The ActivityTranslation assembler class.
    /// </summary>
    public static class ActivityTranslationAssembler
    {
        #region TO DTO
        /// <summary>
        /// From ActivityTranslation Pivot To ActivityTranslation Dto.
        /// </summary>
        /// <param name="activityTranslationPivot">activityTranslation pivot to assemble.</param>
        /// <returns>ActivityTranslationDto result.</returns>
        public static ActivityTranslationDto ToDto(this ActivityTranslationPivot activityTranslationPivot)
        {
            if (activityTranslationPivot == null)
            {
                return null;
            }
            return new ActivityTranslationDto()
            {
                TranslationId = activityTranslationPivot.TranslationId,
                ActivityTitle = activityTranslationPivot.ActivityTitle,
                ActivityIntroduction = activityTranslationPivot.ActivityIntroduction,
                ActivityDescription = activityTranslationPivot.ActivityDescription,
                LanguageId = activityTranslationPivot.LanguageId,
                Language = activityTranslationPivot.Language.ToDto(),
                ActivityId = activityTranslationPivot.ActivityId,
                Activity = activityTranslationPivot.Activity.ToDto(),
            };
        }

        /// <summary>
        /// From ActivityTranslation pivot list to ActivityTranslation dto list.
        /// </summary>
        /// <param name="activityTranslationPivotList">activityTranslation pivot liste to assemble.</param>
        /// <returns>ActivityTranslationdto result.</returns>
        public static List<ActivityTranslationDto> ToDtoList(this List<ActivityTranslationPivot> activityTranslationPivotList)
        {
            return activityTranslationPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From ActivityTranslation dto To ActivityTranslation pivot.
        /// </summary>
        /// <param name="activityTranslationDto">activityTranslation dto to assemble.</param>
        /// <returns>ActivityTranslationpivot result.</returns>
        public static ActivityTranslationPivot ToPivot(this ActivityTranslationDto activityTranslationDto)
        {
            if (activityTranslationDto == null)
            {
                return null;
            }
            return new ActivityTranslationPivot
            {
                TranslationId = activityTranslationDto.TranslationId,
                ActivityTitle = activityTranslationDto.ActivityTitle,
                ActivityIntroduction = activityTranslationDto.ActivityIntroduction,
                ActivityDescription = activityTranslationDto.ActivityDescription,
                LanguageId = activityTranslationDto.LanguageId,
                Language = activityTranslationDto.Language.ToPivot(),
                ActivityId = activityTranslationDto.ActivityId,
                Activity = activityTranslationDto.Activity.ToPivot(),
            };
        }

        /// <summary>
        /// From ActivityTranslationpivot list To ActivityTranslation pivot list.
        /// </summary>
        /// <param name="activityTranslationDtoList">activityTranslation dto list to assemble.</param>
        /// <returns>ActivityTranslationPivot list result.</returns>
        public static List<ActivityTranslationPivot> ToPivotList(this List<ActivityTranslationDto> activityTranslationDtoList)
        {
            return activityTranslationDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From ActivityTranslation Request to ActivityTranslation Request pivot.
        /// </summary>
        /// <param name="request">the request to assemble.</param>
        /// <returns>ActivityTranslation Request pivot result.</returns>
        public static ActivityTranslationRequestPivot ToPivot(this ActivityTranslationRequest request)
        {
            if (request != null)
                return new ActivityTranslationRequestPivot
                {
                    ActivityTranslationPivot = request.ActivityTranslationDto.ToPivot(),
                    ActivityTranslationPivotList = request.ActivityTranslationDtoList.ToPivotList(),
                    FindActivityTranslationPivot =
                        Utility.EnumToEnum<FindActivityTranslationDto, FindActivityTranslationPivot>(request
                            .FindActivityTranslationDto)
                };
            return null;
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From ActivityTranslation Response pivot to ActivityTranslation Message.
        /// </summary>
        /// <param name="response">activityTranslation Response pivot to assemble.</param>
        /// <returns>ActivityTranslation Message result.</returns>
        public static ActivityTranslationMessage ToMessage(this ActivityTranslationResponsePivot response)
        {
            return new ActivityTranslationMessage
            {
                ActivityTranslationDtoList = response?.ActivityTranslationPivotList.ToDtoList(),
                ActivityTranslationDto = response?.ActivityTranslationPivot.ToDto(),
            };
        }
        #endregion
    }
}