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

namespace Riafco.WebApi.Service.Dataflex.pro.About.Assembler
{
    /// <summary>
    /// The StepParagraph assembler class.
    /// </summary>
    public static class StepParagraphAssembler
    {
        #region TODTO

        /// <summary>
        /// From StepParagraph Pivot To StepParagraph Dto.
        /// </summary>
        /// <param name="stepParagraphPivot">stepParagraph pivot to assemble.</param>
        /// <returns>StepParagraphDto result.</returns>
        public static StepParagraphDto ToDto(this StepParagraphPivot stepParagraphPivot)
        {
            if (stepParagraphPivot == null)
            {
                return null;
            }
            return new StepParagraphDto
            {
                Step = stepParagraphPivot.Step.ToDto(),
                ParagraphId = stepParagraphPivot.ParagraphId,
                StepId = stepParagraphPivot.StepId
            };
        }

        /// <summary>
        ///    From StepParagraph pivot list to StepParagraph dto list.
        /// </summary>
        /// <param name="stepParagraphPivotList">stepParagraph pivot liste to assemble.</param>
        /// <returns>StepParagraphdto result.</returns>
        public static List<StepParagraphDto> ToDtoList(this List<StepParagraphPivot> stepParagraphPivotList)
        {
            return stepParagraphPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT

        /// <summary>
        ///    From StepParagraph dto To StepParagraph pivot.
        /// </summary>
        /// <param name="stepParagraphDto">stepParagraph dto to assemble.</param>
        /// <returns>StepParagraphpivot result.</returns>
        public static StepParagraphPivot ToPivot(this StepParagraphDto stepParagraphDto)
        {
            if (stepParagraphDto == null)
            {
                return null;
            }
            return new StepParagraphPivot
            {
                ParagraphId = stepParagraphDto.ParagraphId,
                Step = stepParagraphDto.Step?.ToPivot(),
                StepId = stepParagraphDto.StepId
            };
        }

        /// <summary>
        ///    From StepParagraphpivot list To StepParagraph pivot list.
        /// </summary>
        /// <returns>StepParagraphPivot list result.</returns>
        public static List<StepParagraphPivot> ToPivotList(this List<StepParagraphDto> stepParagraphDtoList)
        {
            return stepParagraphDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT

        /// <summary>
        ///    From StepParagraph Request to StepParagraph Request pivot.
        /// </summary>
        /// <returns>StepParagraph Request pivot result.</returns>
        public static StepParagraphRequestPivot ToPivot(this StepParagraphRequest stepParagraphRequest)
        {
            return new StepParagraphRequestPivot
            {
                StepParagraphPivot = stepParagraphRequest.StepParagraphDto?.ToPivot(),
                FindStepParagraphPivot =
                    Utility.EnumToEnum<FindStepParagraphDto, FindStepParagraphPivot>(stepParagraphRequest
                        .FindStepParagraphDto)
            };
        }

        #endregion

        #region MESSAGE ASSEMBLER

        /// <summary>
        /// From StepParagraph Response pivot to StepParagraph Message.
        /// </summary>
        /// <returns>StepParagraph Message result.</returns>
        public static StepParagraphMessage ToMessage(this StepParagraphResponsePivot stepParagraphResponsePivot)
        {
            if (stepParagraphResponsePivot == null)
            {
                return null;
            }

            return new StepParagraphMessage
            {
                StepParagraphDtoList = stepParagraphResponsePivot.StepParagraphPivotList.ToDtoList(),
                StepParagraphDto = stepParagraphResponsePivot.StepParagraphPivot.ToDto()
            };
        }

        #endregion
    }
}