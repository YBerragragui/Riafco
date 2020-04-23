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
    /// The SectionFile assembler class.
    /// </summary>
    public static class SectionFileAssembler
    {
        #region TO DTO
        /// <summary>
        /// From SectionFile Pivot To SectionFile Dto.
        /// </summary>
        /// <param name="sectionFilePivot">sectionFile pivot to assemble.</param>
        /// <returns>SectionFileDto result.</returns>
        public static SectionFileDto ToDto(this SectionFilePivot sectionFilePivot)
        {
            if (sectionFilePivot == null)
            {
                return null;
            }
            return new SectionFileDto
            {
                SectionFileId = sectionFilePivot.SectionFileId,
                SectionId = sectionFilePivot.SectionId,
                Section = sectionFilePivot.Section.ToDto(),
            };
        }

        /// <summary>
        /// From SectionFile pivot list to SectionFile dto list.
        /// </summary>
        /// <param name="sectionFilePivotList">sectionFile pivot liste to assemble.</param>
        /// <returns>SectionFiledto result.</returns>
        public static List<SectionFileDto> ToDtoList(this List<SectionFilePivot> sectionFilePivotList)
        {
            return sectionFilePivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From SectionFile dto To SectionFile pivot.
        /// </summary>
        /// <param name="sectionFileDto">sectionFile dto to assemble.</param>
        /// <returns>SectionFilepivot result.</returns>
        public static SectionFilePivot ToPivot(this SectionFileDto sectionFileDto)
        {
            if (sectionFileDto == null)
            {
                return null;
            }
            return new SectionFilePivot
            {
                SectionFileId = sectionFileDto.SectionFileId,
                Section = sectionFileDto.Section?.ToPivot(),
                SectionId = sectionFileDto.SectionId
            };
        }

        /// <summary>
        /// From SectionFilepivot list To SectionFile pivot list.
        /// </summary>
        /// <param name="sectionFileDtoList">sectionFile dto list to assemble.</param>
        /// <returns>SectionFilePivot list result.</returns>
        public static List<SectionFilePivot> ToPivotList(this List<SectionFileDto> sectionFileDtoList)
        {
            return sectionFileDtoList?.Select(x => x?.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From SectionFile Request to SectionFile Request pivot.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>SectionFile Request pivot result.</returns>
        public static SectionFileRequestPivot ToPivot(this SectionFileRequest request)
        {
            return new SectionFileRequestPivot
            {
                FindSectionFilePivot = Utility.EnumToEnum<FindSectionFileDto, FindSectionFilePivot>(request.FindSectionFileDto),
                SectionFilePivot = request.SectionFileDto?.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From SectionFile Response pivot to SectionFile Message.
        /// </summary>
        /// <param name="response">SectionFile Response pivot to assemble.</param>
        /// <returns>SectionFile Message result.</returns>
        public static SectionFileMessage ToMessage(this SectionFileResponsePivot response)
        {
            if (response == null)
            {
                return null;
            }
            return new SectionFileMessage
            {
                SectionFileDtoList = response.SectionFilePivotList?.ToDtoList(),
                SectionFileDto = response.SectionFilePivot?.ToDto()
            };
        }
        #endregion
    }
}