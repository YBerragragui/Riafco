using Riafco.WebApi.Service.Dataflex.pro.Languages.Message;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Request;

namespace Riafco.WebApi.Service.Dataflex.pro.Languages.Interface
{
    /// <summary>
    /// The Language client interface.
    /// </summary>
    public interface IServiceLanguageClient
    {
        /// <summary>
        /// Create Language dto.
        /// </summary>
        /// <param name="request"> The LanguageRequest that content Languagedto to add.</param>
        /// <returns>The LanguageMessagePivot result with the LanguagePivot to add.</returns>
        LanguageMessage CreateLanguage(LanguageRequest request);

        /// <summary>
        /// Update Language dto.
        /// </summary>
        /// <param name="request"> The LanguageRequest that content Languagedto to update.</param>
        LanguageMessage UpdateLanguage(LanguageRequest request);

        /// <summary>
        /// Delete Language dto.
        /// </summary>
        /// <param name="request"> The LanguageRequest that content Languagedto to remove.</param>
        /// <returns>The LanguageMessagePivot result with the LanguagePivot removed.</returns>
        LanguageMessage DeleteLanguage(LanguageRequest request);

        /// <summary>
        /// Get the list of Language.
        /// </summary>
        /// <returns>The LanguageMessagePivot result with the LanguagePivot list.</returns>
        LanguageMessage GetAllLanguages();

        /// <summary>
        /// Find Language.
        /// </summary>
        /// <returns>The LanguageMessagePivot result with the LanguagePivot list.</returns>
        LanguageMessage FindLanguages(LanguageRequest request);
    }
}