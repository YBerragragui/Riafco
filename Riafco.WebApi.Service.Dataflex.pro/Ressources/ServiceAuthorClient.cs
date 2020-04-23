using System;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Assembler;
using Riafco.Service.Dataflex.Pro.Ressources.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources
{
    /// <summary>
    /// The Author service client class.
    /// </summary>
    public class ServiceAuthorClient : IServiceAuthorClient
    {
        #region private attributes

        /// <summary>
        /// The Author service instance.
        /// </summary>
        private readonly IServiceAuthor _serviceAuthor;

        #endregion

        #region conscructor

        /// <summary>
        /// Set the Author instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceAuthor">injected instance</param>
        public ServiceAuthorClient(IServiceAuthor injectedServiceAuthor)
        {
            _serviceAuthor = injectedServiceAuthor;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create new Author.
        /// </summary>
        /// <param name="request">author request.</param>
        /// <returns>Author message.</returns>
        public AuthorMessage CreateAuthor(AuthorRequest request)
        {
            AuthorMessage message = new AuthorMessage();
            try
            {
                message = _serviceAuthor.CreateAuthor(request.ToPivot()).ToMessage();
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
        /// Change Author informations.
        /// </summary>
        /// <param name="request">author request.</param>
        /// <returns>Author message.</returns>
        public AuthorMessage UpdateAuthor(AuthorRequest request)
        {
            AuthorMessage message = new AuthorMessage();
            try
            {
                _serviceAuthor.UpdateAuthor(request.ToPivot());
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
        /// Delete Author
        /// </summary>
        /// <param name="request">author request.</param>
        /// <returns>Author message.</returns>
        public AuthorMessage DeleteAuthor(AuthorRequest request)
        {
            AuthorMessage message = new AuthorMessage();
            try
            {
                _serviceAuthor.DeleteAuthor(request.ToPivot());
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
        /// Get list of Author
        /// </summary>
        /// <returns>Author message.</returns>
        public AuthorMessage GetAllAuthors()
        {
            AuthorMessage message = new AuthorMessage();
            try
            {
                message = _serviceAuthor.GetAllAuthors().ToMessage();
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
        /// Search Author
        /// </summary>
        /// <param name="request">author request.</param>
        /// <returns>Author message.</returns>
        public AuthorMessage FindAuthors(AuthorRequest request)
        {
            AuthorMessage message = new AuthorMessage();
            try
            {
                message = _serviceAuthor.FindAuthors(request.ToPivot()).ToMessage();
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