using System;
using Riafco.WebApi.Service.Dataflex.pro.News.Request;
using Riafco.WebApi.Service.Dataflex.pro.News.Message;
using Riafco.WebApi.Service.Dataflex.pro.News.Interface;
using Riafco.WebApi.Service.Dataflex.pro.News.Assembler;
using Riafco.Service.Dataflex.Pro.News.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.News
{
    /// <summary>
    /// The NewsTranslation service client class.
    /// </summary>
    public class ServiceNewsTranslationClient : IServiceNewsTranslationClient
    {
        /// <summary>
        /// The NewsTranslation service instance.
        /// </summary>
        private readonly IServiceNewsTranslation _serviceNewsTranslation;

        /// <summary>
        /// Set the NewsTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceNewsTranslation">injected instance</param>
        public ServiceNewsTranslationClient(IServiceNewsTranslation injectedServiceNewsTranslation)
        {
            _serviceNewsTranslation = injectedServiceNewsTranslation;
        }

        /// <summary>
        /// Add new NewsTranslation
        /// </summary>
        /// <param name="request">NewsTranslation request.</param>
        /// <returns>NewsTranslation message.</returns>
        public NewsTranslationMessage CreateNewsTranslation(NewsTranslationRequest request)
        {
            NewsTranslationMessage message = new NewsTranslationMessage();
            try
            {
                message = _serviceNewsTranslation.CreateNewsTranslation(request.ToPivot()).ToMessage();
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
        /// Add new NewsTranslation
        /// </summary>
        /// <param name="request">NewsTranslation request.</param>
        /// <returns>NewsTranslation message.</returns>
        public NewsTranslationMessage CreateNewsTranslationRange(NewsTranslationRequest request)
        {
            NewsTranslationMessage message = new NewsTranslationMessage();
            try
            {
                message = _serviceNewsTranslation.CreateNewsTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change NewsTranslation informations.
        /// </summary>
        /// <param name="request">NewsTranslation request.</param>
        /// <returns>NewsTranslation message.</returns>
        public NewsTranslationMessage UpdateNewsTranslation(NewsTranslationRequest request)
        {
            NewsTranslationMessage message = new NewsTranslationMessage();
            try
            {
                _serviceNewsTranslation.UpdateNewsTranslation(request.ToPivot());
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
        /// Change NewsTranslation informations.
        /// </summary>
        /// <param name="request">NewsTranslation request.</param>
        /// <returns>NewsTranslation message.</returns>
        public NewsTranslationMessage UpdateNewsTranslationRange(NewsTranslationRequest request)
        {
            NewsTranslationMessage message = new NewsTranslationMessage();
            try
            {
                _serviceNewsTranslation.UpdateNewsTranslationRange(request.ToPivot());
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
        /// Delete NewsTranslation
        /// </summary>
        /// <param name="request">NewsTranslation request.</param>
        /// <returns>NewsTranslation message.</returns>
        public NewsTranslationMessage DeleteNewsTranslation(NewsTranslationRequest request)
        {
            NewsTranslationMessage message = new NewsTranslationMessage();
            try
            {
                _serviceNewsTranslation.DeleteNewsTranslation(request.ToPivot());
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
        /// Get list of NewsTranslation
        /// </summary>
        /// <returns>NewsTranslation message.</returns>
        public NewsTranslationMessage GetAllNewsTranslation()
        {
            NewsTranslationMessage message = new NewsTranslationMessage();
            try
            {
                message = _serviceNewsTranslation.GetAllNewsTranslation().ToMessage();
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
        /// Search NewsTranslation
        /// </summary>
        /// <param name="request">NewsTranslation request.</param>
        /// <returns>NewsTranslation message.</returns>
        public NewsTranslationMessage FindNewsTranslation(NewsTranslationRequest request)
        {
            NewsTranslationMessage message = new NewsTranslationMessage();
            try
            {
                message = _serviceNewsTranslation.FindNewsTranslation(request.ToPivot()).ToMessage();
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