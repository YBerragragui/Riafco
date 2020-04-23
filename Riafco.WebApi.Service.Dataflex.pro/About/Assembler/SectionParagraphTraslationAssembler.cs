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
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Assembler
{
    /// <summary>
    /// The SectionParagraphTraslation assembler class.
    /// </summary>
    public static class SectionParagraphTraslationAssembler
    {
        #region TO DTO
        /// <summary>
        /// From SectionParagraphTraslation Pivot To SectionParagraphTraslation Dto.
        /// </summary>
        /// <param name="sectionParagraphTraslationPivot">sectionParagraphTraslation pivot to assemble.</param>
        /// <returns>SectionParagraphTraslationDto result.</returns>
        public static SectionParagraphTranslationDto ToDto(this SectionParagraphTranslationPivot sectionParagraphTraslationPivot)
        {
            if (sectionParagraphTraslationPivot == null)
            {
                return null;
            }
            return new SectionParagraphTranslationDto
            {
                SectionParagraph = sectionParagraphTraslationPivot.SectionParagraph.ToDto(),
                ParagraphDescription = sectionParagraphTraslationPivot.ParagraphDescription,
                ParagraphTitle = sectionParagraphTraslationPivot.ParagraphTitle,
                TranslationId = sectionParagraphTraslationPivot.TranslationId,
                Language = sectionParagraphTraslationPivot.Language.ToDto(),
                ParagraphId = sectionParagraphTraslationPivot.ParagraphId,
                LanguageId = sectionParagraphTraslationPivot.LanguageId
            };
        }

        /// <summary>
        /// From SectionParagraphTraslation pivot list to SectionParagraphTraslation dto list.
        /// </summary>
        /// <param name="sectionParagraphTraslationPivotList">sectionParagraphTraslation pivot liste to assemble.</param>
        /// <returns>SectionParagraphTraslationdto result.</returns>
        public static List<SectionParagraphTranslationDto> ToDtoList(this List<SectionParagraphTranslationPivot> sectionParagraphTraslationPivotList)
        {
            return sectionParagraphTraslationPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From SectionParagraphTraslation dto To SectionParagraphTraslation pivot.
        /// </summary>
        /// <param name="sectionParagraphTraslationDto">sectionParagraphTraslation dto to assemble.</param>
        /// <returns>SectionParagraphTraslationpivot result.</returns>
        public static SectionParagraphTranslationPivot ToPivot(this SectionParagraphTranslationDto sectionParagraphTraslationDto)
        {
            if (sectionParagraphTraslationDto == null)
            {
                return null;
            }

            return new SectionParagraphTranslationPivot
            {
                SectionParagraph = sectionParagraphTraslationDto.SectionParagraph.ToPivot(),
                ParagraphDescription = sectionParagraphTraslationDto.ParagraphDescription,
                ParagraphTitle = sectionParagraphTraslationDto.ParagraphTitle,
                Language = sectionParagraphTraslationDto.Language.ToPivot(),
                TranslationId = sectionParagraphTraslationDto.TranslationId,
                ParagraphId = sectionParagraphTraslationDto.ParagraphId,
                LanguageId = sectionParagraphTraslationDto.LanguageId
            };
        }

        /// <summary>
        /// From SectionParagraphTraslationpivot list To SectionParagraphTraslation pivot list.
        /// </summary>
        /// <param name="sectionParagraphTraslationDtoList">sectionParagraphTraslation dto list to assemble.</param>
        /// <returns>SectionParagraphTranslationPivot list result.</returns>
        public static List<SectionParagraphTranslationPivot> ToPivotList(this List<SectionParagraphTranslationDto> sectionParagraphTraslationDtoList)
        {
            return sectionParagraphTraslationDtoList?.Select(x => x?.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From SectionParagraphTraslation Request to SectionParagraphTraslation Request pivot.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>SectionParagraphTraslation Request pivot result.</returns>
        public static SectionParagraphTranslationRequestPivot ToPivot(this SectionParagraphTranslationRequest request)
        {
            return new SectionParagraphTranslationRequestPivot
            {
                FindSectionParagraphTranslationPivot = Utility.EnumToEnum<FindSectionParagraphTranslationDto, FindSectionParagraphTranslationPivot>(request.FindSectionParagraphTranslationDto),
                SectionParagraphTranslationPivotList = request.SectionParagraphTranslationDtoList?.ToPivotList(),
                SectionParagraphTranslationPivot = request.SectionParagraphTranslationDto?.ToPivot(),
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From SectionParagraphTraslation Response pivot to SectionParagraphTraslation Message.
        /// </summary>
        /// <param name="response">SectionParagraphTraslation Response pivot to assemble.</param>
        /// <returns>SectionParagraphTraslation Message result.</returns>
        public static SectionParagraphTranslationMessage ToMessage(this SectionParagraphTranslationResponsePivot response)
        {
            return new SectionParagraphTranslationMessage
            {
                SectionParagraphTranslationDtoList = response?.SectionParagraphTranslationPivotList.ToDtoList(),
                SectionParagraphTranslationDto = response?.SectionParagraphTranslationPivot.ToDto(),
            };
        }
        #endregion
    }
}