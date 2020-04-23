using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.About.Interface;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Ressource;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Riafco.WebApi.Dataflex.pro.Controllers.About
{
    /// <summary>
    /// The Step web api controller.
    /// </summary>
    [RoutePrefix("api/Steps")]
    public class StepController : ApiController
    {
        #region PRIVATE ATTRIBUTES.
        /// <summary>
        /// The Step service client instance.
        /// </summary>
        private readonly IServiceStepClient _serviceStepClient;

        /// <summary>
        /// The StepParagraph service client instance.
        /// </summary>
        private readonly IServiceStepParagraphClient _serviceStepParagraphClient;

        /// <summary>
        /// The StepParagraphTranslation service client instance.
        /// </summary>
        private readonly IServiceStepParagraphTranslationClient _serviceStepParagraphTranslationClient;

        #endregion

        #region CONSTRUCTOR.
        /// <summary>
        /// Set the IServiceStepClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceStepClient">injected instance</param>
        /// <param name="serviceStepParagraphClient"></param>
        /// <param name="serviceStepParagraphTranslationClient"></param>
        public StepController(IServiceStepClient injectedServiceStepClient,
            IServiceStepParagraphClient serviceStepParagraphClient,
            IServiceStepParagraphTranslationClient serviceStepParagraphTranslationClient)
        {
            _serviceStepClient = injectedServiceStepClient;
            _serviceStepParagraphClient = serviceStepParagraphClient;
            _serviceStepParagraphTranslationClient = serviceStepParagraphTranslationClient;
        }
        #endregion

        #region STEPS METHODS.

        /// <summary>
        /// Create new Step
        /// </summary>
        /// <returns>Step message.</returns>
        [Route("CreateStep")]
        public IHttpActionResult CreateStep(StepRequest request)
        {
            StepMessage message = new StepMessage();
            List<string> errors = ValidateCreateStep(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepClient.CreateStep(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change Step informations.
        /// </summary>
        /// <returns>Step message.</returns>
        [Route("UpdateStep")]
        public IHttpActionResult UpdateStep(StepRequest request)
        {
            StepMessage message = new StepMessage();
            List<string> errors = ValidateUpdateStep(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepClient.UpdateStep(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Step
        /// </summary>
        /// <returns>Step message.</returns>
        [Route("RemoveStep")]
        public IHttpActionResult DeleteStep(int stepId)
        {
            StepRequest request = new StepRequest { StepDto = new StepDto { StepId = stepId } };
            List<string> errors = ValidateDeleteStep(request);
            StepMessage message = new StepMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepClient.DeleteStep(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Step
        /// </summary>
        /// <returns>Step message.</returns>
        [Route("GetSteps")]
        public IHttpActionResult GetAllSteps()
        {
            StepMessage message = _serviceStepClient.GetAllSteps();
            return Json(message);
        }

        /// <summary>
        /// Find Steps.
        /// </summary>
        /// <returns>Step message.</returns>
        [Route("FindSteps")]
        public IHttpActionResult FindSteps(StepRequest request)
        {
            StepMessage message = new StepMessage();
            List<string> errors = ValidateFindSteps(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepClient.FindSteps(request);
            }
            return Json(message);
        }

        #endregion

        #region STEP PARAGPAH.

        /// <summary>
        /// Create new StepParagraph
        /// </summary>
        /// <returns>StepParagraph message.</returns>
        [Route("CreateStepParagraph")]
        public IHttpActionResult CreateStepParagraph(StepParagraphRequest request)
        {
            StepParagraphMessage message = new StepParagraphMessage();
            List<string> errors = ValidateCreateStepParagraph(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepParagraphClient.CreateStepParagraph(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change StepParagraph informations.
        /// </summary>
        /// <returns>StepParagraph message.</returns>
        [Route("UpdateStepParagraph")]
        public IHttpActionResult UpdateStepParagraph(StepParagraphRequest request)
        {
            StepParagraphMessage message = new StepParagraphMessage();
            List<string> errors = ValidateUpdateStepParagraph(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepParagraphClient.UpdateStepParagraph(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete StepParagraph
        /// </summary>
        /// <returns>StepParagraph message.</returns>
        [Route("RemoveStepParagraph")]
        public IHttpActionResult DeleteStepParagraph(int paragraphId)
        {
            StepParagraphRequest request = new StepParagraphRequest
            {
                StepParagraphDto = new StepParagraphDto { ParagraphId = paragraphId },
                FindStepParagraphDto = FindStepParagraphDto.StepParagraphId
            };

            StepParagraphMessage message = new StepParagraphMessage();
            List<string> errors = ValidateDeleteStepParagraph(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepParagraphClient.DeleteStepParagraph(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of StepParagraph
        /// </summary>
        /// <returns>StepParagraph message.</returns>
        [Route("GetStepParagraphs")]
        public IHttpActionResult GetAllStepParagraphs()
        {
            StepParagraphMessage message = _serviceStepParagraphClient.GetAllStepParagraphs();
            return Json(message);
        }

        /// <summary>
        /// Find StepParagraph
        /// </summary>
        /// <returns>StepParagraph message.</returns>
        [Route("FindStepParagraphs")]
        public IHttpActionResult FindStepParagraphs(StepParagraphRequest request)
        {
            StepParagraphMessage message = new StepParagraphMessage();
            List<string> errors = ValidateFindStepParagraph(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepParagraphClient.FindStepParagraphs(request);
            }
            return Json(message);
        }

        #endregion

        #region STEP PHARAGRAPH TRANSLATION.

        /// <summary>
        /// Create new StepParagraphTranslation
        /// </summary>
        /// <returns>StepParagraphTranslation message.</returns>
        [Route("CreateStepParagraphTranslation")]
        public IHttpActionResult CreateStepParagraphTranslation(StepParagraphTranslationRequest request)
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            List<string> errors = ValidateCreateStepParagraphTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepParagraphTranslationClient.CreateStepParagraphTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new StepParagraphTranslation
        /// </summary>
        /// <returns>StepParagraphTranslation message.</returns>
        [Route("CreateStepParagraphTranslationRange")]
        public IHttpActionResult CreateStepParagraphTranslationRange(StepParagraphTranslationRequest request)
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            List<string> errors = ValidateCreateStepParagraphTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepParagraphTranslationClient.CreateStepParagraphTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change StepParagraphTranslation informations.
        /// </summary>
        /// <returns>StepParagraphTranslation message.</returns>
        [Route("UpdateStepParagraphTranslation")]
        public IHttpActionResult UpdateStepParagraphTranslation(StepParagraphTranslationRequest request)
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            List<string> errors = ValidateUpdateStepParagraphTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepParagraphTranslationClient.UpdateStepParagraphTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change StepParagraphTranslation informations.
        /// </summary>
        /// <returns>StepParagraphTranslation message.</returns>
        [Route("UpdateStepParagraphTranslationRange")]
        public IHttpActionResult UpdateStepParagraphTranslationRange(StepParagraphTranslationRequest request)
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            List<string> errors = ValidateUpdateStepParagraphTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepParagraphTranslationClient.UpdateStepParagraphTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete StepParagraphTranslation
        /// </summary>
        /// <returns>StepParagraphTranslation message.</returns>
        [Route("RemoveStepParagraphTranslation")]
        public IHttpActionResult DeleteStepParagraphTranslation(StepParagraphTranslationRequest request)
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            List<string> errors = ValidateDeleteStepParagraphTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepParagraphTranslationClient.DeleteStepParagraphTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of StepParagraphTranslation.
        /// </summary>
        /// <returns>StepParagraphTranslation message.</returns>
        [Route("GetStepParagraphTranslations")]
        public IHttpActionResult GetAllStepParagraphTranslations()
        {
            StepParagraphTranslationMessage message =
                _serviceStepParagraphTranslationClient.GetAllStepParagraphTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find StepParagraphTranslations.
        /// </summary>
        /// <returns>StepParagraphTranslation message.</returns>
        [Route("FindStepParagraphTranslations")]
        public IHttpActionResult FindStepParagraphTranslations(StepParagraphTranslationRequest request)
        {
            StepParagraphTranslationMessage message = new StepParagraphTranslationMessage();
            List<string> errors = ValidateFindStepParagraphTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = StepMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceStepParagraphTranslationClient.FindStepParagraphTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region PRIVATE STEP VALIDATION METHODS.
        /// <summary>
        /// Validation creation Step.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateStep(StepRequest request)
        {
            var errors = new List<string>();
            if (request?.StepDto == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            return errors;
        }

        /// <summary>
        /// Validation update step.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateStep(StepRequest request)
        {
            var errors = new List<string>();
            if (request?.StepDto == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<StepDto>.ValidateAttributes("StepId", request.StepDto.StepId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete Step.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteStep(StepRequest request)
        {
            var errors = new List<string>();
            if (request?.StepDto == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<StepDto>.ValidateAttributes("StepId", request.StepDto.StepId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete Step.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindSteps(StepRequest request)
        {
            var errors = new List<string>();
            if (request?.StepDto == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<StepDto>.ValidateAttributes("StepId", request.StepDto.StepId.ToString()));
            }
            return errors;
        }
        #endregion

        #region PRIVATE STEP PARAGRAPH VALIDATION METHODS.

        /// <summary>
        /// Validate create section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateStepParagraph(StepParagraphRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.StepParagraphDto == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<StepParagraphDto>.ValidateAttributes("StepId", request.StepParagraphDto.StepId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update step translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateStepParagraph(StepParagraphRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.StepParagraphDto == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<StepParagraphDto>.ValidateAttributes("ParagraphId", request.StepParagraphDto.ParagraphId.ToString()));
                errors.AddRange(GenericValidationAttribute<StepParagraphDto>.ValidateAttributes("StepId", request.StepParagraphDto.StepId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete step translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteStepParagraph(StepParagraphRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.StepParagraphDto == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<StepParagraphDto>.ValidateAttributes("ParagraphId", request.StepParagraphDto.ParagraphId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find paragraph translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindStepParagraph(StepParagraphRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.StepParagraphDto == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindStepParagraphDto)
                {
                    case FindStepParagraphDto.StepId:
                        errors.AddRange(GenericValidationAttribute<StepParagraphDto>.ValidateAttributes("StepId", request.StepParagraphDto.StepId.ToString()));
                        break;
                    case FindStepParagraphDto.StepParagraphId:
                        errors.AddRange(GenericValidationAttribute<StepParagraphDto>.ValidateAttributes("ParagraphId", request.StepParagraphDto.ParagraphId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion

        #region PRIVATE STEP TRANSLATION PARAGRAPH VALIDATION METHODS.

        /// <summary>
        /// Validate create section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateStepParagraphTranslation(StepParagraphTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.StepParagraphTranslationDto == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphDescription", request.StepParagraphTranslationDto.ParagraphDescription));
                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphId", request.StepParagraphTranslationDto.ParagraphId.ToString()));
                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("LanguageId", request.StepParagraphTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphTitle", request.StepParagraphTranslationDto.ParagraphTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate create section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateStepParagraphTranslationRange(StepParagraphTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.StepParagraphTranslationDtoList == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.StepParagraphTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphDescription", translation.ParagraphDescription));
                    errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphId", translation.ParagraphId.ToString()));
                    errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphTitle", translation.ParagraphTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate create section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateStepParagraphTranslation(StepParagraphTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.StepParagraphTranslationDto == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphDescription", request.StepParagraphTranslationDto.ParagraphDescription));
                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("TranslationId", request.StepParagraphTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphId", request.StepParagraphTranslationDto.ParagraphId.ToString()));
                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("LanguageId", request.StepParagraphTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphTitle", request.StepParagraphTranslationDto.ParagraphTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate create section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateStepParagraphTranslationRange(StepParagraphTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.StepParagraphTranslationDtoList == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.StepParagraphTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphDescription", translation.ParagraphDescription));
                    errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("TranslationId", translation.TranslationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphId", translation.ParagraphId.ToString()));
                    errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphTitle", translation.ParagraphTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate find section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindStepParagraphTranslation(StepParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.StepParagraphTranslationDto == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindStepParagraphTranslationDto)
                {
                    case FindStepParagraphTranslationDto.StepParagraphId:
                        errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("ParagraphId", request.StepParagraphTranslationDto.ParagraphId.ToString()));
                        break;
                    case FindStepParagraphTranslationDto.StepParagraphTranslationId:
                        errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("TranslationId", request.StepParagraphTranslationDto.TranslationId.ToString()));
                        break;
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate find section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteStepParagraphTranslation(StepParagraphTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.StepParagraphTranslationDto == null)
            {
                errors.Add(StepMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationDto>.ValidateAttributes("TranslationId", request.StepParagraphTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }
        #endregion
    }
}