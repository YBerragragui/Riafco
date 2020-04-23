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
    /// The Theme assembler class.
    /// </summary>
    public static class ThemeAssembler
    {
        #region TO DTO
        /// <summary>
        /// From Theme Pivot To Theme Dto.
        /// </summary>
        /// <param name="themePivot">theme pivot to assemble.</param>
        /// <returns>ThemeDto result.</returns>
        public static ThemeDto ToDto(this ThemePivot themePivot)
        {
            if (themePivot == null)
            {
                return null;
            }
            return new ThemeDto
            {
                ThemeId = themePivot.ThemeId
            };
        }

        /// <summary>
        ///    From Theme pivot list to Theme dto list.
        /// </summary>
        /// <param name="themePivotList">theme pivot liste to assemble.</param>
        /// <returns>Themedto result.</returns>
        public static List<ThemeDto> ToDtoList(this List<ThemePivot> themePivotList)
        {
            return themePivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From Theme dto To Theme pivot.
        /// </summary>
        /// <param name="themeDto">theme dto to assemble.</param>
        /// <returns>Themepivot result.</returns>
        public static ThemePivot ToPivot(this ThemeDto themeDto)
        {
            if (themeDto == null)
            {
                return null;
            }
            return new ThemePivot
            {
                ThemeId = themeDto.ThemeId
            };
        }

        /// <summary>
        /// From Themepivot list To Theme pivot list.
        /// </summary>
        /// <param name="themeDtoList">theme dto list to assemble.</param>
        /// <returns>ThemePivot list result.</returns>
        public static List<ThemePivot> ToPivotList(this List<ThemeDto> themeDtoList)
        {
            return themeDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From Theme Request to Theme Request pivot.
        /// </summary>
        /// <param name="themeRequest"></param>
        /// <returns>Theme Request pivot result.</returns>
        public static ThemeRequestPivot ToPivot(this ThemeRequest themeRequest)
        {
            return new ThemeRequestPivot
            {
                FindThemePivot = Utility.EnumToEnum<FindThemeDto, FindThemePivot>(themeRequest.FindThemeDto),
                ThemePivot = themeRequest.ThemeDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Theme Response pivot to Theme Message.
        /// </summary>
        /// <param name="themeResponsePivot">Theme Response pivot to assemble.</param>
        /// <returns>Theme Message result.</returns>
        public static ThemeMessage ToMessage(this ThemeResponsePivot themeResponsePivot)
        {
            if (themeResponsePivot == null)
            {
                return null;
            }
            return new ThemeMessage
            {
                ThemeDtoList = themeResponsePivot.ThemePivotList.ToDtoList(),
                ThemeDto = themeResponsePivot.ThemePivot?.ToDto()
            };
        }
        #endregion
    }
}