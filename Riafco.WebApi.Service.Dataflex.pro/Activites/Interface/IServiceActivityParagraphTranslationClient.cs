using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Interface
{
    /// <summary>
    /// The ActivityParagraphTraslation client interface.
    /// </summary>
    public interface IServiceActivityParagraphTranslationClient
    {
        /// <summary>
        /// Create ActivityParagraphTraslation dto.
        /// </summary>
        /// <param name="request"> The ActivityParagraphTraslationRequest that content ActivityParagraphTraslationdto to add.</param>
        /// <returns>The ActivityParagraphTraslationMessagePivot result with the ActivityParagraphTranslationPivot added.</returns>
        ActivityParagraphTranslationMessage CreateActivityParagraphTranslation(ActivityParagraphTranslationRequest request);

        /// <summary>
        /// Create ActivityParagraphTraslation dto list.
        /// </summary>
        /// <param name="request"> The ActivityParagraphTraslationRequest that content ActivityParagraphTraslationdto to add.</param>
        /// <returns>The ActivityParagraphTraslationMessagePivot result with the ActivityParagraphTranslationPivot added.</returns>
        ActivityParagraphTranslationMessage CreateActivityParagraphTranslationRange(ActivityParagraphTranslationRequest request);

        /// <summary>
        /// Update ActivityParagraphTraslation dto.
        /// </summary>
        /// <param name="request"> The ActivityParagraphTraslationRequest that content ActivityParagraphTraslationdto to update.</param>
        ActivityParagraphTranslationMessage UpdateActivityParagraphTranslation(ActivityParagraphTranslationRequest request);

        /// <summary>
        /// Update ActivityParagraphTraslation dto.
        /// </summary>
        /// <param name="request"> The ActivityParagraphTraslationRequest that content ActivityParagraphTraslationdto to update.</param>
        ActivityParagraphTranslationMessage UpdateActivityParagraphTranslationRange(ActivityParagraphTranslationRequest request);

        /// <summary>
        /// Delete ActivityParagraphTraslation dto.
        /// </summary>
        /// <param name="request"> The ActivityParagraphTraslationRequest that content ActivityParagraphTraslationdto to remove.</param>
        /// <returns>The ActivityParagraphTraslationMessagePivot result with the ActivityParagraphTranslationPivot removed.</returns>
        ActivityParagraphTranslationMessage DeleteActivityParagraphTranslation(ActivityParagraphTranslationRequest request);

        /// <summary>
        /// Get the list of ActivityParagraphTraslation.
        /// </summary>
        /// <returns>The ActivityParagraphTraslationMessagePivot result with the ActivityParagraphTranslationPivot list.</returns>
        ActivityParagraphTranslationMessage GetAllActivityParagraphTranslations();

        /// <summary>
        /// Find ActivityParagraphTraslation.
        /// </summary>
        /// <returns>The ActivityParagraphTraslationMessagePivot result with the ActivityParagraphTranslationPivot list.</returns>
        ActivityParagraphTranslationMessage FindActivityParagraphTranslations(ActivityParagraphTranslationRequest request);
    }
}