using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Request;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Message;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Ressource;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto.Enum;

namespace Riafco.WebApi.Dataflex.pro.Controllers.Newsletters
{
    /// <summary>
    /// The Subscriber web api controller.
    /// </summary>
    [RoutePrefix("api/Newsletters")]
    public class NewslettersController : ApiController
    {
        #region private properties
        /// <summary>
        /// The Subscriber service client instance.
        /// </summary>
        private readonly IServiceSubscriberClient _serviceSubscriberClient;

        /// <summary>
        /// The NewsletterMail service client instance.
        /// </summary>
        private readonly IServiceNewsletterMailClient _serviceNewsletterMailClient;

        /// <summary>
        /// The NewsletterMailTranslation service client instance.
        /// </summary>
        private readonly IServiceNewsletterMailTranslationClient _serviceNewsletterMailTranslationClient;
        #endregion
        #region constructor

        /// <summary>
        /// Set the IServiceSubscriberClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceSubscriberClient">injected instance</param>
        /// <param name="injectedServiceNewsletterMailClient"></param>
        /// <param name="injectedServiceNewsletterMailTranslationClient"></param>
        public NewslettersController(IServiceSubscriberClient injectedServiceSubscriberClient, IServiceNewsletterMailClient injectedServiceNewsletterMailClient, IServiceNewsletterMailTranslationClient injectedServiceNewsletterMailTranslationClient)
        {
            _serviceSubscriberClient = injectedServiceSubscriberClient;
            _serviceNewsletterMailClient = injectedServiceNewsletterMailClient;
            _serviceNewsletterMailTranslationClient = injectedServiceNewsletterMailTranslationClient;
        }
        #endregion
        #region public methods Subscribers
        /// <summary>
        /// Create new Subscriber
        /// </summary>
        /// <returns>Subscriber message.</returns>
        [Route("CreateSubscriber")]
        public IHttpActionResult CreateSubscriber(SubscriberRequest request)
        {
            List<string> errors = ValidateCreateSubscriber(request);
            SubscriberMessage message = new SubscriberMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SubscriberMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSubscriberClient.CreateSubscriber(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change Subscriber informations.
        /// </summary>
        /// <returns>Subscriber message.</returns>
        [Route("UpdateSubscriber")]
        public IHttpActionResult UpdateSubscriber(SubscriberRequest request)
        {
            List<string> errors = ValidateUpdateSubscriber(request);
            SubscriberMessage message = new SubscriberMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SubscriberMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSubscriberClient.UpdateSubscriber(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Subscriber
        /// </summary>
        /// <returns>Subscriber message.</returns>
        [Route("RemoveSubscriber")]
        public IHttpActionResult DeleteSubscriber(int subscriberId)
        {
            SubscriberRequest request = new SubscriberRequest
            {
                SubscriberDto = new SubscriberDto { SubscriberId = subscriberId }
            };
            List<string> errors = ValidateDeleteSubscriber(request);
            SubscriberMessage message = new SubscriberMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SubscriberMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSubscriberClient.DeleteSubscriber(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Subscriber
        /// </summary>
        /// <returns>Subscriber message.</returns>
        [Route("GetSubscribers")]
        public IHttpActionResult GetAllSubscribers()
        {
            SubscriberMessage message = _serviceSubscriberClient.GetAllSubscribers();
            return Json(message);
        }

        /// <summary>
        /// Find Subscriber
        /// </summary>
        /// <returns>Subscriber message.</returns>
        [Route("FindSubscribers")]
        public IHttpActionResult FindSubscribers(SubscriberRequest request)
        {
            List<string> errors = ValidateFindSubscribers(request);
            SubscriberMessage message = new SubscriberMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SubscriberMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSubscriberClient.FindSubscribers(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation subscriber methods
        /// <summary>
        /// Validation creation subscriber.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSubscriber(SubscriberRequest request)
        {
            var errors = new List<string>();
            if (request?.SubscriberDto == null)
            {
                errors.Add(SubscriberMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SubscriberDto>.ValidateAttributes("SubscriberEmail", request.SubscriberDto.SubscriberEmail));
                errors.AddRange(GenericValidationAttribute<SubscriberDto>.ValidateAttributes("SubscriberLastName", request.SubscriberDto.SubscriberLastName));
                errors.AddRange(GenericValidationAttribute<SubscriberDto>.ValidateAttributes("SubscriberFirstName", request.SubscriberDto.SubscriberFirstName));
            }
            return errors;
        }

        /// <summary>
        /// Validation update subscriber.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSubscriber(SubscriberRequest request)
        {
            var errors = new List<string>();
            if (request?.SubscriberDto == null)
            {
                errors.Add(SubscriberMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SubscriberDto>.ValidateAttributes("SubscriberEmail", request.SubscriberDto.SubscriberEmail));
                errors.AddRange(GenericValidationAttribute<SubscriberDto>.ValidateAttributes("SubscriberLastName", request.SubscriberDto.SubscriberLastName));
                errors.AddRange(GenericValidationAttribute<SubscriberDto>.ValidateAttributes("SubscriberFirstName", request.SubscriberDto.SubscriberFirstName));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete subscriber.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteSubscriber(SubscriberRequest request)
        {
            var errors = new List<string>();
            if (request?.SubscriberDto == null)
            {
                errors.Add(SubscriberMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SubscriberDto>.ValidateAttributes("SubscriberId", request.SubscriberDto.SubscriberId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete subscriber.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindSubscribers(SubscriberRequest request)
        {
            var errors = new List<string>();
            if (request?.SubscriberDto == null)
            {
                errors.Add(SubscriberMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SubscriberDto>.ValidateAttributes("SubscriberId", request.SubscriberDto.SubscriberId.ToString()));
            }
            return errors;
        }
        #endregion


        #region publics methods newsletter mail

        /// <summary>
        /// Create new NewsletterMail.
        /// </summary>
        /// <returns>NewsletterMail message.</returns>
        [Route("CreateNewsletterMail")]
        public IHttpActionResult CreateNewsletterMail(NewsletterMailRequest request)
        {
            NewsletterMailMessage message = new NewsletterMailMessage();
            List<string> errors = ValidateCreateNewsletterMail(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsletterMailMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsletterMailClient.CreateNewsletterMail(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change NewsletterMail informations.
        /// </summary>
        /// <returns>NewsletterMail message.</returns>
        [Route("UpdateNewsletterMail")]
        public IHttpActionResult UpdateNewsletterMail(NewsletterMailRequest request)
        {
            NewsletterMailMessage message = new NewsletterMailMessage();
            List<string> errors = ValidateUpdateNewsletterMail(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsletterMailMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsletterMailClient.UpdateNewsletterMail(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete NewsletterMail.
        /// </summary>
        /// <returns>NewsletterMail message.</returns>
        [Route("RemoveNewsletterMail")]
        public IHttpActionResult DeleteNewsletterMail(int newsletterMailId)
        {
            NewsletterMailRequest request = new NewsletterMailRequest { NewsletterMailDto = new NewsletterMailDto { NewsletterMailId = newsletterMailId } };
            NewsletterMailMessage message = new NewsletterMailMessage();
            List<string> errors = ValidateDeleteNewsletterMail(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsletterMailMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsletterMailClient.DeleteNewsletterMail(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of NewsletterMail.
        /// </summary>
        /// <returns>NewsletterMail message.</returns>
        [Route("GetNewsletterMails")]
        public IHttpActionResult GetAllNewsletterMails()
        {
            NewsletterMailMessage message = _serviceNewsletterMailClient.GetAllNewsletterMails();
            return Json(message);
        }

        /// <summary>
        /// Find NewsletterMail.
        /// </summary>
        /// <returns>NewsletterMail message.</returns>
        [Route("FindNewsletterMails")]
        public IHttpActionResult FindNewsletterMails(NewsletterMailRequest request)
        {
            NewsletterMailMessage message = new NewsletterMailMessage();
            List<string> errors = ValidateFindNewsletterMail(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsletterMailMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsletterMailClient.FindNewsletterMails(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation methods newsletter mail

        /// <summary>
        /// Validate create activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateNewsletterMail(NewsletterMailRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.NewsletterMailDto == null)
            {
                errors.Add(NewsletterMailMessageResource.NullRequest);
            }
            return errors;
        }

        /// <summary>
        /// Validate update activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateNewsletterMail(NewsletterMailRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.NewsletterMailDto == null)
            {
                errors.Add(NewsletterMailMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsletterMailDto>.ValidateAttributes("NewsletterMailId", request.NewsletterMailDto.NewsletterMailId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteNewsletterMail(NewsletterMailRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.NewsletterMailDto == null)
            {
                errors.Add(NewsletterMailMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsletterMailDto>.ValidateAttributes("NewsletterMailId", request.NewsletterMailDto.NewsletterMailId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete activity translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindNewsletterMail(NewsletterMailRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.NewsletterMailDto == null)
            {
                errors.Add(NewsletterMailMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindNewsletterMailDto)
                {
                    case FindNewsletterMailDto.NewsletterMailId:
                        errors.AddRange(GenericValidationAttribute<NewsletterMailDto>.ValidateAttributes("NewsletterMailId", request.NewsletterMailDto.NewsletterMailId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion

        #region public methods newsletter mail translation

        /// <summary>
        /// Create new NewsletterMailTranslation
        /// </summary>
        /// <returns>NewsletterMailTranslation message.</returns>
        [Route("CreateNewsletterMailTranslation")]
        public IHttpActionResult CreateNewsletterMailTranslation(NewsletterMailTranslationRequest request)
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            List<string> errors = ValidateCreateNewsletterMailTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsletterMailMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsletterMailTranslationClient.CreateNewsletterMailTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new NewsletterMailTranslation List
        /// </summary>
        /// <returns>NewsletterMailTranslation message.</returns>
        [Route("CreateNewsletterMailTranslationRange")]
        public IHttpActionResult CreateNewsletterMailTranslationRange(NewsletterMailTranslationRequest request)
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            List<string> errors = ValidateCreateNewsletterMailTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsletterMailMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsletterMailTranslationClient.CreateNewsletterMailTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change NewsletterMailTranslation informations.
        /// </summary>
        /// <returns>NewsletterMailTranslation message.</returns>
        [Route("UpdateNewsletterMailTranslation")]
        public IHttpActionResult UpdateNewsletterMailTranslation(NewsletterMailTranslationRequest request)
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            List<string> errors = ValidateUpdateNewsletterMailTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsletterMailMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsletterMailTranslationClient.UpdateNewsletterMailTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change NewsletterMailTranslation informations Range.
        /// </summary>
        /// <returns>NewsletterMailTranslation message.</returns>
        [Route("UpdateNewsletterMailTranslationRange")]
        public IHttpActionResult UpdateNewsletterMailTranslationRange(NewsletterMailTranslationRequest request)
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            List<string> errors = ValidateUpdateNewsletterMailTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsletterMailMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsletterMailTranslationClient.UpdateNewsletterMailTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete NewsletterMailTranslation
        /// </summary>
        /// <returns>NewsletterMailTranslation message.</returns>
        [Route("RemoveNewsletterMailTranslation")]
        public IHttpActionResult DeleteNewsletterMailTranslation(NewsletterMailTranslationRequest request)
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            List<string> errors = ValidateDeleteNewsletterMailTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsletterMailMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsletterMailTranslationClient.DeleteNewsletterMailTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of NewsletterMailTranslation
        /// </summary>
        /// <returns>NewsletterMailTranslation message.</returns>
        [Route("GetNewsletterMailTranslations")]
        public IHttpActionResult GetAllNewsletterMailTranslations()
        {
            NewsletterMailTranslationMessage message = _serviceNewsletterMailTranslationClient.GetAllNewsletterMailTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find NewsletterMailTranslation
        /// </summary>
        /// <returns>NewsletterMailTranslation message.</returns>
        [Route("FindNewsletterMailTranslations")]
        public IHttpActionResult FindNewsletterMailTranslations(NewsletterMailTranslationRequest request)
        {
            NewsletterMailTranslationMessage message = new NewsletterMailTranslationMessage();
            List<string> errors = ValidateFindNewsletterMailTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsletterMailMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsletterMailTranslationClient.FindNewsletterMailTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation methods newsletter mail translation

        /// <summary>
        /// Validate create activity file translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateNewsletterMailTranslation(NewsletterMailTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.NewsletterMailTranslationDto == null)
            {
                errors.Add(NewsletterMailMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("NewsletterMailId", request.NewsletterMailTranslationDto.NewsletterMailId.ToString()));
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("NewsletterMailSource", request.NewsletterMailTranslationDto.NewsletterMailSource.ToString()));
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("NewsletterMailSubject", request.NewsletterMailTranslationDto.NewsletterMailSubject));
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("LanguageId", request.NewsletterMailTranslationDto.LanguageId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate create activity file translation range.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateNewsletterMailTranslationRange(NewsletterMailTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.NewsletterMailTranslationDtoList == null)
            {
                errors.Add(NewsletterMailMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.NewsletterMailTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("NewsletterMailId", translation.NewsletterMailId.ToString()));
                    errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("NewsletterMailSource", translation.NewsletterMailSource.ToString()));
                    errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("NewsletterMailSubject", translation.NewsletterMailSubject));
                    errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update activity file translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateNewsletterMailTranslation(NewsletterMailTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.NewsletterMailTranslationDto == null)
            {
                errors.Add(NewsletterMailMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("NewsletterMailId", request.NewsletterMailTranslationDto.NewsletterMailId.ToString()));
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("TranslationId", request.NewsletterMailTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("NewsletterMailSubject", request.NewsletterMailTranslationDto.NewsletterMailSubject));
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("LanguageId", request.NewsletterMailTranslationDto.LanguageId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update activity file translation range.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateNewsletterMailTranslationRange(NewsletterMailTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.NewsletterMailTranslationDtoList == null)
            {
                errors.Add(NewsletterMailMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.NewsletterMailTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("NewsletterMailId", translation.NewsletterMailId.ToString()));
                    errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("TranslationId", translation.TranslationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("NewsletterMailSubject", translation.NewsletterMailSubject));
                    errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate delete activity file translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteNewsletterMailTranslation(NewsletterMailTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.NewsletterMailTranslationDto == null)
            {
                errors.Add(NewsletterMailMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("TranslationId", request.NewsletterMailTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find activity file translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindNewsletterMailTranslation(NewsletterMailTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.NewsletterMailTranslationDto == null)
            {
                errors.Add(NewsletterMailMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindNewsletterMailTranslationDto)
                {
                    case FindNewsletterMailTranslationDto.NewsletterMailId:
                        errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("NewsletterMailId", request.NewsletterMailTranslationDto.NewsletterMailId.ToString()));
                        break;
                    case FindNewsletterMailTranslationDto.NewsletterMailTranslationId:
                        errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationDto>.ValidateAttributes("TranslationId", request.NewsletterMailTranslationDto.TranslationId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion
    }
}