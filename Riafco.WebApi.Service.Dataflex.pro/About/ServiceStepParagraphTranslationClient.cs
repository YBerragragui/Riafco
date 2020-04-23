using System;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;
using Riafco.WebApi.Service.Dataflex.pro.About.Interface;
using Riafco.WebApi.Service.Dataflex.pro.About.Assembler;
using Riafco.Service.Dataflex.Pro.About.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About
{
    /// <summary>
    /// The StepParagraphTranslation service client class.
    /// </summary>
    public class ServiceStepParagraphTranslationClient : IServiceStepParagraphTranslationClient
    {
        #region private attributes

        /// <summary>
        /// The StepParagraphTranslation service instance.
        /// </summary>
        private readonly IServiceStepParagraphTranslation _serviceStepParagraphTranslation;

        #endregion

        #region constructor

        /// <summary>
        /// Set the StepParagraphTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceStepParagraphTranslation">injected instance</param>
        public ServiceStepParagraphTranslationClient(IServiceStepParagraphTranslation injectedServiceStepParagraphTranslation)
        {
            _serviceStepParagraphTranslation = injectedServiceStepParagraphTranslation;
        }

        #endregion

        #region publics methods

        /// <summary>
        /// Add new StepParagraphTranslation
        /// </summary>
        /// <param name="request">stepParagraphTranslation request.</param>
        /// <returns>StepParagraphTranslation message.</returns>
        public StepParagraphTranslationMessage CreateStepParagraphTranslation(StepParagraphTranslationRequest request)
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            try
            {
                message = _serviceStepParagraphTranslation.CreateStepParagraphTranslation(request.ToPivot()).ToMessage();
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
        /// Create trapraph translation list.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public StepParagraphTranslationMessage CreateStepParagraphTranslationRange(StepParagraphTranslationRequest request)
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            try
            {
                message = _serviceStepParagraphTranslation.CreateStepParagraphTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change StepParagraphTranslation informations.
        /// </summary>
        /// <param name="request">stepParagraphTranslation request.</param>
        /// <returns>StepParagraphTranslation message.</returns>
        public StepParagraphTranslationMessage UpdateStepParagraphTranslation(StepParagraphTranslationRequest request)
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            try
            {
                _serviceStepParagraphTranslation.UpdateStepParagraphTranslation(request.ToPivot());
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
        /// Update step paragraph traslation list.
        /// </summary>
        /// <param name="request">the update request.</param>
        /// <returns></returns>
        public StepParagraphTranslationMessage UpdateStepParagraphTranslationRange(StepParagraphTranslationRequest request)
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            try
            {
                _serviceStepParagraphTranslation.UpdateStepParagraphTranslationRange(request.ToPivot());
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
        /// Delete StepParagraphTranslation
        /// </summary>
        /// <param name="request">stepParagraphTranslation request.</param>
        /// <returns>StepParagraphTranslation message.</returns>
        public StepParagraphTranslationMessage DeleteStepParagraphTranslation(StepParagraphTranslationRequest request)
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            try
            {
                _serviceStepParagraphTranslation.DeleteStepParagraphTranslation(request.ToPivot());
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
        /// Get list of StepParagraphTranslation
        /// </summary>
        /// <returns>StepParagraphTranslation message.</returns>
        public StepParagraphTranslationMessage GetAllStepParagraphTranslations()
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            try
            {
                message = _serviceStepParagraphTranslation.GetAllStepParagraphTranslations().ToMessage();
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
        /// Search StepParagraphTranslation
        /// </summary>
        /// <param name="request">stepParagraphTranslation request.</param>
        /// <returns>StepParagraphTranslation message.</returns>
        public StepParagraphTranslationMessage FindStepParagraphTranslations(StepParagraphTranslationRequest request)
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            try
            {
                message = _serviceStepParagraphTranslation.FindStepParagraphTranslations(request.ToPivot()).ToMessage();
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