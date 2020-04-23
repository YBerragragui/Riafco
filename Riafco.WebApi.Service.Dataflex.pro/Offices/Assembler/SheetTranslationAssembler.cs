using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto;
using Riafco.Service.Dataflex.Pro.Offices.Data;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Request;
using Riafco.Service.Dataflex.Pro.Offices.Request;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Message;
using Riafco.Service.Dataflex.Pro.Offices.Response;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto.Enum;
using Riafco.Service.Dataflex.Pro.Offices.Data.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Assembler
{
    /// <summary>
    /// The SheetTranslation assembler class.
    /// </summary>
    public static class SheetTranslationAssembler
    {
        #region TODTO
        /// <summary>
        ///    From SheetTranslation Pivot To SheetTranslation Dto.
        /// </summary>
        /// <param name="sheetTranslationPivot">sheetTranslation pivot to assemble.</param>
        /// <returns>SheetTranslationDto result.</returns>
        public static SheetTranslationDto ToDto(this SheetTranslationPivot sheetTranslationPivot)
        {
            if (sheetTranslationPivot == null)
            {
                return null;
            }
            return new SheetTranslationDto
            {
                TranslationId = sheetTranslationPivot.TranslationId,
                SheetTitle = sheetTranslationPivot.SheetTitle,
                SheetValue = sheetTranslationPivot.SheetValue,
                LanguageId = sheetTranslationPivot.LanguageId,
                Language = sheetTranslationPivot.Language?.ToDto(),
                SheetId = sheetTranslationPivot.SheetId,
                Sheet = sheetTranslationPivot.Sheet?.ToDto(),
            };
        }

        /// <summary>
        ///    From SheetTranslation pivot list to SheetTranslation dto list.
        /// </summary>
        /// <param name="sheetTranslationPivotList">sheetTranslation pivot liste to assemble.</param>
        /// <returns>SheetTranslationdto result.</returns>
        public static List<SheetTranslationDto> ToDtoList(this List<SheetTranslationPivot> sheetTranslationPivotList)
        {
            return sheetTranslationPivotList?.Select(x => x?.ToDto()).ToList();

        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From SheetTranslation dto To SheetTranslation pivot.
        /// </summary>
        /// <param name="sheetTranslationDto">sheetTranslation dto to assemble.</param>
        /// <returns>SheetTranslationpivot result.</returns>
        public static SheetTranslationPivot ToPivot(this SheetTranslationDto sheetTranslationDto)
        {
            if (sheetTranslationDto == null)
            {
                return null;
            }
            return new SheetTranslationPivot
            {
                TranslationId = sheetTranslationDto.TranslationId,
                SheetTitle = sheetTranslationDto.SheetTitle,
                SheetValue = sheetTranslationDto.SheetValue,
                LanguageId = sheetTranslationDto.LanguageId,
                Language = sheetTranslationDto.Language?.ToPivot(),
                SheetId = sheetTranslationDto.SheetId,
                Sheet = sheetTranslationDto.Sheet?.ToPivot(),
            };
        }

        /// <summary>
        ///    From SheetTranslationpivot list To SheetTranslation pivot list.
        /// </summary>
        /// <param name="sheetTranslationDtoList">sheetTranslation dto list to assemble.</param>
        /// <returns>SheetTranslationPivot list result.</returns>
        public static List<SheetTranslationPivot> ToPivotList(this List<SheetTranslationDto> sheetTranslationDtoList)
        {
            return sheetTranslationDtoList?.Select(x => x?.ToPivot()).ToList();

        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From SheetTranslation Request to SheetTranslation Request pivot.
        /// </summary>
        /// <param name="sheetTranslationRequest"></param>
        /// <returns>SheetTranslation Request pivot result.</returns>
        public static SheetTranslationRequestPivot ToPivot(this SheetTranslationRequest sheetTranslationRequest)
        {
            return new SheetTranslationRequestPivot()
            {
                SheetTranslationPivot = sheetTranslationRequest.SheetTranslationDto?.ToPivot(),
                SheetTranslationPivotList = sheetTranslationRequest.SheetTranslationDtoList?.ToPivotList(),
                FindSheetTranslationPivot = Utility.EnumToEnum<FindSheetTranslationDto, FindSheetTranslationPivot>(sheetTranslationRequest.FindSheetTranslationDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From SheetTranslation Response pivot to SheetTranslation Message.
        /// </summary>
        /// <param name="sheetTranslationResponsePivot">SheetTranslation Response pivot to assemble.</param>
        /// <returns>SheetTranslation Message result.</returns>
        public static SheetTranslationMessage ToMessage(this SheetTranslationResponsePivot sheetTranslationResponsePivot)
        {
            if (sheetTranslationResponsePivot == null)
            {
                return null;
            }
            return new SheetTranslationMessage
            {
                SheetTranslationDtoList = sheetTranslationResponsePivot.SheetTranslationPivotList?.ToDtoList(),
                SheetTranslationDto = sheetTranslationResponsePivot.SheetTranslationPivot?.ToDto(),
            };
        }
        #endregion
    }
}