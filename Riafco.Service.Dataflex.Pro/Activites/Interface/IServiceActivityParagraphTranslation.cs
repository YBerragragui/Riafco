using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Response;

namespace Riafco.Service.Dataflex.Pro.Activites.Interface
{
    /// <summary>
    /// The ActivityParagraphTraslation interface.
    /// </summary>
    public interface IServiceActivityParagraphTranslation
    {
        /// <summary>
        /// Create ActivityParagraphTranslationPivot.
        /// </summary>
        /// <param name="request"> The ActivityParagraphTraslationRequest Pivot that content ActivityParagraphTranslationPivot to add.</param>
        /// <returns>The ActivityParagraphTraslationResponsePivot result with the ActivityParagraphTranslationPivot added.</returns>
        ActivityParagraphTranslationResponsePivot CreateActivityParagraphTranslation(ActivityParagraphTranslationRequestPivot request);

        /// <summary>
        /// Create ActivityParagraphTranslationPivot List.
        /// </summary>
        /// <param name="request"> The ActivityParagraphTraslationRequest Pivot that content ActivityParagraphTranslationPivot to add.</param>
        /// <returns>The ActivityParagraphTraslationResponsePivot result with the ActivityParagraphTranslationPivot added.</returns>
        ActivityParagraphTranslationResponsePivot CreateActivityParagraphTranslationRange(ActivityParagraphTranslationRequestPivot request);

        /// <summary>
        /// Update ActivityParagraphTranslationPivot.
        /// </summary>
        /// <param name="request"> The ActivityParagraphTraslationRequest Pivot that content ActivityParagraphTranslationPivot to update.</param>
        void UpdateActivityParagraphTranslation(ActivityParagraphTranslationRequestPivot request);

        /// <summary>
        /// Update ActivityParagraphTranslationPivot List.
        /// </summary>
        /// <param name="request"> The ActivityParagraphTraslationRequest Pivot that content ActivityParagraphTranslationPivot to update.</param>
        void UpdateActivityParagraphTranslationRange(ActivityParagraphTranslationRequestPivot request);

        /// <summary>
        /// Delete ActivityParagraphTranslationPivot.
        /// </summary>
        /// <param name="request"> The ActivityParagraphTraslationRequest Pivot that content ActivityParagraphTranslationPivot to remove.</param>
        void DeleteActivityParagraphTranslation(ActivityParagraphTranslationRequestPivot request);

        /// <summary>
        /// Get ActivityParagraphTraslation list
        /// </summary>
        /// <returns>Response result.</returns>
        ActivityParagraphTranslationResponsePivot GetAllActivityParagraphTraslations();

        /// <summary>
        /// Search ActivityParagraphTraslation.
        /// </summary>
        /// <param name="request"> The ActivityParagraphTraslationRequest Pivot that content ActivityParagraphTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        ActivityParagraphTranslationResponsePivot FindActivityParagraphTranslations(ActivityParagraphTranslationRequestPivot request);

    }
}