using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Interface
{
    /// <summary>
    /// The ThemeTranslation client interface.
    /// </summary>
    public interface IServiceThemeTranslationClient
    {
        /// <summary>
        /// Create ThemeTranslation dto.
        /// </summary>
        /// <param name="themeTranslationRequest"> The ThemeTranslationRequest that content ThemeTranslationdto to add.</param>
        /// <returns>The ThemeTranslationMessagePivot result with the ThemeTranslationPivot added.</returns>
        ThemeTranslationMessage CreateThemeTranslation(ThemeTranslationRequest themeTranslationRequest);

        /// <summary>
        /// Create ThemeTranslation dto range.
        /// </summary>
        /// <param name="themeTranslationRequest"> The ThemeTranslationRequest that content ThemeTranslationdto to add.</param>
        /// <returns>The ThemeTranslationMessagePivot result with the ThemeTranslationPivot added.</returns>
        ThemeTranslationMessage CreateThemeTranslationRange(ThemeTranslationRequest themeTranslationRequest);

        /// <summary>
        /// Update ThemeTranslation dto.
        /// </summary>
        /// <param name="themeTranslationRequest"> The ThemeTranslationRequest that content ThemeTranslationdto to update.</param>
        ThemeTranslationMessage UpdateThemeTranslation(ThemeTranslationRequest themeTranslationRequest);

        /// <summary>
        /// Update ThemeTranslation dto range.
        /// </summary>
        /// <param name="themeTranslationRequest"> The ThemeTranslationRequest that content ThemeTranslationdto to update.</param>
        ThemeTranslationMessage UpdateThemeTranslationRange(ThemeTranslationRequest themeTranslationRequest);

        /// <summary>
        /// Delete ThemeTranslation dto.
        /// </summary>
        /// <param name="themeTranslationRequest"> The ThemeTranslationRequest that content ThemeTranslationdto to remove.</param>
        /// <returns>The ThemeTranslationMessagePivot result with the ThemeTranslationPivot removed.</returns>
        ThemeTranslationMessage DeleteThemeTranslation(ThemeTranslationRequest themeTranslationRequest);

        /// <summary>
        /// Get the list of ThemeTranslation.
        /// </summary>
        /// <returns>The ThemeTranslationMessagePivot result with the ThemeTranslationPivot list.</returns>
        ThemeTranslationMessage GetAllThemeTranslations();

        /// <summary>
        /// Find ThemeTranslation.
        /// </summary>
        /// <returns>The ThemeTranslationMessagePivot result with the ThemeTranslationPivot list.</returns>
        ThemeTranslationMessage FindThemeTranslations(ThemeTranslationRequest themeTranslationRequest);
    }
}