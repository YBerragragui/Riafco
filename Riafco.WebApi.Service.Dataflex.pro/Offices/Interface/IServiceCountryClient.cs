using Riafco.WebApi.Service.Dataflex.pro.Offices.Request;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Interface
{
    /// <summary>
    /// The Country client interface.
    /// </summary>
    public interface IServiceCountryClient
    {
        /// <summary>
        /// Add Country dto.
        /// </summary>
        /// <param name="request"> The CountryRequest that content Countrydto to add.</param>
        /// <returns>The CountryMessagePivot result with the CountryPivot added.</returns>
        CountryMessage CreateCountry(CountryRequest request);

        /// <summary>
        /// Update Country dto.
        /// </summary>
        /// <param name="request"> The CountryRequest that content Countrydto to update.</param>
        CountryMessage UpdateCountry(CountryRequest request);

        /// <summary>
        /// Delete Country dto.
        /// </summary>
        /// <param name="request"> The CountryRequest that content Countrydto to remove.</param>
        /// <returns>The CountryMessagePivot result with the CountryPivot removed.</returns>
        CountryMessage DeleteCountry(CountryRequest request);

        /// <summary>
        /// Get the list of Country.
        /// </summary>
        /// <returns>The CountryMessagePivot result with the CountryPivot list.</returns>
        CountryMessage GetAllCountries();

        /// <summary>
        /// Find Country.
        /// </summary>
        /// <returns>The CountryMessagePivot result with the CountryPivot list.</returns>
        CountryMessage FindCountries(CountryRequest request);
    }
}