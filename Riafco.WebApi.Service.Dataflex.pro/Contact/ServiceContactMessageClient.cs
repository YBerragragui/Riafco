using System;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Request;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Message;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Assembler;
using Riafco.Service.Dataflex.Pro.Contact.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Contact
{
    /// <summary>
    /// The ContactMessage service client class.
    /// </summary>
    public class ServiceContactMessageClient : IServiceContactMessageClient
    {
        /// <summary>
        /// The ContactMessage service instance.
        /// </summary>
        private readonly IServiceContactMessage _serviceContactMessage;

        /// <summary>
        /// Set the ContactMessage instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceContactMessage">injected instance</param>
        public ServiceContactMessageClient(IServiceContactMessage injectedServiceContactMessage)
        {
            _serviceContactMessage = injectedServiceContactMessage;
        }
        /// <summary>
        /// Add new ContactMessage
        /// </summary>
        /// <param name="request">contactMessage request.</param>
        /// <returns>ContactMessage message.</returns>
        public ContactMessageMessage CreateContactMessage(ContactMessageRequest request)
        {
            ContactMessageMessage message = new ContactMessageMessage();
            try
            {
                message = _serviceContactMessage.CreateContactMessage(request.ToPivot()).ToMessage();
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
        /// Delete ContactMessage
        /// </summary>
        /// <param name="request">contactMessage request.</param>
        /// <returns>ContactMessage message.</returns>
        public ContactMessageMessage DeleteContactMessage(ContactMessageRequest request)
        {
            ContactMessageMessage message = new ContactMessageMessage();
            try
            {
                _serviceContactMessage.DeleteContactMessage(request.ToPivot());
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
        /// Get list of ContactMessage
        /// </summary>
        /// <returns>ContactMessage message.</returns>
        public ContactMessageMessage GetAllContactMessages()
        {
            ContactMessageMessage message = new ContactMessageMessage();
            try
            {
                message = _serviceContactMessage.GetAllContactMessages().ToMessage();
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
        /// Search ContactMessage
        /// </summary>
        /// <param name="request">contactMessage request.</param>
        /// <returns>ContactMessage message.</returns>
        public ContactMessageMessage FindContactMessages(ContactMessageRequest request)
        {
            ContactMessageMessage message = new ContactMessageMessage();
            try
            {
                message = _serviceContactMessage.FindContactMessages(request.ToPivot()).ToMessage();
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