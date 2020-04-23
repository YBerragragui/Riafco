using Riafco.Service.Dataflex.Pro.Offices.Data;
using Riafco.Service.Dataflex.Pro.Offices.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Offices.Request
{
    /// <summary>
    /// Gets or Sets The  Country request class.
    /// </summary>
    public class CountryRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  CountryPivot requested.
        /// </summary>
        public CountryPivot CountryPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find CountryEnum.
        /// </summary>
        public FindCountryPivot FindCountryPivot { get; set; }
    }
}