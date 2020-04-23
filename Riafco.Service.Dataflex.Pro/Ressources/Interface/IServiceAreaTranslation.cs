using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;

namespace Riafco.Service.Dataflex.Pro.Ressources.Interface
{
    /// <summary>
    /// The AreaTranslation interface.
    /// </summary>
    public interface IServiceAreaTranslation
    {
        /// <summary>
        /// Create AreaTranslationPivot.
        /// </summary>
        /// <param name="request"> The AreaTranslationRequest Pivot that content AreaTranslationPivot to add.</param>
        /// <returns>The AreaTranslationResponsePivot result with the AreaTranslationPivot added.</returns>
        AreaTranslationResponsePivot CreateAreaTranslation(AreaTranslationRequestPivot request);

        /// <summary>
        /// Create AreaTranslationPivotRange.
        /// </summary>
        /// <param name="request"> The AreaTranslationRequest Pivot that content AreaTranslationPivot to add.</param>
        /// <returns>The AreaTranslationResponsePivot result with the AreaTranslationPivot added.</returns>
        AreaTranslationResponsePivot CreateAreaTranslationRange(AreaTranslationRequestPivot request);

        /// <summary>
        /// Update AreaTranslationPivot.
        /// </summary>
        /// <param name="request"> The AreaTranslationRequest Pivot that content AreaTranslationPivot to update.</param>
        void UpdateAreaTranslation(AreaTranslationRequestPivot request);

        /// <summary>
        /// Update AreaTranslationPivot.
        /// </summary>
        /// <param name="request"> The AreaTranslationRequest Pivot that content AreaTranslationPivot to update.</param>
        void UpdateAreaTranslationRange(AreaTranslationRequestPivot request);

        /// <summary>
        /// Delete AreaTranslationPivot.
        /// </summary>
        /// <param name="request"> The AreaTranslationRequest Pivot that content AreaTranslationPivot to remove.</param>
        void DeleteAreaTranslation(AreaTranslationRequestPivot request);

        /// <summary>
        /// Get AreaTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        AreaTranslationResponsePivot GetAllAreaTranslations();

        /// <summary>
        /// Search AreaTranslation.
        /// </summary>
        /// <param name="request"> The AreaTranslationRequest Pivot that content AreaTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        AreaTranslationResponsePivot FindAreaTranslations(AreaTranslationRequestPivot request);

    }
}