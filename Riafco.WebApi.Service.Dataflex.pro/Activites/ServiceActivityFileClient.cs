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
    /// The ActivityFile service client class.
    /// </summary>
    public class ServiceActivityFileClient : IServiceActivityFileClient
    {
        /// <summary>
        /// The ActivityFile service instance.
        /// </summary>
        private readonly IServiceActivityFile _serviceActivityFile;

        /// <summary>
        /// Set the ActivityFile instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceActivityFile">injected instance</param>
        public ServiceActivityFileClient(IServiceActivityFile injectedServiceActivityFile)
        {
            _serviceActivityFile = injectedServiceActivityFile;
        }

        /// <summary>
        /// Create new ActivityFile
        /// </summary>
        /// <param name="request">activityFile request.</param>
        /// <returns>ActivityFile message.</returns>
        public ActivityFileMessage CreateActivityFile(ActivityFileRequest request)
        {
            ActivityFileMessage message = new ActivityFileMessage();
            try
            {
                message = _serviceActivityFile.CreateActivityFile(request.ToPivot()).ToMessage();
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
        /// Change ActivityFile informations.
        /// </summary>
        /// <param name="request">activityFile request.</param>
        /// <returns>ActivityFile message.</returns>
        public ActivityFileMessage UpdateActivityFile(ActivityFileRequest request)
        {
            ActivityFileMessage message = new ActivityFileMessage();
            try
            {
                _serviceActivityFile.UpdateActivityFile(request.ToPivot());
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
        /// Delete ActivityFile
        /// </summary>
        /// <param name="request">activityFile request.</param>
        /// <returns>ActivityFile message.</returns>
        public ActivityFileMessage DeleteActivityFile(ActivityFileRequest request)
        {
            ActivityFileMessage message = new ActivityFileMessage();
            try
            {
                _serviceActivityFile.DeleteActivityFile(request.ToPivot());
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
        /// Get list of ActivityFile
        /// </summary>
        /// <returns>ActivityFile message.</returns>
        public ActivityFileMessage GetAllActivityFiles()
        {
            ActivityFileMessage message = new ActivityFileMessage();
            try
            {
                message = _serviceActivityFile.GetAllActivityFiles().ToMessage();
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
        /// Search ActivityFile
        /// </summary>
        /// <param name="request">activityFile request.</param>
        /// <returns>ActivityFile message.</returns>
        public ActivityFileMessage FindActivityFiles(ActivityFileRequest request)
        {
            ActivityFileMessage message = new ActivityFileMessage();
            try
            {
                message = _serviceActivityFile.FindActivityFiles(request.ToPivot()).ToMessage();
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