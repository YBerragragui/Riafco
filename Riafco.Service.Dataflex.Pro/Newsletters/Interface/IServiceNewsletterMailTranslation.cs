using Riafco.Service.Dataflex.Pro.Newsletters.Request;
using Riafco.Service.Dataflex.Pro.Newsletters.Response;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Interface
{
    /// <summary>
    /// The NewsletterMailTranslation interface.
    /// </summary>
    public interface IServiceNewsletterMailTranslation
    {
        /// <summary>
        /// Create NewsletterMailTranslationPivot.
        /// </summary>
        /// <param name="request"> The NewsletterMailTranslationRequest Pivot that content NewsletterMailTranslationPivot to add.</param>
        /// <returns>The NewsletterMailTranslationResponsePivot result with the NewsletterMailTranslationPivot added.</returns>
        NewsletterMailTranslationResponsePivot CreateNewsletterMailTranslation(NewsletterMailTranslationRequestPivot request);

        /// <summary>
        /// Create CreateNewsletterMailTranslationRange.
        /// </summary>
        /// <param name="request"> The NewsletterMailTranslationRequest Pivot that content NewsletterMailTranslationPivot to add.</param>
        /// <returns>The NewsletterMailTranslationResponsePivot result with the NewsletterMailTranslationPivot added.</returns>
        NewsletterMailTranslationResponsePivot CreateNewsletterMailTranslationRange(NewsletterMailTranslationRequestPivot request);

        /// <summary>
        /// Update NewsletterMailTranslationPivot.
        /// </summary>
        /// <param name="request"> The NewsletterMailTranslationRequest Pivot that content NewsletterMailTranslationPivot to update.</param>
        void UpdateNewsletterMailTranslation(NewsletterMailTranslationRequestPivot request);

        /// <summary>
        /// Update UpdateNewsletterMailTranslationRange.
        /// </summary>
        /// <param name="request"> The NewsletterMailTranslationRequest Pivot that content NewsletterMailTranslationPivot to update.</param>
        void UpdateNewsletterMailTranslationRange(NewsletterMailTranslationRequestPivot request);

        /// <summary>
        /// Delete NewsletterMailTranslationPivot.
        /// </summary>
        /// <param name="request"> The NewsletterMailTranslationRequest Pivot that content NewsletterMailTranslationPivot to remove.</param>
        void DeleteNewsletterMailTranslation(NewsletterMailTranslationRequestPivot request);

        /// <summary>
        /// Get NewsletterMailTranslation list
        /// </summary>
        /// <returns>Response result.</returns>
        NewsletterMailTranslationResponsePivot GetAllNewsletterMailTranslations();

        /// <summary>
        /// Search NewsletterMailTranslation.
        /// </summary>
        /// <param name="request"> The NewsletterMailTranslationRequest Pivot that content NewsletterMailTranslationPivot to remove.</param>
        /// <returns>Response Result.</returns>
        NewsletterMailTranslationResponsePivot FindNewsletterMailTranslations(NewsletterMailTranslationRequestPivot request);

    }
}