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
    /// The SectionFile service client class.
    /// </summary>
    public class ServiceSectionFileClient : IServiceSectionFileClient
    {
        /// <summary>
        /// The SectionFile service instance.
        /// </summary>
        private readonly IServiceSectionFile _serviceSectionFile;

        /// <summary>
        /// Set the SectionFile instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceSectionFile">injected instance</param>
        public ServiceSectionFileClient(IServiceSectionFile injectedServiceSectionFile)
        {
            _serviceSectionFile = injectedServiceSectionFile;
        }

        /// <summary>
        /// Create new SectionFile
        /// </summary>
        /// <param name="request">sectionFile request.</param>
        /// <returns>SectionFile message.</returns>
        public SectionFileMessage CreateSectionFile(SectionFileRequest request)
        {
            SectionFileMessage message = new SectionFileMessage();
            try
            {
                message = _serviceSectionFile.CreateSectionFile(request.ToPivot()).ToMessage();
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
        /// Change SectionFile informations.
        /// </summary>
        /// <param name="request">sectionFile request.</param>
        /// <returns>SectionFile message.</returns>
        public SectionFileMessage UpdateSectionFile(SectionFileRequest request)
        {
            SectionFileMessage message = new SectionFileMessage();
            try
            {
                _serviceSectionFile.UpdateSectionFile(request.ToPivot());
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
        /// Delete SectionFile
        /// </summary>
        /// <param name="request">sectionFile request.</param>
        /// <returns>SectionFile message.</returns>
        public SectionFileMessage DeleteSectionFile(SectionFileRequest request)
        {
            SectionFileMessage message = new SectionFileMessage();
            try
            {
                _serviceSectionFile.DeleteSectionFile(request.ToPivot());
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
        /// Get list of SectionFile
        /// </summary>
        /// <returns>SectionFile message.</returns>
        public SectionFileMessage GetAllSectionFiles()
        {
            SectionFileMessage message = new SectionFileMessage();
            try
            {
                message = _serviceSectionFile.GetAllSectionFiles().ToMessage();
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
        /// Search SectionFile
        /// </summary>
        /// <param name="request">sectionFile request.</param>
        /// <returns>SectionFile message.</returns>
        public SectionFileMessage FindSectionFiles(SectionFileRequest request)
        {
            SectionFileMessage message = new SectionFileMessage();
            try
            {
                message = _serviceSectionFile.FindSectionFiles(request.ToPivot()).ToMessage();
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