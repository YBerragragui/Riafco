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
    /// The Publication service client class.
    /// </summary>
    public class ServicePublicationClient : IServicePublicationClient
    {
        #region private attributes

        /// <summary>
        /// The Publication service instance.
        /// </summary>
        private readonly IServicePublication _servicePublication;

        #endregion

        #region constructor

        /// <summary>
        /// Set the Publication instane with injected instance.
        /// </summary>
        /// <param name="injectedServicePublication">injected instance</param>
        public ServicePublicationClient(IServicePublication injectedServicePublication)
        {
            _servicePublication = injectedServicePublication;
        }

        #endregion

        #region publics methods
        /// <summary>
        /// Create new Publication
        /// </summary>
        /// <param name="request">publication request.</param>
        /// <returns>Publication message.</returns>
        public PublicationMessage CreatePublication(PublicationRequest request)
        {
            PublicationMessage message = new PublicationMessage();
            try
            {
                message = _servicePublication.CreatePublication(request.ToPivot()).ToMessage();
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
        /// Change Publication informations.
        /// </summary>
        /// <param name="request">publication request.</param>
        /// <returns>Publication message.</returns>
        public PublicationMessage UpdatePublication(PublicationRequest request)
        {
            PublicationMessage message = new PublicationMessage();
            try
            {
                _servicePublication.UpdatePublication(request.ToPivot());
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
        /// Delete Publication
        /// </summary>
        /// <param name="request">publication request.</param>
        /// <returns>Publication message.</returns>
        public PublicationMessage DeletePublication(PublicationRequest request)
        {
            PublicationMessage message = new PublicationMessage();
            try
            {
                _servicePublication.DeletePublication(request.ToPivot());
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
        /// Get list of Publication
        /// </summary>
        /// <returns>Publication message.</returns>
        public PublicationMessage GetAllPublications()
        {
            PublicationMessage message = new PublicationMessage();
            try
            {
                message = _servicePublication.GetAllPublications().ToMessage();
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
        /// Search Publication
        /// </summary>
        /// <param name="request">publication request.</param>
        /// <returns>Publication message.</returns>
        public PublicationMessage FindPublications(PublicationRequest request)
        {
            PublicationMessage message = new PublicationMessage();
            try
            {
                message = _servicePublication.FindPublications(request.ToPivot()).ToMessage();
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