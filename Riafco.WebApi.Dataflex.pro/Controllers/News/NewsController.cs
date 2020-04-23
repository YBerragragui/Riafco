using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.News.Dto;
using Riafco.WebApi.Service.Dataflex.pro.News.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.News.Interface;
using Riafco.WebApi.Service.Dataflex.pro.News.Message;
using Riafco.WebApi.Service.Dataflex.pro.News.Request;
using Riafco.WebApi.Service.Dataflex.pro.News.Ressource;

namespace Riafco.WebApi.Dataflex.pro.Controllers.News
{
    /// <summary>
    /// The News web api controller.
    /// </summary>
    [RoutePrefix("api/News")]
    public class NewsController : ApiController
    {
        #region private attributes
        /// <summary>
        /// The News service client instance.
        /// </summary>
        private readonly IServiceNewsClient _serviceNewsClient;

        /// <summary>
        /// The NewsTranslation service client instance.
        /// </summary>
        private readonly IServiceNewsTranslationClient _serviceNewsTranslationClient;

        #endregion

        #region contructor

        /// <summary>
        /// Set the IServiceNewsClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceNewsClient">injected instance</param>
        /// <param name="injectedServiceNewsTranslationClient">injected instance</param>
        public NewsController(IServiceNewsClient injectedServiceNewsClient, IServiceNewsTranslationClient injectedServiceNewsTranslationClient)
        {
            _serviceNewsClient = injectedServiceNewsClient;
            _serviceNewsTranslationClient = injectedServiceNewsTranslationClient;
        }

        #endregion

        #region private validation news methods
        /// <summary>
        /// Validation creation news.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateNews(NewsRequest request)
        {
            var errors = new List<string>();
            if (request?.NewsDto == null)
            {
                errors.Add(NewsMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsDto>.ValidateAttributes("NewsImage", request.NewsDto.NewsImage.ToString()));
                errors.AddRange(GenericValidationAttribute<NewsDto>.ValidateAttributes("NewsDate", request.NewsDto.NewsDate.ToString("dd/MM/yyyy")));

            }
            return errors;
        }

