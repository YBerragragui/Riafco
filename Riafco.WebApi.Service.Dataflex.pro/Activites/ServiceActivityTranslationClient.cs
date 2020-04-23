using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Service.Dataflex.Pro.Activites.Interface;
using Riafco.Service.Dataflex.Pro.Activites.Response;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Assembler;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Ressource;
using System;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites
{
    /// <summary>
    /// The ActivityTranslation service client class.
    /// </summary>
    public class ServiceActivityTranslationClient : IServiceActivityTranslationClient
    {
        #region private attributes 

        /// <summary>
        /// The ActivityTranslation service instance.
        /// </summary>
        private readonly IServiceActivityTranslation _serviceActivityTranslation;

        #endregion

        #region constroctor

        /// <summary>
        /// Set the ActivityTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceActivityTranslation">injected instance</param>
        public ServiceActivityTranslationClient(IServiceActivityTranslation injectedServiceActivityTranslation)
        {
            _serviceActivityTranslation = injectedServiceActivityTranslation;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create new ActivityTranslation
        /// </summary>
        /// <param name="request">activityTranslation request.</param>
        /// <returns>ActivityTranslation message.</returns>
        public ActivityTranslationMessage CreateActivityTranslation(ActivityTranslationRequest request)
        {
            ActivityTranslationMessage message = new ActivityTranslationMessage();
            try
            {
                message = _serviceActivityTranslation.CreateActivityTranslation(request.ToPivot()).ToMessage();
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
        /// Create new ActivityTranslation
        /// </summary>
        /// <param name="request">activityTranslation request.</param>
        /// <returns>ActivityTranslation message.</returns>
        public ActivityTranslationMessage CreateActivityTranslationRange(ActivityTranslationRequest request)
        {
            ActivityTranslationMessage message = new ActivityTranslationMessage();
            try
            {
                message = _serviceActivityTranslation.CreateActivityTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change ActivityTranslation informations.
        /// </summary>
        /// <param name="request">activityTranslation request.</param>
        /// <returns>ActivityTranslation message.</returns>
        public ActivityTranslationMessage UpdateActivityTranslation(ActivityTranslationRequest request)
        {
            ActivityTranslationMessage message = new ActivityTranslationMessage();
            try
            {
                request.FindActivityTranslationDto = FindActivityTranslationDto.ActivityTranslationId;
                ActivityTranslationResponsePivot response = _serviceActivityTranslation.FindActivityTranslations(request.ToPivot());
                if (response?.ActivityTranslationPivot == null)
                {
                    message.ErrorMessage = ActivityMessageResource.NotFountTraslation;
                    message.OperationSuccess = false;
                }
                else
                {
                    _serviceActivityTranslation.UpdateActivityTranslation(request.ToPivot());
                    message.OperationSuccess = true;
                }

            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }


        /// <summary>
        /// Change ActivityTranslation informations.
        /// </summary>
        /// <param name="request">activityTranslation request.</param>
        /// <returns>ActivityTranslation message.</returns>
        public ActivityTranslationMessage UpdateActivityTranslationRange(ActivityTranslationRequest request)
        {
            ActivityTranslationMessage message = new ActivityTranslationMessage();
            try
            {
                _serviceActivityTranslation.UpdateActivityTranslationRange(request.ToPivot());
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
        /// Delete ActivityTranslation
        /// </summary>
        /// <param name="request">activityTranslation request.</param>
        /// <returns>ActivityTranslation message.</returns>
        public ActivityTranslationMessage DeleteActivityTranslation(ActivityTranslationRequest request)
        {
            ActivityTranslationMessage message = new ActivityTranslationMessage();
            try
            {
                request.FindActivityTranslationDto = FindActivityTranslationDto.ActivityTranslationId;
                ActivityTranslationResponsePivot response = _serviceActivityTranslation.FindActivityTranslations(request.ToPivot());
                if (response?.ActivityTranslationPivot == null)
                {
                    message.ErrorMessage = ActivityMessageResource.NotFountTraslation;
                    message.OperationSuccess = false;
                }
                else
                {
                    _serviceActivityTranslation.DeleteActivityTranslation(request.ToPivot());
                    message.OperationSuccess = true;
                }
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Get list of ActivityTranslation
        /// </summary>
        /// <returns>ActivityTranslation message.</returns>
        public ActivityTranslationMessage GetAllActivityTranslations()
        {
            ActivityTranslationMessage message = new ActivityTranslationMessage();
            try
            {
                message = _serviceActivityTranslation.GetAllActivityTranslations().ToMessage();
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
        /// Search ActivityTranslation
        /// </summary>
        /// <param name="request">activityTranslation request.</param>
        /// <returns>ActivityTranslation message.</returns>
        public ActivityTranslationMessage FindActivityTranslations(ActivityTranslationRequest request)
        {
            ActivityTranslationMessage message = new ActivityTranslationMessage();
            try
            {
                message = _serviceActivityTranslation.FindActivityTranslations(request.ToPivot()).ToMessage();
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