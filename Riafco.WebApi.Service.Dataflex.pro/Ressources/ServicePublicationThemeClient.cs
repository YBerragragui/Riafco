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
    /// The PublicationTheme service client class.
    /// </summary>
    public class ServicePublicationThemeClient : IServicePublicationThemeClient
    {
        #region private attributes

        /// <summary>
        /// The PublicationTheme service instance.
        /// </summary>
        private readonly IServicePublicationTheme _servicePublicationTheme;

        #endregion

        #region constructor

        /// <summary>
        /// Set the PublicationTheme instane with injected instance.
        /// </summary>
        /// <param name="injectedServicePublicationTheme">injected instance</param>
        public ServicePublicationThemeClient(IServicePublicationTheme injectedServicePublicationTheme)
        {
            _servicePublicationTheme = injectedServicePublicationTheme;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create new PublicationTheme
        /// </summary>
        /// <param name="request">publicationTheme request.</param>
        /// <returns>PublicationTheme message.</returns>
        public PublicationThemeMessage CreatePublicationTheme(PublicationThemeRequest request)
        {
            PublicationThemeMessage message = new PublicationThemeMessage();
            try
            {
                message = _servicePublicationTheme.CreatePublicationTheme(request.ToPivot()).ToMessage();
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
        /// Create new PublicationTheme range.
        /// </summary>
        /// <param name="request">publicationTheme request.</param>
        /// <returns>PublicationTheme message.</returns>
        public PublicationThemeMessage CreatePublicationThemeRange(PublicationThemeRequest request)
        {
            PublicationThemeMessage message = new PublicationThemeMessage();
            try
            {
                message = _servicePublicationTheme.CreatePublicationThemeRange(request.ToPivot()).ToMessage();
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
        /// Change PublicationTheme informations.
        /// </summary>
        /// <param name="request">publicationTheme request.</param>
        /// <returns>PublicationTheme message.</returns>
        public PublicationThemeMessage UpdatePublicationTheme(PublicationThemeRequest request)
        {
            PublicationThemeMessage message = new PublicationThemeMessage();
            try
            {
                _servicePublicationTheme.UpdatePublicationTheme(request.ToPivot());
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
        /// Change PublicationTheme range informations.
        /// </summary>
        /// <param name="request">publicationTheme request.</param>
        /// <returns>PublicationTheme message.</returns>
        public PublicationThemeMessage UpdatePublicationThemeRange(PublicationThemeRequest request)
        {
            PublicationThemeMessage message = new PublicationThemeMessage();
            try
            {
                _servicePublicationTheme.UpdatePublicationThemeRange(request.ToPivot());
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
        /// Delete PublicationTheme
        /// </summary>
        /// <param name="request">publicationTheme request.</param>
        /// <returns>PublicationTheme message.</returns>
        public PublicationThemeMessage DeletePublicationTheme(PublicationThemeRequest request)
        {
            PublicationThemeMessage message = new PublicationThemeMessage();
            try
            {
                _servicePublicationTheme.DeletePublicationTheme(request.ToPivot());
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
        /// Get list of PublicationTheme
        /// </summary>
        /// <returns>PublicationTheme message.</returns>
        public PublicationThemeMessage GetAllPublicationThemes()
        {
            PublicationThemeMessage message = new PublicationThemeMessage();
            try
            {
                message = _servicePublicationTheme.GetAllPublicationThemes().ToMessage();
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
        /// Search PublicationTheme
        /// </summary>
        /// <param name="request">publicationTheme request.</param>
        /// <returns>PublicationTheme message.</returns>
        public PublicationThemeMessage FindPublicationThemes(PublicationThemeRequest request)
        {
            PublicationThemeMessage message = new PublicationThemeMessage();
            try
            {
                message = _servicePublicationTheme.FindPublicationThemes(request.ToPivot()).ToMessage();
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