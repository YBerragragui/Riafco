using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;
using Riafco.Service.Dataflex.Pro.About.Response;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Assembler
{
    /// <summary>
    /// The SectionParagraph assembler class.
    /// </summary>
    public static class SectionParagraphAssembler
    {
        #region TO DTO
        /// <summary>
        /// From SectionParagraph Pivot To SectionParagraph Dto.
        /// </summary>
        /// <param name="sectionParagraphPivot">sectionParagraph pivot to assemble.</param>
        /// <returns>SectionParagraphDto result.</returns>
        public static SectionParagraphDto ToDto(this SectionParagraphPivot sectionParagraphPivot)
        {
            if (sectionParagraphPivot == null)
            {
                return null;
            }

            return new SectionParagraphDto
            {
                Section = sectionParagraphPivot.Section?.ToDto(),
                ParagraphId = sectionParagraphPivot.ParagraphId,
                SectionId = sectionParagraphPivot.SectionId
            };
        }

        /// <summary>
        /// From SectionParagraph pivot list to SectionParagraph dto list.
        /// </summary>
        /// <param name="sectionParagraphPivotList">sectionParagraph pivot liste to assemble.</param>
        /// <returns>SectionParagraphdto result.</returns>
        public static List<SectionParagraphDto> ToDtoList(this List<SectionParagraphPivot> sectionParagraphPivotList)
        {
            return sectionParagraphPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From SectionParagraph dto To SectionParagraph pivot.
        /// </summary>
        /// <param name="sectionParagraphDto">sectionParagraph dto to assemble.</param>
        /// <returns>SectionParagraphpivot result.</returns>
        public static SectionParagraphPivot ToPivot(this SectionParagraphDto sectionParagraphDto)
        {
            if (sectionParagraphDto == null)
            {
                return null;
            }

            return new SectionParagraphPivot
            {
                ParagraphId = sectionParagraphDto.ParagraphId,
                SectionId = sectionParagraphDto.SectionId,
                Section = sectionParagraphDto.Section.ToPivot(),
            };
        }

        /// <summary>
        /// From SectionParagraphpivot list To SectionParagraph pivot list.
        /// </summary>
        /// <param name="sectionParagraphDtoList">sectionParagraph dto list to assemble.</param>
        /// <returns>SectionParagraphPivot list result.</returns>
        public static List<SectionParagraphPivot> ToPivotList(this List<SectionParagraphDto> sectionParagraphDtoList)
        {
            return sectionParagraphDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From SectionParagraph Request to SectionParagraph Request pivot.
        /// </summary>
        /// <param name="request">the request to assemble.</param>
        /// <returns>SectionParagraph Request pivot result.</returns>
        public static SectionParagraphRequestPivot ToPivot(this SectionParagraphRequest request)
        {
            return new SectionParagraphRequestPivot
            {
                FindSectionParagraphPivot = Utility.EnumToEnum<FindSectionParagraphDto, FindSectionParagraphPivot>(request.FindSectionParagraphDto),
                SectionParagraphPivot = request.SectionParagraphDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From SectionParagraph Response pivot to SectionParagraph Message.
        /// </summary>
        /// <param name="response">SectionParagraph Response pivot to assemble.</param>
        /// <returns>SectionParagraph Message result.</returns>
        public static SectionParagraphMessage ToMessage(this SectionParagraphResponsePivot response)
        {
            return new SectionParagraphMessage
            {
                SectionParagraphDtoList = response?.SectionParagraphPivotList.ToDtoList(),
                SectionParagraphDto = response?.SectionParagraphPivot.ToDto(),
            };
        }
        #endregion
    }
}