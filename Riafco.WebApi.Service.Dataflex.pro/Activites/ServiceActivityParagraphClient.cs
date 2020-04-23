using System;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Assembler;
using Riafco.Service.Dataflex.Pro.Activites.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites
{
    /// <summary>
    /// The ActivityParagraph service client class.
    /// </summary>
    public class ServiceActivityParagraphClient : IServiceActivityParagraphClient
    {
        #region private attributes

        /// <summary>
        /// The ActivityParagraph service instance.
        /// </summary>
        private readonly IServiceActivityParagraph _serviceActivityParagraph;

        #endregion

        #region constructor
        
        /// <summary>
        /// Set the ActivityParagraph instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceActivityParagraph">injected instance</param>
        public ServiceActivityParagraphClient(IServiceActivityParagraph injectedServiceActivityParagraph)
        {
            _serviceActivityParagraph = injectedServiceActivityParagraph;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create new ActivityParagraph
        /// </summary>
        /// <param name="request">activityParagraph request.</param>
        /// <returns>ActivityParagraph message.</returns>
        public ActivityParagraphMessage CreateActivityParagraph(ActivityParagraphRequest request)
        {
            ActivityParagraphMessage message = new ActivityParagraphMessage();
            try
            {
                message = _serviceActivityParagraph.CreateActivityParagraph(request.ToPivot()).ToMessage();
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
        /// Change ActivityParagraph informations.
        /// </summary>
        /// <param name="request">activityParagraph request.</param>
        /// <returns>ActivityParagraph message.</returns>
        public ActivityParagraphMessage UpdateActivityParagraph(ActivityParagraphRequest request)
        {
            ActivityParagraphMessage message = new ActivityParagraphMessage();
            try
            {
                _serviceActivityParagraph.UpdateActivityParagraph(request.ToPivot());
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
        /// Delete ActivityParagraph
        /// </summary>
        /// <param name="request">activityParagraph request.</param>
        /// <returns>ActivityParagraph message.</returns>
        public ActivityParagraphMessage DeleteActivityParagraph(ActivityParagraphRequest request)
        {
            ActivityParagraphMessage message = new ActivityParagraphMessage();
            try
            {
                _serviceActivityParagraph.DeleteActivityParagraph(request.ToPivot());
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
        /// Get list of ActivityParagraph
        /// </summary>
        /// <returns>ActivityParagraph message.</returns>
        public ActivityParagraphMessage GetAllActivityParagraphs()
        {
            ActivityParagraphMessage message = new ActivityParagraphMessage();
            try
            {
                message = _serviceActivityParagraph.GetAllActivityParagraphs().ToMessage();
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
        /// Search ActivityParagraph
        /// </summary>
        /// <param name="request">activityParagraph request.</param>
        /// <returns>ActivityParagraph message.</returns>
        public ActivityParagraphMessage FindActivityParagraphs(ActivityParagraphRequest request)
        {
            ActivityParagraphMessage message = new ActivityParagraphMessage();
            try
            {
                message = _serviceActivityParagraph.FindActivityParagraphs(request.ToPivot()).ToMessage();
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