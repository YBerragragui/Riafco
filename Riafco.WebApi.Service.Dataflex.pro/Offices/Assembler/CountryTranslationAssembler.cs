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
    /// The CountryTranslation assembler class.
    /// </summary>
    public static class CountryTranslationAssembler
    {
        #region TODTO
        /// <summary>
        ///    From CountryTranslation Pivot To CountryTranslation Dto.
        /// </summary>
        /// <param name="countryTranslationPivot">countryTranslation pivot to assemble.</param>
        /// <returns>CountryTranslationDto result.</returns>
        public static CountryTranslationDto ToDto(this CountryTranslationPivot countryTranslationPivot)
        {
            if (countryTranslationPivot == null)
            {
                return null;
            }
            return new CountryTranslationDto()
            {
                TranslationId = countryTranslationPivot.TranslationId,
                CountryName = countryTranslationPivot.CountryName,
                CountryTitle = countryTranslationPivot.CountryTitle,
                CountryDescription = countryTranslationPivot.CountryDescription,
                CountrySummary = countryTranslationPivot.CountrySummary,
                CountryId = countryTranslationPivot.CountryId,
                Country = countryTranslationPivot.Country.ToDto(),
                LanguageId = countryTranslationPivot.LanguageId,
                Language = countryTranslationPivot.Language.ToDto(),
            };
        }

        /// <summary>
        ///    From CountryTranslation pivot list to CountryTranslation dto list.
        /// </summary>
        /// <param name="countryTranslationPivotList">countryTranslation pivot liste to assemble.</param>
        /// <returns>CountryTranslationdto result.</returns>
        public static List<CountryTranslationDto> ToDtoList(this List<CountryTranslationPivot> countryTranslationPivotList)
        {
            return countryTranslationPivotList?.Select(x => x?.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From CountryTranslation dto To CountryTranslation pivot.
        /// </summary>
        /// <param name="countryTranslationDto">countryTranslation dto to assemble.</param>
        /// <returns>CountryTranslationpivot result.</returns>
        public static CountryTranslationPivot ToPivot(this CountryTranslationDto countryTranslationDto)
        {
            if (countryTranslationDto == null)
            {
                return null;
            }
            return new CountryTranslationPivot()
            {
                TranslationId = countryTranslationDto.TranslationId,
                CountryName = countryTranslationDto.CountryName,
                CountryTitle = countryTranslationDto.CountryTitle,
                CountryDescription = countryTranslationDto.CountryDescription,
                CountrySummary = countryTranslationDto.CountrySummary,
                CountryId = countryTranslationDto.CountryId,
                Country = countryTranslationDto.Country?.ToPivot(),
                LanguageId = countryTranslationDto.LanguageId,
                Language = countryTranslationDto.Language?.ToPivot(),
            };
        }

        /// <summary>
        ///    From CountryTranslationpivot list To CountryTranslation pivot list.
        /// </summary>
        /// <param name="countryTranslationDtoList">countryTranslation dto list to assemble.</param>
        /// <returns>CountryTranslationPivot list result.</returns>
        public static List<CountryTranslationPivot> ToPivotList(this List<CountryTranslationDto> countryTranslationDtoList)
        {
            return countryTranslationDtoList?.Select(x => x?.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From CountryTranslation Request to CountryTranslation Request pivot.
        /// </summary>
        /// <param name="countryTranslationRequest"></param>
        /// <returns>CountryTranslation Request pivot result.</returns>
        public static CountryTranslationRequestPivot ToPivot(this CountryTranslationRequest countryTranslationRequest)
        {
            return new CountryTranslationRequestPivot()
            {
                CountryTranslationPivot = countryTranslationRequest.CountryTranslationDto?.ToPivot(),
                CountryTranslationPivotList = countryTranslationRequest.CountryTranslationDtoList?.ToPivotList(),
                FindCountryTranslationPivot = Utility.EnumToEnum<FindCountryTranslationDto, FindCountryTranslationPivot>(countryTranslationRequest.FindCountryTranslationDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From CountryTranslation Response pivot to CountryTranslation Message.
        /// </summary>
        /// <param name="countryTranslationResponsePivot">CountryTranslation Response pivot to assemble.</param>
        /// <returns>CountryTranslation Message result.</returns>
        public static CountryTranslationMessage ToMessage(this CountryTranslationResponsePivot countryTranslationResponsePivot)
        {
            if (countryTranslationResponsePivot == null)
            {
                return null;
            }
            return new CountryTranslationMessage()
            {
                CountryTranslationDtoList = countryTranslationResponsePivot.CountryTranslationPivotList?.ToDtoList(),
                CountryTranslationDto = countryTranslationResponsePivot.CountryTranslationPivot?.ToDto(),
            };
        }

        #endregion

    }
}