using Riafco.Service.Dataflex.Pro.Offices.Request;
using Riafco.Service.Dataflex.Pro.Offices.Response;

namespace Riafco.Service.Dataflex.Pro.Offices.Interface
{
    /// <summary>
    /// The CountryTranslation interface.
    /// </summary>
    public interface IServiceCountryTranslation
    {
        /// <summary>
        /// Create CountryTranslationPivot.
        /// </summary>
        /// <param name="request"> The CountryTranslationRequest Pivot that content CountryTranslationPivot to add.</param>
        /// <returns>The CountryTranslationResponsePivot result with the CountryTranslationPivot added.</returns>
        CountryTranslationResponsePivot CreateCountryTranslation(CountryTranslationRequestPivot request);

        /// <summary>
        /// Create CreateCountryTranslationRange.
        /// </summary>
        /// <param name="request"> The CountryTranslationRequest Pivot that content CreateCountryTranslationRange to add.</param>
        /// <returns>The CountryTranslationResponsePivot result with the CountryTranslationPivot added.</returns>
        CountryTranslationResponsePivot CreateCountryTranslationRange(CountryTranslationRequestPivot request);


        /// <summary>
        /// Update CountryTranslationPivot.
        /// </summary>
        /// <param name="request"> The CountryTranslationRequest Pivot that content CountryTranslationPivot to update.</param>
        void UpdateCountryTranslation(CountryTranslationRequestPivot request);

        /// <summary>
        /// Update UpdateCountryTranslationRange.
        /// </summary>
        /// <param name="request"> The CountryTranslationRequest Pivot that content UpdateCountryTranslationRange to update.</param>
        void UpdateCountryTranslationRange(CountryTranslationRequestPivot request);

        /// <summary>
        /// Delete CountryTranslationPivot.
        /// </summary>
        /// <param name="request"> The CountryTranslationRequest Pivot that content CountryTranslationPivot to remove.</param>
        void DeleteCountryTranslation(CountryTranslationRequestPivot request);

        /// <summary>
        /// Get CountryTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        CountryTranslationResponsePivot GetAllCountryTranslations();

        /// <summary>
        /// Search CountryTranslation.
        /// </summary>
        /// <param name="request"> The CountryTranslationRequest Pivot that content CountryTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        CountryTranslationResponsePivot FindCountryTranslations(CountryTranslationRequestPivot request);

    }
}