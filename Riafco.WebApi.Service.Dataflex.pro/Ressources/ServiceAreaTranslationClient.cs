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
    /// The AreaTranslation service client class.
    /// </summary>
    public class ServiceAreaTranslationClient : IServiceAreaTranslationClient
    {
        #region private attributes

        /// <summary>
        /// The AreaTranslation service instance.
        /// </summary>
        private readonly IServiceAreaTranslation _serviceAreaTranslation;

        #endregion

        #region constructor

        /// <summary>
        /// Set the AreaTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceAreaTranslation">injected instance</param>
        public ServiceAreaTranslationClient(IServiceAreaTranslation injectedServiceAreaTranslation)
        {
            _serviceAreaTranslation = injectedServiceAreaTranslation;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create new AreaTranslation
        /// </summary>
        /// <param name="request">areaTranslation request.</param>
        /// <returns>AreaTranslation message.</returns>
        public AreaTranslationMessage CreateAreaTranslation(AreaTranslationRequest request)
        {
            AreaTranslationMessage message = new AreaTranslationMessage();
            try
            {
                message = _serviceAreaTranslation.CreateAreaTranslation(request.ToPivot()).ToMessage();
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
        /// Create new AreaTranslation
        /// </summary>
        /// <param name="request">areaTranslation request.</param>
        /// <returns>AreaTranslation message.</returns>
        public AreaTranslationMessage CreateAreaTranslationRange(AreaTranslationRequest request)
        {
            AreaTranslationMessage message = new AreaTranslationMessage();
            try
            {
                message = _serviceAreaTranslation.CreateAreaTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change AreaTranslation informations.
        /// </summary>
        /// <param name="request">areaTranslation request.</param>
        /// <returns>AreaTranslation message.</returns>
        public AreaTranslationMessage UpdateAreaTranslation(AreaTranslationRequest request)
        {
            AreaTranslationMessage message = new AreaTranslationMessage();
            try
            {
                _serviceAreaTranslation.UpdateAreaTranslation(request.ToPivot());
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
        /// Change AreaTranslation informations range.
        /// </summary>
        /// <param name="request">areaTranslation request.</param>
        /// <returns>AreaTranslation message.</returns>
        public AreaTranslationMessage UpdateAreaTranslationRange(AreaTranslationRequest request)
        {
            AreaTranslationMessage message = new AreaTranslationMessage();
            try
            {
                _serviceAreaTranslation.UpdateAreaTranslationRange(request.ToPivot());
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
        /// Delete AreaTranslation
        /// </summary>
        /// <param name="request">areaTranslation request.</param>
        /// <returns>AreaTranslation message.</returns>
        public AreaTranslationMessage DeleteAreaTranslation(AreaTranslationRequest request)
        {
            AreaTranslationMessage message = new AreaTranslationMessage();
            try
            {
                _serviceAreaTranslation.DeleteAreaTranslation(request.ToPivot());
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
        /// Get list of AreaTranslation
        /// </summary>
        /// <returns>AreaTranslation message.</returns>
        public AreaTranslationMessage GetAllAreaTranslations()
        {
            AreaTranslationMessage message = new AreaTranslationMessage();
            try
            {
                message = _serviceAreaTranslation.GetAllAreaTranslations().ToMessage();
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
        /// Search AreaTranslation
        /// </summary>
        /// <param name="request">areaTranslation request.</param>
        /// <returns>AreaTranslation message.</returns>
        public AreaTranslationMessage FindAreaTranslations(AreaTranslationRequest request)
        {
            AreaTranslationMessage message = new AreaTranslationMessage();
            try
            {
                message = _serviceAreaTranslation.FindAreaTranslations(request.ToPivot()).ToMessage();
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