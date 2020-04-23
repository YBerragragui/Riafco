using System;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Request;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Message;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Assembler;
using Riafco.Service.Dataflex.Pro.Newsletters.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters
{
    /// <summary>
    /// The NewsletterMail service client class.
    /// </summary>
    public class ServiceNewsletterMailClient : IServiceNewsletterMailClient
    {
        /// <summary>
        /// The NewsletterMail service instance.
        /// </summary>
        private readonly IServiceNewsletterMail _serviceNewsletterMail;

        /// <summary>
        /// Set the NewsletterMail instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceNewsletterMail">injected instance</param>
        public ServiceNewsletterMailClient(IServiceNewsletterMail injectedServiceNewsletterMail)
        {
            _serviceNewsletterMail = injectedServiceNewsletterMail;
        }

        /// <summary>
        /// Create new NewsletterMail
        /// </summary>
        /// <param name="request">newsletterMail request.</param>
        /// <returns>NewsletterMail message.</returns>
        public NewsletterMailMessage CreateNewsletterMail(NewsletterMailRequest request)
        {
            NewsletterMailMessage message = new NewsletterMailMessage();
            try
            {
                message = _serviceNewsletterMail.CreateNewsletterMail(request.ToPivot()).ToMessage();
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Change NewsletterMail informations.
        /// </summary>
        /// <param name="request">newsletterMail request.</param>
        /// <returns>NewsletterMail message.</returns>
        public NewsletterMailMessage UpdateNewsletterMail(NewsletterMailRequest request)
        {
            NewsletterMailMessage message = new NewsletterMailMessage();
            try
            {
                _serviceNewsletterMail.UpdateNewsletterMail(request.ToPivot());
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Delete NewsletterMail
        /// </summary>
        /// <param name="request">newsletterMail request.</param>
        /// <returns>NewsletterMail message.</returns>
        public NewsletterMailMessage DeleteNewsletterMail(NewsletterMailRequest request)
        {
            NewsletterMailMessage message = new NewsletterMailMessage();
            try
            {
                _serviceNewsletterMail.DeleteNewsletterMail(request.ToPivot());
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Get list of NewsletterMail
        /// </summary>
        /// <returns>NewsletterMail message.</returns>
        public NewsletterMailMessage GetAllNewsletterMails()
        {
            NewsletterMailMessage message = new NewsletterMailMessage();
            try
            {
                message = _serviceNewsletterMail.GetAllNewsletterMails().ToMessage();
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Search NewsletterMail
        /// </summary>
        /// <param name="request">newsletterMail request.</param>
        /// <returns>NewsletterMail message.</returns>
        public NewsletterMailMessage FindNewsletterMails(NewsletterMailRequest request)
        {
            NewsletterMailMessage message = new NewsletterMailMessage();
            try
            {
                message = _serviceNewsletterMail.FindNewsletterMails(request.ToPivot()).ToMessage();
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

    }
}