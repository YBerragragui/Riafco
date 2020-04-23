using Riafco.Service.Dataflex.Pro.Offices.Data;
using Riafco.Service.Dataflex.Pro.Offices.Data.Enum;
using System;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Offices.Request
{
    /// <summary>
    /// Gets or Sets The  CountryTranslation request class.
    /// </summary>
    public class CountryTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  CountryTranslationPivot requested.
        /// </summary>
        public CountryTranslationPivot CountryTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryTranslationPivot requested.
        /// </summary>
        public List<CountryTranslationPivot> CountryTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  Find CountryTranslationEnum.
        /// </summary>
        public FindCountryTranslationPivot FindCountryTranslationPivot { get; set; }
    }
}