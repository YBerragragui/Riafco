using System;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Request;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Message;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Assembler;
using Riafco.Service.Dataflex.Pro.Partners.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Partners
{
    /// <summary>
    /// The Partner service client class.
    /// </summary>
    public class ServicePartnerClient : IServicePartnerClient
    {
        /// <summary>
        /// The Partner service instance.
        /// </summary>
        private readonly IServicePartner _servicePartner;

        /// <summary>
        /// Set the Partner instane with injected instance.
        /// </summary>
        /// <param name="injectedServicePartner">injected instance</param>
        public ServicePartnerClient(IServicePartner injectedServicePartner)
        {
            _servicePartner = injectedServicePartner;
        }
        /// <summary>
        /// Add new Partner
        /// </summary>
        /// <param name="request">partner request.</param>
        /// <returns>Partner message.</returns>
        public PartnerMessage CreatePartner(PartnerRequest request)
        {
            PartnerMessage message = new PartnerMessage();
            try
            {
                message = _servicePartner.CreatePartner(request.ToPivot()).ToMessage();
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
        /// Change Partner informations.
        /// </summary>
        /// <param name="request">partner request.</param>
        /// <returns>Partner message.</returns>
        public PartnerMessage UpdatePartner(PartnerRequest request)
        {
            PartnerMessage message = new PartnerMessage();
            try
            {
                _servicePartner.UpdatePartner(request.ToPivot());
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
        /// Delete Partner
        /// </summary>
        /// <param name="request">partner request.</param>
        /// <returns>Partner message.</returns>
        public PartnerMessage DeletePartner(PartnerRequest request)
        {
            PartnerMessage message = new PartnerMessage();
            try
            {
                _servicePartner.DeletePartner(request.ToPivot());
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
        /// Get list of Partner
        /// </summary>
        /// <returns>Partner message.</returns>
        public PartnerMessage GetAllPartners()
        {
            PartnerMessage message = new PartnerMessage();
            try
            {
                message = _servicePartner.GetAllPartners().ToMessage();
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
        /// Search Partner
        /// </summary>
        /// <param name="request">partner request.</param>
        /// <returns>Partner message.</returns>
        public PartnerMessage FindPartners(PartnerRequest request)
        {
            PartnerMessage message = new PartnerMessage();
            try
            {
                message = _servicePartner.FindPartners(request.ToPivot()).ToMessage();
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