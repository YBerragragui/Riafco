using Riafco.WebApi.Service.Dataflex.pro.Offices.Request;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Interface
{
    /// <summary>
    /// The CountryTranslation client interface.
    /// </summary>
    public interface IServiceCountryTranslationClient
    {
        /// <summary>
        /// Add CountryTranslation dto.
        /// </summary>
        /// <param name="request"> The CountryTranslationRequest that content CountryTranslationdto to add.</param>
        /// <returns>The CountryTranslationMessagePivot result with the CountryTranslationPivot added.</returns>
        CountryTranslationMessage CreateCountryTranslation(CountryTranslationRequest request);

        /// <summary>
        /// Add CreateCountryTranslationRange dto.
        /// </summary>
        /// <param name="request"> The CountryTranslationRequest that content CreateCountryTranslationRange to add.</param>
        /// <returns>The CountryTranslationMessagePivot result with the CountryTranslationPivot added.</returns>
        CountryTranslationMessage CreateCountryTranslationRange(CountryTranslationRequest request);

        /// <summary>
        /// Update CountryTranslation dto.
        /// </summary>
        /// <param name="request"> The CountryTranslationRequest that content CountryTranslationdto to update.</param>
        CountryTranslationMessage UpdateCountryTranslation(CountryTranslationRequest request);

        /// <summary>
        /// Update UpdateCountryTranslationRange dto.
        /// </summary>
        /// <param name="request"> The CountryTranslationRequest that content UpdateCountryTranslationRange to update.</param>
        CountryTranslationMessage UpdateCountryTranslationRange(CountryTranslationRequest request);

        /// <summary>
        /// Delete CountryTranslation dto.
        /// </summary>
        /// <param name="request"> The CountryTranslationRequest that content CountryTranslationdto to remove.</param>
        /// <returns>The CountryTranslationMessagePivot result with the CountryTranslationPivot removed.</returns>
        CountryTranslationMessage DeleteCountryTranslation(CountryTranslationRequest request);

        /// <summary>
        /// Get the list of CountryTranslation.
        /// </summary>
        /// <returns>The CountryTranslationMessagePivot result with the CountryTranslationPivot list.</returns>
        CountryTranslationMessage GetAllCountryTranslations();

        /// <summary>
        /// Find CountryTranslation.
        /// </summary>
        /// <returns>The CountryTranslationMessagePivot result with the CountryTranslationPivot list.</returns>
        CountryTranslationMessage FindCountryTranslations(CountryTranslationRequest request);
    }
}