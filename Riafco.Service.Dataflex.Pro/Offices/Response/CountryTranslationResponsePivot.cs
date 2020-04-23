using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Offices.Data;

namespace Riafco.Service.Dataflex.Pro.Offices.Response
{
    /// <summary>
    /// The CountryTranslation response class.
    /// </summary>
    public class CountryTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  CountryTranslationPivotList.
        /// </summary>
        public List<CountryTranslationPivot> CountryTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryTranslationPivot.
        /// </summary>
        public CountryTranslationPivot CountryTranslationPivot { get; set; }

    }
}