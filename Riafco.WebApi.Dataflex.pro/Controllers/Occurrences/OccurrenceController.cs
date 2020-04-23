using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Message;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Request;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Ressource;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Riafco.WebApi.Dataflex.pro.Controllers.Occurrences
{
    /// <summary>
    /// The Occurrence web api controller.
    /// </summary>
    [RoutePrefix("api/Occurrences")]
    public class OccurrenceController : ApiController
    {
        #region private properties
        /// <summary>
        /// The Occurrence service client instance.
        /// </summary>
        private readonly IServiceOccurrenceClient _serviceOccurrenceClient;
        /// <summary>
        /// The OccurrenceTranslation service client instance.
        /// </summary>
        private readonly IServiceOccurrenceTranslationClient _serviceOccurrenceTranslationClient;

        #endregion

        #region constructor
        /// <summary>
        /// Set the IServiceOccurrenceClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceOccurrenceClient">injected instance</param>
        /// <param name="injectedServiceOccurrenceTranslationClient">injected instance</param>
        public OccurrenceController(IServiceOccurrenceClient injectedServiceOccurrenceClient, IServiceOccurrenceTranslationClient injectedServiceOccurrenceTranslationClient)
        {
            _serviceOccurrenceClient = injectedServiceOccurrenceClient;
            _serviceOccurrenceTranslationClient = injectedServiceOccurrenceTranslationClient;
        }
        #endregion

        #region public methods Occurrences
        /// <summary>
        /// Create new Occurrence
        /// </summary>
        /// <returns>Occurrence message.</returns>
        [Route("CreateOccurrence")]
        public IHttpActionResult CreateOccurrence(OccurrenceRequest request)
        {
            List<string> errors = ValidateCreateOccurrence(request);
            OccurrenceMessage message = new OccurrenceMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = OccurrenceMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceOccurrenceClient.CreateOccurrence(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change Occurrence informations.
        /// </summary>
        /// <returns>Occurrence message.</returns>
        [Route("UpdateOccurrence")]
        public IHttpActionResult UpdateOccurrence(OccurrenceRequest request)
        {
            List<string> errors = ValidateUpdateOccurrence(request);
            OccurrenceMessage message = new OccurrenceMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = OccurrenceMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceOccurrenceClient.UpdateOccurrence(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Occurrence
        /// </summary>
        /// <returns>Occurrence message.</returns>
        [Route("RemoveOccurrence")]
        public IHttpActionResult DeleteOccurrence(int occurrenceId)
        {
            OccurrenceRequest request = new OccurrenceRequest
            {
                OccurrenceDto = new OccurrenceDto { OccurrenceId = occurrenceId }
            };
            List<string> errors = ValidateOccurrenceId(request);
            OccurrenceMessage message = new OccurrenceMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = OccurrenceMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceOccurrenceClient.DeleteOccurrence(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Occurrences
        /// </summary>
        /// <returns>Occurrence message.</returns>
        [Route("GetOccurrences")]
        public IHttpActionResult GetAllOccurrences()
        {
            OccurrenceMessage message = _serviceOccurrenceClient.GetAllOccurrences();
            return Json(message);
        }

        /// <summary>
        /// Find Occurrences.
        /// </summary>
        /// <returns>Occurrence message.</returns>
        [Route("FindOccurrences")]
        public IHttpActionResult FindOccurrences(OccurrenceRequest request)
        {
            List<string> errors = ValidateOccurrenceId(request);
            OccurrenceMessage message = new OccurrenceMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = OccurrenceMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceOccurrenceClient.FindOccurrences(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation occurrence methods
        /// <summary>
        /// Validation creation occurrence.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateOccurrence(OccurrenceRequest request)
        {
            var errors = new List<string>();
            if (request?.OccurrenceDto == null)
            {
                errors.Add(OccurrenceMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<OccurrenceDto>.ValidateAttributes("OccurrenceStartDate",
                    request.OccurrenceDto.OccurrenceStartDate.ToString("dd/MM/yyyy")));
                errors.AddRange(GenericValidationAttribute<OccurrenceDto>.ValidateAttributes("OccurrenceEndDate",
                    request.OccurrenceDto.OccurrenceEndDate.ToString("dd/MM/yyyy")));
                errors.AddRange(GenericValidationAttribute<OccurrenceDto>.ValidateAttributes("OccurrenceLink",
                    request.OccurrenceDto.OccurrenceLink));
            }
            return errors;
        }

        /// <summary>
        /// Validation update occurrence.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateOccurrence(OccurrenceRequest request)
        {
            var errors = new List<string>();
            if (request?.OccurrenceDto == null)
            {
                errors.Add(OccurrenceMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<OccurrenceDto>.ValidateAttributes("OccurrenceStartDate",
                    request.OccurrenceDto.OccurrenceStartDate.ToString("dd/MM/yyyy")));
                errors.AddRange(GenericValidationAttribute<OccurrenceDto>.ValidateAttributes("OccurrenceEndDate",
                    request.OccurrenceDto.OccurrenceEndDate.ToString("dd/MM/yyyy")));
                errors.AddRange(GenericValidationAttribute<OccurrenceDto>.ValidateAttributes("OccurrenceId",
                    request.OccurrenceDto.OccurrenceId.ToString()));
                errors.AddRange(GenericValidationAttribute<OccurrenceDto>.ValidateAttributes("OccurrenceLink",
                    request.OccurrenceDto.OccurrenceLink));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete occurrence.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateOccurrenceId(OccurrenceRequest request)
        {
            var errors = new List<string>();
            if (request?.OccurrenceDto == null)
            {
                errors.Add(OccurrenceMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<OccurrenceDto>.ValidateAttributes("OccurrenceId",
                    request.OccurrenceDto.OccurrenceId.ToString()));
            }
            return errors;
        }
        #endregion

        #region public methods occurrence translation

        /// <summary>
        /// Create new OccurrenceTranslation
        /// </summary>
        /// <returns>OccurrenceTranslation message.</returns>
        [Route("CreateOccurrenceTranslation")]
        public IHttpActionResult CreateOccurrenceTranslation(OccurrenceTranslationRequest request)
        {
            List<string> errors = ValidateCreateOccurrenceTranslation(request);
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = OccurrenceMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceOccurrenceTranslationClient.CreateOccurrenceTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new OccurrenceTranslation
        /// </summary>
        /// <returns>OccurrenceTranslation message.</returns>
        [Route("CreateOccurrenceTranslationRange")]
        public IHttpActionResult CreateOccurrenceTranslationRange(OccurrenceTranslationRequest request)
        {
            List<string> errors = ValidateCreateOccurrenceTranslationRange(request);
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = OccurrenceMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceOccurrenceTranslationClient.CreateOccurrenceTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change OccurrenceTranslation informations.
        /// </summary>
        /// <returns>OccurrenceTranslation message.</returns>
        [Route("UpdateOccurrenceTranslation")]
        public IHttpActionResult UpdateOccurrenceTranslation(OccurrenceTranslationRequest request)
        {
            List<string> errors = ValidateUpdateOccurrenceTranslation(request);
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = OccurrenceMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceOccurrenceTranslationClient.UpdateOccurrenceTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change OccurrenceTranslation informations.
        /// </summary>
        /// <returns>OccurrenceTranslation message.</returns>
        [Route("UpdateOccurrenceTranslationRange")]
        public IHttpActionResult UpdateOccurrenceTranslationRange(OccurrenceTranslationRequest request)
        {
            List<string> errors = ValidateUpdateOccurrenceTranslationRange(request);
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = OccurrenceMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceOccurrenceTranslationClient.UpdateOccurrenceTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete OccurrenceTranslation
        /// </summary>
        /// <returns>OccurrenceTranslation message.</returns>
        [Route("RemoveOccurrenceTranslation")]
        public IHttpActionResult DeleteOccurrenceTranslation(int translationId)
        {
            OccurrenceTranslationRequest request = new OccurrenceTranslationRequest
            {
                OccurrenceTranslationDto = new OccurrenceTranslationDto
                {
                    TranslationId = translationId
                }
            };

            List<string> errors = ValidateDeleteOccurrenceTranslation(request);
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = OccurrenceMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceOccurrenceTranslationClient.DeleteOccurrenceTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of OccurrenceTranslations
        /// </summary>
        /// <returns>OccurrenceTranslation message.</returns>
        [Route("GetOccurrenceTranslations")]
        public IHttpActionResult GetAllOccurrenceTranslations()
        {
            OccurrenceTranslationMessage message = _serviceOccurrenceTranslationClient.GetAllOccurrenceTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find OccurrenceTranslations.
        /// </summary>
        /// <returns>OccurrenceTranslation message.</returns>
        [Route("FindOccurrenceTranslations")]
        public IHttpActionResult FindOccurrenceTranslations(OccurrenceTranslationRequest request)
        {
            List<string> errors = ValidateFindOccurrenceTranslations(request);
            OccurrenceTranslationMessage message = new OccurrenceTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = OccurrenceMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceOccurrenceTranslationClient.FindOccurrenceTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region private translate occurrence methods
        /// <summary>
        /// Validate create occurrence translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateOccurrenceTranslation(OccurrenceTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.OccurrenceTranslationDto == null)
            {
                errors.Add(OccurrenceMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes(
                    "OccurrenceDescription", request.OccurrenceTranslationDto.OccurrenceDescription));
                errors.AddRange(GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("OccurrenceId",
                    request.OccurrenceTranslationDto.OccurrenceId.ToString()));
                errors.AddRange(GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("LanguageId",
                    request.OccurrenceTranslationDto.LanguageId.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("OccurrenceTitle",
                        request.OccurrenceTranslationDto.OccurrenceTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate create occurrence translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateOccurrenceTranslationRange(OccurrenceTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.OccurrenceTranslationDtoList == null)
            {
                errors.Add(OccurrenceMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.OccurrenceTranslationDtoList)
                {
                    errors.AddRange(
                        GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("OccurrenceDescription",
                            translation.OccurrenceDescription));
                    errors.AddRange(
                        GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("LanguageId",
                            translation.LanguageId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("OccurrenceId",
                            translation.OccurrenceId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("OccurrenceTitle",
                            translation.OccurrenceTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update occurrence translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateOccurrenceTranslation(OccurrenceTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.OccurrenceTranslationDto == null)
            {
                errors.Add(OccurrenceMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes(
                    "OccurrenceDescription", request.OccurrenceTranslationDto.OccurrenceDescription));
                errors.AddRange(GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("TranslationId",
                    request.OccurrenceTranslationDto.TranslationId.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("OccurrenceTitle",
                        request.OccurrenceTranslationDto.OccurrenceTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate update occurrence translation list.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateOccurrenceTranslationRange(OccurrenceTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.OccurrenceTranslationDtoList == null)
            {
                errors.Add(OccurrenceMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.OccurrenceTranslationDtoList)
                {
                    errors.AddRange(
                        GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("OccurrenceDescription",
                            translation.OccurrenceDescription));
                    errors.AddRange(
                        GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("TranslationId",
                            translation.TranslationId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("OccurrenceTitle",
                            translation.OccurrenceTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate find occurrence translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindOccurrenceTranslations(OccurrenceTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.OccurrenceTranslationDto == null)
            {
                errors.Add(OccurrenceMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindOccurrenceTranslationDto)
                {
                    case FindOccurrenceTranslationDto.OccurrenceId:
                        errors.AddRange(GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes(
                            "OccurrenceId", request.OccurrenceTranslationDto.OccurrenceId.ToString()));
                        break;
                    case FindOccurrenceTranslationDto.OccurrenceTranslationId:
                        errors.AddRange(GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes(
                            "TranslationId", request.OccurrenceTranslationDto.TranslationId.ToString()));
                        break;
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate find occurrence translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteOccurrenceTranslation(OccurrenceTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.OccurrenceTranslationDto == null)
            {
                errors.Add(OccurrenceMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<OccurrenceTranslationDto>.ValidateAttributes("TranslationId",
                    request.OccurrenceTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }
        #endregion
    }
}