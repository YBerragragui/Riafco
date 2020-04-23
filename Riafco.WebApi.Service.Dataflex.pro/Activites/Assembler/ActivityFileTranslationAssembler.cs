using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;
using Riafco.Service.Dataflex.Pro.Activites.Response;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto.Enum;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Assembler
{
    /// <summary>
    /// The ActivityFileTranslation assembler class.
    /// </summary>
    public static class ActivityFileTranslationAssembler
    {
        #region TODTO
        /// <summary>
        /// From ActivityFileTranslation Pivot To ActivityFileTranslation Dto.
        /// </summary>
        /// <param name="activityFileTranslationPivot">activityFileTranslation pivot to assemble.</param>
        /// <returns>ActivityFileTranslationDto result.</returns>
        public static ActivityFileTranslationDto ToDto(this ActivityFileTranslationPivot activityFileTranslationPivot)
        {
            if (activityFileTranslationPivot == null)
            {
                return null;
            }
            return new ActivityFileTranslationDto
            {
                ActivityFileSource = activityFileTranslationPivot.ActivityFileSource,
                ActivityFile = activityFileTranslationPivot.ActivityFile.ToDto(),
                ActivityFileText = activityFileTranslationPivot.ActivityFileText,
                ActivityFileId = activityFileTranslationPivot.ActivityFileId,
                TranslationId = activityFileTranslationPivot.TranslationId,
                Language = activityFileTranslationPivot.Language.ToDto(),
                LanguageId = activityFileTranslationPivot.LanguageId
            };
        }

        /// <summary>
        /// From ActivityFileTranslation pivot list to ActivityFileTranslation dto list.
        /// </summary>
        /// <param name="activityFileTranslationPivotList">activityFileTranslation pivot liste to assemble.</param>
        /// <returns>ActivityFileTranslationdto result.</returns>
        public static List<ActivityFileTranslationDto> ToDtoList(this List<ActivityFileTranslationPivot> activityFileTranslationPivotList)
        {
            return activityFileTranslationPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From ActivityFileTranslation dto To ActivityFileTranslation pivot.
        /// </summary>
        /// <param name="activityFileTranslationDto">activityFileTranslation dto to assemble.</param>
        /// <returns>ActivityFileTranslationpivot result.</returns>
        public static ActivityFileTranslationPivot ToPivot(this ActivityFileTranslationDto activityFileTranslationDto)
        {
            if (activityFileTranslationDto == null)
            {
                return null;
            }
            return new ActivityFileTranslationPivot
            {
                ActivityFileSource = activityFileTranslationDto.ActivityFileSource,
                ActivityFile = activityFileTranslationDto.ActivityFile?.ToPivot(),
                ActivityFileText = activityFileTranslationDto.ActivityFileText,
                ActivityFileId = activityFileTranslationDto.ActivityFileId,
                Language = activityFileTranslationDto.Language?.ToPivot(),
                TranslationId = activityFileTranslationDto.TranslationId,
                LanguageId = activityFileTranslationDto.LanguageId
            };
        }

        /// <summary>
        /// From ActivityFileTranslationpivot list To ActivityFileTranslation pivot list.
        /// </summary>
        /// <param name="activityFileTranslationDtoList">activityFileTranslation dto list to assemble.</param>
        /// <returns>ActivityFileTranslationPivot list result.</returns>
        public static List<ActivityFileTranslationPivot> ToPivotList(this List<ActivityFileTranslationDto> activityFileTranslationDtoList)
        {
            return activityFileTranslationDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From ActivityFileTranslation Request to ActivityFileTranslation Request pivot.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ActivityFileTranslation Request pivot result.</returns>
        public static ActivityFileTranslationRequestPivot ToPivot(this ActivityFileTranslationRequest request)
        {
            return new ActivityFileTranslationRequestPivot
            {
                FindActivityFileTranslationPivot = Utility.EnumToEnum<FindActivityFileTranslationDto, FindActivityFileTranslationPivot>(request.FindActivityFileTranslationDto),
                ActivityFileTranslationPivotList = request.ActivityFileTranslationDtoList.ToPivotList(),
                ActivityFileTranslationPivot = request.ActivityFileTranslationDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From ActivityFileTranslation Response pivot to ActivityFileTranslation Message.
        /// </summary>
        /// <param name="response">ActivityFileTranslation Response pivot to assemble.</param>
        /// <returns>ActivityFileTranslation Message result.</returns>
        public static ActivityFileTranslationMessage ToMessage(this ActivityFileTranslationResponsePivot response)
        {
            if (response == null)
            {
                return null;
            }
            return new ActivityFileTranslationMessage
            {
                ActivityFileTranslationDtoList = response.ActivityFileTranslationPivotList.ToDtoList(),
                ActivityFileTranslationDto = response.ActivityFileTranslationPivot.ToDto()
            };
        }
        #endregion
    }
}