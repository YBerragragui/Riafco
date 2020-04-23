using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Offices.Data;

namespace Riafco.Service.Dataflex.Pro.Offices.Response
{
    /// <summary>
    /// The Country response class.
    /// </summary>
    public class CountryResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  CountryPivotList.
        /// </summary>
        public List<CountryPivot> CountryPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryPivot.
        /// </summary>
        public CountryPivot CountryPivot { get; set; }

    }
}