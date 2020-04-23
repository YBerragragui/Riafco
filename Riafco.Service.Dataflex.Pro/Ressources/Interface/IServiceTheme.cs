using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;

namespace Riafco.Service.Dataflex.Pro.Ressources.Interface
{
    /// <summary>
    /// The Theme interface.
    /// </summary>
    public interface IServiceTheme
    {
        /// <summary>
        /// Create ThemePivot.
        /// </summary>
        /// <param name="request"> The ThemeRequest Pivot that content ThemePivot to add.</param>
        /// <returns>The ThemeResponsePivot result with the ThemePivot added.</returns>
        ThemeResponsePivot CreateTheme(ThemeRequestPivot request);

        /// <summary>
        /// Update ThemePivot.
        /// </summary>
        /// <param name="request"> The ThemeRequest Pivot that content ThemePivot to update.</param>
        void UpdateTheme(ThemeRequestPivot request);

        /// <summary>
        /// Delete ThemePivot.
        /// </summary>
        /// <param name="request"> The ThemeRequest Pivot that content ThemePivot to remove.</param>
        void DeleteTheme(ThemeRequestPivot request);

        /// <summary>
        /// Get Theme list
        /// </summary>
        /// <returns>Response result.</returns>
        ThemeResponsePivot GetAllThemes();

        /// <summary>
        /// Search Theme.
        /// </summary>
        /// <param name="request"> The ThemeRequest Pivot that content ThemePivot to remove.</param>
        /// <returns>Response Result.</returns>
        ThemeResponsePivot FindThemes(ThemeRequestPivot request);
    }
}