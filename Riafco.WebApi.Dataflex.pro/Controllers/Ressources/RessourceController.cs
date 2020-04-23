using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Ressource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Riafco.WebApi.Dataflex.pro.Controllers.Ressources
{
    /// <summary>
    /// The Author web api controller.
    /// </summary>
    [RoutePrefix("api/Ressources")]
    public class RessourceController : ApiController
    {
        #region private attributes

        /// <summary>
        /// The Author service client instance.
        /// </summary>
        private readonly IServiceAuthorClient _serviceAuthorClient;

        /// <summary>
        /// The Theme service client instance.
        /// </summary>
        private readonly IServiceThemeClient _serviceThemeClient;

        /// <summary>
        /// The ThemeTranslation service client instance.
        /// </summary>
        private readonly IServiceThemeTranslationClient _serviceThemeTranslationClient;

        /// <summary>
        /// The Area service client instance.
        /// </summary>
        private readonly IServiceAreaClient _serviceAreaClient;

        /// <summary>
        /// The AreaTranslation service client instance.
        /// </summary>
        private readonly IServiceAreaTranslationClient _serviceAreaTranslationClient;

        /// <summary>
        /// The Publication service client instance.
        /// </summary>
        private readonly IServicePublicationClient _servicePublicationClient;

        /// <summary>
        /// The PublicationTranslation service client instance.
        /// </summary>
        private readonly IServicePublicationTranslationClient _servicePublicationTranslationClient;

        /// <summary>
        /// The PublicationTheme service client instance.
        /// </summary>
        private readonly IServicePublicationThemeClient _servicePublicationThemeClient;

        #endregion

        #region constructor

        /// <summary>
        /// Set the IServiceAuthorClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceAuthorClient">injected instance</param>
        /// <param name="injectedServiceThemeClient">injected instance</param>
        /// <param name="injectedServiceThemeTranslationClient">injected instance</param>
        /// <param name="injectedServiceAreaClient">injected instance</param>
        /// <param name="injectedServiceAreaTranslationClient">injected instance</param>
        /// <param name="injectedServicePublicationClient">injected instance</param>
        /// <param name="injectedServicePublicationTranslationClient">injected instance</param>
        /// <param name="injectedServicePublicationThemeClient">injected instance</param>
        public RessourceController(IServiceAuthorClient injectedServiceAuthorClient,
            IServiceThemeClient injectedServiceThemeClient,
            IServiceThemeTranslationClient injectedServiceThemeTranslationClient,
            IServiceAreaClient injectedServiceAreaClient,
            IServiceAreaTranslationClient injectedServiceAreaTranslationClient,
            IServicePublicationClient injectedServicePublicationClient,
            IServicePublicationTranslationClient injectedServicePublicationTranslationClient,
            IServicePublicationThemeClient injectedServicePublicationThemeClient)
        {
            _servicePublicationTranslationClient = injectedServicePublicationTranslationClient;
            _servicePublicationThemeClient = injectedServicePublicationThemeClient;
            _serviceThemeTranslationClient = injectedServiceThemeTranslationClient;
            _serviceAreaTranslationClient = injectedServiceAreaTranslationClient;
            _servicePublicationClient = injectedServicePublicationClient;
            _serviceAuthorClient = injectedServiceAuthorClient;
            _serviceThemeClient = injectedServiceThemeClient;
            _serviceAreaClient = injectedServiceAreaClient;
        }

        #endregion

        #region public author methods

        /// <summary>
        /// Create new Author
        /// </summary>
        /// <returns>Author message.</returns>
        [Route("CreateAuthor")]
        public IHttpActionResult CreateAuthor(AuthorRequest request)
        {
            AuthorMessage message = new AuthorMessage();
            List<string> errors = ValidationCreateAuthor(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AuthorMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAuthorClient.CreateAuthor(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change Author informations.
        /// </summary>
        /// <returns>Author message.</returns>
        [Route("UpdateAuthor")]
        public IHttpActionResult UpdateAuthor(AuthorRequest request)
        {
            AuthorMessage message = new AuthorMessage();
            List<string> errors = ValidationUpdateAuthor(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AuthorMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAuthorClient.UpdateAuthor(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Author
        /// </summary>
        /// <returns>Author message.</returns>
        [Route("RemoveAuthor")]
        public IHttpActionResult DeleteAuthor(int authorId)
        {
            AuthorRequest request = new AuthorRequest
            {
                AuthorDto = new AuthorDto { AuthorId = authorId },
                FindAuthorDto = FindAuthorDto.AuthorId
            };
            AuthorMessage message = new AuthorMessage();
            List<string> errors = ValidationDeleteAuthor(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AuthorMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAuthorClient.DeleteAuthor(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Author
        /// </summary>
        /// <returns>Author message.</returns>
        [Route("GetAuthors")]
        public IHttpActionResult GetAllAuthors()
        {
            AuthorMessage message = _serviceAuthorClient.GetAllAuthors();
            return Json(message);
        }

        /// <summary>
        /// Find Authors.
        /// </summary>
        /// <returns>Author message.</returns>
        [Route("FindAuthors")]
        public IHttpActionResult FindAuthors(AuthorRequest request)
        {
            AuthorMessage message = new AuthorMessage();
            List<string> errors = ValidationFindAuthors(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AuthorMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAuthorClient.FindAuthors(request);
            }
            return Json(message);
        }
        #endregion

        #region public theme methods

        /// <summary>
        /// Create new Theme
        /// </summary>
        /// <returns>Theme message.</returns>
        [Route("CreateTheme")]
        public IHttpActionResult CreateTheme(ThemeRequest request)
        {
            ThemeMessage message = _serviceThemeClient.CreateTheme(request);
            return Json(message);
        }

        /// <summary>
        /// Change Theme informations.
        /// </summary>
        /// <returns>Theme message.</returns>
        [Route("UpdateTheme")]
        public IHttpActionResult UpdateTheme(ThemeRequest request)
        {
            ThemeMessage message = new ThemeMessage();
            List<string> errors = ValidationTheme(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceThemeClient.UpdateTheme(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Theme
        /// </summary>
        /// <returns>Theme message.</returns>
        [Route("RemoveTheme")]
        public IHttpActionResult DeleteTheme(int themeId)
        {
            ThemeRequest request = new ThemeRequest { ThemeDto = new ThemeDto { ThemeId = themeId } };
            List<string> errors = ValidationTheme(request);
            ThemeMessage message = new ThemeMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceThemeClient.DeleteTheme(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Theme
        /// </summary>
        /// <returns>Theme message.</returns>
        [Route("GetThemes")]
        public IHttpActionResult GetAllThemes()
        {
            ThemeMessage message = _serviceThemeClient.GetAllThemes();
            return Json(message);
        }

        /// <summary>
        /// Find Theme
        /// </summary>
        /// <returns>Theme message.</returns>
        [Route("FindThemes")]
        public IHttpActionResult FindThemes(ThemeRequest request)
        {
            ThemeMessage message = new ThemeMessage();
            List<string> errors = ValidationTheme(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceThemeClient.FindThemes(request);
            }
            return Json(message);
        }

        #endregion

        #region public theme translation methods

        /// <summary>
        /// Create new ThemeTranslation
        /// </summary>
        /// <returns>ThemeTranslation message.</returns>
        [Route("CreateThemeTranslation")]
        public IHttpActionResult CreateThemeTranslation(ThemeTranslationRequest request)
        {
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            List<string> errors = ValidationCreateThemeTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceThemeTranslationClient.CreateThemeTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new ThemeTranslation
        /// </summary>
        /// <returns>ThemeTranslation message.</returns>
        [Route("CreateThemeTranslationRange")]
        public IHttpActionResult CreateThemeTranslationRange(ThemeTranslationRequest request)
        {
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            List<string> errors = ValidationCreateThemeTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceThemeTranslationClient.CreateThemeTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change ThemeTranslation informations.
        /// </summary>
        /// <returns>ThemeTranslation message.</returns>
        [Route("UpdateThemeTranslation")]
        public IHttpActionResult UpdateThemeTranslation(ThemeTranslationRequest request)
        {
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            List<string> errors = ValidationUpdateThemeTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceThemeTranslationClient.UpdateThemeTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change ThemeTranslation informations.
        /// </summary>
        /// <returns>ThemeTranslation message.</returns>
        [Route("UpdateThemeTranslationRange")]
        public IHttpActionResult UpdateThemeTranslationRange(ThemeTranslationRequest request)
        {
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            List<string> errors = ValidationUpdateThemeTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceThemeTranslationClient.UpdateThemeTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete ThemeTranslation
        /// </summary>
        /// <returns>ThemeTranslation message.</returns>
        [Route("RemoveThemeTranslation")]
        public IHttpActionResult DeleteThemeTranslation(int translationId)
        {
            ThemeTranslationRequest request = new ThemeTranslationRequest { ThemeTranslationDto = new ThemeTranslationDto { TranslationId = translationId } };
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            List<string> errors = ValidationDeleteThemeTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceThemeTranslationClient.DeleteThemeTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of ThemeTranslation
        /// </summary>
        /// <returns>ThemeTranslation message.</returns>
        [Route("GetThemeTranslations")]
        public IHttpActionResult GetAllThemeTranslations()
        {
            ThemeTranslationMessage message = _serviceThemeTranslationClient.GetAllThemeTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find ThemeTranslation
        /// </summary>
        /// <returns>ThemeTranslation message.</returns>
        [Route("FindThemeTranslations")]
        public IHttpActionResult FindThemeTranslation(ThemeTranslationRequest request)
        {
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            List<string> errors = ValidationFindThemeTranslations(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceThemeTranslationClient.FindThemeTranslations(request);
            }
            return Json(message);
        }

        #endregion

        #region public area methods

        /// <summary>
        /// Create new Area
        /// </summary>
        /// <returns>Area message.</returns>
        [Route("CreateArea")]
        public IHttpActionResult CreateArea(AreaRequest request)
        {
            AreaMessage message = _serviceAreaClient.CreateArea(request);
            return Json(message);
        }

        /// <summary>
        /// Change Area informations.
        /// </summary>
        /// <returns>Area message.</returns>
        [Route("UpdateArea")]
        public IHttpActionResult UpdateArea(AreaRequest request)
        {
            List<string> errors = ValidationArea(request);
            AreaMessage message = new AreaMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AreaMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAreaClient.UpdateArea(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Area
        /// </summary>
        /// <returns>Area message.</returns>
        [Route("RemoveArea")]
        public IHttpActionResult DeleteArea(int areaId)
        {
            AreaRequest request = new AreaRequest
            {
                AreaDto = new AreaDto { AreaId = areaId }
            };
            List<string> errors = ValidationArea(request);
            AreaMessage message = new AreaMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AreaMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAreaClient.DeleteArea(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Area
        /// </summary>
        /// <returns>Area message.</returns>
        [Route("GetAreas")]
        public IHttpActionResult GetAllAreas()
        {
            AreaMessage message = _serviceAreaClient.GetAllAreas();
            return Json(message);
        }

        /// <summary>
        /// Find Area
        /// </summary>
        /// <returns>Area message.</returns>
        [Route("FindAreas")]
        public IHttpActionResult FindAreas(AreaRequest request)
        {
            List<string> errors = ValidationArea(request);
            AreaMessage message = new AreaMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AreaMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAreaClient.FindAreas(request);
            }
            return Json(message);
        }

        #endregion

        #region public area translation methods

        /// <summary>
        /// Create new AreaTranslation
        /// </summary>
        /// <returns>AreaTranslation message.</returns>
        [Route("CreateAreaTranslation")]
        public IHttpActionResult CreateAreaTranslation(AreaTranslationRequest request)
        {
            List<string> errors = ValidationCreateAreaTranslation(request);
            AreaTranslationMessage message = new AreaTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AreaMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAreaTranslationClient.CreateAreaTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new AreaTranslation
        /// </summary>
        /// <returns>AreaTranslation message.</returns>
        [Route("CreateAreaTranslationRange")]
        public IHttpActionResult CreateAreaTranslationRange(AreaTranslationRequest request)
        {
            List<string> errors = ValidationCreateAreaTranslationRange(request);
            AreaTranslationMessage message = new AreaTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AreaMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAreaTranslationClient.CreateAreaTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change AreaTranslation informations.
        /// </summary>
        /// <returns>AreaTranslation message.</returns>
        [Route("UpdateAreaTranslation")]
        public IHttpActionResult UpdateAreaTranslation(AreaTranslationRequest request)
        {
            List<string> errors = ValidationUpdateAreaTranslation(request);
            AreaTranslationMessage message = new AreaTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AreaMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAreaTranslationClient.UpdateAreaTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change AreaTranslation informations range.
        /// </summary>
        /// <returns>AreaTranslation message.</returns>
        [Route("UpdateAreaTranslationRange")]
        public IHttpActionResult UpdateAreaTranslationRange(AreaTranslationRequest request)
        {
            List<string> errors = ValidationUpdateAreaTranslationRange(request);
            AreaTranslationMessage message = new AreaTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AreaMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAreaTranslationClient.UpdateAreaTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete AreaTranslation
        /// </summary>
        /// <returns>AreaTranslation message.</returns>
        [Route("RemoveAreaTranslation")]
        public IHttpActionResult DeleteAreaTranslation(int translationId)
        {
            AreaTranslationRequest request =
                new AreaTranslationRequest
                {
                    AreaTranslationDto = new AreaTranslationDto { TranslationId = translationId }
                };
            List<string> errors = ValidationDeleteAreaTranslation(request);
            AreaTranslationMessage message = new AreaTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AreaMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAreaTranslationClient.DeleteAreaTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of AreaTranslation
        /// </summary>
        /// <returns>AreaTranslation message.</returns>
        [Route("GetAreaTranslations")]
        public IHttpActionResult GetAllAreaTranslations()
        {
            AreaTranslationMessage message = _serviceAreaTranslationClient.GetAllAreaTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find AreaTranslation
        /// </summary>
        /// <returns>AreaTranslation message.</returns>
        [Route("FindAreaTranslations")]
        public IHttpActionResult FindAreaTranslations(AreaTranslationRequest request)
        {
            List<string> errors = ValidationFindAreaTranslations(request);
            AreaTranslationMessage message = new AreaTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = AreaMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceAreaTranslationClient.FindAreaTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region public publication methods

        /// <summary>
        /// Create new Publication
        /// </summary>
        /// <returns>Publication message.</returns>
        [Route("CreatePublication")]
        public IHttpActionResult CreatePublication(PublicationRequest request)
        {
            List<string> errors = ValidationCreatePublication(request);
            PublicationMessage message = new PublicationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationClient.CreatePublication(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change Publication informations.
        /// </summary>
        /// <returns>Publication message.</returns>
        [Route("UpdatePublication")]
        public IHttpActionResult UpdatePublication(PublicationRequest request)
        {
            List<string> errors = ValidationUpdatePublication(request);
            PublicationMessage message = new PublicationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationClient.UpdatePublication(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Publication
        /// </summary>
        /// <returns>Publication message.</returns>
        [Route("RemovePublication")]
        public IHttpActionResult DeletePublication(int publicationId)
        {
            PublicationRequest request = new PublicationRequest
            {
                PublicationDto = new PublicationDto { PublicationId = publicationId }
            };
            List<string> errors = ValidationDeletePublication(request);
            PublicationMessage message = new PublicationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationClient.DeletePublication(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Publication
        /// </summary>
        /// <returns>Publication message.</returns>
        [Route("GetPublications")]
        public IHttpActionResult GetAllPublications()
        {
            PublicationMessage message = _servicePublicationClient.GetAllPublications();
            return Json(message);
        }

        /// <summary>
        /// Find Publication
        /// </summary>
        /// <returns>Publication message.</returns>
        [Route("FindPublications")]
        public IHttpActionResult FindPublications(PublicationRequest request)
        {
            List<string> errors = ValidationFindPublication(request);
            PublicationMessage message = new PublicationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationClient.FindPublications(request);
            }
            return Json(message);
        }

        #endregion

        #region public publication translation methods

        /// <summary>
        /// Create new PublicationTranslation
        /// </summary>
        /// <returns>PublicationTranslation message.</returns>
        [Route("CreatePublicationTranslation")]
        public IHttpActionResult CreatePublicationTranslation(PublicationTranslationRequest request)
        {
            List<string> errors = ValidationCreatePublicationTranslation(request);
            PublicationTranslationMessage message = new PublicationTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationTranslationClient.CreatePublicationTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new PublicationTranslation
        /// </summary>
        /// <returns>PublicationTranslation message.</returns>
        [Route("CreatePublicationTranslationRange")]
        public IHttpActionResult CreatePublicationTranslationRange(PublicationTranslationRequest request)
        {
            List<string> errors = ValidationCreatePublicationTranslationRange(request);
            PublicationTranslationMessage message = new PublicationTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationTranslationClient.CreatePublicationTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change PublicationTranslation informations.
        /// </summary>
        /// <returns>PublicationTranslation message.</returns>
        [Route("UpdatePublicationTranslation")]
        public IHttpActionResult UpdatePublicationTranslation(PublicationTranslationRequest request)
        {
            List<string> errors = ValidationUpdatePublicationTranslation(request);
            PublicationTranslationMessage message = new PublicationTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationTranslationClient.UpdatePublicationTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change PublicationTranslation informations range.
        /// </summary>
        /// <returns>PublicationTranslation message.</returns>
        [Route("UpdatePublicationTranslationRange")]
        public IHttpActionResult UpdatePublicationTranslationRange(PublicationTranslationRequest request)
        {
            List<string> errors = ValidationUpdatePublicationTranslationRange(request);
            PublicationTranslationMessage message = new PublicationTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationTranslationClient.UpdatePublicationTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete PublicationTranslation
        /// </summary>
        /// <returns>PublicationTranslation message.</returns>
        [Route("RemovePublicationTranslation")]
        public IHttpActionResult DeletePublicationTranslation(int translationId)
        {
            PublicationTranslationRequest request =
                new PublicationTranslationRequest
                {
                    PublicationTranslationDto = new PublicationTranslationDto { PublicationTranslationId = translationId }
                };
            List<string> errors = ValidationDeletePublicationTranslation(request);
            PublicationTranslationMessage message = new PublicationTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationTranslationClient.DeletePublicationTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of PublicationTranslation
        /// </summary>
        /// <returns>PublicationTranslation message.</returns>
        [Route("GetPublicationTranslations")]
        public IHttpActionResult GetAllPublicationTranslations()
        {
            PublicationTranslationMessage message = _servicePublicationTranslationClient.GetAllPublicationTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find PublicationTranslation
        /// </summary>
        /// <returns>PublicationTranslation message.</returns>
        [Route("FindPublicationTranslations")]
        public IHttpActionResult FindPublicationTranslations(PublicationTranslationRequest request)
        {
            List<string> errors = ValidationFindPublicationTranslations(request);
            PublicationTranslationMessage message = new PublicationTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationTranslationClient.FindPublicationTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region public theme publication methods

        /// <summary>
        /// Create new PublicationTheme.
        /// </summary>
        /// <returns>PublicationTheme message.</returns>
        [Route("CreatePublicationTheme")]
        public IHttpActionResult CreatePublicationTheme(PublicationThemeRequest request)
        {
            List<string> errors = ValidationCreatePublicationTheme(request);
            PublicationThemeMessage message = new PublicationThemeMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationThemeClient.CreatePublicationTheme(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new PublicationTheme range.
        /// </summary>
        /// <returns>PublicationTheme message.</returns>
        [Route("CreatePublicationThemeRange")]
        public IHttpActionResult CreatePublicationThemeRange(PublicationThemeRequest request)
        {
            List<string> errors = ValidationCreatePublicationThemeRange(request);
            PublicationThemeMessage message = new PublicationThemeMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationThemeClient.CreatePublicationThemeRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change PublicationTheme informations.
        /// </summary>
        /// <returns>PublicationTheme message.</returns>
        [Route("UpdatePublicationTheme")]
        public IHttpActionResult UpdatePublicationTheme(PublicationThemeRequest request)
        {
            List<string> errors = ValidationUpdatePublicationTheme(request);
            PublicationThemeMessage message = new PublicationThemeMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationThemeClient.UpdatePublicationTheme(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change PublicationTheme informations range.
        /// </summary>
        /// <returns>PublicationTheme message.</returns>
        [Route("UpdatePublicationThemeRange")]
        public IHttpActionResult UpdatePublicationThemeRange(PublicationThemeRequest request)
        {
            List<string> errors = ValidationUpdatePublicationThemeRange(request);
            PublicationThemeMessage message = new PublicationThemeMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationThemeClient.UpdatePublicationThemeRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete PublicationTheme.
        /// </summary>
        /// <returns>PublicationTheme message.</returns>
        [Route("RemovePublicationTheme")]
        public IHttpActionResult DeletePublicationTheme(int publicationThemeId)
        {
            PublicationThemeRequest request = new PublicationThemeRequest
            {
                PublicationThemeDto = new PublicationThemeDto { PublicationThemeId = publicationThemeId }
            };
            List<string> errors = ValidationDeletePublicationTheme(request);
            PublicationThemeMessage message = new PublicationThemeMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationThemeClient.DeletePublicationTheme(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of PublicationTheme
        /// </summary>
        /// <returns>PublicationTheme message.</returns>
        [Route("GetPublicationThemes")]
        public IHttpActionResult GetAllPublicationThemes()
        {
            PublicationThemeMessage message = _servicePublicationThemeClient.GetAllPublicationThemes();
            return Json(message);
        }

        /// <summary>
        /// Find PublicationTheme
        /// </summary>
        /// <returns>PublicationTheme message.</returns>
        [Route("FindPublicationThemes")]
        public IHttpActionResult FindPublicationThemes(PublicationThemeRequest request)
        {
            List<string> errors = ValidationFindPublicationThemes(request);
            PublicationThemeMessage message = new PublicationThemeMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PublicationThemeMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePublicationThemeClient.FindPublicationThemes(request);
            }
            return Json(message);
        }
        #endregion


        #region private author validation methods

        /// <summary>
        /// Validate create Author.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationCreateAuthor(AuthorRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.AuthorDto == null)
            {
                errors.Add(AuthorMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<AuthorDto>.ValidateAttributes("AuthorFirstName", request.AuthorDto.AuthorFirstName));
                errors.AddRange(GenericValidationAttribute<AuthorDto>.ValidateAttributes("AuthorLastName", request.AuthorDto.AuthorLastName));
            }
            return errors;
        }

        /// <summary>
        /// Validate update Author.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationUpdateAuthor(AuthorRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.AuthorDto == null)
            {
                errors.Add(AuthorMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<AuthorDto>.ValidateAttributes("AuthorFirstName", request.AuthorDto.AuthorFirstName));
                errors.AddRange(GenericValidationAttribute<AuthorDto>.ValidateAttributes("AuthorLastName", request.AuthorDto.AuthorLastName));
                errors.AddRange(GenericValidationAttribute<AuthorDto>.ValidateAttributes("AuthorId", request.AuthorDto.AuthorId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete Author.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationDeleteAuthor(AuthorRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.AuthorDto == null)
            {
                errors.Add(AuthorMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<AuthorDto>.ValidateAttributes("AuthorId", request.AuthorDto.AuthorId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find Author.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationFindAuthors(AuthorRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.AuthorDto == null)
            {
                errors.Add(AuthorMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<AuthorDto>.ValidateAttributes("AuthorId", request.AuthorDto.AuthorId.ToString()));
            }
            return errors;
        }

        #endregion

        #region private theme validation methods
        /// <summary>
        /// Validate theme.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationTheme(ThemeRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ThemeDto == null)
            {
                errors.Add(ThemeMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ThemeDto>.ValidateAttributes("ThemeId", request.ThemeDto.ThemeId.ToString()));
            }
            return errors;
        }
        #endregion

        #region private theme translation validation methods
        /// <summary>
        /// Validate create theme translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationCreateThemeTranslation(ThemeTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ThemeTranslationDto == null)
            {
                errors.Add(ThemeMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("LanguageId", request.ThemeTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("ThemeId", request.ThemeTranslationDto.ThemeId.ToString()));
                errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("ThemeName", request.ThemeTranslationDto.ThemeName));
            }
            return errors;
        }

        /// <summary>
        /// Validate create theme translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationCreateThemeTranslationRange(ThemeTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ThemeTranslationDtoList == null)
            {
                errors.Add(ThemeMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.ThemeTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("ThemeId", translation.ThemeId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("ThemeName", translation.ThemeName));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update theme translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationUpdateThemeTranslation(ThemeTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ThemeTranslationDto == null)
            {
                errors.Add(ThemeMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("TranslationId", request.ThemeTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("LanguageId", request.ThemeTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("ThemeId", request.ThemeTranslationDto.ThemeId.ToString()));
                errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("ThemeName", request.ThemeTranslationDto.ThemeName));
            }
            return errors;
        }

        /// <summary>
        /// Validate update theme translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationUpdateThemeTranslationRange(ThemeTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ThemeTranslationDtoList == null)
            {
                errors.Add(ThemeMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.ThemeTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("TranslationId", translation.TranslationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("ThemeId", translation.ThemeId.ToString()));
                    errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("ThemeName", translation.ThemeName));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate delete theme translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationDeleteThemeTranslation(ThemeTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ThemeTranslationDto == null)
            {
                errors.Add(ThemeMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("TranslationId", request.ThemeTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find theme translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationFindThemeTranslations(ThemeTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.ThemeTranslationDto == null)
            {
                errors.Add(ThemeMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindThemeTranslationDto)
                {
                    case FindThemeTranslationDto.ThemeTranslationId:
                        errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("TranslationId", request.ThemeTranslationDto.TranslationId.ToString()));
                        break;
                    case FindThemeTranslationDto.ThemeId:
                        errors.AddRange(GenericValidationAttribute<ThemeTranslationDto>.ValidateAttributes("ThemeId", request.ThemeTranslationDto.ThemeId.ToString()));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return errors;
        }
        #endregion

        #region private area validation methods
        /// <summary>
        /// Validate theme.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationArea(AreaRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.AreaDto == null)
            {
                errors.Add(ThemeMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<AreaDto>.ValidateAttributes("AreaId", request.AreaDto.AreaId.ToString()));
            }
            return errors;
        }
        #endregion

        #region private area translation validation methods
        /// <summary>
        /// Validate create area translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationCreateAreaTranslation(AreaTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.AreaTranslationDto == null)
            {
                errors.Add(AreaMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("LanguageId", request.AreaTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("AreaId", request.AreaTranslationDto.AreaId.ToString()));
                errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("AreaName", request.AreaTranslationDto.AreaName));
            }
            return errors;
        }

        /// <summary>
        /// Validate create area translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationCreateAreaTranslationRange(AreaTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.AreaTranslationDtoList == null)
            {
                errors.Add(AreaMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.AreaTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("AreaId", translation.AreaId.ToString()));
                    errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("AreaName", translation.AreaName));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update area translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationUpdateAreaTranslation(AreaTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.AreaTranslationDto == null)
            {
                errors.Add(AreaMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("TranslationId", request.AreaTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("LanguageId", request.AreaTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("AreaId", request.AreaTranslationDto.AreaId.ToString()));
                errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("AreaName", request.AreaTranslationDto.AreaName));
            }
            return errors;
        }

        /// <summary>
        /// Validate update area translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationUpdateAreaTranslationRange(AreaTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.AreaTranslationDtoList == null)
            {
                errors.Add(AreaMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.AreaTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("TranslationId", translation.TranslationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("AreaId", translation.AreaId.ToString()));
                    errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("AreaName", translation.AreaName));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate delete area translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationDeleteAreaTranslation(AreaTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.AreaTranslationDto == null)
            {
                errors.Add(AreaMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("TranslationId", request.AreaTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find area translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationFindAreaTranslations(AreaTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.AreaTranslationDto == null)
            {
                errors.Add(AreaMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindAreaTranslationDto)
                {
                    case FindAreaTranslationDto.AreaTranslationId:
                        errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("TranslationId", request.AreaTranslationDto.TranslationId.ToString()));
                        break;
                    case FindAreaTranslationDto.AreaId:
                        errors.AddRange(GenericValidationAttribute<AreaTranslationDto>.ValidateAttributes("AreaId", request.AreaTranslationDto.AreaId.ToString()));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return errors;
        }
        #endregion

        #region private publication validation methods
        /// <summary>
        /// Create validate publication.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationCreatePublication(PublicationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationDto == null)
            {
                errors.Add(ThemeMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PublicationDto>.ValidateAttributes("PublicationDate", request.PublicationDto.PublicationDate.ToString("dd/MM/yyyy")));
                errors.AddRange(GenericValidationAttribute<PublicationDto>.ValidateAttributes("PublicationImage", request.PublicationDto.PublicationImage.ToString()));
                errors.AddRange(GenericValidationAttribute<PublicationDto>.ValidateAttributes("AuthorId", request.PublicationDto.AuthorId.ToString()));
                errors.AddRange(GenericValidationAttribute<PublicationDto>.ValidateAttributes("AreaId", request.PublicationDto.AreaId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update publication.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationUpdatePublication(PublicationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationDto == null)
            {
                errors.Add(ThemeMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PublicationDto>.ValidateAttributes("PublicationDate", request.PublicationDto.PublicationDate.ToString("dd/MM/yyyy")));
                errors.AddRange(GenericValidationAttribute<PublicationDto>.ValidateAttributes("PublicationId", request.PublicationDto.PublicationId.ToString()));
                errors.AddRange(GenericValidationAttribute<PublicationDto>.ValidateAttributes("AuthorId", request.PublicationDto.AuthorId.ToString()));
                errors.AddRange(GenericValidationAttribute<PublicationDto>.ValidateAttributes("AreaId", request.PublicationDto.AreaId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete publication.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationDeletePublication(PublicationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationDto == null)
            {
                errors.Add(ThemeMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PublicationDto>.ValidateAttributes("PublicationId", request.PublicationDto.PublicationId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete publication.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationFindPublication(PublicationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationDto == null)
            {
                errors.Add(ThemeMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PublicationDto>.ValidateAttributes("PublicationId", request.PublicationDto.PublicationId.ToString()));
            }
            return errors;
        }
        #endregion

        #region private publication translation validation methods
        /// <summary>
        /// Validate create publication translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationCreatePublicationTranslation(PublicationTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationTranslationDto == null)
            {
                errors.Add(PublicationMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes(
                    "PublicationId", request.PublicationTranslationDto.PublicationId.ToString()));
                errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes(
                    "PublicationSummary", request.PublicationTranslationDto.PublicationSummary));
                errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes(
                    "PublicationTitle", request.PublicationTranslationDto.PublicationTitle));
                errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes("LanguageId",
                    request.PublicationTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes("PublicationFile",
                    request.PublicationTranslationDto.PublicationFile));
            }
            return errors;
        }

        /// <summary>
        /// Validate create publication translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationCreatePublicationTranslationRange(PublicationTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationTranslationDtoList == null)
            {
                errors.Add(PublicationMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.PublicationTranslationDtoList)
                {
                    errors.AddRange(
                        GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes("PublicationId",
                            translation.PublicationId.ToString()));

                    errors.AddRange(
                        GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes("PublicationSummary",
                            translation.PublicationSummary));

                    errors.AddRange(
                        GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes("PublicationTitle",
                            translation.PublicationTitle));

                    errors.AddRange(
                        GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes("LanguageId",
                            translation.LanguageId.ToString()));

                    errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes(
                        "PublicationFile",
                        translation.PublicationFile));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update publication translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationUpdatePublicationTranslation(PublicationTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationTranslationDto == null)
            {
                errors.Add(PublicationMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes(
                    "PublicationTranslationId", request.PublicationTranslationDto.PublicationTranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes(
                    "PublicationId", request.PublicationTranslationDto.PublicationId.ToString()));
                errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes(
                    "PublicationSummary", request.PublicationTranslationDto.PublicationSummary));
                errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes(
                    "PublicationTitle", request.PublicationTranslationDto.PublicationTitle));
                errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes("LanguageId",
                    request.PublicationTranslationDto.LanguageId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update publication translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationUpdatePublicationTranslationRange(PublicationTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationTranslationDtoList == null)
            {
                errors.Add(PublicationMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.PublicationTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes(
                        "PublicationTranslationId", translation.PublicationTranslationId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes("PublicationId",
                            translation.PublicationId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes("PublicationSummary",
                            translation.PublicationSummary));
                    errors.AddRange(
                        GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes("PublicationTitle",
                            translation.PublicationTitle));
                    errors.AddRange(
                        GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes("LanguageId",
                            translation.LanguageId.ToString()));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate delete publication translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationDeletePublicationTranslation(PublicationTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationTranslationDto == null)
            {
                errors.Add(PublicationMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes(
                    "PublicationTranslationId", request.PublicationTranslationDto.PublicationTranslationId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find publication translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationFindPublicationTranslations(PublicationTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationTranslationDto == null)
            {
                errors.Add(PublicationMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindPublicationTranslationDto)
                {
                    case FindPublicationTranslationDto.PublicationTranslationId:
                        errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes(
                            "PublicationTranslationId",
                            request.PublicationTranslationDto.PublicationTranslationId.ToString()));
                        break;
                    case FindPublicationTranslationDto.PublicationId:
                        errors.AddRange(GenericValidationAttribute<PublicationTranslationDto>.ValidateAttributes(
                            "PublicationId", request.PublicationTranslationDto.PublicationId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion

        #region private publication theme validation methods
        /// <summary>
        /// Validate create publication translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationCreatePublicationTheme(PublicationThemeRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationThemeDto == null)
            {
                errors.Add(PublicationMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("PublicationId", request.PublicationThemeDto.PublicationId.ToString()));
                errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("ThemeId", request.PublicationThemeDto.ThemeId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate create publication translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationCreatePublicationThemeRange(PublicationThemeRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationThemeDtoList == null)
            {
                errors.Add(PublicationMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.PublicationThemeDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("PublicationId", translation.PublicationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("ThemeId", translation.ThemeId.ToString()));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update publication translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationUpdatePublicationTheme(PublicationThemeRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationThemeDto == null)
            {
                errors.Add(PublicationMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("PublicationThemeId", request.PublicationThemeDto.PublicationThemeId.ToString()));
                errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("PublicationId", request.PublicationThemeDto.PublicationId.ToString()));
                errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("ThemeId", request.PublicationThemeDto.ThemeId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update publication translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationUpdatePublicationThemeRange(PublicationThemeRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationThemeDtoList == null)
            {
                errors.Add(PublicationMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.PublicationThemeDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("PublicationThemeId", translation.PublicationThemeId.ToString()));
                    errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("PublicationId", translation.PublicationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("ThemeId", translation.ThemeId.ToString()));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate delete publication translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationDeletePublicationTheme(PublicationThemeRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationThemeDto == null)
            {
                errors.Add(PublicationMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("PublicationThemeId", request.PublicationThemeDto.PublicationThemeId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find publication translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation.</returns>
        private List<string> ValidationFindPublicationThemes(PublicationThemeRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.PublicationThemeDto == null)
            {
                errors.Add(PublicationMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindPublicationThemeDto)
                {
                    case FindPublicationThemeDto.PublicationThemeId:
                        errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("PublicationThemeId", request.PublicationThemeDto.PublicationThemeId.ToString()));
                        break;
                    case FindPublicationThemeDto.PublicationId:
                        errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("PublicationId", request.PublicationThemeDto.PublicationId.ToString()));
                        break;
                    case FindPublicationThemeDto.PublicationIdAndThemeId:
                        errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("PublicationId", request.PublicationThemeDto.PublicationId.ToString()));
                        errors.AddRange(GenericValidationAttribute<PublicationThemeDto>.ValidateAttributes("ThemeId", request.PublicationThemeDto.ThemeId.ToString()));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return errors;
        }
        #endregion
    }
}