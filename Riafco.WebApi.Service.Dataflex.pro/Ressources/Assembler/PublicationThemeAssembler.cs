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
    /// The PublicationTheme assembler class.
    /// </summary>
    public static class PublicationThemeAssembler
    {
        #region TO DTO
        /// <summary>
        /// From PublicationTheme Pivot To PublicationTheme Dto.
        /// </summary>
        /// <param name="publicationThemePivot">publicationTheme pivot to assemble.</param>
        /// <returns>PublicationThemeDto result.</returns>
        public static PublicationThemeDto ToDto(this PublicationThemePivot publicationThemePivot)
        {
            if (publicationThemePivot == null)
            {
                return null;
            }
            return new PublicationThemeDto
            {
                PublicationThemeId = publicationThemePivot.PublicationThemeId,
                Publication = publicationThemePivot.Publication.ToDto(),
                PublicationId = publicationThemePivot.PublicationId,
                Theme = publicationThemePivot.Theme.ToDto(),
                ThemeId = publicationThemePivot.ThemeId
            };
        }

        /// <summary>
        ///    From PublicationTheme pivot list to PublicationTheme dto list.
        /// </summary>
        /// <param name="publicationThemePivotList">publicationTheme pivot liste to assemble.</param>
        /// <returns>PublicationThemedto result.</returns>
        public static List<PublicationThemeDto> ToDtoList(this List<PublicationThemePivot> publicationThemePivotList)
        {
            return publicationThemePivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From PublicationTheme dto To PublicationTheme pivot.
        /// </summary>
        /// <param name="publicationThemeDto">publicationTheme dto to assemble.</param>
        /// <returns>PublicationThemepivot result.</returns>
        public static PublicationThemePivot ToPivot(this PublicationThemeDto publicationThemeDto)
        {
            if (publicationThemeDto == null)
            {
                return null;
            }
            return new PublicationThemePivot
            {
                PublicationThemeId = publicationThemeDto.PublicationThemeId,
                Publication = publicationThemeDto.Publication.ToPivot(),
                PublicationId = publicationThemeDto.PublicationId,
                Theme = publicationThemeDto.Theme.ToPivot(),
                ThemeId = publicationThemeDto.ThemeId
            };
        }

        /// <summary>
        /// From PublicationThemepivot list To PublicationTheme pivot list.
        /// </summary>
        /// <param name="publicationThemeDtoList">publicationTheme dto list to assemble.</param>
        /// <returns>PublicationThemePivot list result.</returns>
        public static List<PublicationThemePivot> ToPivotList(this List<PublicationThemeDto> publicationThemeDtoList)
        {
            return publicationThemeDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From PublicationTheme Request to PublicationTheme Request pivot.
        /// </summary>
        /// <param name="publicationThemeRequest"></param>
        /// <returns>PublicationTheme Request pivot result.</returns>
        public static PublicationThemeRequestPivot ToPivot(this PublicationThemeRequest publicationThemeRequest)
        {
            return new PublicationThemeRequestPivot
            {
                FindPublicationThemePivot = Utility.EnumToEnum<FindPublicationThemeDto, FindPublicationThemePivot>(publicationThemeRequest.FindPublicationThemeDto),
                PublicationThemePivotList = publicationThemeRequest.PublicationThemeDtoList.ToPivotList(),
                PublicationThemePivot = publicationThemeRequest.PublicationThemeDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From PublicationTheme Response pivot to PublicationTheme Message.
        /// </summary>
        /// <param name="publicationThemeResponsePivot">PublicationTheme Response pivot to assemble.</param>
        /// <returns>PublicationTheme Message result.</returns>
        public static PublicationThemeMessage ToMessage(this PublicationThemeResponsePivot publicationThemeResponsePivot)
        {
            if (publicationThemeResponsePivot == null)
            {
                return null;
            }
            return new PublicationThemeMessage
            {
                PublicationThemeDtoList = publicationThemeResponsePivot.PublicationThemePivotList.ToDtoList(),
                PublicationThemeDto = publicationThemeResponsePivot.PublicationThemePivot.ToDto(),

                ThemeTranslationDtoList = publicationThemeResponsePivot.ThemeTranslationPivotList.ToDtoList(),
                ThemeTranslationDto = publicationThemeResponsePivot.ThemeTranslationPivot.ToDto(),

                PublicationTranslationDtoList = publicationThemeResponsePivot.PublicationTranslationPivotList.ToDtoList(),
                PublicationTranslationDto = publicationThemeResponsePivot.PublicationTranslationPivot.ToDto(),
            };
        }
        #endregion
    }
}