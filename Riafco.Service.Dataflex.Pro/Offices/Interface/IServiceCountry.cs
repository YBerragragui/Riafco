using Riafco.Service.Dataflex.Pro.Offices.Request;
using Riafco.Service.Dataflex.Pro.Offices.Response;

namespace Riafco.Service.Dataflex.Pro.Offices.Interface
{
    /// <summary>
    /// The Country interface.
    /// </summary>
    public interface IServiceCountry
    {
        /// <summary>
        /// Create CountryPivot.
        /// </summary>
        /// <param name="request"> The CountryRequest Pivot that content CountryPivot to add.</param>
        /// <returns>The CountryResponsePivot result with the CountryPivot added.</returns>
        CountryResponsePivot CreateCountry(CountryRequestPivot request);

        /// <summary>
        /// Update CountryPivot.
        /// </summary>
        /// <param name="request"> The CountryRequest Pivot that content CountryPivot to update.</param>
        void UpdateCountry(CountryRequestPivot request);

        /// <summary>
        /// Delete CountryPivot.
        /// </summary>
        /// <param name="request"> The CountryRequest Pivot that content CountryPivot to remove.</param>
        void DeleteCountry(CountryRequestPivot request);

        /// <summary>
        /// Get Country list
        /// </summary>
        /// <returns>Response result.</returns>
        CountryResponsePivot GetAllCountries();

        /// <summary>
        /// Search Country.
        /// </summary>
        /// <param name="request"> The CountryRequest Pivot that content CountryPivot to remove.</param>
        /// <returns>Response Result.</returns>
        CountryResponsePivot FindCountries(CountryRequestPivot request);

    }
}