using Riafco.Framework.Dataflex.pro.Util;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;
using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Response;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Assembler
{
    /// <summary>
    /// The SectionTranslation assembler class.
    /// </summary>
    public static class SectionTranslationAssembler
    {
        #region TO DTO
        /// <summary>
        /// From SectionTranslation Pivot To SectionTranslation Dto.
        /// </summary>
        /// <param name="sectionTranslationPivot">sectionTranslation pivot to assemble.</param>
        /// <returns>SectionTranslationDto result.</returns>
        public static SectionTranslationDto ToDto(this SectionTranslationPivot sectionTranslationPivot)
        {
            if (sectionTranslationPivot == null)
            {
                return null;
            }
            return new SectionTranslationDto
            {
                SectionDesciption = sectionTranslationPivot.SectionDesciption,
                TranslationId = sectionTranslationPivot.TranslationId,
                Language = sectionTranslationPivot.Language.ToDto(),
                SectionTitle = sectionTranslationPivot.SectionTitle,
                Section = sectionTranslationPivot.Section.ToDto(),
                LanguageId = sectionTranslationPivot.LanguageId,
                SectionId = sectionTranslationPivot.SectionId
            };
        }

        /// <summary>
        ///    From SectionTranslation pivot list to SectionTranslation dto list.
        /// </summary>
        /// <param name="sectionTranslationPivotList">sectionTranslation pivot liste to assemble.</param>
        /// <returns>SectionTranslationdto result.</returns>
        public static List<SectionTranslationDto> ToDtoList(this List<SectionTranslationPivot> sectionTranslationPivotList)
        {
            return sectionTranslationPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From SectionTranslation dto To SectionTranslation pivot.
        /// </summary>
        /// <param name="sectionTranslationDto">sectionTranslation dto to assemble.</param>
        /// <returns>SectionTranslationpivot result.</returns>
        public static SectionTranslationPivot ToPivot(this SectionTranslationDto sectionTranslationDto)
        {
            if (sectionTranslationDto == null)
            {
                return null;
            }
            return new SectionTranslationPivot
            {
                SectionDesciption = sectionTranslationDto.SectionDesciption,
                Language = sectionTranslationDto.Language.ToPivot(),
                TranslationId = sectionTranslationDto.TranslationId,
                SectionTitle = sectionTranslationDto.SectionTitle,
                Section = sectionTranslationDto.Section.ToPivot(),
                LanguageId = sectionTranslationDto.LanguageId,
                SectionId = sectionTranslationDto.SectionId
            };
        }

        /// <summary>
        /// From SectionTranslationpivot list To SectionTranslation pivot list.
        /// </summary>
        /// <param name="sectionTranslationDtoList">sectionTranslation dto list to assemble.</param>
        /// <returns>SectionTranslationPivot list result.</returns>
        public static List<SectionTranslationPivot> ToPivotList(this List<SectionTranslationDto> sectionTranslationDtoList)
        {
            return sectionTranslationDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT

        /// <summary>
        ///From SectionTranslation Request to SectionTranslation Request pivot.
        /// </summary>
        /// <param name="sectionTranslationRequest"></param>
        /// <returns>SectionTranslation Request pivot result.</returns>
        public static SectionTranslationRequestPivot ToPivot(this SectionTranslationRequest sectionTranslationRequest)
        {
            return new SectionTranslationRequestPivot()
            {
                SectionTranslationPivot = sectionTranslationRequest.SectionTranslationDto?.ToPivot(),
                SectionTranslationPivotList = sectionTranslationRequest.SectionTranslationDtoList.ToPivotList(),
                FindSectionTranslationPivot =
                    Utility.EnumToEnum<FindSectionTranslationDto, FindSectionTranslationPivot>(sectionTranslationRequest
                        .FindSectionTranslationDto)
            };
        }

        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From SectionTranslation Response pivot to SectionTranslation Message.
        /// </summary>
        /// <param name="sectionTranslationResponsePivot">SectionTranslation Response pivot to assemble.</param>
        /// <returns>SectionTranslation Message result.</returns>
        public static SectionTranslationMessage ToMessage(this SectionTranslationResponsePivot sectionTranslationResponsePivot)
        {
            if (sectionTranslationResponsePivot == null)
            {
                return null;
            }
            return new SectionTranslationMessage
            {
                SectionTranslationDtoList = sectionTranslationResponsePivot.SectionTranslationPivotList?.ToDtoList(),
                SectionTranslationDto = sectionTranslationResponsePivot.SectionTranslationPivot?.ToDto()
            };
        }
        #endregion
    }
}