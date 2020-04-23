using Riafco.Entity.Dataflex.Pro.Offices;
using Riafco.Service.Dataflex.Pro.Offices.Data;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;

namespace Riafco.Service.Dataflex.Pro.Offices.Assembler
{
    /// <summary>
    /// The SheetTranslation assembler class.
    /// </summary>
    public static class SheetTranslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From SheetTranslation To SheetTranslation Pivot.
        /// </summary>
        /// <param name="sheetTranslation">sheetTranslation TO ASSEMBLE</param>
        /// <returns>SheetTranslationPivot result.</returns>
        public static SheetTranslationPivot ToPivot(this SheetTranslation sheetTranslation)
        {
            if (sheetTranslation == null)
            {
                return null;
            }
            return new SheetTranslationPivot()
            {
                TranslationId = sheetTranslation.TranslationId,
                SheetTitle = sheetTranslation.SheetTitle,
                SheetValue = sheetTranslation.SheetValue,
                LanguageId = sheetTranslation.LanguageId,
                Language = sheetTranslation.Language?.ToPivot(),
                SheetId = sheetTranslation.SheetId,
                Sheet = sheetTranslation.Sheet?.ToPivot(),
            };
        }

        /// <summary>
        /// From SheetTranslation list to SheetTranslation pivot list.
        /// </summary>
        /// <param name="sheetTranslationList">sheetTranslationList to assemble.</param>
        /// <returns>list of SheetTranslationPivot result.</returns>
        public static List<SheetTranslationPivot> ToPivotList(this List<SheetTranslation> sheetTranslationList)
        {
            return sheetTranslationList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion


        #region TO ENTITY 
        /// <summary>
        /// From SheetTranslationPivot to SheetTranslation.
        /// </summary>
        /// <param name="sheetTranslationPivot">sheetTranslationPivot to assemble.</param>
        /// <returns>SheetTranslation result.</returns>
        public static SheetTranslation ToEntity(this SheetTranslationPivot sheetTranslationPivot)
        {
            if (sheetTranslationPivot == null)
            {
                return null;
            }
            return new SheetTranslation()
            {
                TranslationId = sheetTranslationPivot.TranslationId,
                SheetTitle = sheetTranslationPivot.SheetTitle,
                SheetValue = sheetTranslationPivot.SheetValue,
                LanguageId = sheetTranslationPivot.LanguageId,
                Language = sheetTranslationPivot.Language?.ToEntity(),
                SheetId = sheetTranslationPivot.SheetId,
                Sheet = sheetTranslationPivot.Sheet?.ToEntity(),
            };
        }

        /// <summary>
        /// From SheetTranslationPivotList to SheetTranslationList .
        /// </summary>
        /// <param name="sheetTranslationPivotList">SheetTranslationPivotList to assemble.</param>
        /// <returns> list of SheetTranslation result.</returns>
        public static List<SheetTranslation> ToEntityList(this List<SheetTranslationPivot> sheetTranslationPivotList)
        {
            return sheetTranslationPivotList?.Select(x => x?.ToEntity()).ToList();

        }
        #endregion
    }
}