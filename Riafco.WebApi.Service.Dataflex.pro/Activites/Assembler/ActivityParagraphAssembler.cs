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

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Assembler
{
    /// <summary>
    /// The ActivityParagraph assembler class.
    /// </summary>
    public static class ActivityParagraphAssembler
    {
        #region TO DTO
        /// <summary>
        /// From ActivityParagraph Pivot To ActivityParagraph Dto.
        /// </summary>
        /// <param name="activityParagraphPivot">activityParagraph pivot to assemble.</param>
        /// <returns>ActivityParagraphDto result.</returns>
        public static ActivityParagraphDto ToDto(this ActivityParagraphPivot activityParagraphPivot)
        {
            if (activityParagraphPivot == null)
            {
                return null;
            }

            return new ActivityParagraphDto
            {
                ParagraphImage = activityParagraphPivot.ParagraphImage,
                Activity = activityParagraphPivot.Activity?.ToDto(),
                ParagraphId = activityParagraphPivot.ParagraphId,
                ActivityId = activityParagraphPivot.ActivityId
            };
        }

        /// <summary>
        /// From ActivityParagraph pivot list to ActivityParagraph dto list.
        /// </summary>
        /// <param name="activityParagraphPivotList">activityParagraph pivot liste to assemble.</param>
        /// <returns>ActivityParagraphdto result.</returns>
        public static List<ActivityParagraphDto> ToDtoList(this List<ActivityParagraphPivot> activityParagraphPivotList)
        {
            return activityParagraphPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From ActivityParagraph dto To ActivityParagraph pivot.
        /// </summary>
        /// <param name="activityParagraphDto">activityParagraph dto to assemble.</param>
        /// <returns>ActivityParagraphpivot result.</returns>
        public static ActivityParagraphPivot ToPivot(this ActivityParagraphDto activityParagraphDto)
        {
            if (activityParagraphDto == null)
            {
                return null;
            }

            return new ActivityParagraphPivot
            {
                ParagraphId = activityParagraphDto.ParagraphId,
                ParagraphImage = activityParagraphDto.ParagraphImage,
                ActivityId = activityParagraphDto.ActivityId,
                Activity = activityParagraphDto.Activity.ToPivot(),
            };
        }

        /// <summary>
        /// From ActivityParagraphpivot list To ActivityParagraph pivot list.
        /// </summary>
        /// <param name="activityParagraphDtoList">activityParagraph dto list to assemble.</param>
        /// <returns>ActivityParagraphPivot list result.</returns>
        public static List<ActivityParagraphPivot> ToPivotList(this List<ActivityParagraphDto> activityParagraphDtoList)
        {
            return activityParagraphDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From ActivityParagraph Request to ActivityParagraph Request pivot.
        /// </summary>
        /// <param name="request">the request to assemble.</param>
        /// <returns>ActivityParagraph Request pivot result.</returns>
        public static ActivityParagraphRequestPivot ToPivot(this ActivityParagraphRequest request)
        {
            return new ActivityParagraphRequestPivot
            {
                FindActivityParagraphPivot = Utility.EnumToEnum<FindActivityParagraphDto, FindActivityParagraphPivot>(request.FindActivityParagraphDto),
                ActivityParagraphPivot = request.ActivityParagraphDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From ActivityParagraph Response pivot to ActivityParagraph Message.
        /// </summary>
        /// <param name="response">ActivityParagraph Response pivot to assemble.</param>
        /// <returns>ActivityParagraph Message result.</returns>
        public static ActivityParagraphMessage ToMessage(this ActivityParagraphResponsePivot response)
        {
            return new ActivityParagraphMessage
            {
                ActivityParagraphDtoList = response?.ActivityParagraphPivotList.ToDtoList(),
                ActivityParagraphDto = response?.ActivityParagraphPivot.ToDto(),
            };
        }
        #endregion
    }
}