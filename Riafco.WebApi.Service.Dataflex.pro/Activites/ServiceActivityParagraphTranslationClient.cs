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
    /// The ActivityParagraphTraslation service client class.
    /// </summary>
    public class ServiceActivityParagraphTranslationClient : IServiceActivityParagraphTranslationClient
    {
        #region private attributes

        /// <summary>
        /// The ActivityParagraphTraslation service instance.
        /// </summary>
        private readonly IServiceActivityParagraphTranslation _serviceActivityParagraphTraslation;

        #endregion

        #region constructor

        /// <summary>
        /// Set the ActivityParagraphTraslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceActivityParagraphTraslation">injected instance</param>
        public ServiceActivityParagraphTranslationClient(IServiceActivityParagraphTranslation injectedServiceActivityParagraphTraslation)
        {
            _serviceActivityParagraphTraslation = injectedServiceActivityParagraphTraslation;
        }

        #endregion

        #region publics methods

        /// <summary>
        /// Create new ActivityParagraphTraslation
        /// </summary>
        /// <param name="request">activityParagraphTraslation request.</param>
        /// <returns>ActivityParagraphTraslation message.</returns>
        public ActivityParagraphTranslationMessage CreateActivityParagraphTranslation(ActivityParagraphTranslationRequest request)
        {
            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            try
            {
                message = _serviceActivityParagraphTraslation.CreateActivityParagraphTranslation(request.ToPivot()).ToMessage();
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
        /// Create new ActivityParagraphTraslation List
        /// </summary>
        /// <param name="request">activityParagraphTraslation request.</param>
        /// <returns>ActivityParagraphTraslation message.</returns>
        public ActivityParagraphTranslationMessage CreateActivityParagraphTranslationRange(ActivityParagraphTranslationRequest request)
        {
            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            try
            {
                message = _serviceActivityParagraphTraslation.CreateActivityParagraphTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change ActivityParagraphTraslation informations.
        /// </summary>
        /// <param name="request">activityParagraphTraslation request.</param>
        /// <returns>ActivityParagraphTraslation message.</returns>
        public ActivityParagraphTranslationMessage UpdateActivityParagraphTranslation(ActivityParagraphTranslationRequest request)
        {
            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            try
            {
                _serviceActivityParagraphTraslation.UpdateActivityParagraphTranslation(request.ToPivot());
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
        /// Change ActivityParagraphTraslation informations List.
        /// </summary>
        /// <param name="request">activityParagraphTraslation request.</param>
        /// <returns>ActivityParagraphTraslation message.</returns>
        public ActivityParagraphTranslationMessage UpdateActivityParagraphTranslationRange(ActivityParagraphTranslationRequest request)
        {
            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            try
            {
                _serviceActivityParagraphTraslation.UpdateActivityParagraphTranslationRange(request.ToPivot());
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
        /// Delete ActivityParagraphTraslation
        /// </summary>
        /// <param name="request">activityParagraphTraslation request.</param>
        /// <returns>ActivityParagraphTraslation message.</returns>
        public ActivityParagraphTranslationMessage DeleteActivityParagraphTranslation(ActivityParagraphTranslationRequest request)
        {
            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            try
            {
                _serviceActivityParagraphTraslation.DeleteActivityParagraphTranslation(request.ToPivot());
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
        /// Get list of ActivityParagraphTraslation
        /// </summary>
        /// <returns>ActivityParagraphTraslation message.</returns>
        public ActivityParagraphTranslationMessage GetAllActivityParagraphTranslations()
        {
            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            try
            {
                message = _serviceActivityParagraphTraslation.GetAllActivityParagraphTraslations().ToMessage();
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
        /// Search ActivityParagraphTraslation
        /// </summary>
        /// <param name="request">activityParagraphTraslation request.</param>
        /// <returns>ActivityParagraphTraslation message.</returns>
        public ActivityParagraphTranslationMessage FindActivityParagraphTranslations(ActivityParagraphTranslationRequest request)
        {
            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            try
            {
                message = _serviceActivityParagraphTraslation.FindActivityParagraphTranslations(request.ToPivot()).ToMessage();
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