using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;

namespace Riafco.Service.Dataflex.Pro.Ressources.Interface
{
    /// <summary>
    /// The ThemeTranslation interface.
    /// </summary>
    public interface IServiceThemeTranslation
    {
        /// <summary>
        /// Create ThemeTranslationPivot.
        /// </summary>
        /// <param name="request"> The ThemeTranslationRequest Pivot that content ThemeTranslationPivot to add.</param>
        /// <returns>The ThemeTranslationResponsePivot result with the ThemeTranslationPivot added.</returns>
        ThemeTranslationResponsePivot CreateThemeTranslation(ThemeTranslationRequestPivot request);

        /// <summary>
        /// Create ThemeTranslationPivotRange.
        /// </summary>
        /// <param name="request"> The ThemeTranslationRequest Pivot that content ThemeTranslationPivot to add.</param>
        /// <returns>The ThemeTranslationResponsePivot result with the ThemeTranslationPivot added.</returns>
        ThemeTranslationResponsePivot CreateThemeTranslationRange(ThemeTranslationRequestPivot request);

        /// <summary>
        /// Update ThemeTranslationPivot.
        /// </summary>
        /// <param name="request"> The ThemeTranslationRequest Pivot that content ThemeTranslationPivot to update.</param>
        void UpdateThemeTranslation(ThemeTranslationRequestPivot request);

        /// <summary>
        /// Update ThemeTranslationPivotRange.
        /// </summary>
        /// <param name="request"> The ThemeTranslationRequest Pivot that content ThemeTranslationPivot to update.</param>
        void UpdateThemeTranslationRange(ThemeTranslationRequestPivot request);

        /// <summary>
        /// Delete ThemeTranslationPivot.
        /// </summary>
        /// <param name="request"> The ThemeTranslationRequest Pivot that content ThemeTranslationPivot to remove.</param>
        void DeleteThemeTranslation(ThemeTranslationRequestPivot request);

        /// <summary>
        /// Get ThemeTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        ThemeTranslationResponsePivot GetAllThemeTranslations();

        /// <summary>
        /// Search ThemeTranslation.
        /// </summary>
        /// <param name="request"> The ThemeTranslationRequest Pivot that content ThemeTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        ThemeTranslationResponsePivot FindThemeTranslations(ThemeTranslationRequestPivot request);
    }
}