using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Message;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Request;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Ressource;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Riafco.WebApi.Dataflex.pro.Controllers.Languages
{
    /// <summary>
    /// The Language web api controller.
    /// </summary>
    [RoutePrefix("api/Languages")]
    public class LanguageController : ApiController
    {
        #region private attributes

        /// <summary>
        /// The Language service client instance.
        /// </summary>
        private readonly IServiceLanguageClient _serviceLanguageClient;

        #endregion

        #region constroctor

        /// <summary>
        /// Set the IServiceLanguageClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceLanguageClient">injected instance</param>
        public LanguageController(IServiceLanguageClient injectedServiceLanguageClient)
        {
            _serviceLanguageClient = injectedServiceLanguageClient;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Add new Language
        /// </summary>
        /// <returns>Language message.</returns>
        [Route("CreateLanguage")]
        public IHttpActionResult CreateLanguage(LanguageRequest request)
        {
            var errors = ValidateCreateLanguage(request);
            var message = new LanguageMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = LanguageMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceLanguageClient.CreateLanguage(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change Language informations.
        /// </summary>
        /// <returns>Language message.</returns>
        [Route("UpdateLanguage")]
        public IHttpActionResult UpdateLanguage(LanguageRequest request)
        {
            var errors = ValidateUpdateLanguage(request);
            var message = new LanguageMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = LanguageMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceLanguageClient.UpdateLanguage(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Language
        /// </summary>
        /// <returns>Language message.</returns>
        [Route("RemoveLanguage")]
        public IHttpActionResult DeleteLanguage(int languageId)
        {
            LanguageRequest request = new LanguageRequest
            {
                LanguageDto = new LanguageDto { LanguageId = languageId }
            };

            List<string> errors = ValidateDeleteLanguage(request);
            LanguageMessage message = new LanguageMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = LanguageMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {

                message = _serviceLanguageClient.DeleteLanguage(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of languages
        /// </summary>
        /// <returns>Language message.</returns>
        [Route("GetLanguages")]
        public IHttpActionResult GetAllLanguages()
        {
            var message = _serviceLanguageClient.GetAllLanguages();
            return Json(message);
        }

        /// <summary>
        /// Find Language
        /// </summary>
        /// <returns>Language message.</returns>
        [Route("FindLanguages")]
        public IHttpActionResult FindLanguages(LanguageRequest request)
        {
            List<string> errors = ValidateFindLanguage(request);
            LanguageMessage message = new LanguageMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = LanguageMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceLanguageClient.FindLanguages(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Validate update Language.
        /// </summary>
        /// <param name="request">the request to validate</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindLanguage(LanguageRequest request)
        {
            var errors = new List<string>();
            if (request == null)
            {
                errors.Add(LanguageMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<LanguageDto>.ValidateAttributes("LanguageId", request.LanguageDto.LanguageId.ToString()));
            }
            return errors;
        }
        #endregion

        #region private validation methods
        /// <summary>
        /// Validate add Language.
        /// </summary>
        /// <param name="request">the request to validate</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateLanguage(LanguageRequest request)
        {
            var errors = new List<string>();
            if (request?.LanguageDto == null)
            {
                errors.Add(LanguageMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<LanguageDto>.ValidateAttributes("LanguagePrefix", request.LanguageDto.LanguagePrefix));
                errors.AddRange(GenericValidationAttribute<LanguageDto>.ValidateAttributes("LanguagePicture", request.LanguageDto.LanguagePicture.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update Language.
        /// </summary>
        /// <param name="request">the request to validate</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateLanguage(LanguageRequest request)
        {
            var errors = new List<string>();
            if (request?.LanguageDto == null)
            {
                errors.Add(LanguageMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<LanguageDto>.ValidateAttributes("LanguageId", request.LanguageDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<LanguageDto>.ValidateAttributes("LanguagePrefix", request.LanguageDto.LanguagePrefix));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete Language.
        /// </summary>
        /// <param name="request">the request attribute to validate</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteLanguage(LanguageRequest request)
        {
            var errors = new List<string>();
            if (request?.LanguageDto == null)
            {
                errors.Add(LanguageMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<LanguageDto>.ValidateAttributes("LanguageId", request.LanguageDto.LanguageId.ToString()));
            }
            return errors;
        }
        #endregion
    }
}