using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Message;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Request;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Ressource;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto.Enum;

namespace Riafco.WebApi.Dataflex.pro.Controllers.Activites
{
    /// <summary>
    /// The Activity web api controller.
    /// </summary>
    [RoutePrefix("api/Activities")]
    public class ActivityController : ApiController
    {
        #region private attributes
        /// <summary>
        /// The Activity service client instance.
        /// </summary>
        private readonly IServiceActivityClient _serviceActivityClient;

        /// <summary>
        /// The ActivityTranslation service client instance.
        /// </summary>
        private readonly IServiceActivityTranslationClient _serviceActivityTranslationClient;

        /// <summary>
        /// The ActivityParagraph service client instance.
        /// </summary>
        private readonly IServiceActivityParagraphClient _serviceActivityParagraphClient;

        /// <summary>
        /// The ActivityParagraphTraslation service client instance.
        /// </summary>
        private readonly IServiceActivityParagraphTranslationClient _serviceActivityParagraphTraslationClient;

        /// <summary>
        /// The ActivityFile service client instance.
        /// </summary>
        private readonly IServiceActivityFileClient _serviceActivityFileClient;

        /// <summary>
        /// The ActivityFileTranslation service client instance.
        /// </summary>
        private readonly IServiceActivityFileTranslationClient _serviceActivityFileTranslationClient;

        #endregion

        #region constructor

        /// <summary>
        /// Set the IServiceActivityClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceActivityClient">injected instance</param>
        /// <param name="injectedServiceActivityTranslationClient">injected instance</param>
        /// <param name="injectedServiceActivityParagraphClient">injected instance</param>
        /// <param name="injectedServiceActivityParagraphTraslationClient">injected instance</param>
        /// <param name="injectedServiceActivityFileClient">injected instance</param>
        /// <param name="injectedServiceActivityFileTranslationClient">injected instance</param>
        public ActivityController(IServiceActivityClient injectedServiceActivityClient,
            IServiceActivityTranslationClient injectedServiceActivityTranslationClient,
            IServiceActivityParagraphClient injectedServiceActivityParagraphClient,
            IServiceActivityParagraphTranslationClient injectedServiceActivityParagraphTraslationClient,
            IServiceActivityFileClient injectedServiceActivityFileClient,
            IServiceActivityFileTranslationClient injectedServiceActivityFileTranslationClient)
        {
            //ACTIVITY
            _serviceActivityTranslationClient = injectedServiceActivityTranslationClient;
            _serviceActivityClient = injectedServiceActivityClient;

            //PARAGRAPH
            _serviceActivityParagraphClient = injectedServiceActivityParagraphClient;
            _serviceActivityParagraphTraslationClient = injectedServiceActivityParagraphTraslationClient;

            //FILES :
            _serviceActivityFileClient = injectedServiceActivityFileClient;
            _serviceActivityFileTranslationClient = injectedServiceActivityFileTranslationClient;
        }

        #endregion

        #region public methods activity

