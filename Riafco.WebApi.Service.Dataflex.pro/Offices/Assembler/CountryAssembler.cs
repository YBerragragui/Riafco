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

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Assembler
{
    /// <summary>
    /// The Country assembler class.
    /// </summary>
    public static class CountryAssembler
    {
        #region TODTO
        /// <summary>
        ///    From Country Pivot To Country Dto.
        /// </summary>
        /// <param name="countryPivot">country pivot to assemble.</param>
        /// <returns>CountryDto result.</returns>
        public static CountryDto ToDto(this CountryPivot countryPivot)
        {
            if (countryPivot == null)
            {
                return null;
            }
            return new CountryDto
            {
                CountryShortName = countryPivot.CountryShortName,
                CountryImage = countryPivot.CountryImage,
                CountryCode = countryPivot.CountryCode,
                CountryId = countryPivot.CountryId
            };
        }

        /// <summary>
        ///    From Country pivot list to Country dto list.
        /// </summary>
        /// <param name="countryPivotList">country pivot liste to assemble.</param>
        /// <returns>Countrydto result.</returns>
        public static List<CountryDto> ToDtoList(this List<CountryPivot> countryPivotList)
        {
            return countryPivotList?.Select(x => x?.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From Country dto To Country pivot.
        /// </summary>
        /// <param name="countryDto">country dto to assemble.</param>
        /// <returns>Countrypivot result.</returns>
        public static CountryPivot ToPivot(this CountryDto countryDto)
        {
            if (countryDto == null)
            {
                return null;
            }
            return new CountryPivot
            {
                CountryShortName = countryDto.CountryShortName,
                CountryImage = countryDto.CountryImage,
                CountryCode =  countryDto.CountryCode,
                CountryId = countryDto.CountryId
            };
        }

        /// <summary>
        ///    From Countrypivot list To Country pivot list.
        /// </summary>
        /// <param name="countryDtoList">country dto list to assemble.</param>
        /// <returns>CountryPivot list result.</returns>
        public static List<CountryPivot> ToPivotList(this List<CountryDto> countryDtoList)
        {
            return countryDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From Country Request to Country Request pivot.
        /// </summary>
        /// <param name="countryRequest"></param>
        /// <returns>Country Request pivot result.</returns>
        public static CountryRequestPivot ToPivot(this CountryRequest countryRequest)
        {
            return new CountryRequestPivot
            {
                CountryPivot = countryRequest.CountryDto.ToPivot(),
                FindCountryPivot = Utility.EnumToEnum<FindCountryDto, FindCountryPivot>(countryRequest.FindCountryDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Country Response pivot to Country Message.
        /// </summary>
        /// <param name="countryResponsePivot">Country Response pivot to assemble.</param>
        /// <returns>Country Message result.</returns>
        public static CountryMessage ToMessage(this CountryResponsePivot countryResponsePivot)
        {
            if (countryResponsePivot == null)
            {
                return null;
            }
            return new CountryMessage
            {
                CountryDtoList = countryResponsePivot.CountryPivotList.ToDtoList(),
                CountryDto = countryResponsePivot.CountryPivot.ToDto()
            };
        }
        #endregion
    }
}