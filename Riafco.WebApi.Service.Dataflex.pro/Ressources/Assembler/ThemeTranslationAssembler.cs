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
    /// The ThemeTranslation assembler class.
    /// </summary>
    public static class ThemeTranslationAssembler
    {
        #region TO DTO
        /// <summary>
        /// From ThemeTranslation Pivot To ThemeTranslation Dto.
        /// </summary>
        /// <param name="themeTranslationPivot">themeTranslation pivot to assemble.</param>
        /// <returns>ThemeTranslationDto result.</returns>
        public static ThemeTranslationDto ToDto(this ThemeTranslationPivot themeTranslationPivot)
        {
            if (themeTranslationPivot == null)
            {
                return null;
            }
            return new ThemeTranslationDto
            {
                TranslationId = themeTranslationPivot.TranslationId,
                ThemeName = themeTranslationPivot.ThemeName,
                ThemeId = themeTranslationPivot.ThemeId,
                Theme = themeTranslationPivot.Theme.ToDto(),
                LanguageId = themeTranslationPivot.LanguageId,
                Language = themeTranslationPivot.Language.ToDto(),
            };
        }

        /// <summary>
        /// From ThemeTranslation pivot list to ThemeTranslation dto list.
        /// </summary>
        /// <param name="themeTranslationPivotList">themeTranslation pivot liste to assemble.</param>
        /// <returns>ThemeTranslationdto result.</returns>
        public static List<ThemeTranslationDto> ToDtoList(this List<ThemeTranslationPivot> themeTranslationPivotList)
        {
            return themeTranslationPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From ThemeTranslation dto To ThemeTranslation pivot.
        /// </summary>
        /// <param name="themeTranslationDto">themeTranslation dto to assemble.</param>
        /// <returns>ThemeTranslationpivot result.</returns>
        public static ThemeTranslationPivot ToPivot(this ThemeTranslationDto themeTranslationDto)
        {
            if (themeTranslationDto == null)
            {
                return null;
            }
            return new ThemeTranslationPivot
            {
                TranslationId = themeTranslationDto.TranslationId,
                ThemeName = themeTranslationDto.ThemeName,
                ThemeId = themeTranslationDto.ThemeId,
                Theme = themeTranslationDto.Theme.ToPivot(),
                LanguageId = themeTranslationDto.LanguageId,
                Language = themeTranslationDto.Language.ToPivot()
            };
        }

        /// <summary>
        /// From ThemeTranslationpivot list To ThemeTranslation pivot list.
        /// </summary>
        /// <param name="themeTranslationDtoList">themeTranslation dto list to assemble.</param>
        /// <returns>ThemeTranslationPivot list result.</returns>
        public static List<ThemeTranslationPivot> ToPivotList(this List<ThemeTranslationDto> themeTranslationDtoList)
        {
            return themeTranslationDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From ThemeTranslation Request to ThemeTranslation Request pivot.
        /// </summary>
        /// <param name="themeTranslationRequest"></param>
        /// <returns>ThemeTranslation Request pivot result.</returns>
        public static ThemeTranslationRequestPivot ToPivot(this ThemeTranslationRequest themeTranslationRequest)
        {
            return new ThemeTranslationRequestPivot
            {
                FindThemeTranslationPivot = Utility.EnumToEnum<FindThemeTranslationDto, FindThemeTranslationPivot>(themeTranslationRequest.FindThemeTranslationDto),
                ThemeTranslationPivotList = themeTranslationRequest.ThemeTranslationDtoList.ToPivotList(),
                ThemeTranslationPivot = themeTranslationRequest.ThemeTranslationDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From ThemeTranslation Response pivot to ThemeTranslation Message.
        /// </summary>
        /// <param name="themeTranslationResponsePivot">ThemeTranslation Response pivot to assemble.</param>
        /// <returns>ThemeTranslation Message result.</returns>
        public static ThemeTranslationMessage ToMessage(this ThemeTranslationResponsePivot themeTranslationResponsePivot)
        {
            if (themeTranslationResponsePivot == null)
            {
                return null;
            }
            return new ThemeTranslationMessage
            {
                ThemeTranslationDtoList = themeTranslationResponsePivot.ThemeTranslationPivotList.ToDtoList(),
                ThemeTranslationDto = themeTranslationResponsePivot.ThemeTranslationPivot.ToDto()
            };
        }
        #endregion
    }
}