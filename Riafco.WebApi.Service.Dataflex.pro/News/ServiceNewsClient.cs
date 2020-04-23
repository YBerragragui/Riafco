using System;
using Riafco.WebApi.Service.Dataflex.pro.News.Request;
using Riafco.WebApi.Service.Dataflex.pro.News.Message;
using Riafco.WebApi.Service.Dataflex.pro.News.Interface;
using Riafco.WebApi.Service.Dataflex.pro.News.Assembler;
using Riafco.Service.Dataflex.Pro.News.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.News
{
    /// <summary>
    /// The News service client class.
    /// </summary>
    public class ServiceNewsClient : IServiceNewsClient
    {
        /// <summary>
        /// The News service instance.
        /// </summary>
        private readonly IServiceNews _serviceNews;

        /// <summary>
        /// Set the News instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceNews">injected instance</param>
        public ServiceNewsClient(IServiceNews injectedServiceNews)
        {
            _serviceNews = injectedServiceNews;
        }

        /// <summary>
        /// Add new News
        /// </summary>
        /// <param name="request">news request.</param>
        /// <returns>News message.</returns>
        public NewsMessage CreateNews(NewsRequest request)
        {
            NewsMessage message = new NewsMessage();
            try
            {
                message = _serviceNews.CreateNews(request.ToPivot()).ToMessage();
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
        /// Change News informations.
        /// </summary>
        /// <param name="request">news request.</param>
        /// <returns>News message.</returns>
        public NewsMessage UpdateNews(NewsRequest request)
        {
            NewsMessage message = new NewsMessage();
            try
            {
                _serviceNews.UpdateNews(request.ToPivot());
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
        /// Delete News
        /// </summary>
        /// <param name="request">news request.</param>
        /// <returns>News message.</returns>
        public NewsMessage DeleteNews(NewsRequest request)
        {
            NewsMessage message = new NewsMessage();
            try
            {
                _serviceNews.DeleteNews(request.ToPivot());
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
        /// Get list of News
        /// </summary>
        /// <returns>News message.</returns>
        public NewsMessage GetAllNews()
        {
            NewsMessage message = new NewsMessage();
            try
            {
                message = _serviceNews.GetAllNews().ToMessage();
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
        /// Search News
        /// </summary>
        /// <param name="request">news request.</param>
        /// <returns>News message.</returns>
        public NewsMessage FindNews(NewsRequest request)
        {
            NewsMessage message = new NewsMessage();
            try
            {
                message = _serviceNews.FindNews(request.ToPivot()).ToMessage();
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