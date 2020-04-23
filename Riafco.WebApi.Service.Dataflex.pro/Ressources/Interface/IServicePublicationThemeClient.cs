using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Interface
{
    /// <summary>
    /// The PublicationTheme client interface.
    /// </summary>
    public interface IServicePublicationThemeClient
    {
        /// <summary>
        /// Create PublicationTheme dto.
        /// </summary>
        /// <param name="request"> The PublicationThemeRequest that content PublicationThemedto to add.</param>
        /// <returns>The PublicationThemeMessagePivot result with the PublicationThemePivot added.</returns>
        PublicationThemeMessage CreatePublicationTheme(PublicationThemeRequest request);

        /// <summary>
        /// Ctreate PublicationTheme dto.
        /// </summary>
        /// <param name="request"> The PublicationThemeRequest that content PublicationThemedto to add.</param>
        /// <returns>The PublicationThemeMessagePivot result with the PublicationThemePivot added.</returns>
        PublicationThemeMessage CreatePublicationThemeRange(PublicationThemeRequest request);

        /// <summary>
        /// Update PublicationTheme dto.
        /// </summary>
        /// <param name="request"> The PublicationThemeRequest that content PublicationThemedto to update.</param>
        PublicationThemeMessage UpdatePublicationTheme(PublicationThemeRequest request);

        /// <summary>
        /// Update range PublicationTheme dto.
        /// </summary>
        /// <param name="request"> The PublicationThemeRequest that content PublicationThemedto to update.</param>
        PublicationThemeMessage UpdatePublicationThemeRange(PublicationThemeRequest request);

        /// <summary>
        /// Delete PublicationTheme dto.
        /// </summary>
        /// <param name="request"> The PublicationThemeRequest that content PublicationThemedto to remove.</param>
        /// <returns>The PublicationThemeMessagePivot result with the PublicationThemePivot removed.</returns>
        PublicationThemeMessage DeletePublicationTheme(PublicationThemeRequest request);

        /// <summary>
        /// Get the list of PublicationTheme.
        /// </summary>
        /// <returns>The PublicationThemeMessagePivot result with the PublicationThemePivot list.</returns>
        PublicationThemeMessage GetAllPublicationThemes();

        /// <summary>
        /// Find PublicationTheme.
        /// </summary>
        /// <returns>The PublicationThemeMessagePivot result with the PublicationThemePivot list.</returns>
        PublicationThemeMessage FindPublicationThemes(PublicationThemeRequest request);
    }
}