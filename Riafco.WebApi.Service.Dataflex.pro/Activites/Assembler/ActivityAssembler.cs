using Riafco.Framework.Dataflex.pro.Util;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;
using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Response;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Assembler
{
    /// <summary>
    /// The Activity assembler class.
    /// </summary>
    public static class ActivityAssembler
    {
        #region TO DTO
        /// <summary>
        /// From Activity Pivot To Activity Dto.
        /// </summary>
        /// <param name="activityPivot">activity pivot to assemble.</param>
        /// <returns>ActivityDto result.</returns>
        public static ActivityDto ToDto(this ActivityPivot activityPivot)
        {
            if (activityPivot == null)
            {
                return null;
            }
            return new ActivityDto
            {
                ActivityId = activityPivot.ActivityId,
                ActivityIcon = activityPivot.ActivityIcon,
                ActivityImage = activityPivot.ActivityImage
            };
        }

        /// <summary>
        /// From Activity pivot list to Activity dto list.
        /// </summary>
        /// <param name="activityPivotList">activity pivot liste to assemble.</param>
        /// <returns>Activitydto result.</returns>
        public static List<ActivityDto> ToDtoList(this List<ActivityPivot> activityPivotList)
        {
            return activityPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From Activity dto To Activity pivot.
        /// </summary>
        /// <param name="activityDto">activity dto to assemble.</param>
        /// <returns>Activitypivot result.</returns>
        public static ActivityPivot ToPivot(this ActivityDto activityDto)
        {
            if (activityDto == null)
            {
                return null;
            }
            return new ActivityPivot
            {
                ActivityId = activityDto.ActivityId,
                ActivityIcon = activityDto.ActivityIcon,
                ActivityImage = activityDto.ActivityImage
            };
        }

        /// <summary>
        /// From Activitypivot list To Activity pivot list.
        /// </summary>
        /// <param name="activityDtoList">activity dto list to assemble.</param>
        /// <returns>ActivityPivot list result.</returns>
        public static List<ActivityPivot> ToPivotList(this List<ActivityDto> activityDtoList)
        {
            return activityDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From Activity Request to Activity Request pivot.
        /// </summary>
        /// <param name="request">the request to assemble.</param>
        /// <returns>Activity Request pivot result.</returns>
        public static ActivityRequestPivot ToPivot(this ActivityRequest request)
        {
            return new ActivityRequestPivot
            {
                FindActivityPivot = Utility.EnumToEnum<FindActivityDto, FindActivityPivot>(request.FindActivityDto),
                ActivityPivot = request.ActivityDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Activity Response pivot to Activity Message.
        /// </summary>
        /// <param name="response">activity Response pivot to assemble.</param>
        /// <returns>Activity Message result.</returns>
        public static ActivityMessage ToMessage(this ActivityResponsePivot response)
        {
            return new ActivityMessage
            {
                ActivityDtoList = response?.ActivityPivotList.ToDtoList(),
                ActivityDto = response?.ActivityPivot.ToDto()
            };
        }
        #endregion
    }
}