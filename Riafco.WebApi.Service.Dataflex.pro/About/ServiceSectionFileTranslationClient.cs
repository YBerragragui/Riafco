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
    /// The SectionFileTranslation service client class.
    /// </summary>
    public class ServiceSectionFileTranslationClient : IServiceSectionFileTranslationClient
    {
        /// <summary>
        /// The SectionFileTranslation service instance.
        /// </summary>
        private readonly IServiceSectionFileTranslation _serviceSectionFileTranslation;

        /// <summary>
        /// Set the SectionFileTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceSectionFileTranslation">injected instance</param>
        public ServiceSectionFileTranslationClient(IServiceSectionFileTranslation injectedServiceSectionFileTranslation)
        {
            _serviceSectionFileTranslation = injectedServiceSectionFileTranslation;
        }

        /// <summary>
        /// Create new SectionFileTranslation
        /// </summary>
        /// <param name="request">sectionFileTranslation request.</param>
        /// <returns>SectionFileTranslation message.</returns>
        public SectionFileTranslationMessage CreateSectionFileTranslation(SectionFileTranslationRequest request)
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            try
            {
                message = _serviceSectionFileTranslation.CreateSectionFileTranslation(request.ToPivot()).ToMessage();
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
        /// Create new SectionFileTranslation list
        /// </summary>
        /// <param name="request">sectionFileTranslation request.</param>
        /// <returns>SectionFileTranslation message.</returns>
        public SectionFileTranslationMessage CreateSectionFileTranslationRange(SectionFileTranslationRequest request)
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            try
            {
                message = _serviceSectionFileTranslation.CreateSectionFileTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change SectionFileTranslation informations.
        /// </summary>
        /// <param name="request">sectionFileTranslation request.</param>
        /// <returns>SectionFileTranslation message.</returns>
        public SectionFileTranslationMessage UpdateSectionFileTranslation(SectionFileTranslationRequest request)
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            try
            {
                _serviceSectionFileTranslation.UpdateSectionFileTranslation(request.ToPivot());
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
        /// Change SectionFileTranslation informations List.
        /// </summary>
        /// <param name="request">sectionFileTranslation request.</param>
        /// <returns>SectionFileTranslation message.</returns>
        public SectionFileTranslationMessage UpdateSectionFileTranslationRange(SectionFileTranslationRequest request)
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            try
            {
                _serviceSectionFileTranslation.UpdateSectionFileTranslationRange(request.ToPivot());
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
        /// Delete SectionFileTranslation
        /// </summary>
        /// <param name="request">sectionFileTranslation request.</param>
        /// <returns>SectionFileTranslation message.</returns>
        public SectionFileTranslationMessage DeleteSectionFileTranslation(SectionFileTranslationRequest request)
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            try
            {
                _serviceSectionFileTranslation.DeleteSectionFileTranslation(request.ToPivot());
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
        /// Get list of SectionFileTranslation
        /// </summary>
        /// <returns>SectionFileTranslation message.</returns>
        public SectionFileTranslationMessage GetAllSectionFileTranslations()
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            try
            {
                message = _serviceSectionFileTranslation.GetAllSectionFileTranslations().ToMessage();
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
        /// Search SectionFileTranslation
        /// </summary>
        /// <param name="request">sectionFileTranslation request.</param>
        /// <returns>SectionFileTranslation message.</returns>
        public SectionFileTranslationMessage FindSectionFileTranslations(SectionFileTranslationRequest request)
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            try
            {
                message = _serviceSectionFileTranslation.FindSectionFileTranslations(request.ToPivot()).ToMessage();
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