using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Interface
{
    /// <summary>
    /// The Theme client interface.
    /// </summary>
    public interface IServiceThemeClient
    {
        /// <summary>
        /// Add Theme dto.
        /// </summary>
        /// <param name="themeRequest"> The ThemeRequest that content Themedto to add.</param>
        /// <returns>The ThemeMessagePivot result with the ThemePivot added.</returns>
        ThemeMessage CreateTheme(ThemeRequest themeRequest);

        /// <summary>
        /// Update Theme dto.
        /// </summary>
        /// <param name="themeRequest"> The ThemeRequest that content Themedto to update.</param>
        ThemeMessage UpdateTheme(ThemeRequest themeRequest);

        /// <summary>
        /// Delete Theme dto.
        /// </summary>
        /// <param name="themeRequest"> The ThemeRequest that content Themedto to remove.</param>
        /// <returns>The ThemeMessagePivot result with the ThemePivot removed.</returns>
        ThemeMessage DeleteTheme(ThemeRequest themeRequest);

        /// <summary>
        /// Get the list of Theme.
        /// </summary>
        /// <returns>The ThemeMessagePivot result with the ThemePivot list.</returns>
        ThemeMessage GetAllThemes();

        /// <summary>
        /// Find Theme.
        /// </summary>
        /// <returns>The ThemeMessagePivot result with the ThemePivot list.</returns>
        ThemeMessage FindThemes(ThemeRequest themeRequest);
    }
}