        /// <summary>
        /// Create new Activity
        /// </summary>
        /// <returns>Activity message.</returns>
        [Route("CreateActivity")]
        public IHttpActionResult CreateActivity(ActivityRequest request)
        {
            List<string> errors = ValidateCreateActivity(request);
            ActivityMessage message = new ActivityMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityClient.CreateActivity(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change Activity informations.
        /// </summary>
        /// <returns>Activity message.</returns>
        [Route("UpdateActivity")]
        public IHttpActionResult UpdateActivity(ActivityRequest request)
        {
            List<string> errors = ValidateUpdateActivity(request);
            ActivityMessage message = new ActivityMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityClient.UpdateActivity(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Activity
        /// </summary>
        /// <returns>Activity message.</returns>
        [Route("RemoveActivity")]
        public IHttpActionResult DeleteActivity(int activityId)
        {
            ActivityRequest request = new ActivityRequest
            {
                ActivityDto = new ActivityDto { ActivityId = activityId }
            };
            List<string> errors = ValidateDeleteActivity(request);
            ActivityMessage message = new ActivityMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityClient.DeleteActivity(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Activity
        /// </summary>
        /// <returns>Activity message.</returns>
        [Route("GetActivities")]
        public IHttpActionResult GetAllActivities()
        {
            ActivityMessage message = _serviceActivityClient.GetAllActivities();
            return Json(message);
        }

        /// <summary>
        /// Find Activity
        /// </summary>
        /// <returns>Activity message.</returns>
        [Route("FindActivities")]
        public IHttpActionResult FindActivities(ActivityRequest request)
        {
            List<string> errors = ValidateFindActivities(request);
            ActivityMessage message = new ActivityMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityClient.FindActivities(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation activity methods
        /// <summary>
        /// Validation creation activity.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateActivity(ActivityRequest request)
        {
            var errors = new List<string>();
            if (request?.ActivityDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityDto>.ValidateAttributes("ActivityIcon", request.ActivityDto.ActivityIcon.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityDto>.ValidateAttributes("ActivityImage", request.ActivityDto.ActivityImage.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validation update activity.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateActivity(ActivityRequest request)
        {
            var errors = new List<string>();
            if (request?.ActivityDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityDto>.ValidateAttributes("ActivityId", request.ActivityDto.ActivityId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete activity.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteActivity(ActivityRequest request)
        {
            var errors = new List<string>();
            if (request?.ActivityDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityDto>.ValidateAttributes("ActivityId", request.ActivityDto.ActivityId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete activity.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindActivities(ActivityRequest request)
        {
            var errors = new List<string>();
            if (request?.ActivityDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityDto>.ValidateAttributes("ActivityId", request.ActivityDto.ActivityId.ToString()));
            }
            return errors;
        }
        #endregion

        #region public methods activity translation

        /// <summary>
        /// Create new ActivityTranslation
        /// </summary>
        /// <returns>ActivityTranslation message.</returns>
        [Route("CreateActivityTranslation")]
        public IHttpActionResult CreateActivityTranslation(ActivityTranslationRequest request)
        {
            List<string> errors = ValidateCreateActivityTranslation(request);
            ActivityTranslationMessage message = new ActivityTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityTranslationClient.CreateActivityTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new ActivityTranslation
        /// </summary>
        /// <returns>ActivityTranslation message.</returns>
        [Route("CreateActivityTranslationRange")]
        public IHttpActionResult CreateActivityTranslationRange(ActivityTranslationRequest request)
        {
            List<string> errors = ValidateCreateActivityTranslationRange(request);
            ActivityTranslationMessage message = new ActivityTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityTranslationClient.CreateActivityTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change ActivityTranslation informations.
        /// </summary>
        /// <returns>ActivityTranslation message.</returns>
        [Route("UpdateActivityTranslation")]
        public IHttpActionResult UpdateActivityTranslation(ActivityTranslationRequest request)
        {
            List<string> errors = ValidateUpdateActivityTranslation(request);
            ActivityTranslationMessage message = new ActivityTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityTranslationClient.UpdateActivityTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change ActivityTranslation informations.
        /// </summary>
        /// <returns>ActivityTranslation message.</returns>
        [Route("UpdateActivityTranslationRange")]
        public IHttpActionResult UpdateActivityTranslationRange(ActivityTranslationRequest request)
        {
            List<string> errors = ValidateUpdateActivityTranslationRange(request);
            ActivityTranslationMessage message = new ActivityTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityTranslationClient.UpdateActivityTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete ActivityTranslation
        /// </summary>
        /// <returns>ActivityTranslation message.</returns>
        [Route("RemoveActivityTranslation")]
        public IHttpActionResult DeleteActivityTranslation(int translationId)
        {
            ActivityTranslationRequest request = new ActivityTranslationRequest
            {
                ActivityTranslationDto = new ActivityTranslationDto {TranslationId = translationId}
            };

            List<string> errors = ValidateDeleteActivityTranslation(request);
            ActivityTranslationMessage message = new ActivityTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityTranslationClient.DeleteActivityTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of ActivityTranslation
        /// </summary>
        /// <returns>ActivityTranslation message.</returns>
        [Route("GetActivityTranslations")]
        public IHttpActionResult GetAllActivityTranslations()
        {
            ActivityTranslationMessage message = _serviceActivityTranslationClient.GetAllActivityTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find ActivityTranslation
        /// </summary>
        /// <returns>ActivityTranslation message.</returns>
        [Route("FindActivityTranslations")]
        public IHttpActionResult FindActivityTranslations(ActivityTranslationRequest request)
        {
            List<string> errors = ValidateFindActivityTranslations(request);
            ActivityTranslationMessage message = new ActivityTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityTranslationClient.FindActivityTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region private translate activity methods
        /// <summary>
        /// Validate create activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateActivityTranslation(ActivityTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.ActivityTranslationDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityIntroduction", request.ActivityTranslationDto.ActivityIntroduction));
                errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityDescription", request.ActivityTranslationDto.ActivityDescription));
                errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityId", request.ActivityTranslationDto.ActivityId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("LanguageId", request.ActivityTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityTitle", request.ActivityTranslationDto.ActivityTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate create activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateActivityTranslationRange(ActivityTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.ActivityTranslationDtoList == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.ActivityTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityIntroduction", translation.ActivityIntroduction));
                    errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityDescription", translation.ActivityDescription));
                    errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityId", translation.ActivityId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityTitle", translation.ActivityTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateActivityTranslation(ActivityTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.ActivityTranslationDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityIntroduction", request.ActivityTranslationDto.ActivityIntroduction));
                errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityDescription", request.ActivityTranslationDto.ActivityDescription));
                errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("TranslationId", request.ActivityTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityTitle", request.ActivityTranslationDto.ActivityTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate update activity translation list.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateActivityTranslationRange(ActivityTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.ActivityTranslationDtoList == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.ActivityTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityIntroduction", translation.ActivityIntroduction));
                    errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityDescription", translation.ActivityDescription));
                    errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("TranslationId", translation.TranslationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityTitle", translation.ActivityTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate find activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindActivityTranslations(ActivityTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.ActivityTranslationDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindActivityTranslationDto)
                {
                    case FindActivityTranslationDto.ActivityId:
                        errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityId", request.ActivityTranslationDto.ActivityId.ToString()));
                        break;
                    case FindActivityTranslationDto.ActivityTranslationId:
                        errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("TranslationId", request.ActivityTranslationDto.TranslationId.ToString()));
                        break;
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate find activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteActivityTranslation(ActivityTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.ActivityTranslationDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("TranslationId", request.ActivityTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }
        #endregion

        #region public methods activity paragraph

        /// <summary>
        /// Create new ActivityParagraph
        /// </summary>
        /// <returns>ActivityParagraph message.</returns>
        [Route("CreateActivityParagraph")]
        public IHttpActionResult CreateActivityParagraph(ActivityParagraphRequest request)
        {
            ActivityParagraphMessage message = new ActivityParagraphMessage();
            List<string> errors = ValidateCreateActivityParagraph(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityParagraphClient.CreateActivityParagraph(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change ActivityParagraph informations.
        /// </summary>
        /// <returns>ActivityParagraph message.</returns>
        [Route("UpdateActivityParagraph")]
        public IHttpActionResult UpdateActivityParagraph(ActivityParagraphRequest request)
        {
            ActivityParagraphMessage message = new ActivityParagraphMessage();
            List<string> errors = ValidateUpdateActivityParagraph(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityParagraphClient.UpdateActivityParagraph(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete ActivityParagraph
        /// </summary>
        /// <returns>ActivityParagraph message.</returns>
        [Route("RemoveActivityParagraph")]
        public IHttpActionResult DeleteActivityParagraph(int paragraphId)
        {
            ActivityParagraphRequest request = new ActivityParagraphRequest
            {
                ActivityParagraphDto = new ActivityParagraphDto { ParagraphId = paragraphId },
                FindActivityParagraphDto = FindActivityParagraphDto.ActivityParagraphId
            };

            ActivityParagraphMessage message = new ActivityParagraphMessage();
            List<string> errors = ValidateDeleteActivityParagraph(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityParagraphClient.DeleteActivityParagraph(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of ActivityParagraph
        /// </summary>
        /// <returns>ActivityParagraph message.</returns>
        [Route("GetActivityParagraphs")]
        public IHttpActionResult GetAllActivityParagraphs()
        {
            ActivityParagraphMessage message = _serviceActivityParagraphClient.GetAllActivityParagraphs();
            return Json(message);
        }

        /// <summary>
        /// Find ActivityParagraph
        /// </summary>
        /// <returns>ActivityParagraph message.</returns>
        [Route("FindActivityParagraphs")]
        public IHttpActionResult FindActivityParagraphs(ActivityParagraphRequest request)
        {
            ActivityParagraphMessage message = new ActivityParagraphMessage();
            List<string> errors = ValidateFindActivityParagraph(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityParagraphClient.FindActivityParagraphs(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation methods paragraph

        /// <summary>
        /// Validate create activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateActivityParagraph(ActivityParagraphRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityParagraphDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityParagraphDto>.ValidateAttributes("ParagraphImage", request.ActivityParagraphDto.ParagraphImage.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityParagraphDto>.ValidateAttributes("ActivityId", request.ActivityParagraphDto.ActivityId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateActivityParagraph(ActivityParagraphRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityParagraphDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityParagraphDto>.ValidateAttributes("ParagraphId", request.ActivityParagraphDto.ParagraphId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityParagraphDto>.ValidateAttributes("ActivityId", request.ActivityParagraphDto.ActivityId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteActivityParagraph(ActivityParagraphRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityParagraphDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityParagraphDto>.ValidateAttributes("ParagraphId", request.ActivityParagraphDto.ParagraphId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindActivityParagraph(ActivityParagraphRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityParagraphDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindActivityParagraphDto)
                {
                    case FindActivityParagraphDto.ActivityId:
                        errors.AddRange(GenericValidationAttribute<ActivityTranslationDto>.ValidateAttributes("ActivityId", request.ActivityParagraphDto.ActivityId.ToString()));
                        break;
                    case FindActivityParagraphDto.ActivityParagraphId:
                        errors.AddRange(GenericValidationAttribute<ActivityParagraphDto>.ValidateAttributes("ParagraphId", request.ActivityParagraphDto.ParagraphId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion

        #region publics methods translation paragraph 
        /// <summary>
        /// Create new ActivityParagraphTraslation
        /// </summary>
        /// <returns>ActivityParagraphTraslation message.</returns>
        [Route("CreateActivityParagraphTranslation")]
        public IHttpActionResult CreateActivityParagraphTranslation(ActivityParagraphTranslationRequest request)
        {
            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            List<string> errors = ValidateCreateActivityParagraphTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityParagraphTraslationClient.CreateActivityParagraphTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new ActivityParagraphTraslation range
        /// </summary>
        /// <returns>ActivityParagraphTraslation message.</returns>
        [Route("CreateActivityParagraphTranslationRange")]
        public IHttpActionResult CreateActivityParagraphTranslationRange(ActivityParagraphTranslationRequest request)
        {
            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            List<string> errors = ValidateCreateActivityParagraphTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityParagraphTraslationClient.CreateActivityParagraphTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change ActivityParagraphTraslation informations.
        /// </summary>
        /// <returns>ActivityParagraphTraslation message.</returns>
        [Route("UpdateActivityParagraphTranslation")]
        public IHttpActionResult UpdateActivityParagraphTranslation(ActivityParagraphTranslationRequest request)
        {
            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            List<string> errors = ValidateUpdateActivityParagraphTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityParagraphTraslationClient.UpdateActivityParagraphTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change ActivityParagraphTraslation informations.
        /// </summary>
        /// <returns>ActivityParagraphTraslation message.</returns>
        [Route("UpdateActivityParagraphTranslationRange")]
        public IHttpActionResult UpdateActivityParagraphTranslationRange(ActivityParagraphTranslationRequest request)
        {
            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            List<string> errors = ValidateUpdateActivityParagraphTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityParagraphTraslationClient.UpdateActivityParagraphTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete ActivityParagraphTraslation
        /// </summary>
        /// <returns>ActivityParagraphTraslation message.</returns>
        [Route("DeleteActivityParagraphTranslation")]
        public IHttpActionResult DeleteActivityParagraphTranslation(int translationId)
        {
            ActivityParagraphTranslationRequest request = new ActivityParagraphTranslationRequest
            {
                ActivityParagraphTranslationDto = new ActivityParagraphTranslationDto { TranslationId = translationId },
                FindActivityParagraphTranslationDto = FindActivityParagraphTranslationDto.ActivityParagraphTranslationId
            };

            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            List<string> errors = ValidateDeleteActivityParagraphTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityParagraphTraslationClient.DeleteActivityParagraphTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of ActivityParagraphTraslation
        /// </summary>
        /// <returns>ActivityParagraphTraslation message.</returns>
        [Route("GetActivityParagraphTranslations")]
        public IHttpActionResult GetAllActivityParagraphTranslations()
        {
            ActivityParagraphTranslationMessage message = _serviceActivityParagraphTraslationClient.GetAllActivityParagraphTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find ActivityParagraphTraslation
        /// </summary>
        /// <returns>ActivityParagraphTraslation message.</returns>
        [Route("FindActivityParagraphTranslations")]
        public IHttpActionResult FindActivityParagraphTranslations(ActivityParagraphTranslationRequest request)
        {
            ActivityParagraphTranslationMessage message = new ActivityParagraphTranslationMessage();
            List<string> errors = ValidateFindActivityParagraphTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityParagraphTraslationClient.FindActivityParagraphTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region validate private methods translation paragraph
        /// <summary>
        /// Validate Create Activity Paragraph Traslation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateActivityParagraphTranslation(ActivityParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityParagraphTranslationDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphDescription", request.ActivityParagraphTranslationDto.ParagraphDescription));
                errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphId", request.ActivityParagraphTranslationDto.ParagraphId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("LanguageId", request.ActivityParagraphTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphTitle", request.ActivityParagraphTranslationDto.ParagraphTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate Create Activity Paragraph Traslation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateActivityParagraphTranslationRange(ActivityParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityParagraphTranslationDtoList == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.ActivityParagraphTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphDescription", translation.ParagraphDescription));
                    errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphId", translation.ParagraphId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphTitle", translation.ParagraphTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update Activity Paragraph Translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateActivityParagraphTranslation(ActivityParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityParagraphTranslationDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphDescription", request.ActivityParagraphTranslationDto.ParagraphDescription));
                errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("TranslationId", request.ActivityParagraphTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphId", request.ActivityParagraphTranslationDto.ParagraphId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("LanguageId", request.ActivityParagraphTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphTitle", request.ActivityParagraphTranslationDto.ParagraphTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate update Activity Paragraph Translation Range.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateActivityParagraphTranslationRange(ActivityParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityParagraphTranslationDtoList == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.ActivityParagraphTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphDescription", translation.ParagraphDescription));
                    errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("TranslationId", translation.TranslationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphId", translation.ParagraphId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphTitle", translation.ParagraphTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate delete Activity Paragraph Translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteActivityParagraphTranslation(ActivityParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityParagraphTranslationDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("TranslationId", request.ActivityParagraphTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate Find Activity Paragraph Translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindActivityParagraphTranslation(ActivityParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityParagraphTranslationDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindActivityParagraphTranslationDto)
                {
                    case FindActivityParagraphTranslationDto.ActivityParagraphTranslationId:
                        errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("TranslationId", request.ActivityParagraphTranslationDto.TranslationId.ToString()));
                        break;
                    case FindActivityParagraphTranslationDto.ActivityParagraphId:
                        errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationDto>.ValidateAttributes("ParagraphId", request.ActivityParagraphTranslationDto.ParagraphId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion

        #region publics methods file activity

        /// <summary>
        /// Create new ActivityFile.
        /// </summary>
        /// <returns>ActivityFile message.</returns>
        [Route("CreateActivityFile")]
        public IHttpActionResult CreateActivityFile(ActivityFileRequest request)
        {
            ActivityFileMessage message = new ActivityFileMessage();
            List<string> errors = ValidateCreateActivityFile(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityFileClient.CreateActivityFile(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change ActivityFile informations.
        /// </summary>
        /// <returns>ActivityFile message.</returns>
        [Route("UpdateActivityFile")]
        public IHttpActionResult UpdateActivityFile(ActivityFileRequest request)
        {
            ActivityFileMessage message = new ActivityFileMessage();
            List<string> errors = ValidateUpdateActivityFile(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityFileClient.UpdateActivityFile(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete ActivityFile.
        /// </summary>
        /// <returns>ActivityFile message.</returns>
        [Route("RemoveActivityFile")]
        public IHttpActionResult DeleteActivityFile(int fileId)
        {
            ActivityFileRequest request = new ActivityFileRequest { ActivityFileDto = new ActivityFileDto { ActivityFileId = fileId } };
            ActivityFileMessage message = new ActivityFileMessage();
            List<string> errors = ValidateDeleteActivityFile(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityFileClient.DeleteActivityFile(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of ActivityFile.
        /// </summary>
        /// <returns>ActivityFile message.</returns>
        [Route("GetActivityFiles")]
        public IHttpActionResult GetAllActivityFiles()
        {
            ActivityFileMessage message = _serviceActivityFileClient.GetAllActivityFiles();
            return Json(message);
        }

        /// <summary>
        /// Find ActivityFile.
        /// </summary>
        /// <returns>ActivityFile message.</returns>
        [Route("FindActivityFiles")]
        public IHttpActionResult FindActivityFiles(ActivityFileRequest request)
        {
            ActivityFileMessage message = new ActivityFileMessage();
            List<string> errors = ValidateFindActivityFile(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityFileClient.FindActivityFiles(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation methods file activity

        /// <summary>
        /// Validate create activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateActivityFile(ActivityFileRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityFileDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityFileDto>.ValidateAttributes("ActivityId", request.ActivityFileDto.ActivityId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateActivityFile(ActivityFileRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityFileDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityFileDto>.ValidateAttributes("ActivityFileId", request.ActivityFileDto.ActivityFileId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityFileDto>.ValidateAttributes("ActivityId", request.ActivityFileDto.ActivityId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteActivityFile(ActivityFileRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityFileDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityFileDto>.ValidateAttributes("ActivityFileId", request.ActivityFileDto.ActivityFileId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindActivityFile(ActivityFileRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityFileDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindActivityFileDto)
                {
                    case FindActivityFileDto.ActivityFileId:
                        errors.AddRange(GenericValidationAttribute<ActivityFileDto>.ValidateAttributes("ActivityFileId", request.ActivityFileDto.ActivityFileId.ToString()));
                        break;
                    case FindActivityFileDto.ActivityId:
                        errors.AddRange(GenericValidationAttribute<ActivityFileDto>.ValidateAttributes("ActivityId", request.ActivityFileDto.ActivityId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion

        #region public methods file activity translation

        /// <summary>
        /// Create new ActivityFileTranslation
        /// </summary>
        /// <returns>ActivityFileTranslation message.</returns>
        [Route("CreateActivityFileTranslation")]
        public IHttpActionResult CreateActivityFileTranslation(ActivityFileTranslationRequest request)
        {
            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            List<string> errors = ValidateCreateActivityFileTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityFileTranslationClient.CreateActivityFileTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new ActivityFileTranslation List
        /// </summary>
        /// <returns>ActivityFileTranslation message.</returns>
        [Route("CreateActivityFileTranslationRange")]
        public IHttpActionResult CreateActivityFileTranslationRange(ActivityFileTranslationRequest request)
        {
            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            List<string> errors = ValidateCreateActivityFileTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityFileTranslationClient.CreateActivityFileTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change ActivityFileTranslation informations.
        /// </summary>
        /// <returns>ActivityFileTranslation message.</returns>
        [Route("UpdateActivityFileTranslation")]
        public IHttpActionResult UpdateActivityFileTranslation(ActivityFileTranslationRequest request)
        {
            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            List<string> errors = ValidateUpdateActivityFileTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityFileTranslationClient.UpdateActivityFileTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change ActivityFileTranslation informations Range.
        /// </summary>
        /// <returns>ActivityFileTranslation message.</returns>
        [Route("UpdateActivityFileTranslationRange")]
        public IHttpActionResult UpdateActivityFileTranslationRange(ActivityFileTranslationRequest request)
        {
            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            List<string> errors = ValidateUpdateActivityFileTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityFileTranslationClient.UpdateActivityFileTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete ActivityFileTranslation
        /// </summary>
        /// <returns>ActivityFileTranslation message.</returns>
        [Route("RemoveActivityFileTranslation")]
        public IHttpActionResult DeleteActivityFileTranslation(int translationId)
        {
            ActivityFileTranslationRequest request = new ActivityFileTranslationRequest
            {
                ActivityFileTranslationDto = new ActivityFileTranslationDto {TranslationId = translationId}
            };

            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            List<string> errors = ValidateDeleteActivityFileTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityFileTranslationClient.DeleteActivityFileTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of ActivityFileTranslation
        /// </summary>
        /// <returns>ActivityFileTranslation message.</returns>
        [Route("GetActivityFileTranslations")]
        public IHttpActionResult GetAllActivityFileTranslations()
        {
            ActivityFileTranslationMessage message = _serviceActivityFileTranslationClient.GetAllActivityFileTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find ActivityFileTranslation
        /// </summary>
        /// <returns>ActivityFileTranslation message.</returns>
        [Route("FindActivityFileTranslations")]
        public IHttpActionResult FindActivityFileTranslations(ActivityFileTranslationRequest request)
        {
            ActivityFileTranslationMessage message = new ActivityFileTranslationMessage();
            List<string> errors = ValidateFindActivityFileTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ActivityMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceActivityFileTranslationClient.FindActivityFileTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation methods file activity translation

        /// <summary>
        /// Validate create activity file translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateActivityFileTranslation(ActivityFileTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityFileTranslationDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("ActivityFileId", request.ActivityFileTranslationDto.ActivityFileId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("ActivityFileText", request.ActivityFileTranslationDto.ActivityFileText));
                errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("LanguageId", request.ActivityFileTranslationDto.LanguageId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate create activity file translation range.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateActivityFileTranslationRange(ActivityFileTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityFileTranslationDtoList == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.ActivityFileTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("ActivityFileId", translation.ActivityFileId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("ActivityFileText", translation.ActivityFileText));
                    errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update activity file translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateActivityFileTranslation(ActivityFileTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityFileTranslationDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("ActivityFileId", request.ActivityFileTranslationDto.ActivityFileId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("TranslationId", request.ActivityFileTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("ActivityFileText", request.ActivityFileTranslationDto.ActivityFileText));
                errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("LanguageId", request.ActivityFileTranslationDto.LanguageId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update activity file translation range.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateActivityFileTranslationRange(ActivityFileTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityFileTranslationDtoList == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.ActivityFileTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("ActivityFileId", translation.ActivityFileId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("TranslationId", translation.TranslationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("ActivityFileText", translation.ActivityFileText));
                    errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate delete activity file translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteActivityFileTranslation(ActivityFileTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityFileTranslationDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("TranslationId", request.ActivityFileTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find activity file translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindActivityFileTranslation(ActivityFileTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ActivityFileTranslationDto == null)
            {
                errors.Add(ActivityMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindActivityFileTranslationDto)
                {
                    case FindActivityFileTranslationDto.ActivityFileId:
                        errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("ActivityFileId", request.ActivityFileTranslationDto.ActivityFileId.ToString()));
                        break;
                    case FindActivityFileTranslationDto.ActivityFileTranslationId:
                        errors.AddRange(GenericValidationAttribute<ActivityFileTranslationDto>.ValidateAttributes("TranslationId", request.ActivityFileTranslationDto.TranslationId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion
    }
}