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

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Assembler
{
    /// <summary>
    /// The ActivityFile assembler class.
    /// </summary>
    public static class ActivityFileAssembler
    {
        #region TO DTO
        /// <summary>
        /// From ActivityFile Pivot To ActivityFile Dto.
        /// </summary>
        /// <param name="activityFilePivot">activityFile pivot to assemble.</param>
        /// <returns>ActivityFileDto result.</returns>
        public static ActivityFileDto ToDto(this ActivityFilePivot activityFilePivot)
        {
            if (activityFilePivot == null)
            {
                return null;
            }
            return new ActivityFileDto
            {
                ActivityFileId = activityFilePivot.ActivityFileId,
                ActivityId = activityFilePivot.ActivityId,
                Activity = activityFilePivot.Activity.ToDto(),
            };
        }

        /// <summary>
        /// From ActivityFile pivot list to ActivityFile dto list.
        /// </summary>
        /// <param name="activityFilePivotList">activityFile pivot liste to assemble.</param>
        /// <returns>ActivityFiledto result.</returns>
        public static List<ActivityFileDto> ToDtoList(this List<ActivityFilePivot> activityFilePivotList)
        {
            return activityFilePivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From ActivityFile dto To ActivityFile pivot.
        /// </summary>
        /// <param name="activityFileDto">activityFile dto to assemble.</param>
        /// <returns>ActivityFilepivot result.</returns>
        public static ActivityFilePivot ToPivot(this ActivityFileDto activityFileDto)
        {
            if (activityFileDto == null)
            {
                return null;
            }
            return new ActivityFilePivot
            {
                ActivityFileId = activityFileDto.ActivityFileId,
                Activity = activityFileDto.Activity?.ToPivot(),
                ActivityId = activityFileDto.ActivityId
            };
        }

        /// <summary>
        /// From ActivityFilepivot list To ActivityFile pivot list.
        /// </summary>
        /// <param name="activityFileDtoList">activityFile dto list to assemble.</param>
        /// <returns>ActivityFilePivot list result.</returns>
        public static List<ActivityFilePivot> ToPivotList(this List<ActivityFileDto> activityFileDtoList)
        {
            return activityFileDtoList?.Select(x => x?.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From ActivityFile Request to ActivityFile Request pivot.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ActivityFile Request pivot result.</returns>
        public static ActivityFileRequestPivot ToPivot(this ActivityFileRequest request)
        {
            return new ActivityFileRequestPivot
            {
                FindActivityFilePivot = Utility.EnumToEnum<FindActivityFileDto, FindActivityFilePivot>(request.FindActivityFileDto),
                ActivityFilePivot = request.ActivityFileDto?.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From ActivityFile Response pivot to ActivityFile Message.
        /// </summary>
        /// <param name="response">ActivityFile Response pivot to assemble.</param>
        /// <returns>ActivityFile Message result.</returns>
        public static ActivityFileMessage ToMessage(this ActivityFileResponsePivot response)
        {
            if (response == null)
            {
                return null;
            }
            return new ActivityFileMessage
            {
                ActivityFileDtoList = response.ActivityFilePivotList?.ToDtoList(),
                ActivityFileDto = response.ActivityFilePivot?.ToDto()
            };
        }
        #endregion
    }
}