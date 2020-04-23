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
    /// The StepParagraph service client class.
    /// </summary>
    public class ServiceStepParagraphClient : IServiceStepParagraphClient
    {
        #region private atributes

        /// <summary>
        /// The StepParagraph service instance.
        /// </summary>
        private readonly IServiceStepParagraph _serviceStepParagraph;

        #endregion

        #region constructor

        /// <summary>
        /// Set the StepParagraph instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceStepParagraph">injected instance</param>
        public ServiceStepParagraphClient(IServiceStepParagraph injectedServiceStepParagraph)
        {
            _serviceStepParagraph = injectedServiceStepParagraph;
        }

        #endregion

        #region Publics methods
        
        /// <summary>
        /// Add new StepParagraph
        /// </summary>
        /// <param name="request">stepParagraph request.</param>
        /// <returns>StepParagraph message.</returns>
        public StepParagraphMessage CreateStepParagraph(StepParagraphRequest request)
        {
            StepParagraphMessage message = new StepParagraphMessage();
            try
            {
                message = _serviceStepParagraph.CreateStepParagraph(request.ToPivot()).ToMessage();
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
        /// Change StepParagraph informations.
        /// </summary>
        /// <param name="request">stepParagraph request.</param>
        /// <returns>StepParagraph message.</returns>
        public StepParagraphMessage UpdateStepParagraph(StepParagraphRequest request)
        {
            StepParagraphMessage message = new StepParagraphMessage();
            try
            {
                _serviceStepParagraph.UpdateStepParagraph(request.ToPivot());
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
        /// Delete StepParagraph
        /// </summary>
        /// <param name="request">stepParagraph request.</param>
        /// <returns>StepParagraph message.</returns>
        public StepParagraphMessage DeleteStepParagraph(StepParagraphRequest request)
        {
            StepParagraphMessage message = new StepParagraphMessage();
            try
            {
                _serviceStepParagraph.DeleteStepParagraph(request.ToPivot());
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
        /// Get list of StepParagraph
        /// </summary>
        /// <returns>StepParagraph message.</returns>
        public StepParagraphMessage GetAllStepParagraphs()
        {
            StepParagraphMessage message = new StepParagraphMessage();
            try
            {
                message = _serviceStepParagraph.GetAllStepParagraphs().ToMessage();
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
        /// Search StepParagraph
        /// </summary>
        /// <param name="request">stepParagraph request.</param>
        /// <returns>StepParagraph message.</returns>
        public StepParagraphMessage FindStepParagraphs(StepParagraphRequest request)
        {
            StepParagraphMessage message = new StepParagraphMessage();
            try
            {
                message = _serviceStepParagraph.FindStepParagraphs(request.ToPivot()).ToMessage();
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