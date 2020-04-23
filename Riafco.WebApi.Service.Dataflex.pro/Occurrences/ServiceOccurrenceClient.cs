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
    /// The Occurrence service client class.
    /// </summary>
    public class ServiceOccurrenceClient : IServiceOccurrenceClient
    {
        /// <summary>
        /// The Occurrence service instance.
        /// </summary>
        private readonly IServiceOccurrence _serviceOccurrence;

        /// <summary>
        /// Set the Occurrence instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceOccurrence">injected instance</param>
        public ServiceOccurrenceClient(IServiceOccurrence injectedServiceOccurrence)
        {
            _serviceOccurrence = injectedServiceOccurrence;
        }

        /// <summary>
        /// Add new Occurrence
        /// </summary>
        /// <param name="request">occurrence request.</param>
        /// <returns>Occurrence message.</returns>
        public OccurrenceMessage CreateOccurrence(OccurrenceRequest request)
        {
            OccurrenceMessage message = new OccurrenceMessage();
            try
            {
                message = _serviceOccurrence.CreateOccurrence(request.ToPivot()).ToMessage();
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
        /// Change Occurrence informations.
        /// </summary>
        /// <param name="request">occurrence request.</param>
        /// <returns>Occurrence message.</returns>
        public OccurrenceMessage UpdateOccurrence(OccurrenceRequest request)
        {
            OccurrenceMessage message = new OccurrenceMessage();

            try
            {
                _serviceOccurrence.UpdateOccurrence(request.ToPivot());
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
        /// Delete Occurrence
        /// </summary>
        /// <param name="request">occurrence request.</param>
        /// <returns>Occurrence message.</returns>
        public OccurrenceMessage DeleteOccurrence(OccurrenceRequest request)
        {
            OccurrenceMessage message = new OccurrenceMessage();
            try
            {
                _serviceOccurrence.DeleteOccurrence(request.ToPivot());
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
        /// Get list of Occurrence
        /// </summary>
        /// <returns>Occurrence message.</returns>
        public OccurrenceMessage GetAllOccurrences()
        {
            OccurrenceMessage message = new OccurrenceMessage();
            try
            {
                message = _serviceOccurrence.GetAllOccurrences().ToMessage();
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
        /// Search Occurrence
        /// </summary>
        /// <param name="request">occurrence request.</param>
        /// <returns>Occurrence message.</returns>
        public OccurrenceMessage FindOccurrences(OccurrenceRequest request)
        {
            OccurrenceMessage message = new OccurrenceMessage();
            try
            {
                message = _serviceOccurrence.FindOccurrences(request.ToPivot()).ToMessage();
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