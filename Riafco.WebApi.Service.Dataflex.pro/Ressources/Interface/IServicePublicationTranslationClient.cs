using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Interface
{
    /// <summary>
    /// The PublicationTranslation client interface.
    /// </summary>
    public interface IServicePublicationTranslationClient
    {
        /// <summary>
        /// Create PublicationTranslation dto.
        /// </summary>
        /// <param name="publicationTranslationRequest"> The PublicationTranslationRequest that content PublicationTranslationdto to add.</param>
        /// <returns>The PublicationTranslationMessagePivot result with the PublicationTranslationPivot added.</returns>
        PublicationTranslationMessage CreatePublicationTranslation(PublicationTranslationRequest publicationTranslationRequest);

        /// <summary>
        /// Create PublicationTranslation dto.
        /// </summary>
        /// <param name="publicationTranslationRequest"> The PublicationTranslationRequest that content PublicationTranslationdto to add.</param>
        /// <returns>The PublicationTranslationMessagePivot result with the PublicationTranslationPivot added.</returns>
        PublicationTranslationMessage CreatePublicationTranslationRange(PublicationTranslationRequest publicationTranslationRequest);

        /// <summary>
        /// Update PublicationTranslation dto.
        /// </summary>
        /// <param name="publicationTranslationRequest"> The PublicationTranslationRequest that content PublicationTranslationdto to update.</param>
        PublicationTranslationMessage UpdatePublicationTranslation(PublicationTranslationRequest publicationTranslationRequest);

        /// <summary>
        /// Update PublicationTranslation dto.
        /// </summary>
        /// <param name="publicationTranslationRequest"> The PublicationTranslationRequest that content PublicationTranslationdto to update.</param>
        PublicationTranslationMessage UpdatePublicationTranslationRange(PublicationTranslationRequest publicationTranslationRequest);

        /// <summary>
        /// Delete PublicationTranslation dto.
        /// </summary>
        /// <param name="publicationTranslationRequest"> The PublicationTranslationRequest that content PublicationTranslationdto to remove.</param>
        /// <returns>The PublicationTranslationMessagePivot result with the PublicationTranslationPivot removed.</returns>
        PublicationTranslationMessage DeletePublicationTranslation(PublicationTranslationRequest publicationTranslationRequest);

        /// <summary>
        /// Get the list of PublicationTranslation.
        /// </summary>
        /// <returns>The PublicationTranslationMessagePivot result with the PublicationTranslationPivot list.</returns>
        PublicationTranslationMessage GetAllPublicationTranslations();

        /// <summary>
        /// Find PublicationTranslation.
        /// </summary>
        /// <returns>The PublicationTranslationMessagePivot result with the PublicationTranslationPivot list.</returns>
        PublicationTranslationMessage FindPublicationTranslations(PublicationTranslationRequest publicationTranslationRequest);
    }
}