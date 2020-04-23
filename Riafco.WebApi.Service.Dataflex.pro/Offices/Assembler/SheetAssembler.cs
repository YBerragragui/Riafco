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
    /// The Sheet assembler class.
    /// </summary>
    public static class SheetAssembler
    {
        #region TODTO
        /// <summary>
        ///    From Sheet Pivot To Sheet Dto.
        /// </summary>
        /// <param name="sheetPivot">sheet pivot to assemble.</param>
        /// <returns>SheetDto result.</returns>
        public static SheetDto ToDto(this SheetPivot sheetPivot)
        {
            if (sheetPivot == null)
            {
                return null;
            }
            return new SheetDto()
            {
                SheetId = sheetPivot.SheetId,
                CountryId = sheetPivot.CountryId,
                Country = sheetPivot.Country?.ToDto(),
            };
        }

        /// <summary>
        ///    From Sheet pivot list to Sheet dto list.
        /// </summary>
        /// <param name="sheetPivotList">sheet pivot liste to assemble.</param>
        /// <returns>Sheetdto result.</returns>
        public static List<SheetDto> ToDtoList(this List<SheetPivot> sheetPivotList)
        {
            return sheetPivotList?.Select(x => x?.ToDto()).ToList();

        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From Sheet dto To Sheet pivot.
        /// </summary>
        /// <param name="sheetDto">sheet dto to assemble.</param>
        /// <returns>Sheetpivot result.</returns>
        public static SheetPivot ToPivot(this SheetDto sheetDto)
        {
            if (sheetDto == null)
            {
                return null;
            }
            return new SheetPivot
            {
                SheetId = sheetDto.SheetId,
                CountryId = sheetDto.CountryId,
                Country = sheetDto.Country?.ToPivot(),
            };
        }

        /// <summary>
        ///    From Sheetpivot list To Sheet pivot list.
        /// </summary>
        /// <param name="sheetDtoList">sheet dto list to assemble.</param>
        /// <returns>SheetPivot list result.</returns>
        public static List<SheetPivot> ToPivotList(this List<SheetDto> sheetDtoList)
        {
            return sheetDtoList?.Select(x => x?.ToPivot()).ToList();

        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From Sheet Request to Sheet Request pivot.
        /// </summary>
        /// <param name="sheetRequest"></param>
        /// <returns>Sheet Request pivot result.</returns>
        public static SheetRequestPivot ToPivot(this SheetRequest sheetRequest)
        {
            return new SheetRequestPivot
            {
                SheetPivot = sheetRequest.SheetDto?.ToPivot(),
                FindSheetPivot = Utility.EnumToEnum<FindSheetDto, FindSheetPivot>(sheetRequest.FindSheetDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Sheet Response pivot to Sheet Message.
        /// </summary>
        /// <param name="sheetResponsePivot">Sheet Response pivot to assemble.</param>
        /// <returns>Sheet Message result.</returns>
        public static SheetMessage ToMessage(this SheetResponsePivot sheetResponsePivot)
        {
            if (sheetResponsePivot == null)
            {
                return null;
            }
            return new SheetMessage
            {
                SheetDtoList = sheetResponsePivot.SheetPivotList?.ToDtoList(),
                SheetDto = sheetResponsePivot.SheetPivot?.ToDto(),
            };
        }
        #endregion
    }
}