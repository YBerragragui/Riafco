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
    /// The NewsletterMailTranslation service client class.
    /// </summary>
    public class ServiceNewsletterMailTranslationClient : IServiceNewsletterMailTranslationClient
    {
        /// <summary>
        /// The NewsletterMailTranslation service instance.
        /// </summary>
        private readonly IServiceNewsletterMailTranslation _serviceNewsletterMailTranslation;

        /// <summary>
        /// Set the NewsletterMailTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceNewsletterMailTranslation">injected instance</param>
        public ServiceNewsletterMailTranslationClient(
            IServiceNewsletterMailTranslation injectedServiceNewsletterMailTranslation)
        {
            _serviceNewsletterMailTranslation = injectedServiceNewsletterMailTranslation;
        }

        /// <summary>
        /// Create new NewsletterMailTranslation
        /// </summary>
        /// <param name="request">newsletterMailTranslation request.</param>
        /// <returns>NewsletterMailTranslation message.</returns>
        public NewsletterMailTranslationMessage CreateNewsletterMailTranslation(NewsletterMailTranslationRequest request)
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            try
            {
                message = _serviceNewsletterMailTranslation.CreateNewsletterMailTranslation(request.ToPivot()).ToMessage();
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
        /// Create new NewsletterMailTranslation list
        /// </summary>
        /// <param name="request">newsletterMailTranslation request.</param>
        /// <returns>NewsletterMailTranslation message.</returns>
        public NewsletterMailTranslationMessage CreateNewsletterMailTranslationRange(NewsletterMailTranslationRequest request)
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            try
            {
                message = _serviceNewsletterMailTranslation.CreateNewsletterMailTranslationRange(request.ToPivot())
                    .ToMessage();
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
        /// Change NewsletterMailTranslation informations.
        /// </summary>
        /// <param name="request">newsletterMailTranslation request.</param>
        /// <returns>NewsletterMailTranslation message.</returns>
        public NewsletterMailTranslationMessage UpdateNewsletterMailTranslation(NewsletterMailTranslationRequest request)
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            try
            {
                _serviceNewsletterMailTranslation.UpdateNewsletterMailTranslation(request.ToPivot());
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
        /// Change NewsletterMailTranslation informations List.
        /// </summary>
        /// <param name="request">newsletterMailTranslation request.</param>
        /// <returns>NewsletterMailTranslation message.</returns>
        public NewsletterMailTranslationMessage UpdateNewsletterMailTranslationRange(NewsletterMailTranslationRequest request)
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            try
            {
                _serviceNewsletterMailTranslation.UpdateNewsletterMailTranslationRange(request.ToPivot());
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
        /// Delete NewsletterMailTranslation
        /// </summary>
        /// <param name="request">newsletterMailTranslation request.</param>
        /// <returns>NewsletterMailTranslation message.</returns>
        public NewsletterMailTranslationMessage DeleteNewsletterMailTranslation(NewsletterMailTranslationRequest request)
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            try
            {
                _serviceNewsletterMailTranslation.DeleteNewsletterMailTranslation(request.ToPivot());
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
        /// Get list of NewsletterMailTranslation
        /// </summary>
        /// <returns>NewsletterMailTranslation message.</returns>
        public NewsletterMailTranslationMessage GetAllNewsletterMailTranslations()
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            try
            {
                message = _serviceNewsletterMailTranslation.GetAllNewsletterMailTranslations().ToMessage();
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
        /// Search NewsletterMailTranslation
        /// </summary>
        /// <param name="request">newsletterMailTranslation request.</param>
        /// <returns>NewsletterMailTranslation message.</returns>
        public NewsletterMailTranslationMessage FindNewsletterMailTranslations(NewsletterMailTranslationRequest request)
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            try
            {
                message = _serviceNewsletterMailTranslation.FindNewsletterMailTranslations(request.ToPivot()).ToMessage();
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