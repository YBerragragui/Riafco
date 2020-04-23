using System;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Assembler;
using Riafco.Service.Dataflex.Pro.Activites.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites
{
    /// <summary>
    /// The ActivityFileTranslation service client class.
    /// </summary>
    public class ServiceActivityFileTranslationClient : IServiceActivityFileTranslationClient
    {
        /// <summary>
        /// The ActivityFileTranslation service instance.
        /// </summary>
        private readonly IServiceActivityFileTranslation _serviceActivityFileTranslation;

        /// <summary>
        /// Set the ActivityFileTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceActivityFileTranslation">injected instance</param>
        public ServiceActivityFileTranslationClient(IServiceActivityFileTranslation injectedServiceActivityFileTranslation)
        {
            _serviceActivityFileTranslation = injectedServiceActivityFileTranslation;
        }

        /// <summary>
        /// Create new ActivityFileTranslation
        /// </summary>
        /// <param name="request">activityFileTranslation request.</param>
        /// <returns>ActivityFileTranslation message.</returns>
        public ActivityFileTranslationMessage CreateActivityFileTranslation(ActivityFileTranslationRequest request)
        {
            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            try
            {
                message = _serviceActivityFileTranslation.CreateActivityFileTranslation(request.ToPivot()).ToMessage();
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
        /// Create new ActivityFileTranslation list
        /// </summary>
        /// <param name="request">activityFileTranslation request.</param>
        /// <returns>ActivityFileTranslation message.</returns>
        public ActivityFileTranslationMessage CreateActivityFileTranslationRange(ActivityFileTranslationRequest request)
        {
            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            try
            {
                message = _serviceActivityFileTranslation.CreateActivityFileTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change ActivityFileTranslation informations.
        /// </summary>
        /// <param name="request">activityFileTranslation request.</param>
        /// <returns>ActivityFileTranslation message.</returns>
        public ActivityFileTranslationMessage UpdateActivityFileTranslation(ActivityFileTranslationRequest request)
        {
            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            try
            {
                _serviceActivityFileTranslation.UpdateActivityFileTranslation(request.ToPivot());
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
        /// Change ActivityFileTranslation informations List.
        /// </summary>
        /// <param name="request">activityFileTranslation request.</param>
        /// <returns>ActivityFileTranslation message.</returns>
        public ActivityFileTranslationMessage UpdateActivityFileTranslationRange(ActivityFileTranslationRequest request)
        {
            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            try
            {
                _serviceActivityFileTranslation.UpdateActivityFileTranslationRange(request.ToPivot());
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
        /// Delete ActivityFileTranslation
        /// </summary>
        /// <param name="request">activityFileTranslation request.</param>
        /// <returns>ActivityFileTranslation message.</returns>
        public ActivityFileTranslationMessage DeleteActivityFileTranslation(ActivityFileTranslationRequest request)
        {
            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            try
            {
                _serviceActivityFileTranslation.DeleteActivityFileTranslation(request.ToPivot());
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
        /// Get list of ActivityFileTranslation
        /// </summary>
        /// <returns>ActivityFileTranslation message.</returns>
        public ActivityFileTranslationMessage GetAllActivityFileTranslations()
        {
            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            try
            {
                message = _serviceActivityFileTranslation.GetAllActivityFileTranslations().ToMessage();
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
        /// Search ActivityFileTranslation
        /// </summary>
        /// <param name="request">activityFileTranslation request.</param>
        /// <returns>ActivityFileTranslation message.</returns>
        public ActivityFileTranslationMessage FindActivityFileTranslations(ActivityFileTranslationRequest request)
        {
            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            try
            {
                message = _serviceActivityFileTranslation.FindActivityFileTranslations(request.ToPivot()).ToMessage();
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