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
    /// The Section service client class.
    /// </summary>
    public class ServiceSectionClient : IServiceSectionClient
    {
        /// <summary>
        /// The Section service instance.
        /// </summary>
        private readonly IServiceSection _serviceSection;

        /// <summary>
        /// Set the Section instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceSection">injected instance</param>
        public ServiceSectionClient(IServiceSection injectedServiceSection)
        {
            _serviceSection = injectedServiceSection;
        }

        /// <summary>
        /// Add new Section
        /// </summary>
        /// <param name="request">section request.</param>
        /// <returns>Section message.</returns>
        public SectionMessage CreateSection(SectionRequest request)
        {
            SectionMessage message = new SectionMessage();
            try
            {
                message = _serviceSection.CreateSection(request.ToPivot()).ToMessage();
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
        /// Change Section informations.
        /// </summary>
        /// <param name="request">section request.</param>
        /// <returns>Section message.</returns>
        public SectionMessage UpdateSection(SectionRequest request)
        {
            SectionMessage message = new SectionMessage();

            try
            {
                _serviceSection.UpdateSection(request.ToPivot());
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
        /// Delete Section
        /// </summary>
        /// <param name="request">section request.</param>
        /// <returns>Section message.</returns>
        public SectionMessage DeleteSection(SectionRequest request)
        {
            SectionMessage message = new SectionMessage();
            try
            {
                _serviceSection.DeleteSection(request.ToPivot());
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
        /// Get list of Section
        /// </summary>
        /// <returns>Section message.</returns>
        public SectionMessage GetAllSections()
        {
            SectionMessage message = new SectionMessage();
            try
            {
                message = _serviceSection.GetAllSections().ToMessage();
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
        /// Search Section
        /// </summary>
        /// <param name="request">section request.</param>
        /// <returns>Section message.</returns>
        public SectionMessage FindSections(SectionRequest request)
        {
            SectionMessage message = new SectionMessage();
            try
            {
                message = _serviceSection.FindSections(request.ToPivot()).ToMessage();
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