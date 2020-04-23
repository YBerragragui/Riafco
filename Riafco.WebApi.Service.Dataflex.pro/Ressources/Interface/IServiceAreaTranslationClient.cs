using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Interface
{
    /// <summary>
    /// The AreaTranslation client interface.
    /// </summary>
    public interface IServiceAreaTranslationClient
    {
        /// <summary>
        /// Create AreaTranslation dto.
        /// </summary>
        /// <param name="areaTranslationRequest"> The AreaTranslationRequest that content AreaTranslationdto to add.</param>
        /// <returns>The AreaTranslationMessagePivot result with the AreaTranslationPivot added.</returns>
        AreaTranslationMessage CreateAreaTranslation(AreaTranslationRequest areaTranslationRequest);

        /// <summary>
        /// Create AreaTranslation dto range.
        /// </summary>
        /// <param name="areaTranslationRequest"> The AreaTranslationRequest that content AreaTranslationdto to add.</param>
        /// <returns>The AreaTranslationMessagePivot result with the AreaTranslationPivot added.</returns>
        AreaTranslationMessage CreateAreaTranslationRange(AreaTranslationRequest areaTranslationRequest);

        /// <summary>
        /// Update AreaTranslation dto.
        /// </summary>
        /// <param name="areaTranslationRequest"> The AreaTranslationRequest that content AreaTranslationdto to update.</param>
        AreaTranslationMessage UpdateAreaTranslation(AreaTranslationRequest areaTranslationRequest);

        /// <summary>
        /// Update AreaTranslation dto range.
        /// </summary>
        /// <param name="areaTranslationRequest"> The AreaTranslationRequest that content AreaTranslationdto to update.</param>
        AreaTranslationMessage UpdateAreaTranslationRange(AreaTranslationRequest areaTranslationRequest);

        /// <summary>
        /// Delete AreaTranslation dto.
        /// </summary>
        /// <param name="areaTranslationRequest"> The AreaTranslationRequest that content AreaTranslationdto to remove.</param>
        /// <returns>The AreaTranslationMessagePivot result with the AreaTranslationPivot removed.</returns>
        AreaTranslationMessage DeleteAreaTranslation(AreaTranslationRequest areaTranslationRequest);

        /// <summary>
        /// Get the list of AreaTranslation.
        /// </summary>
        /// <returns>The AreaTranslationMessagePivot result with the AreaTranslationPivot list.</returns>
        AreaTranslationMessage GetAllAreaTranslations();

        /// <summary>
        /// Find AreaTranslation.
        /// </summary>
        /// <returns>The AreaTranslationMessagePivot result with the AreaTranslationPivot list.</returns>
        AreaTranslationMessage FindAreaTranslations(AreaTranslationRequest areaTranslationRequest);
    }
}