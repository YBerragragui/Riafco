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
    /// The Section assembler class.
    /// </summary>
    public static class SectionAssembler
    {
        #region TODTO
        /// <summary>
        /// From Section Pivot To Section Dto.
        /// </summary>
        /// <param name="sectionPivot">section pivot to assemble.</param>
        /// <returns>SectionDto result.</returns>
        public static SectionDto ToDto(this SectionPivot sectionPivot)
        {
            if (sectionPivot == null)
            {
                return null;
            }

            return new SectionDto
            {
                SectionId = sectionPivot.SectionId,
                SectionImage = sectionPivot.SectionImage,
            };
        }

        /// <summary>
        /// From Section pivot list to Section dto list.
        /// </summary>
        /// <param name="sectionPivotList">section pivot liste to assemble.</param>
        /// <returns>Sectiondto result.</returns>
        public static List<SectionDto> ToDtoList(this List<SectionPivot> sectionPivotList)
        {
            return sectionPivotList?.Select(x => x?.ToDto()).ToList();

        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From Section dto To Section pivot.
        /// </summary>
        /// <param name="sectionDto">section dto to assemble.</param>
        /// <returns>Sectionpivot result.</returns>
        public static SectionPivot ToPivot(this SectionDto sectionDto)
        {
            if (sectionDto == null)
            {
                return null;
            }
            return new SectionPivot()
            {
                SectionId = sectionDto.SectionId,
                SectionImage = sectionDto.SectionImage,
            };
        }

        /// <summary>
        /// From Sectionpivot list To Section pivot list.
        /// </summary>
        /// <param name="sectionDtoList">section dto list to assemble.</param>
        /// <returns>SectionPivot list result.</returns>
        public static List<SectionPivot> ToPivotList(this List<SectionDto> sectionDtoList)
        {
            return sectionDtoList?.Select(x => x?.ToPivot()).ToList();

        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From Section Request to Section Request pivot.
        /// </summary>
        /// <param name="sectionRequest"></param>
        /// <returns>Section Request pivot result.</returns>
        public static SectionRequestPivot ToPivot(this SectionRequest sectionRequest)
        {
            return new SectionRequestPivot()
            {
                SectionPivot = sectionRequest.SectionDto?.ToPivot(),
                FindSectionPivot = Utility.EnumToEnum<FindSectionDto, FindSectionPivot>(sectionRequest.FindSectionDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Section Response pivot to Section Message.
        /// </summary>
        /// <param name="sectionResponsePivot">Section Response pivot to assemble.</param>
        /// <returns>Section Message result.</returns>
        public static SectionMessage ToMessage(this SectionResponsePivot sectionResponsePivot)
        {
            if (sectionResponsePivot == null)
            {
                return null;
            }
            return new SectionMessage()
            {
                SectionDtoList = sectionResponsePivot.SectionPivotList?.ToDtoList(),
                SectionDto = sectionResponsePivot.SectionPivot?.ToDto(),
            };
        }

        #endregion

    }
}