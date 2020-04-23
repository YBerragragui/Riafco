using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Service.Dataflex.Pro.Languages.Interface;
using Riafco.Service.Dataflex.Pro.Languages.Response;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Message;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Request;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Ressource;
using System;

namespace Riafco.WebApi.Service.Dataflex.pro.Languages
{
    /// <summary>
    /// The Language service client class.
    /// </summary>
    public class ServiceLanguageClient : IServiceLanguageClient
    {
        #region private attributes

        /// <summary>
        /// The Language service instance.
        /// </summary>
        private readonly IServiceLanguage _serviceLanguage;

        #endregion

        #region constructor

        /// <summary>
        /// Set the Language instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceLanguage">injected instance</param>
        public ServiceLanguageClient(IServiceLanguage injectedServiceLanguage)
        {
            _serviceLanguage = injectedServiceLanguage;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create new Language
        /// </summary>
        /// <param name="request">language request.</param>
        /// <returns>Language message.</returns>
        public LanguageMessage CreateLanguage(LanguageRequest request)
        {
            LanguageMessage message = new LanguageMessage();
            try
            {
                message = _serviceLanguage.CreateLanguage(request.ToPivot()).ToMessage();
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
        /// Change Language informations.
        /// </summary>
        /// <param name="request">language request.</param>
        /// <returns>Language message.</returns>
        public LanguageMessage UpdateLanguage(LanguageRequest request)
        {
            LanguageMessage message = new LanguageMessage();
            try
            {
                request.FindLanguageDto = FindLanguageDto.LanguageId;
                LanguageResponsePivot findMessage = _serviceLanguage.FindLanguages(request.ToPivot());
                if (findMessage?.LanguagePivot == null)
                {
                    message.ErrorMessage = LanguageMessageResource.NotFound;
                    message.OperationSuccess = false;
                }
                else
                {
                    _serviceLanguage.UpdateLanguage(request.ToPivot());
                    message.OperationSuccess = true;
                }
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Delete Language
        /// </summary>
        /// <param name="request">language request.</param>
        /// <returns>Language message.</returns>
        public LanguageMessage DeleteLanguage(LanguageRequest request)
        {
            LanguageMessage message = new LanguageMessage();
            try
            {
                request.FindLanguageDto = FindLanguageDto.LanguageId;
                LanguageResponsePivot findMessage = _serviceLanguage.FindLanguages(request.ToPivot());
                if (findMessage?.LanguagePivot == null)
                {
                    message.ErrorMessage = LanguageMessageResource.NotFound;
                    message.OperationSuccess = false;
                }
                else
                {
                    _serviceLanguage.DeleteLanguage(request.ToPivot());
                    message.OperationSuccess = true;
                }
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Get list of Language
        /// </summary>
        /// <returns>Language message.</returns>
        public LanguageMessage GetAllLanguages()
        {
            LanguageMessage message = new LanguageMessage();
            try
            {
                message = _serviceLanguage.GetAllLanguages().ToMessage();
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
        /// Search Language
        /// </summary>
        /// <param name="request">language request.</param>
        /// <returns>Language message.</returns>
        public LanguageMessage FindLanguages(LanguageRequest request)
        {
            LanguageMessage message = new LanguageMessage();
            try
            {
                message = _serviceLanguage.FindLanguages(request.ToPivot()).ToMessage();
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