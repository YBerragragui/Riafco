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
    /// The Activity service client class.
    /// </summary>
    public class ServiceActivityClient : IServiceActivityClient
    {
        #region private attributes

        /// <summary>
        /// The Activity service instance.
        /// </summary>
        private readonly IServiceActivity _serviceActivity;

        #endregion

        #region constructor

        /// <summary>
        /// Set the Activity instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceActivity">injected instance</param>
        public ServiceActivityClient(IServiceActivity injectedServiceActivity)
        {
            _serviceActivity = injectedServiceActivity;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create new Activity
        /// </summary>
        /// <param name="request">activity request.</param>
        /// <returns>Activity message.</returns>
        public ActivityMessage CreateActivity(ActivityRequest request)
        {
            ActivityMessage message = new ActivityMessage();
            try
            {
                message = _serviceActivity.CreateActivity(request.ToPivot()).ToMessage();
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
        /// Change Activity informations.
        /// </summary>
        /// <param name="request">activity request.</param>
        /// <returns>Activity message.</returns>
        public ActivityMessage UpdateActivity(ActivityRequest request)
        {
            ActivityMessage message = new ActivityMessage();
            try
            {
                request.FindActivityDto = FindActivityDto.ActivityId;
                ActivityResponsePivot response = _serviceActivity.FindActivities(request.ToPivot());
                if (response?.ActivityPivot != null)
                {
                    _serviceActivity.UpdateActivity(request.ToPivot());
                    message.OperationSuccess = true;
                }
                else
                {
                    message.ErrorMessage = ActivityMessageResource.NotFoundActivity;
                    message.ErrorType = ErrorType.FunctionalError;
                    message.OperationSuccess = false;
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
        /// Delete Activity
        /// </summary>
        /// <param name="request">activity request.</param>
        /// <returns>Activity message.</returns>
        public ActivityMessage DeleteActivity(ActivityRequest request)
        {
            ActivityMessage message = new ActivityMessage();
            try
            {
                request.FindActivityDto = FindActivityDto.ActivityId;
                ActivityResponsePivot response = _serviceActivity.FindActivities(request.ToPivot());
                if (response?.ActivityPivot != null)
                {
                    _serviceActivity.DeleteActivity(request.ToPivot());
                    message.OperationSuccess = true;
                }
                else
                {
                    message.ErrorMessage = ActivityMessageResource.NotFoundActivity;
                    message.ErrorType = ErrorType.FunctionalError;
                    message.OperationSuccess = false;
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
        /// Get list of Activity
        /// </summary>
        /// <returns>Activity message.</returns>
        public ActivityMessage GetAllActivities()
        {
            ActivityMessage message = new ActivityMessage();
            try
            {
                message = _serviceActivity.GetAllActivities().ToMessage();
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
        /// Search Activity
        /// </summary>
        /// <param name="request">activity request.</param>
        /// <returns>Activity message.</returns>
        public ActivityMessage FindActivities(ActivityRequest request)
        {
            ActivityMessage message = new ActivityMessage();
            try
            {
                message = _serviceActivity.FindActivities(request.ToPivot()).ToMessage();
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