        /// <summary>
        /// Validation update news.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateNews(NewsRequest request)
        {
            var errors = new List<string>();
            if (request?.NewsDto == null)
            {
                errors.Add(NewsMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsDto>.ValidateAttributes("NewsId", request.NewsDto.NewsId.ToString()));
                errors.AddRange(GenericValidationAttribute<NewsDto>.ValidateAttributes("NewsDate", request.NewsDto.NewsDate.ToString("dd/MM/yyyy")));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete news.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteNews(NewsRequest request)
        {
            var errors = new List<string>();
            if (request?.NewsDto == null)
            {
                errors.Add(NewsMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsDto>.ValidateAttributes("NewsId", request.NewsDto.NewsId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete news.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindNews(NewsRequest request)
        {
            var errors = new List<string>();
            if (request?.NewsDto == null)
            {
                errors.Add(NewsMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsDto>.ValidateAttributes("NewsId", request.NewsDto.NewsId.ToString()));
            }
            return errors;
        }
        #endregion

        #region public news methods

        /// <summary>
        /// Create new News
        /// </summary>
        /// <returns>News message.</returns>
        [Route("CreateNews")]
        public IHttpActionResult CreateNews(NewsRequest request)
        {
            List<string> errors = ValidateCreateNews(request);
            NewsMessage message = new NewsMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsClient.CreateNews(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change News informations.
        /// </summary>
        /// <returns>News message.</returns>
        [Route("UpdateNews")]
        public IHttpActionResult UpdateNews(NewsRequest request)
        {
            List<string> errors = ValidateUpdateNews(request);
            NewsMessage message = new NewsMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsClient.UpdateNews(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete News
        /// </summary>
        /// <returns>News message.</returns>
        [Route("RemoveNews")]
        public IHttpActionResult DeleteNews(int newsId)
        {
            NewsRequest request = new NewsRequest
            {
                NewsDto = new NewsDto { NewsId = newsId }
            };
            List<string> errors = ValidateDeleteNews(request);
            NewsMessage message = new NewsMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsClient.DeleteNews(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of News
        /// </summary>
        /// <returns>News message.</returns>
        [Route("GetNews")]
        public IHttpActionResult GetAllNews()
        {
            NewsMessage message = _serviceNewsClient.GetAllNews();
            return Json(message);
        }

        /// <summary>
        /// Find News
        /// </summary>
        /// <returns>News message.</returns>
        [Route("FindNews")]
        public IHttpActionResult FindNews(NewsRequest request)
        {
            List<string> errors = ValidateFindNews(request);
            NewsMessage message = new NewsMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsClient.FindNews(request);
            }
            return Json(message);
        }
        #endregion

        #region private translate news methods
        /// <summary>
        /// Validate create news translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateNewsTranslation(NewsTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.NewsTranslationDto == null)
            {
                errors.Add(NewsMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsSummary", request.NewsTranslationDto.NewsSummary));
                errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsDescription", request.NewsTranslationDto.NewsDescription));
                errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsId", request.NewsTranslationDto.NewsId.ToString()));
                errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("LanguageId", request.NewsTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsTitle", request.NewsTranslationDto.NewsTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate create news translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateNewsTranslationRange(NewsTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.NewsTranslationDtoList == null)
            {
                errors.Add(NewsMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.NewsTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsSummary", translation.NewsSummary));
                    errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsDescription", translation.NewsDescription));
                    errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsId", translation.NewsId.ToString()));
                    errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsTitle", translation.NewsTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update news translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateNewsTranslation(NewsTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.NewsTranslationDto == null)
            {
                errors.Add(NewsMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsSummary", request.NewsTranslationDto.NewsSummary));
                errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsDescription", request.NewsTranslationDto.NewsDescription));
                errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("TranslationId", request.NewsTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsTitle", request.NewsTranslationDto.NewsTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate update news translation list.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateNewsTranslationRange(NewsTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.NewsTranslationDtoList == null)
            {
                errors.Add(NewsMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.NewsTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsSummary", translation.NewsSummary));
                    errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsDescription", translation.NewsDescription));
                    errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("TranslationId", translation.TranslationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsTitle", translation.NewsTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate find news translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindNewsTranslations(NewsTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.NewsTranslationDto == null)
            {
                errors.Add(NewsMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindNewsTranslationDto)
                {
                    case FindNewsTranslationDto.NewsId:
                        errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("NewsId", request.NewsTranslationDto.NewsId.ToString()));
                        break;
                    case FindNewsTranslationDto.NewsTranslationId:
                        errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("TranslationId", request.NewsTranslationDto.TranslationId.ToString()));
                        break;
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate find news translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteNewsTranslation(NewsTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.NewsTranslationDto == null)
            {
                errors.Add(NewsMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsTranslationDto>.ValidateAttributes("TranslationId", request.NewsTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }
        #endregion

        #region public translation news methods

        /// <summary>
        /// Create new NewsTranslation
        /// </summary>
        /// <returns>NewsTranslation message.</returns>
        [Route("CreateNewsTranslation")]
        public IHttpActionResult CreateNewsTranslation(NewsTranslationRequest request)
        {
            List<string> errors = ValidateCreateNewsTranslation(request);
            NewsTranslationMessage message = new NewsTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsTranslationClient.CreateNewsTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new NewsTranslation
        /// </summary>
        /// <returns>NewsTranslation message.</returns>
        [Route("CreateNewsTranslationRange")]
        public IHttpActionResult CreateNewsTranslationRange(NewsTranslationRequest request)
        {
            List<string> errors = ValidateCreateNewsTranslationRange(request);
            NewsTranslationMessage message = new NewsTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsTranslationClient.CreateNewsTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change NewsTranslation informations.
        /// </summary>
        /// <returns>NewsTranslation message.</returns>
        [Route("UpdateNewsTranslation")]
        public IHttpActionResult UpdateNewsTranslation(NewsTranslationRequest request)
        {
            List<string> errors = ValidateUpdateNewsTranslation(request);
            NewsTranslationMessage message = new NewsTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsTranslationClient.UpdateNewsTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change NewsTranslation informations.
        /// </summary>
        /// <returns>NewsTranslation message.</returns>
        [Route("UpdateNewsTranslationRange")]
        public IHttpActionResult UpdateNewsTranslationRange(NewsTranslationRequest request)
        {
            List<string> errors = ValidateUpdateNewsTranslationRange(request);
            NewsTranslationMessage message = new NewsTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsTranslationClient.UpdateNewsTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete NewsTranslation
        /// </summary>
        /// <returns>NewsTranslation message.</returns>
        [Route("RemoveNewsTranslation")]
        public IHttpActionResult DeleteNewsTranslation(int translationId)
        {
            NewsTranslationRequest request = new NewsTranslationRequest
            {
                NewsTranslationDto = new NewsTranslationDto
                {
                    TranslationId = translationId
                }
            };

            List<string> errors = ValidateDeleteNewsTranslation(request);
            NewsTranslationMessage message = new NewsTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsTranslationClient.DeleteNewsTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of NewsTranslation
        /// </summary>
        /// <returns>NewsTranslation message.</returns>
        [Route("GetNewsTranslations")]
        public IHttpActionResult GetAllNewsTranslation()
        {
            NewsTranslationMessage message = _serviceNewsTranslationClient.GetAllNewsTranslation();
            return Json(message);
        }

        /// <summary>
        /// Find NewsTranslation
        /// </summary>
        /// <returns>NewsTranslation message.</returns>
        [Route("FindNewsTranslation")]
        public IHttpActionResult FindNewsTranslation(NewsTranslationRequest request)
        {
            List<string> errors = ValidateFindNewsTranslations(request);
            NewsTranslationMessage message = new NewsTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = NewsMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceNewsTranslationClient.FindNewsTranslation(request);
            }
            return Json(message);
        }

        #endregion
    }
}