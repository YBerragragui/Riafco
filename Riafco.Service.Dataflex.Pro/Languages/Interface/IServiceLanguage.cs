using Riafco.Service.Dataflex.Pro.Languages.Request;
using Riafco.Service.Dataflex.Pro.Languages.Response;

namespace Riafco.Service.Dataflex.Pro.Languages.Interface
{
    /// <summary>
    /// The Language interface.
    /// </summary>
    public interface IServiceLanguage
    {
        /// <summary>
        /// Create LanguagePivot.
        /// </summary>
        /// <param name="request"> The LanguageRequest Pivot that content LanguagePivot to add.</param>
        /// <returns>The LanguageResponsePivot result with the LanguagePivot added.</returns>
        LanguageResponsePivot CreateLanguage(LanguageRequestPivot request);

        /// <summary>
        /// Update LanguagePivot.
        /// </summary>
        /// <param name="request"> The LanguageRequest Pivot that content LanguagePivot to update.</param>
        void UpdateLanguage(LanguageRequestPivot request);

        /// <summary>
        /// Delete LanguagePivot.
        /// </summary>
        /// <param name="request"> The LanguageRequest Pivot that content LanguagePivot to remove.</param>
        void DeleteLanguage(LanguageRequestPivot request);

        /// <summary>
        /// Get Language list
        /// </summary>
        /// <returns>Response result.</returns>
        LanguageResponsePivot GetAllLanguages();

        /// <summary>
        /// Search Language.
        /// </summary>
        /// <param name="request"> The LanguageRequest Pivot that content LanguagePivot to remove.</param>
        /// <returns>Response Result.</returns>
        LanguageResponsePivot FindLanguages(LanguageRequestPivot request);
    }
}