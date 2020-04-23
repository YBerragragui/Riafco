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
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Assembler
{
    /// <summary>
    /// The AreaTranslation assembler class.
    /// </summary>
    public static class AreaTranslationAssembler
    {
        #region TO DTO
        /// <summary>
        /// From AreaTranslation Pivot To AreaTranslation Dto.
        /// </summary>
        /// <param name="areaTranslationPivot">areaTranslation pivot to assemble.</param>
        /// <returns>AreaTranslationDto result.</returns>
        public static AreaTranslationDto ToDto(this AreaTranslationPivot areaTranslationPivot)
        {
            if (areaTranslationPivot == null)
            {
                return null;
            }
            return new AreaTranslationDto
            {
                TranslationId = areaTranslationPivot.TranslationId,
                Language = areaTranslationPivot.Language.ToDto(),
                LanguageId = areaTranslationPivot.LanguageId,
                AreaName = areaTranslationPivot.AreaName,
                Area = areaTranslationPivot.Area.ToDto(),
                AreaId = areaTranslationPivot.AreaId
            };
        }

        /// <summary>
        ///    From AreaTranslation pivot list to AreaTranslation dto list.
        /// </summary>
        /// <param name="areaTranslationPivotList">areaTranslation pivot liste to assemble.</param>
        /// <returns>AreaTranslationdto result.</returns>
        public static List<AreaTranslationDto> ToDtoList(this List<AreaTranslationPivot> areaTranslationPivotList)
        {
            return areaTranslationPivotList?.Select(x => x.ToDto()).ToList();
        }
        #endregion

        #region TO PIVOT
        /// <summary>
        /// From AreaTranslation dto To AreaTranslation pivot.
        /// </summary>
        /// <param name="areaTranslationDto">areaTranslation dto to assemble.</param>
        /// <returns>AreaTranslationpivot result.</returns>
        public static AreaTranslationPivot ToPivot(this AreaTranslationDto areaTranslationDto)
        {
            if (areaTranslationDto == null)
            {
                return null;
            }
            return new AreaTranslationPivot
            {
                TranslationId = areaTranslationDto.TranslationId,
                AreaName = areaTranslationDto.AreaName,
                AreaId = areaTranslationDto.AreaId,
                Area = areaTranslationDto.Area?.ToPivot(),
                LanguageId = areaTranslationDto.LanguageId,
                Language = areaTranslationDto.Language?.ToPivot(),
            };
        }

        /// <summary>
        /// From AreaTranslationpivot list To AreaTranslation pivot list.
        /// </summary>
        /// <param name="areaTranslationDtoList">areaTranslation dto list to assemble.</param>
        /// <returns>AreaTranslationPivot list result.</returns>
        public static List<AreaTranslationPivot> ToPivotList(this List<AreaTranslationDto> areaTranslationDtoList)
        {
            return areaTranslationDtoList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From AreaTranslation Request to AreaTranslation Request pivot.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>AreaTranslation Request pivot result.</returns>
        public static AreaTranslationRequestPivot ToPivot(this AreaTranslationRequest request)
        {
            return new AreaTranslationRequestPivot
            {
                FindAreaTranslationPivot = Utility.EnumToEnum<FindAreaTranslationDto, FindAreaTranslationPivot>(request.FindAreaTranslationDto),
                AreaTranslationPivotList = request.AreaTranslationDtoList.ToPivotList(),
                AreaTranslationPivot = request.AreaTranslationDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From AreaTranslation Response pivot to AreaTranslation Message.
        /// </summary>
        /// <param name="response">AreaTranslation Response pivot to assemble.</param>
        /// <returns>AreaTranslation Message result.</returns>
        public static AreaTranslationMessage ToMessage(this AreaTranslationResponsePivot response)
        {
            if (response == null)
            {
                return null;
            }
            return new AreaTranslationMessage
            {
                AreaTranslationDtoList = response.AreaTranslationPivotList.ToDtoList(),
                AreaTranslationDto = response.AreaTranslationPivot.ToDto()
            };
        }

        #endregion
    }
}