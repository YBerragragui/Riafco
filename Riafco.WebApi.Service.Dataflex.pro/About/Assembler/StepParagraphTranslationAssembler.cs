using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;
using Riafco.Service.Dataflex.Pro.About.Response;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Assembler
{
    /// <summary>
    /// The StepParagraphTranslation assembler class.
    /// </summary>
    public static class StepParagraphTranslationAssembler
    {
        #region TO DTO
        /// <summary>
        /// From StepParagraphTranslation Pivot To StepParagraphTranslation Dto.
        /// </summary>
        /// <param name="stepParagraphTranslationPivot">stepParagraphTranslation pivot to assemble.</param>
        /// <returns>StepParagraphTranslationDto result.</returns>
        public static StepParagraphTranslationDto ToDto(this StepParagraphTranslationPivot stepParagraphTranslationPivot)
        {
            if (stepParagraphTranslationPivot == null)
            {
                return null;
            }
            return new StepParagraphTranslationDto
            {
                TranslationId = stepParagraphTranslationPivot.TranslationId,
                ParagraphTitle = stepParagraphTranslationPivot.ParagraphTitle,
                ParagraphDescription = stepParagraphTranslationPivot.ParagraphDescription,
                LanguageId = stepParagraphTranslationPivot.LanguageId,
                Language = stepParagraphTranslationPivot.Language?.ToDto(),
                ParagraphId = stepParagraphTranslationPivot.ParagraphId,
                StepParagraph = stepParagraphTranslationPivot.StepParagraph?.ToDto(),
            };

        }

        /// <summary>
        ///    From StepParagraphTranslation pivot list to StepParagraphTranslation dto list.
        /// </summary>
        /// <param name="stepParagraphTranslationPivotList">stepParagraphTranslation pivot liste to assemble.</param>
        /// <returns>StepParagraphTranslationdto result.</returns>
        public static List<StepParagraphTranslationDto> ToDtoList(this List<StepParagraphTranslationPivot> stepParagraphTranslationPivotList)
        {
            return stepParagraphTranslationPivotList?.Select(x => x.ToDto()).ToList();

        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From StepParagraphTranslation dto To StepParagraphTranslation pivot.
        /// </summary>
        /// <param name="stepParagraphTranslationDto">stepParagraphTranslation dto to assemble.</param>
        /// <returns>StepParagraphTranslationpivot result.</returns>
        public static StepParagraphTranslationPivot ToPivot(this StepParagraphTranslationDto stepParagraphTranslationDto)
        {
            if (stepParagraphTranslationDto == null)
            {
                return null;
            }
            return new StepParagraphTranslationPivot
            {
                TranslationId = stepParagraphTranslationDto.TranslationId,
                ParagraphTitle = stepParagraphTranslationDto.ParagraphTitle,
                ParagraphDescription = stepParagraphTranslationDto.ParagraphDescription,
                LanguageId = stepParagraphTranslationDto.LanguageId,
                Language = stepParagraphTranslationDto.Language?.ToPivot(),
                ParagraphId = stepParagraphTranslationDto.ParagraphId,
                StepParagraph = stepParagraphTranslationDto.StepParagraph?.ToPivot(),
            };
        }
        /// <summary>
        ///    From StepParagraphTranslationpivot list To StepParagraphTranslation pivot list.
        /// </summary>
        /// <returns>StepParagraphTranslationPivot list result.</returns>
        public static List<StepParagraphTranslationPivot> ToPivotList(this List<StepParagraphTranslationDto> stepParagraphTranslationDtoList)
        {
            return stepParagraphTranslationDtoList?.Select(x => x.ToPivot()).ToList();

        }

        #endregion

        #region REQUEST ASSEMBLERT

        /// <summary>
        /// From StepParagraphTranslation Request to StepParagraphTranslation Request pivot.
        /// </summary>
        /// <returns>StepParagraphTranslation Request pivot result.</returns>
        public static StepParagraphTranslationRequestPivot ToPivot(this StepParagraphTranslationRequest stepParagraphTranslationRequest)
        {
            return new StepParagraphTranslationRequestPivot()
            {
                StepParagraphTranslationPivot = stepParagraphTranslationRequest.StepParagraphTranslationDto?.ToPivot(),
                FindStepParagraphTranslationPivot =
                    Utility.EnumToEnum<FindStepParagraphTranslationDto, FindStepParagraphTranslationPivot>(
                        stepParagraphTranslationRequest.FindStepParagraphTranslationDto),
                StepParagraphTranslationPivotList =
                    stepParagraphTranslationRequest.StepParagraphTranslationDtoList.ToPivotList()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER

        /// <summary>
        /// From StepParagraphTranslation Response pivot to StepParagraphTranslation Message.
        /// </summary>
        /// <returns>StepParagraphTranslation Message result.</returns>
        public static StepParagraphTranslationMessage ToMessage(this StepParagraphTranslationResponsePivot stepParagraphTranslationResponsePivot)
        {
            if (stepParagraphTranslationResponsePivot == null)
            {
                return null;
            }
            else
            {
                return new StepParagraphTranslationMessage()
                {
                    StepParagraphTranslationDtoList = stepParagraphTranslationResponsePivot.StepParagraphTranslationPivotList?.ToDtoList(),
                    StepParagraphTranslationDto = stepParagraphTranslationResponsePivot.StepParagraphTranslationPivot?.ToDto(),
                };
            }
        }

        #endregion

    }
}