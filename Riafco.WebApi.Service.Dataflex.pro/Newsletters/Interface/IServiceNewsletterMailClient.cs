using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Request;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Message;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Interface
{
    /// <summary>
    /// The NewsletterMail client interface.
    /// </summary>
    public interface IServiceNewsletterMailClient
    {
        /// <summary>
        /// Add NewsletterMail dto.
        /// </summary>
        /// <param name="request"> The NewsletterMailRequest that content NewsletterMaildto to add.</param>
        /// <returns>The NewsletterMailMessagePivot result with the NewsletterMailPivot added.</returns>
        NewsletterMailMessage CreateNewsletterMail(NewsletterMailRequest request);

        /// <summary>
        /// Update NewsletterMail dto.
        /// </summary>
        /// <param name="request"> The NewsletterMailRequest that content NewsletterMaildto to update.</param>
        NewsletterMailMessage UpdateNewsletterMail(NewsletterMailRequest request);

        /// <summary>
        /// Delete NewsletterMail dto.
        /// </summary>
        /// <param name="request"> The NewsletterMailRequest that content NewsletterMaildto to remove.</param>
        /// <returns>The NewsletterMailMessagePivot result with the NewsletterMailPivot removed.</returns>
        NewsletterMailMessage DeleteNewsletterMail(NewsletterMailRequest request);

        /// <summary>
        /// Get the list of NewsletterMail.
        /// </summary>
        /// <returns>The NewsletterMailMessagePivot result with the NewsletterMailPivot list.</returns>
        NewsletterMailMessage GetAllNewsletterMails();

        /// <summary>
        /// Find NewsletterMail.
        /// </summary>
        /// <returns>The NewsletterMailMessagePivot result with the NewsletterMailPivot list.</returns>
        NewsletterMailMessage FindNewsletterMails(NewsletterMailRequest request);
    }
}