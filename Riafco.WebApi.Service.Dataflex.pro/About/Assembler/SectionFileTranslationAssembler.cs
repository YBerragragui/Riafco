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
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Assembler
{
    /// <summary>
    /// The SectionFileTranslation assembler class.
    /// </summary>
    public static class SectionFileTranslationAssembler
    {
        #region TODTO
        /// <summary>
        /// From SectionFileTranslation Pivot To SectionFileTranslation Dto.
        /// </summary>
        /// <param name="sectionFileTranslationPivot">sectionFileTranslation pivot to assemble.</param>
        /// <returns>SectionFileTranslationDto result.</returns>
        public static SectionFileTranslationDto ToDto(this SectionFileTranslationPivot sectionFileTranslationPivot)
        {
            if (sectionFileTranslationPivot == null)
            {
                return null;
            }
            return new SectionFileTranslationDto
            {
                SectionFileSource = sectionFileTranslationPivot.SectionFileSource,
                SectionFile = sectionFileTranslationPivot.SectionFile.ToDto(),
                SectionFileText = sectionFileTranslationPivot.SectionFileText,
                SectionFileId = sectionFileTranslationPivot.SectionFileId,
                TranslationId = sectionFileTranslationPivot.TranslationId,
                Language = sectionFileTranslationPivot.Language.ToDto(),
                LanguageId = sectionFileTranslationPivot.LanguageId
            };
        }

        /// <summary>
        /// From SectionFileTranslation pivot list to SectionFileTranslation dto list.
        /// </summary>
        /// <param name="sectionFileTranslationPivotList">sectionFileTranslation pivot liste to assemble.</param>
        /// <returns>SectionFileTranslationdto result.</returns>
        public static List<SectionFileTranslationDto> ToDtoList(this List<SectionFileTranslationPivot> sectionFileTranslationPivotList)
        {
            return sectionFileTranslationPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From SectionFileTranslation dto To SectionFileTranslation pivot.
        /// </summary>
        /// <param name="sectionFileTranslationDto">sectionFileTranslation dto to assemble.</param>
        /// <returns>SectionFileTranslationpivot result.</returns>
        public static SectionFileTranslationPivot ToPivot(this SectionFileTranslationDto sectionFileTranslationDto)
        {
            if (sectionFileTranslationDto == null)
            {
                return null;
            }
            return new SectionFileTranslationPivot
            {
                SectionFileSource = sectionFileTranslationDto.SectionFileSource,
                SectionFile = sectionFileTranslationDto.SectionFile?.ToPivot(),
                SectionFileText = sectionFileTranslationDto.SectionFileText,
                SectionFileId = sectionFileTranslationDto.SectionFileId,
                Language = sectionFileTranslationDto.Language?.ToPivot(),
                TranslationId = sectionFileTranslationDto.TranslationId,
                LanguageId = sectionFileTranslationDto.LanguageId
            };
        }

        /// <summary>
        /// From SectionFileTranslationpivot list To SectionFileTranslation pivot list.
        /// </summary>
        /// <param name="sectionFileTranslationDtoList">sectionFileTranslation dto list to assemble.</param>
        /// <returns>SectionFileTranslationPivot list result.</returns>
        public static List<SectionFileTranslationPivot> ToPivotList(this List<SectionFileTranslationDto> sectionFileTranslationDtoList)
        {
            return sectionFileTranslationDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From SectionFileTranslation Request to SectionFileTranslation Request pivot.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>SectionFileTranslation Request pivot result.</returns>
        public static SectionFileTranslationRequestPivot ToPivot(this SectionFileTranslationRequest request)
        {
            return new SectionFileTranslationRequestPivot
            {
                FindSectionFileTranslationPivot = Utility.EnumToEnum<FindSectionFileTranslationDto, FindSectionFileTranslationPivot>(request.FindSectionFileTranslationDto),
                SectionFileTranslationPivotList = request.SectionFileTranslationDtoList.ToPivotList(),
                SectionFileTranslationPivot = request.SectionFileTranslationDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From SectionFileTranslation Response pivot to SectionFileTranslation Message.
        /// </summary>
        /// <param name="response">SectionFileTranslation Response pivot to assemble.</param>
        /// <returns>SectionFileTranslation Message result.</returns>
        public static SectionFileTranslationMessage ToMessage(this SectionFileTranslationResponsePivot response)
        {
            if (response == null)
            {
                return null;
            }
            return new SectionFileTranslationMessage
            {
                SectionFileTranslationDtoList = response.SectionFileTranslationPivotList.ToDtoList(),
                SectionFileTranslationDto = response.SectionFileTranslationPivot.ToDto()
            };
        }
        #endregion
    }
}