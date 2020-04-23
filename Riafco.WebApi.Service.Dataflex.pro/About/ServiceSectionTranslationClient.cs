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
    /// The SectionTranslation service client class.
    /// </summary>
    public class ServiceSectionTranslationClient : IServiceSectionTranslationClient
    {
        /// <summary>
        /// The SectionTranslation service instance.
        /// </summary>
        private readonly IServiceSectionTranslation _serviceSectionTranslation;

        /// <summary>
        /// Set the SectionTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceSectionTranslation">injected instance</param>
        public ServiceSectionTranslationClient(IServiceSectionTranslation injectedServiceSectionTranslation)
        {
            _serviceSectionTranslation = injectedServiceSectionTranslation;
        }

        /// <summary>
        /// Add new SectionTranslation
        /// </summary>
        /// <param name="request">sectionTranslation request.</param>
        /// <returns>SectionTranslation message.</returns>
        public SectionTranslationMessage CreateSectionTranslation(SectionTranslationRequest request)
        {
            SectionTranslationMessage message = new SectionTranslationMessage();
            try
            {
                message = _serviceSectionTranslation.CreateSectionTranslation(request.ToPivot()).ToMessage();
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
        /// Add new CreateSectionTranslationRange
        /// </summary>
        /// <param name="request">sectionTranslation request.</param>
        /// <returns>SectionTranslation message.</returns>
        public SectionTranslationMessage CreateSectionTranslationRange(SectionTranslationRequest request)
        {
            SectionTranslationMessage message = new SectionTranslationMessage();
            try
            {
                message = _serviceSectionTranslation.CreateSectionTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change SectionTranslation informations.
        /// </summary>
        /// <param name="request">sectionTranslation request.</param>
        /// <returns>SectionTranslation message.</returns>
        public SectionTranslationMessage UpdateSectionTranslation(SectionTranslationRequest request)
        {
            SectionTranslationMessage message = new SectionTranslationMessage();
            try
            {
                _serviceSectionTranslation.UpdateSectionTranslation(request.ToPivot());
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
        /// Change UpdateSectionTranslationRange informations.
        /// </summary>
        /// <param name="request">sectionTranslation request.</param>
        /// <returns>SectionTranslation message.</returns>
        public SectionTranslationMessage UpdateSectionTranslationRange(SectionTranslationRequest request)
        {
            SectionTranslationMessage message = new SectionTranslationMessage();
            try
            {
                _serviceSectionTranslation.UpdateSectionTranslationRange(request.ToPivot());
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
        /// Delete SectionTranslation
        /// </summary>
        /// <param name="request">sectionTranslation request.</param>
        /// <returns>SectionTranslation message.</returns>
        public SectionTranslationMessage DeleteSectionTranslation(SectionTranslationRequest request)
        {
            SectionTranslationMessage message = new SectionTranslationMessage();
            try
            {
                _serviceSectionTranslation.DeleteSectionTranslation(request.ToPivot());
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
        /// Get list of SectionTranslation
        /// </summary>
        /// <returns>SectionTranslation message.</returns>
        public SectionTranslationMessage GetAllSectionTranslations()
        {
            SectionTranslationMessage message = new SectionTranslationMessage();
            try
            {
                message = _serviceSectionTranslation.GetAllSectionTranslations().ToMessage();
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
        /// Search SectionTranslation
        /// </summary>
        /// <param name="request">sectionTranslation request.</param>
        /// <returns>SectionTranslation message.</returns>
        public SectionTranslationMessage FindSectionTranslations(SectionTranslationRequest request)
        {
            SectionTranslationMessage message = new SectionTranslationMessage();
            try
            {
                message = _serviceSectionTranslation.FindSectionTranslations(request.ToPivot()).ToMessage();
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