using Riafco.Framework.Dataflex.pro.Util;
using Riafco.Service.Dataflex.Pro.Languages.Data;
using Riafco.Service.Dataflex.Pro.Languages.Data.Enum;
using Riafco.Service.Dataflex.Pro.Languages.Request;
using Riafco.Service.Dataflex.Pro.Languages.Response;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Message;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Request;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler
{
    /// <summary>
    /// The Language assembler class.
    /// </summary>
    public static class LanguageAssembler
    {
        #region TO DTO
        /// <summary>
        /// From Language Pivot To Language Dto.
        /// </summary>
        /// <param name="languagePivot">language pivot to assemble.</param>
        /// <returns>LanguageDto result.</returns>
        public static LanguageDto ToDto(this LanguagePivot languagePivot)
        {
            if (languagePivot == null)
            {
                return null;
            }
            return new LanguageDto
            {
                LanguageId = languagePivot.LanguageId,
                LanguagePrefix = languagePivot.LanguagePrefix,
                LanguagePicture = languagePivot.LanguagePicture
            };
        }

        /// <summary>
        /// From Language pivot list to Language dto list.
        /// </summary>
        /// <param name="languagePivotList">language pivot liste to assemble.</param>
        /// <returns>Languagedto result.</returns>
        public static List<LanguageDto> ToDtoList(this List<LanguagePivot> languagePivotList)
        {
            return languagePivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From Language dto To Language pivot.
        /// </summary>
        /// <param name="languageDto">language dto to assemble.</param>
        /// <returns>Languagepivot result.</returns>
        public static LanguagePivot ToPivot(this LanguageDto languageDto)
        {
            if (languageDto == null)
            {
                return null;
            }
            return new LanguagePivot
            {
                LanguageId = languageDto.LanguageId,
                LanguagePrefix = languageDto.LanguagePrefix,
                LanguagePicture = languageDto.LanguagePicture,
            };
        }

        /// <summary>
        /// From Languagepivot list To Language pivot list.
        /// </summary>
        /// <param name="languageDtoList">language dto list to assemble.</param>
        /// <returns>LanguagePivot list result.</returns>
        public static List<LanguagePivot> ToPivotList(this List<LanguageDto> languageDtoList)
        {
            return languageDtoList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From Language Request to Language Request pivot.
        /// </summary>
        /// <param name="languageRequest">the request to assemble.</param>
        /// <returns>Language Request pivot result.</returns>
        public static LanguageRequestPivot ToPivot(this LanguageRequest languageRequest)
        {
            return new LanguageRequestPivot
            {
                LanguagePivot = languageRequest.LanguageDto.ToPivot(),
                FindLanguagePivot = Utility.EnumToEnum<FindLanguageDto, FindLanguagePivot>(languageRequest.FindLanguageDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Language Response pivot to Language Message.
        /// </summary>
        /// <param name="languageResponsePivot">language Response pivot to assemble.</param>
        /// <returns>Language Message result.</returns>
        public static LanguageMessage ToMessage(this LanguageResponsePivot languageResponsePivot)
        {
            return new LanguageMessage
            {
                LanguageDtoList = languageResponsePivot?.LanguagePivotList.ToDtoList(),
                LanguageDto = languageResponsePivot?.LanguagePivot.ToDto()
            };
        }
        #endregion

    }
}