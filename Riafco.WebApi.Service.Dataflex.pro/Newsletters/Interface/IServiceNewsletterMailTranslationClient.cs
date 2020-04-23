using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Request;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Interface
{
    /// <summary>
    /// The NewsletterMailTranslation client interface.
    /// </summary>
    public interface IServiceNewsletterMailTranslationClient
    {
        /// <summary>
        /// Add NewsletterMailTranslation dto.
        /// </summary>
        /// <param name="request"> The NewsletterMailTranslationRequest that content NewsletterMailTranslationdto to add.</param>
        /// <returns>The NewsletterMailTranslationMessagePivot result with the NewsletterMailTranslationPivot added.</returns>
        NewsletterMailTranslationMessage CreateNewsletterMailTranslation(NewsletterMailTranslationRequest request);

        /// <summary>
        /// Add CreateNewsletterMailTranslationRange dto.
        /// </summary>
        /// <param name="request"> The NewsletterMailTranslationRequest that content NewsletterMailTranslationdto to add.</param>
        /// <returns>The NewsletterMailTranslationMessagePivot result with the NewsletterMailTranslationPivot added.</returns>
        NewsletterMailTranslationMessage CreateNewsletterMailTranslationRange(NewsletterMailTranslationRequest request);

        /// <summary>
        /// Update NewsletterMailTranslation dto.
        /// </summary>
        /// <param name="request"> The NewsletterMailTranslationRequest that content NewsletterMailTranslationdto to update.</param>
        NewsletterMailTranslationMessage UpdateNewsletterMailTranslation(NewsletterMailTranslationRequest request);

        /// <summary>
        /// Update UpdateNewsletterMailTranslationRange dto.
        /// </summary>
        /// <param name="request"> The NewsletterMailTranslationRequest that content NewsletterMailTranslationdto to update.</param>
        NewsletterMailTranslationMessage UpdateNewsletterMailTranslationRange(NewsletterMailTranslationRequest request);

        /// <summary>
        /// Delete NewsletterMailTranslation dto.
        /// </summary>
        /// <param name="request"> The NewsletterMailTranslationRequest that content NewsletterMailTranslationdto to remove.</param>
        /// <returns>The NewsletterMailTranslationMessagePivot result with the NewsletterMailTranslationPivot removed.</returns>
        NewsletterMailTranslationMessage DeleteNewsletterMailTranslation(NewsletterMailTranslationRequest request);

        /// <summary>
        /// Get the list of NewsletterMailTranslation.
        /// </summary>
        /// <returns>The NewsletterMailTranslationMessagePivot result with the NewsletterMailTranslationPivot list.</returns>
        NewsletterMailTranslationMessage GetAllNewsletterMailTranslations();

        /// <summary>
        /// Find NewsletterMailTranslation.
        /// </summary>
        /// <returns>The NewsletterMailTranslationMessagePivot result with the NewsletterMailTranslationPivot list.</returns>
        NewsletterMailTranslationMessage FindNewsletterMailTranslations(NewsletterMailTranslationRequest request);
    }
}