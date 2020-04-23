using System;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Request;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Message;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Assembler;
using Riafco.Service.Dataflex.Pro.Newsletters.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters
{
    /// <summary>
    /// The Subscriber service client class.
    /// </summary>
    public class ServiceSubscriberClient : IServiceSubscriberClient
    {
        /// <summary>
        /// The Subscriber service instance.
        /// </summary>
        private readonly IServiceSubscriber _serviceSubscriber;

        /// <summary>
        /// Set the Subscriber instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceSubscriber">injected instance</param>
        public ServiceSubscriberClient(IServiceSubscriber injectedServiceSubscriber)
        {
            _serviceSubscriber = injectedServiceSubscriber;
        }
        /// <summary>
        /// Add new Subscriber
        /// </summary>
        /// <param name="request">subscriber request.</param>
        /// <returns>Subscriber message.</returns>
        public SubscriberMessage CreateSubscriber(SubscriberRequest request)
        {
            SubscriberMessage message = new SubscriberMessage();
            try
            {
                message = _serviceSubscriber.CreateSubscriber(request.ToPivot()).ToMessage();
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
        /// Change Subscriber informations.
        /// </summary>
        /// <param name="request">subscriber request.</param>
        /// <returns>Subscriber message.</returns>
        public SubscriberMessage UpdateSubscriber(SubscriberRequest request)
        {
            SubscriberMessage message = new SubscriberMessage();
            try
            {
                _serviceSubscriber.UpdateSubscriber(request.ToPivot());
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
        /// Delete Subscriber
        /// </summary>
        /// <param name="request">subscriber request.</param>
        /// <returns>Subscriber message.</returns>
        public SubscriberMessage DeleteSubscriber(SubscriberRequest request)
        {
            SubscriberMessage message = new SubscriberMessage();
            try
            {
                _serviceSubscriber.DeleteSubscriber(request.ToPivot());
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
        /// Get list of Subscriber
        /// </summary>
        /// <returns>Subscriber message.</returns>
        public SubscriberMessage GetAllSubscribers()
        {
            SubscriberMessage message = new SubscriberMessage();
            try
            {
                message = _serviceSubscriber.GetAllSubscribers().ToMessage();
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
        /// Search Subscriber
        /// </summary>
        /// <param name="request">subscriber request.</param>
        /// <returns>Subscriber message.</returns>
        public SubscriberMessage FindSubscribers(SubscriberRequest request)
        {
            SubscriberMessage message = new SubscriberMessage();
            try
            {
                message = _serviceSubscriber.FindSubscribers(request.ToPivot()).ToMessage();
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