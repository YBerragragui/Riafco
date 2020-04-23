using Riafco.Entity.Dataflex.Pro.Offices;
using Riafco.Service.Dataflex.Pro.Offices.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Offices.Assembler
{
    /// <summary>
    /// The Country assembler class.
    /// </summary>
    public static class CountryAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Country To Country Pivot.
        /// </summary>
        /// <param name="country">country TO ASSEMBLE</param>
        /// <returns>CountryPivot result.</returns>
        public static CountryPivot ToPivot(this Country country)
        {
            if (country == null)
            {
                return null;
            }
            return new CountryPivot
            {
                CountryShortName = country.CountryShortName,
                CountryImage = country.CountryImage,
                CountryCode = country.CountryCode,
                CountryId = country.CountryId
            };
        }

        /// <summary>
        /// From Country list to Country pivot list.
        /// </summary>
        /// <param name="countryList">countryList to assemble.</param>
        /// <returns>list of CountryPivot result.</returns>
        public static List<CountryPivot> ToPivotList(this List<Country> countryList)
        {
            return countryList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From CountryPivot to Country.
        /// </summary>
        /// <param name="countryPivot">countryPivot to assemble.</param>
        /// <returns>Country result.</returns>
        public static Country ToEntity(this CountryPivot countryPivot)
        {
            if (countryPivot == null)
            {
                return null;
            }
            return new Country
            {
                CountryShortName = countryPivot.CountryShortName,
                CountryImage = countryPivot.CountryImage,
                CountryCode = countryPivot.CountryCode,
                CountryId = countryPivot.CountryId
            };
        }

        /// <summary>
        /// From CountryPivotList to CountryList .
        /// </summary>
        /// <param name="countryPivotList">CountryPivotList to assemble.</param>
        /// <returns> list of Country result.</returns>
        public static List<Country> ToEntityList(this List<CountryPivot> countryPivotList)
        {
            return countryPivotList?.Select(x => x?.ToEntity()).ToList();
        }
        #endregion
    }
}