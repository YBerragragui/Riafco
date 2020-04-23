using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;

namespace Riafco.Service.Dataflex.Pro.Ressources.Interface
{
    /// <summary>
    /// The PublicationTranslation interface.
    /// </summary>
    public interface IServicePublicationTranslation
    {
        /// <summary>
        /// Create PublicationTranslationPivot.
        /// </summary>
        /// <param name="request"> The PublicationTranslationRequest Pivot that content PublicationTranslationPivot to add.</param>
        /// <returns>The PublicationTranslationResponsePivot result with the PublicationTranslationPivot added.</returns>
        PublicationTranslationResponsePivot CreatePublicationTranslation(PublicationTranslationRequestPivot request);

        /// <summary>
        /// Create PublicationTranslationPivot Range.
        /// </summary>
        /// <param name="request"> The PublicationTranslationRequest Pivot that content PublicationTranslationPivot to add.</param>
        /// <returns>The PublicationTranslationResponsePivot result with the PublicationTranslationPivot added.</returns>
        PublicationTranslationResponsePivot CreatePublicationTranslationRange(PublicationTranslationRequestPivot request);

        /// <summary>
        /// Update PublicationTranslationPivot.
        /// </summary>
        /// <param name="request"> The PublicationTranslationRequest Pivot that content PublicationTranslationPivot to update.</param>
        void UpdatePublicationTranslation(PublicationTranslationRequestPivot request);

        /// <summary>
        /// Update PublicationTranslationPivot Range.
        /// </summary>
        /// <param name="request"> The PublicationTranslationRequest Pivot that content PublicationTranslationPivot to update.</param>
        void UpdatePublicationTranslationRange(PublicationTranslationRequestPivot request);

        /// <summary>
        /// Delete PublicationTranslationPivot.
        /// </summary>
        /// <param name="request"> The PublicationTranslationRequest Pivot that content PublicationTranslationPivot to remove.</param>
        void DeletePublicationTranslation(PublicationTranslationRequestPivot request);

        /// <summary>
        /// Get PublicationTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        PublicationTranslationResponsePivot GetAllPublicationTranslations();

        /// <summary>
        /// Search PublicationTranslation.
        /// </summary>
        /// <param name="request"> The PublicationTranslationRequest Pivot that content PublicationTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        PublicationTranslationResponsePivot FindPublicationTranslations(PublicationTranslationRequestPivot request);

    }
}