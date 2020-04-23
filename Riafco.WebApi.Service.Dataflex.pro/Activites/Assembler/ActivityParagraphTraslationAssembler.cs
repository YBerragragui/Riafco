using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;
using Riafco.Service.Dataflex.Pro.Activites.Response;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Assembler
{
    /// <summary>
    /// The ActivityParagraphTraslation assembler class.
    /// </summary>
    public static class ActivityParagraphTraslationAssembler
    {
        #region TO DTO
        /// <summary>
        /// From ActivityParagraphTraslation Pivot To ActivityParagraphTraslation Dto.
        /// </summary>
        /// <param name="activityParagraphTraslationPivot">activityParagraphTraslation pivot to assemble.</param>
        /// <returns>ActivityParagraphTraslationDto result.</returns>
        public static ActivityParagraphTranslationDto ToDto(this ActivityParagraphTranslationPivot activityParagraphTraslationPivot)
        {
            if (activityParagraphTraslationPivot == null)
            {
                return null;
            }
            return new ActivityParagraphTranslationDto
            {
                ActivityParagraph = activityParagraphTraslationPivot.ActivityParagraph.ToDto(),
                ParagraphDescription = activityParagraphTraslationPivot.ParagraphDescription,
                ParagraphTitle = activityParagraphTraslationPivot.ParagraphTitle,
                TranslationId = activityParagraphTraslationPivot.TranslationId,
                Language = activityParagraphTraslationPivot.Language.ToDto(),
                ParagraphId = activityParagraphTraslationPivot.ParagraphId,
                LanguageId = activityParagraphTraslationPivot.LanguageId
            };
        }

        /// <summary>
        /// From ActivityParagraphTraslation pivot list to ActivityParagraphTraslation dto list.
        /// </summary>
        /// <param name="activityParagraphTraslationPivotList">activityParagraphTraslation pivot liste to assemble.</param>
        /// <returns>ActivityParagraphTraslationdto result.</returns>
        public static List<ActivityParagraphTranslationDto> ToDtoList(this List<ActivityParagraphTranslationPivot> activityParagraphTraslationPivotList)
        {
            return activityParagraphTraslationPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From ActivityParagraphTraslation dto To ActivityParagraphTraslation pivot.
        /// </summary>
        /// <param name="activityParagraphTraslationDto">activityParagraphTraslation dto to assemble.</param>
        /// <returns>ActivityParagraphTraslationpivot result.</returns>
        public static ActivityParagraphTranslationPivot ToPivot(this ActivityParagraphTranslationDto activityParagraphTraslationDto)
        {
            if (activityParagraphTraslationDto == null)
            {
                return null;
            }

            return new ActivityParagraphTranslationPivot
            {
                ActivityParagraph = activityParagraphTraslationDto.ActivityParagraph.ToPivot(),
                ParagraphDescription = activityParagraphTraslationDto.ParagraphDescription,
                ParagraphTitle = activityParagraphTraslationDto.ParagraphTitle,
                Language = activityParagraphTraslationDto.Language.ToPivot(),
                TranslationId = activityParagraphTraslationDto.TranslationId,
                ParagraphId = activityParagraphTraslationDto.ParagraphId,
                LanguageId = activityParagraphTraslationDto.LanguageId
            };
        }

        /// <summary>
        /// From ActivityParagraphTraslationpivot list To ActivityParagraphTraslation pivot list.
        /// </summary>
        /// <param name="activityParagraphTraslationDtoList">activityParagraphTraslation dto list to assemble.</param>
        /// <returns>ActivityParagraphTranslationPivot list result.</returns>
        public static List<ActivityParagraphTranslationPivot> ToPivotList(this List<ActivityParagraphTranslationDto> activityParagraphTraslationDtoList)
        {
            return activityParagraphTraslationDtoList?.Select(x => x?.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From ActivityParagraphTraslation Request to ActivityParagraphTraslation Request pivot.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ActivityParagraphTraslation Request pivot result.</returns>
        public static ActivityParagraphTranslationRequestPivot ToPivot(this ActivityParagraphTranslationRequest request)
        {
            return new ActivityParagraphTranslationRequestPivot
            {
                FindActivityParagraphTranslationPivot = Utility.EnumToEnum<FindActivityParagraphTranslationDto, FindActivityParagraphTranslationPivot>(request.FindActivityParagraphTranslationDto),
                ActivityParagraphTranslationPivotList = request.ActivityParagraphTranslationDtoList?.ToPivotList(),
                ActivityParagraphTranslationPivot = request.ActivityParagraphTranslationDto?.ToPivot(),
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From ActivityParagraphTraslation Response pivot to ActivityParagraphTraslation Message.
        /// </summary>
        /// <param name="response">ActivityParagraphTraslation Response pivot to assemble.</param>
        /// <returns>ActivityParagraphTraslation Message result.</returns>
        public static ActivityParagraphTranslationMessage ToMessage(this ActivityParagraphTranslationResponsePivot response)
        {
            return new ActivityParagraphTranslationMessage
            {
                ActivityParagraphTranslationDtoList = response?.ActivityParagraphTranslationPivotList.ToDtoList(),
                ActivityParagraphTranslationDto = response?.ActivityParagraphTranslationPivot.ToDto(),
            };
        }
        #endregion
    }
}