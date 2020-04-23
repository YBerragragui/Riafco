using System;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Assembler;
using Riafco.Service.Dataflex.Pro.Ressources.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources
{
    /// <summary>
    /// The PublicationTranslation service client class.
    /// </summary>
    public class ServicePublicationTranslationClient : IServicePublicationTranslationClient
    {
        #region private attributes

        /// <summary>
        /// The PublicationTranslation service instance.
        /// </summary>
        private readonly IServicePublicationTranslation _servicePublicationTranslation;

        #endregion

        #region constructor

        /// <summary>
        /// Set the PublicationTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServicePublicationTranslation">injected instance</param>
        public ServicePublicationTranslationClient(IServicePublicationTranslation injectedServicePublicationTranslation)
        {
            _servicePublicationTranslation = injectedServicePublicationTranslation;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create new PublicationTranslation
        /// </summary>
        /// <param name="request">publicationTranslation request.</param>
        /// <returns>PublicationTranslation message.</returns>
        public PublicationTranslationMessage CreatePublicationTranslation(PublicationTranslationRequest request)
        {
            PublicationTranslationMessage message = new PublicationTranslationMessage();
            try
            {
                message = _servicePublicationTranslation.CreatePublicationTranslation(request.ToPivot()).ToMessage();
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
        /// Create new PublicationTranslation
        /// </summary>
        /// <param name="request">publicationTranslation request.</param>
        /// <returns>PublicationTranslation message.</returns>
        public PublicationTranslationMessage CreatePublicationTranslationRange(PublicationTranslationRequest request)
        {
            PublicationTranslationMessage message = new PublicationTranslationMessage();
            try
            {
                message = _servicePublicationTranslation.CreatePublicationTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change PublicationTranslation informations.
        /// </summary>
        /// <param name="request">publicationTranslation request.</param>
        /// <returns>PublicationTranslation message.</returns>
        public PublicationTranslationMessage UpdatePublicationTranslation(PublicationTranslationRequest request)
        {
            PublicationTranslationMessage message = new PublicationTranslationMessage();
            try
            {
                _servicePublicationTranslation.UpdatePublicationTranslation(request.ToPivot());
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
        /// Change PublicationTranslation informations.
        /// </summary>
        /// <param name="request">publicationTranslation request.</param>
        /// <returns>PublicationTranslation message.</returns>
        public PublicationTranslationMessage UpdatePublicationTranslationRange(PublicationTranslationRequest request)
        {
            PublicationTranslationMessage message = new PublicationTranslationMessage();
            try
            {
                _servicePublicationTranslation.UpdatePublicationTranslationRange(request.ToPivot());
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
        /// Delete PublicationTranslation
        /// </summary>
        /// <param name="request">publicationTranslation request.</param>
        /// <returns>PublicationTranslation message.</returns>
        public PublicationTranslationMessage DeletePublicationTranslation(PublicationTranslationRequest request)
        {
            PublicationTranslationMessage message = new PublicationTranslationMessage();
            try
            {
                _servicePublicationTranslation.DeletePublicationTranslation(request.ToPivot());
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
        /// Get list of PublicationTranslation
        /// </summary>
        /// <returns>PublicationTranslation message.</returns>
        public PublicationTranslationMessage GetAllPublicationTranslations()
        {
            PublicationTranslationMessage message = new PublicationTranslationMessage();
            try
            {
                message = _servicePublicationTranslation.GetAllPublicationTranslations().ToMessage();
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
        /// Search PublicationTranslation
        /// </summary>
        /// <param name="request">publicationTranslation request.</param>
        /// <returns>PublicationTranslation message.</returns>
        public PublicationTranslationMessage FindPublicationTranslations(PublicationTranslationRequest request)
        {
            PublicationTranslationMessage message = new PublicationTranslationMessage();
            try
            {
                message = _servicePublicationTranslation.FindPublicationTranslations(request.ToPivot()).ToMessage();
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }
        #endregion
    }
}