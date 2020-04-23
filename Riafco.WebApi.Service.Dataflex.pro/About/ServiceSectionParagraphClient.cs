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
    /// The SectionParagraph service client class.
    /// </summary>
    public class ServiceSectionParagraphClient : IServiceSectionParagraphClient
    {
        #region private attributes

        /// <summary>
        /// The SectionParagraph service instance.
        /// </summary>
        private readonly IServiceSectionParagraph _serviceSectionParagraph;

        #endregion

        #region constructor
        
        /// <summary>
        /// Set the SectionParagraph instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceSectionParagraph">injected instance</param>
        public ServiceSectionParagraphClient(IServiceSectionParagraph injectedServiceSectionParagraph)
        {
            _serviceSectionParagraph = injectedServiceSectionParagraph;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create new SectionParagraph
        /// </summary>
        /// <param name="request">sectionParagraph request.</param>
        /// <returns>SectionParagraph message.</returns>
        public SectionParagraphMessage CreateSectionParagraph(SectionParagraphRequest request)
        {
            SectionParagraphMessage message = new SectionParagraphMessage();
            try
            {
                message = _serviceSectionParagraph.CreateSectionParagraph(request.ToPivot()).ToMessage();
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
        /// Change SectionParagraph informations.
        /// </summary>
        /// <param name="request">sectionParagraph request.</param>
        /// <returns>SectionParagraph message.</returns>
        public SectionParagraphMessage UpdateSectionParagraph(SectionParagraphRequest request)
        {
            SectionParagraphMessage message = new SectionParagraphMessage();
            try
            {
                _serviceSectionParagraph.UpdateSectionParagraph(request.ToPivot());
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
        /// Delete SectionParagraph
        /// </summary>
        /// <param name="request">sectionParagraph request.</param>
        /// <returns>SectionParagraph message.</returns>
        public SectionParagraphMessage DeleteSectionParagraph(SectionParagraphRequest request)
        {
            SectionParagraphMessage message = new SectionParagraphMessage();
            try
            {
                _serviceSectionParagraph.DeleteSectionParagraph(request.ToPivot());
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
        /// Get list of SectionParagraph
        /// </summary>
        /// <returns>SectionParagraph message.</returns>
        public SectionParagraphMessage GetAllSectionParagraphs()
        {
            SectionParagraphMessage message = new SectionParagraphMessage();
            try
            {
                message = _serviceSectionParagraph.GetAllSectionParagraphs().ToMessage();
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
        /// Search SectionParagraph
        /// </summary>
        /// <param name="request">sectionParagraph request.</param>
        /// <returns>SectionParagraph message.</returns>
        public SectionParagraphMessage FindSectionParagraphs(SectionParagraphRequest request)
        {
            SectionParagraphMessage message = new SectionParagraphMessage();
            try
            {
                message = _serviceSectionParagraph.FindSectionParagraphs(request.ToPivot()).ToMessage();
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