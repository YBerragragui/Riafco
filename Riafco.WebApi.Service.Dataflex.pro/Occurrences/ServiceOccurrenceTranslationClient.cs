using System;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Request;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Message;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Assembler;
using Riafco.Service.Dataflex.Pro.Occurrences.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Occurrences
{
    /// <summary>
    /// The OccurrenceTranslation service client class.
    /// </summary>
    public class ServiceOccurrenceTranslationClient : IServiceOccurrenceTranslationClient
    {
        /// <summary>
        /// The OccurrenceTranslation service instance.
        /// </summary>
        private readonly IServiceOccurrenceTranslation _serviceOccurrenceTranslation;

        /// <summary>
        /// Set the OccurrenceTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceOccurrenceTranslation">injected instance</param>
        public ServiceOccurrenceTranslationClient(IServiceOccurrenceTranslation injectedServiceOccurrenceTranslation)
        {
            _serviceOccurrenceTranslation = injectedServiceOccurrenceTranslation;
        }

        /// <summary>
        /// Add new OccurrenceTranslation
        /// </summary>
        /// <param name="request">occurrenceTranslation request.</param>
        /// <returns>OccurrenceTranslation message.</returns>
        public OccurrenceTranslationMessage CreateOccurrenceTranslation(OccurrenceTranslationRequest request)
        {
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();
            try
            {
                message = _serviceOccurrenceTranslation.CreateOccurrenceTranslation(request.ToPivot()).ToMessage();
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
        /// Add new CreateOccurrenceTranslationRange
        /// </summary>
        /// <param name="request">occurrenceTranslation request.</param>
        /// <returns>OccurrenceTranslation message.</returns>
        public OccurrenceTranslationMessage CreateOccurrenceTranslationRange(OccurrenceTranslationRequest request)
        {
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();
            try
            {
                message = _serviceOccurrenceTranslation.CreateOccurrenceTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change OccurrenceTranslation informations.
        /// </summary>
        /// <param name="request">occurrenceTranslation request.</param>
        /// <returns>OccurrenceTranslation message.</returns>
        public OccurrenceTranslationMessage UpdateOccurrenceTranslation(OccurrenceTranslationRequest request)
        {
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();
            try
            {
                _serviceOccurrenceTranslation.UpdateOccurrenceTranslation(request.ToPivot());
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
        /// Change UpdateOccurrenceTranslationRange informations.
        /// </summary>
        /// <param name="request">occurrenceTranslation request.</param>
        /// <returns>OccurrenceTranslation message.</returns>
        public OccurrenceTranslationMessage UpdateOccurrenceTranslationRange(OccurrenceTranslationRequest request)
        {
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();
            try
            {
                _serviceOccurrenceTranslation.UpdateOccurrenceTranslationRange(request.ToPivot());
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
        /// Delete OccurrenceTranslation
        /// </summary>
        /// <param name="request">occurrenceTranslation request.</param>
        /// <returns>OccurrenceTranslation message.</returns>
        public OccurrenceTranslationMessage DeleteOccurrenceTranslation(OccurrenceTranslationRequest request)
        {
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();
            try
            {
                _serviceOccurrenceTranslation.DeleteOccurrenceTranslation(request.ToPivot());
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
        /// Get list of OccurrenceTranslation
        /// </summary>
        /// <returns>OccurrenceTranslation message.</returns>
        public OccurrenceTranslationMessage GetAllOccurrenceTranslations()
        {
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();
            try
            {
                message = _serviceOccurrenceTranslation.GetAllOccurrenceTranslations().ToMessage();
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
        /// Search OccurrenceTranslation
        /// </summary>
        /// <param name="request">occurrenceTranslation request.</param>
        /// <returns>OccurrenceTranslation message.</returns>
        public OccurrenceTranslationMessage FindOccurrenceTranslations(OccurrenceTranslationRequest request)
        {
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();
            try
            {
                message = _serviceOccurrenceTranslation.FindOccurrenceTranslations(request.ToPivot()).ToMessage();
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