using Riafco.Entity.Dataflex.Pro.Offices;
using Riafco.Service.Dataflex.Pro.Offices.Data;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;

namespace Riafco.Service.Dataflex.Pro.Offices.Assembler
{
    /// <summary>
    /// The CountryTranslation assembler class.
    /// </summary>
    public static class CountryTranslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From CountryTranslation To CountryTranslation Pivot.
        /// </summary>
        /// <param name="countryTranslation">countryTranslation TO ASSEMBLE</param>
        /// <returns>CountryTranslationPivot result.</returns>
        public static CountryTranslationPivot ToPivot(this CountryTranslation countryTranslation)
        {
            if (countryTranslation == null)
            {
                return null;
            }
            return new CountryTranslationPivot
            {
                TranslationId = countryTranslation.TranslationId,
                CountryName = countryTranslation.CountryName,
                CountryTitle = countryTranslation.CountryTitle,
                CountryDescription = countryTranslation.CountryDescription,
                CountrySummary = countryTranslation.CountrySummary,
                CountryId = countryTranslation.CountryId,
                Country = countryTranslation.Country.ToPivot(),
                LanguageId = countryTranslation.LanguageId,
                Language = countryTranslation.Language.ToPivot(),
            };
        }

        /// <summary>
        /// From CountryTranslation list to CountryTranslation pivot list.
        /// </summary>
        /// <param name="countryTranslationList">countryTranslationList to assemble.</param>
        /// <returns>list of CountryTranslationPivot result.</returns>
        public static List<CountryTranslationPivot> ToPivotList(this List<CountryTranslation> countryTranslationList)
        {
            return countryTranslationList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From CountryTranslationPivot to CountryTranslation.
        /// </summary>
        /// <param name="countryTranslationPivot">countryTranslationPivot to assemble.</param>
        /// <returns>CountryTranslation result.</returns>
        public static CountryTranslation ToEntity(this CountryTranslationPivot countryTranslationPivot)
        {
            if (countryTranslationPivot == null)
            {
                return null;
            }
            return new CountryTranslation
            {
                TranslationId = countryTranslationPivot.TranslationId,
                CountryName = countryTranslationPivot.CountryName,
                CountryTitle = countryTranslationPivot.CountryTitle,
                CountryDescription = countryTranslationPivot.CountryDescription,
                CountrySummary = countryTranslationPivot.CountrySummary,
                CountryId = countryTranslationPivot.CountryId,
                Country = countryTranslationPivot.Country.ToEntity(),
                LanguageId = countryTranslationPivot.LanguageId,
                Language = countryTranslationPivot.Language.ToEntity(),
            };
        }

        /// <summary>
        /// From CountryTranslationPivotList to CountryTranslationList .
        /// </summary>
        /// <param name="countryTranslationPivotList">CountryTranslationPivotList to assemble.</param>
        /// <returns> list of CountryTranslation result.</returns>
        public static List<CountryTranslation> ToEntityList(this List<CountryTranslationPivot> countryTranslationPivotList)
        {
            return countryTranslationPivotList?.Select(x => x?.ToEntity()).ToList();

        }
        #endregion
    }
}