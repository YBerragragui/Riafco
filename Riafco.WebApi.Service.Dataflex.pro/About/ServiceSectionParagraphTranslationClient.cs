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
    /// The SectionParagraphTraslation service client class.
    /// </summary>
    public class ServiceSectionParagraphTranslationClient : IServiceSectionParagraphTranslationClient
    {
        #region private attributes

        /// <summary>
        /// The SectionParagraphTraslation service instance.
        /// </summary>
        private readonly IServiceSectionParagraphTranslation _serviceSectionParagraphTraslation;

        #endregion

        #region constructor

        /// <summary>
        /// Set the SectionParagraphTraslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceSectionParagraphTraslation">injected instance</param>
        public ServiceSectionParagraphTranslationClient(IServiceSectionParagraphTranslation injectedServiceSectionParagraphTraslation)
        {
            _serviceSectionParagraphTraslation = injectedServiceSectionParagraphTraslation;
        }

        #endregion

        #region publics methods

        /// <summary>
        /// Create new SectionParagraphTraslation
        /// </summary>
        /// <param name="request">sectionParagraphTraslation request.</param>
        /// <returns>SectionParagraphTraslation message.</returns>
        public SectionParagraphTranslationMessage CreateSectionParagraphTranslation(SectionParagraphTranslationRequest request)
        {
            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            try
            {
                message = _serviceSectionParagraphTraslation.CreateSectionParagraphTranslation(request.ToPivot()).ToMessage();
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
        /// Create new SectionParagraphTraslation List
        /// </summary>
        /// <param name="request">sectionParagraphTraslation request.</param>
        /// <returns>SectionParagraphTraslation message.</returns>
        public SectionParagraphTranslationMessage CreateSectionParagraphTranslationRange(SectionParagraphTranslationRequest request)
        {
            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            try
            {
                message = _serviceSectionParagraphTraslation.CreateSectionParagraphTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change SectionParagraphTraslation informations.
        /// </summary>
        /// <param name="request">sectionParagraphTraslation request.</param>
        /// <returns>SectionParagraphTraslation message.</returns>
        public SectionParagraphTranslationMessage UpdateSectionParagraphTranslation(SectionParagraphTranslationRequest request)
        {
            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            try
            {
                _serviceSectionParagraphTraslation.UpdateSectionParagraphTranslation(request.ToPivot());
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
        /// Change SectionParagraphTraslation informations List.
        /// </summary>
        /// <param name="request">sectionParagraphTraslation request.</param>
        /// <returns>SectionParagraphTraslation message.</returns>
        public SectionParagraphTranslationMessage UpdateSectionParagraphTranslationRange(SectionParagraphTranslationRequest request)
        {
            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            try
            {
                _serviceSectionParagraphTraslation.UpdateSectionParagraphTranslationRange(request.ToPivot());
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
        /// Delete SectionParagraphTraslation
        /// </summary>
        /// <param name="request">sectionParagraphTraslation request.</param>
        /// <returns>SectionParagraphTraslation message.</returns>
        public SectionParagraphTranslationMessage DeleteSectionParagraphTranslation(SectionParagraphTranslationRequest request)
        {
            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            try
            {
                _serviceSectionParagraphTraslation.DeleteSectionParagraphTranslation(request.ToPivot());
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
        /// Get list of SectionParagraphTraslation
        /// </summary>
        /// <returns>SectionParagraphTraslation message.</returns>
        public SectionParagraphTranslationMessage GetAllSectionParagraphTranslations()
        {
            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            try
            {
                message = _serviceSectionParagraphTraslation.GetAllSectionParagraphTraslations().ToMessage();
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
        /// Search SectionParagraphTraslation
        /// </summary>
        /// <param name="request">sectionParagraphTraslation request.</param>
        /// <returns>SectionParagraphTraslation message.</returns>
        public SectionParagraphTranslationMessage FindSectionParagraphTranslations(SectionParagraphTranslationRequest request)
        {
            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            try
            {
                message = _serviceSectionParagraphTraslation.FindSectionParagraphTranslations(request.ToPivot()).ToMessage();
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