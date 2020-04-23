using Riafco.Service.Dataflex.Pro.Newsletters.Request;
using Riafco.Service.Dataflex.Pro.Newsletters.Response;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Interface
{
    /// <summary>
    /// The NewsletterMail interface.
    /// </summary>
    public interface IServiceNewsletterMail
    {
        /// <summary>
        /// Create NewsletterMailPivot.
        /// </summary>
        /// <param name="request"> The NewsletterMailRequest Pivot that content NewsletterMailPivot to add.</param>
        /// <returns>The NewsletterMailResponsePivot result with the NewsletterMailPivot added.</returns>
        NewsletterMailResponsePivot CreateNewsletterMail(NewsletterMailRequestPivot request);

        /// <summary>
        /// Update NewsletterMailPivot.
        /// </summary>
        /// <param name="request"> The NewsletterMailRequest Pivot that content NewsletterMailPivot to update.</param>
        void UpdateNewsletterMail(NewsletterMailRequestPivot request);

        /// <summary>
        /// Delete NewsletterMailPivot.
        /// </summary>
        /// <param name="request"> The NewsletterMailRequest Pivot that content NewsletterMailPivot to remove.</param>
        void DeleteNewsletterMail(NewsletterMailRequestPivot request);

        /// <summary>
        /// Get NewsletterMail list
        /// </summary>
        /// <returns>Response result.</returns>
        NewsletterMailResponsePivot GetAllNewsletterMails();

        /// <summary>
        /// Search NewsletterMail.
        /// </summary>
        /// <param name="request"> The NewsletterMailRequest Pivot that content NewsletterMailPivot to remove.</param>
        /// <returns>Response Result.</returns>
        NewsletterMailResponsePivot FindNewsletterMails(NewsletterMailRequestPivot request);
    }
}