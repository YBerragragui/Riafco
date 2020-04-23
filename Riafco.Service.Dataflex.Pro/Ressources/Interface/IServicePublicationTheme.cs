using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;

namespace Riafco.Service.Dataflex.Pro.Ressources.Interface
{
    /// <summary>
    /// The PublicationTheme interface.
    /// </summary>
    public interface IServicePublicationTheme
    {
        /// <summary>
        /// Create PublicationThemePivot.
        /// </summary>
        /// <param name="request"> The PublicationThemeRequest Pivot that content PublicationThemePivot to add.</param>
        /// <returns>The PublicationThemeResponsePivot result with the PublicationThemePivot added.</returns>
        PublicationThemeResponsePivot CreatePublicationTheme(PublicationThemeRequestPivot request);

        /// <summary>
        /// Create PublicationThemePivot Range.
        /// </summary>
        /// <param name="request"> The PublicationThemeRequest Pivot that content PublicationThemePivot to add.</param>
        /// <returns>The PublicationThemeResponsePivot result with the PublicationThemePivot added.</returns>
        PublicationThemeResponsePivot CreatePublicationThemeRange(PublicationThemeRequestPivot request);

        /// <summary>
        /// Update PublicationThemePivot.
        /// </summary>
        /// <param name="request"> The PublicationThemeRequest Pivot that content PublicationThemePivot to update.</param>
        void UpdatePublicationTheme(PublicationThemeRequestPivot request);

        /// <summary>
        /// Update PublicationThemePivot Range.
        /// </summary>
        /// <param name="request"> The PublicationThemeRequest Pivot that content PublicationThemePivot to update.</param>
        void UpdatePublicationThemeRange(PublicationThemeRequestPivot request);

        /// <summary>
        /// Delete PublicationThemePivot.
        /// </summary>
        /// <param name="request"> The PublicationThemeRequest Pivot that content PublicationThemePivot to remove.</param>
        void DeletePublicationTheme(PublicationThemeRequestPivot request);

        /// <summary>
        /// Get PublicationTheme list
        /// </summary>
        /// <returns>Response result.</returns>
        PublicationThemeResponsePivot GetAllPublicationThemes();

        /// <summary>
        /// Search PublicationTheme.
        /// </summary>
        /// <param name="request"> The PublicationThemeRequest Pivot that content PublicationThemePivot to remove.</param>
        /// <returns>Response Result.</returns>
        PublicationThemeResponsePivot FindPublicationThemes(PublicationThemeRequestPivot request);
    }
}