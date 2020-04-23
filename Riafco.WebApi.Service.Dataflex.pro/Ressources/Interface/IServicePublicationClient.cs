using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Interface
{
    /// <summary>
    /// The Publication client interface.
    /// </summary>
    public interface IServicePublicationClient
    {
        /// <summary>
        /// Create Publication dto.
        /// </summary>
        /// <param name="request"> The PublicationRequest that content Publicationdto to add.</param>
        /// <returns>The PublicationMessagePivot result with the PublicationPivot added.</returns>
        PublicationMessage CreatePublication(PublicationRequest request);

        /// <summary>
        /// Update Publication dto.
        /// </summary>
        /// <param name="request"> The PublicationRequest that content Publicationdto to update.</param>
        PublicationMessage UpdatePublication(PublicationRequest request);

        /// <summary>
        /// Delete Publication dto.
        /// </summary>
        /// <param name="request"> The PublicationRequest that content Publicationdto to remove.</param>
        /// <returns>The PublicationMessagePivot result with the PublicationPivot removed.</returns>
        PublicationMessage DeletePublication(PublicationRequest request);

        /// <summary>
        /// Get the list of Publication.
        /// </summary>
        /// <returns>The PublicationMessagePivot result with the PublicationPivot list.</returns>
        PublicationMessage GetAllPublications();

        /// <summary>
        /// Find Publication.
        /// </summary>
        /// <returns>The PublicationMessagePivot result with the PublicationPivot list.</returns>
        PublicationMessage FindPublications(PublicationRequest request);
    }
}