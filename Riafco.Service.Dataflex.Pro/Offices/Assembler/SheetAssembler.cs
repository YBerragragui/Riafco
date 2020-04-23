using Riafco.Entity.Dataflex.Pro.Offices;
using Riafco.Service.Dataflex.Pro.Offices.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Offices.Assembler
{
    /// <summary>
    /// The Sheet assembler class.
    /// </summary>
    public static class SheetAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Sheet To Sheet Pivot.
        /// </summary>
        /// <param name="sheet">sheet TO ASSEMBLE</param>
        /// <returns>SheetPivot result.</returns>
        public static SheetPivot ToPivot(this Sheet sheet)
        {
            if (sheet == null)
            {
                return null;
            }
            return new SheetPivot()
            {
                SheetId = sheet.SheetId,
                CountryId = sheet.CountryId,
                Country = sheet.Country.ToPivot(),
            };
        }

        /// <summary>
        /// From Sheet list to Sheet pivot list.
        /// </summary>
        /// <param name="sheetList">sheetList to assemble.</param>
        /// <returns>list of SheetPivot result.</returns>
        public static List<SheetPivot> ToPivotList(this List<Sheet> sheetList)
        {
            return sheetList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion


        #region TO ENTITY 
        /// <summary>
        /// From SheetPivot to Sheet.
        /// </summary>
        /// <param name="sheetPivot">sheetPivot to assemble.</param>
        /// <returns>Sheet result.</returns>
        public static Sheet ToEntity(this SheetPivot sheetPivot)
        {
            if (sheetPivot == null)
            {
                return null;
            }
            return new Sheet()
            {
                SheetId = sheetPivot.SheetId,
                CountryId = sheetPivot.CountryId,
                Country = sheetPivot.Country?.ToEntity(),
            };
        }

        /// <summary>
        /// From SheetPivotList to SheetList .
        /// </summary>
        /// <param name="sheetPivotList">SheetPivotList to assemble.</param>
        /// <returns> list of Sheet result.</returns>
        public static List<Sheet> ToEntityList(this List<SheetPivot> sheetPivotList)
        {
            return sheetPivotList?.Select(x => x?.ToEntity()).ToList();

        }
        #endregion
    }
}