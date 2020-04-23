using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;
using Riafco.Service.Dataflex.Pro.Ressources.Response;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto.Enum;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Assembler
{
    /// <summary>
    /// The Area assembler class.
    /// </summary>
    public static class AreaAssembler
    {
        #region TO DTO
        /// <summary>
        /// From Area Pivot To Area Dto.
        /// </summary>
        /// <param name="areaPivot">area pivot to assemble.</param>
        /// <returns>AreaDto result.</returns>
        public static AreaDto ToDto(this AreaPivot areaPivot)
        {
            if (areaPivot == null)
            {
                return null;
            }
            return new AreaDto
            {
                AreaId = areaPivot.AreaId,
            };
        }

        /// <summary>
        ///    From Area pivot list to Area dto list.
        /// </summary>
        /// <param name="areaPivotList">area pivot liste to assemble.</param>
        /// <returns>Areadto result.</returns>
        public static List<AreaDto> ToDtoList(this List<AreaPivot> areaPivotList)
        {
            return areaPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From Area dto To Area pivot.
        /// </summary>
        /// <param name="areaDto">area dto to assemble.</param>
        /// <returns>Areapivot result.</returns>
        public static AreaPivot ToPivot(this AreaDto areaDto)
        {
            if (areaDto == null)
            {
                return null;
            }
            return new AreaPivot
            {
                AreaId = areaDto.AreaId,
            };
        }

        /// <summary>
        /// From Areapivot list To Area pivot list.
        /// </summary>
        /// <param name="areaDtoList">area dto list to assemble.</param>
        /// <returns>AreaPivot list result.</returns>
        public static List<AreaPivot> ToPivotList(this List<AreaDto> areaDtoList)
        {
            return areaDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From Area Request to Area Request pivot.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Area Request pivot result.</returns>
        public static AreaRequestPivot ToPivot(this AreaRequest request)
        {
            return new AreaRequestPivot
            {
                FindAreaPivot = Utility.EnumToEnum<FindAreaDto, FindAreaPivot>(request.FindAreaDto),
                AreaPivot = request.AreaDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Area Response pivot to Area Message.
        /// </summary>
        /// <param name="response">Area Response pivot to assemble.</param>
        /// <returns>Area Message result.</returns>
        public static AreaMessage ToMessage(this AreaResponsePivot response)
        {
            if (response == null)
            {
                return null;
            }
            return new AreaMessage
            {
                AreaDtoList = response.AreaPivotList?.ToDtoList(),
                AreaDto = response.AreaPivot?.ToDto()
            };
        }
        #endregion
    }
}