using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.About.Interface;
using Riafco.WebApi.Service.Dataflex.pro.About.Request;
using Riafco.WebApi.Service.Dataflex.pro.About.Message;
using Riafco.WebApi.Service.Dataflex.pro.About.Ressource;

namespace Riafco.WebApi.Dataflex.pro.Controllers.About
{
    /// <summary>
    /// The Section web api controller.
    /// </summary>
    [RoutePrefix("api/About")]
    public class SectionController : ApiController
    {
        #region private properties
        /// <summary>
        /// The Section service client instance.
        /// </summary>
        private readonly IServiceSectionClient _serviceSectionClient;
        /// <summary>
        /// The SectionTranslation service client instance.
        /// </summary>
        private readonly IServiceSectionTranslationClient _serviceSectionTranslationClient;

        /// <summary>
        /// The SectionParagraph service client instance.
        /// </summary>
        private readonly IServiceSectionParagraphClient _serviceSectionParagraphClient;

        /// <summary>
        /// The SectionParagraphTraslation service client instance.
        /// </summary>
        private readonly IServiceSectionParagraphTranslationClient _serviceSectionParagraphTraslationClient;
        /// <summary>
        /// The SectionFile service client instance.
        /// </summary>
        private readonly IServiceSectionFileClient _serviceSectionFileClient;

        /// <summary>
        /// The SectionFileTranslation service client instance.
        /// </summary>
        private readonly IServiceSectionFileTranslationClient _serviceSectionFileTranslationClient;

        #endregion

        #region constructor

        /// <summary>
        /// Set the IServiceSectionClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceSectionClient">injected instance</param>
        /// <param name="injectedServiceSectionTranslationClient">injected instance</param>
        /// <param name="injectedServiceSectionParagraphClient">injected instance</param>
        /// <param name="injectedServiceSectionParagraphTraslationClient">injected instance</param>
        /// <param name="injectedServiceSectionFileClient">injected instance</param>
        /// <param name="injectedServiceSectionFileTranslationClient">injected instance</param>
        public SectionController(IServiceSectionClient injectedServiceSectionClient,
            IServiceSectionTranslationClient injectedServiceSectionTranslationClient,
            IServiceSectionParagraphClient injectedServiceSectionParagraphClient,
            IServiceSectionParagraphTranslationClient injectedServiceSectionParagraphTraslationClient,
            IServiceSectionFileClient injectedServiceSectionFileClient,
            IServiceSectionFileTranslationClient injectedServiceSectionFileTranslationClient)
        {
            _serviceSectionTranslationClient = injectedServiceSectionTranslationClient;
            _serviceSectionClient = injectedServiceSectionClient;
            _serviceSectionParagraphClient = injectedServiceSectionParagraphClient;
            _serviceSectionParagraphTraslationClient = injectedServiceSectionParagraphTraslationClient;
            _serviceSectionFileClient = injectedServiceSectionFileClient;
            _serviceSectionFileTranslationClient = injectedServiceSectionFileTranslationClient;
        }
        #endregion

        #region public methods Sections
        /// <summary>
        /// Create new Section
        /// </summary>
        /// <returns>Section message.</returns>
        [Route("CreateSection")]
        public IHttpActionResult CreateSection(SectionRequest request)
        {
            List<string> errors = ValidateCreateSection(request);
            SectionMessage message = new SectionMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionClient.CreateSection(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change Section informations.
        /// </summary>
        /// <returns>Section message.</returns>
        [Route("UpdateSection")]
        public IHttpActionResult UpdateSection(SectionRequest request)
        {
            List<string> errors = ValidateUpdateSection(request);
            SectionMessage message = new SectionMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionClient.UpdateSection(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Section
        /// </summary>
        /// <returns>Section message.</returns>
        [Route("RemoveSection")]
        public IHttpActionResult DeleteSection(int sectionId)
        {
            SectionRequest request = new SectionRequest
            {
                SectionDto = new SectionDto { SectionId = sectionId }
            };
            List<string> errors = ValidateDeleteSection(request);
            SectionMessage message = new SectionMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionClient.DeleteSection(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Section
        /// </summary>
        /// <returns>Section message.</returns>
        [Route("GetSections")]
        public IHttpActionResult GetAllSections()
        {
            SectionMessage message = _serviceSectionClient.GetAllSections();
            return Json(message);
        }

        /// <summary>
        /// Find Section
        /// </summary>
        /// <returns>Section message.</returns>
        [Route("FindSections")]
        public IHttpActionResult FindSections(SectionRequest request)
        {
            List<string> errors = ValidateFindSections(request);
            SectionMessage message = new SectionMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionClient.FindSections(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation section methods
        /// <summary>
        /// Validation creation section.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSection(SectionRequest request)
        {
            var errors = new List<string>();
            if (request?.SectionDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            return errors;
        }

        /// <summary>
        /// Validation update section.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSection(SectionRequest request)
        {
            var errors = new List<string>();
            if (request?.SectionDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionDto>.ValidateAttributes("SectionId", request.SectionDto.SectionId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete section.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteSection(SectionRequest request)
        {
            var errors = new List<string>();
            if (request?.SectionDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionDto>.ValidateAttributes("SectionId", request.SectionDto.SectionId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete section.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindSections(SectionRequest request)
        {
            var errors = new List<string>();
            if (request?.SectionDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionDto>.ValidateAttributes("SectionId", request.SectionDto.SectionId.ToString()));
            }
            return errors;
        }
        #endregion

        #region public methods section translation

        /// <summary>
        /// Create new SectionTranslation
        /// </summary>
        /// <returns>SectionTranslation message.</returns>
        [Route("CreateSectionTranslation")]
        public IHttpActionResult CreateSectionTranslation(SectionTranslationRequest request)
        {
            List<string> errors = ValidateCreateSectionTranslation(request);
            SectionTranslationMessage message = new SectionTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionTranslationClient.CreateSectionTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new SectionTranslation
        /// </summary>
        /// <returns>SectionTranslation message.</returns>
        [Route("CreateSectionTranslationRange")]
        public IHttpActionResult CreateSectionTranslationRange(SectionTranslationRequest request)
        {
            List<string> errors = ValidateCreateSectionTranslationRange(request);
            SectionTranslationMessage message = new SectionTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionTranslationClient.CreateSectionTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change SectionTranslation informations.
        /// </summary>
        /// <returns>SectionTranslation message.</returns>
        [Route("UpdateSectionTranslation")]
        public IHttpActionResult UpdateSectionTranslation(SectionTranslationRequest request)
        {
            List<string> errors = ValidateUpdateSectionTranslation(request);
            SectionTranslationMessage message = new SectionTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionTranslationClient.UpdateSectionTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change SectionTranslation informations.
        /// </summary>
        /// <returns>SectionTranslation message.</returns>
        [Route("UpdateSectionTranslationRange")]
        public IHttpActionResult UpdateSectionTranslationRange(SectionTranslationRequest request)
        {
            List<string> errors = ValidateUpdateSectionTranslationRange(request);
            SectionTranslationMessage message = new SectionTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionTranslationClient.UpdateSectionTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete SectionTranslation
        /// </summary>
        /// <returns>SectionTranslation message.</returns>
        [Route("RemoveSectionTranslation")]
        public IHttpActionResult DeleteSectionTranslation(int translationId)
        {
            SectionTranslationRequest request = new SectionTranslationRequest
            {
                SectionTranslationDto = new SectionTranslationDto { TranslationId = translationId }
            };
            List<string> errors = ValidateDeleteSectionTranslation(request);
            SectionTranslationMessage message = new SectionTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionTranslationClient.DeleteSectionTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of SectionTranslation
        /// </summary>
        /// <returns>SectionTranslation message.</returns>
        [Route("GetSectionTranslations")]
        public IHttpActionResult GetAllSectionTranslations()
        {
            SectionTranslationMessage message = _serviceSectionTranslationClient.GetAllSectionTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find SectionTranslation
        /// </summary>
        /// <returns>SectionTranslation message.</returns>
        [Route("FindSectionTranslations")]
        public IHttpActionResult FindSectionTranslations(SectionTranslationRequest request)
        {
            List<string> errors = ValidateFindSectionTranslations(request);
            SectionTranslationMessage message = new SectionTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionTranslationClient.FindSectionTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region private translate section methods
        /// <summary>
        /// Validate create section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSectionTranslation(SectionTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.SectionTranslationDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("SectionId", request.SectionTranslationDto.SectionId.ToString()));
                errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("LanguageId", request.SectionTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("SectionTitle", request.SectionTranslationDto.SectionTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate create section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSectionTranslationRange(SectionTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.SectionTranslationDtoList == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.SectionTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("SectionId", translation.SectionId.ToString()));
                    errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("SectionTitle", translation.SectionTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSectionTranslation(SectionTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.SectionTranslationDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("TranslationId", request.SectionTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("SectionTitle", request.SectionTranslationDto.SectionTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate update section translation list.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSectionTranslationRange(SectionTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.SectionTranslationDtoList == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.SectionTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("TranslationId", translation.TranslationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("SectionTitle", translation.SectionTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate find section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindSectionTranslations(SectionTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.SectionTranslationDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindSectionTranslationDto)
                {
                    case FindSectionTranslationDto.SectionId:
                        errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("SectionId", request.SectionTranslationDto.SectionId.ToString()));
                        break;
                    case FindSectionTranslationDto.SectionTranslationId:
                        errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("TranslationId", request.SectionTranslationDto.TranslationId.ToString()));
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
        private List<string> ValidateDeleteSectionTranslation(SectionTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.SectionTranslationDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("TranslationId", request.SectionTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }
        #endregion


        #region public methods section paragraph

        /// <summary>
        /// Create new SectionParagraph
        /// </summary>
        /// <returns>SectionParagraph message.</returns>
        [Route("CreateSectionParagraph")]
        public IHttpActionResult CreateSectionParagraph(SectionParagraphRequest request)
        {
            SectionParagraphMessage message = new SectionParagraphMessage();
            List<string> errors = ValidateCreateSectionParagraph(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionParagraphClient.CreateSectionParagraph(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change SectionParagraph informations.
        /// </summary>
        /// <returns>SectionParagraph message.</returns>
        [Route("UpdateSectionParagraph")]
        public IHttpActionResult UpdateSectionParagraph(SectionParagraphRequest request)
        {
            SectionParagraphMessage message = new SectionParagraphMessage();
            List<string> errors = ValidateUpdateSectionParagraph(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionParagraphClient.UpdateSectionParagraph(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete SectionParagraph
        /// </summary>
        /// <returns>SectionParagraph message.</returns>
        [Route("RemoveSectionParagraph")]
        public IHttpActionResult DeleteSectionParagraph(int paragraphId)
        {
            SectionParagraphRequest request = new SectionParagraphRequest
            {
                SectionParagraphDto = new SectionParagraphDto { ParagraphId = paragraphId },
                FindSectionParagraphDto = FindSectionParagraphDto.SectionParagraphId
            };

            SectionParagraphMessage message = new SectionParagraphMessage();
            List<string> errors = ValidateDeleteSectionParagraph(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionParagraphClient.DeleteSectionParagraph(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of SectionParagraph
        /// </summary>
        /// <returns>SectionParagraph message.</returns>
        [Route("GetSectionParagraphs")]
        public IHttpActionResult GetAllSectionParagraphs()
        {
            SectionParagraphMessage message = _serviceSectionParagraphClient.GetAllSectionParagraphs();
            return Json(message);
        }

        /// <summary>
        /// Find SectionParagraph
        /// </summary>
        /// <returns>SectionParagraph message.</returns>
        [Route("FindSectionParagraphs")]
        public IHttpActionResult FindSectionParagraphs(SectionParagraphRequest request)
        {
            SectionParagraphMessage message = new SectionParagraphMessage();
            List<string> errors = ValidateFindSectionParagraph(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionParagraphClient.FindSectionParagraphs(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation methods paragraph

        /// <summary>
        /// Validate create section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSectionParagraph(SectionParagraphRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionParagraphDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionParagraphDto>.ValidateAttributes("SectionId", request.SectionParagraphDto.SectionId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSectionParagraph(SectionParagraphRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionParagraphDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionParagraphDto>.ValidateAttributes("ParagraphId", request.SectionParagraphDto.ParagraphId.ToString()));
                errors.AddRange(GenericValidationAttribute<SectionParagraphDto>.ValidateAttributes("SectionId", request.SectionParagraphDto.SectionId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteSectionParagraph(SectionParagraphRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionParagraphDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionParagraphDto>.ValidateAttributes("ParagraphId", request.SectionParagraphDto.ParagraphId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindSectionParagraph(SectionParagraphRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionParagraphDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindSectionParagraphDto)
                {
                    case FindSectionParagraphDto.SectionId:
                        errors.AddRange(GenericValidationAttribute<SectionTranslationDto>.ValidateAttributes("SectionId", request.SectionParagraphDto.SectionId.ToString()));
                        break;
                    case FindSectionParagraphDto.SectionParagraphId:
                        errors.AddRange(GenericValidationAttribute<SectionParagraphDto>.ValidateAttributes("ParagraphId", request.SectionParagraphDto.ParagraphId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion

        #region publics methods translation paragraph 
        /// <summary>
        /// Create new SectionParagraphTraslation
        /// </summary>
        /// <returns>SectionParagraphTraslation message.</returns>
        [Route("CreateSectionParagraphTranslation")]
        public IHttpActionResult CreateSectionParagraphTranslation(SectionParagraphTranslationRequest request)
        {
            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            List<string> errors = ValidateCreateSectionParagraphTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionParagraphTraslationClient.CreateSectionParagraphTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new SectionParagraphTraslation range
        /// </summary>
        /// <returns>SectionParagraphTraslation message.</returns>
        [Route("CreateSectionParagraphTranslationRange")]
        public IHttpActionResult CreateSectionParagraphTranslationRange(SectionParagraphTranslationRequest request)
        {
            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            List<string> errors = ValidateCreateSectionParagraphTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionParagraphTraslationClient.CreateSectionParagraphTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change SectionParagraphTraslation informations.
        /// </summary>
        /// <returns>SectionParagraphTraslation message.</returns>
        [Route("UpdateSectionParagraphTranslation")]
        public IHttpActionResult UpdateSectionParagraphTranslation(SectionParagraphTranslationRequest request)
        {
            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            List<string> errors = ValidateUpdateSectionParagraphTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionParagraphTraslationClient.UpdateSectionParagraphTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change SectionParagraphTraslation informations.
        /// </summary>
        /// <returns>SectionParagraphTraslation message.</returns>
        [Route("UpdateSectionParagraphTranslationRange")]
        public IHttpActionResult UpdateSectionParagraphTranslationRange(SectionParagraphTranslationRequest request)
        {
            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            List<string> errors = ValidateUpdateSectionParagraphTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionParagraphTraslationClient.UpdateSectionParagraphTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete SectionParagraphTraslation
        /// </summary>
        /// <returns>SectionParagraphTraslation message.</returns>
        [Route("DeleteSectionParagraphTranslation")]
        public IHttpActionResult DeleteSectionParagraphTranslation(int translationId)
        {
            SectionParagraphTranslationRequest request = new SectionParagraphTranslationRequest
            {
                SectionParagraphTranslationDto = new SectionParagraphTranslationDto { TranslationId = translationId },
                FindSectionParagraphTranslationDto = FindSectionParagraphTranslationDto.SectionParagraphTranslationId
            };

            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            List<string> errors = ValidateDeleteSectionParagraphTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionParagraphTraslationClient.DeleteSectionParagraphTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of SectionParagraphTraslation
        /// </summary>
        /// <returns>SectionParagraphTraslation message.</returns>
        [Route("GetSectionParagraphTranslations")]
        public IHttpActionResult GetAllSectionParagraphTranslations()
        {
            SectionParagraphTranslationMessage message = _serviceSectionParagraphTraslationClient.GetAllSectionParagraphTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find SectionParagraphTraslation
        /// </summary>
        /// <returns>SectionParagraphTraslation message.</returns>
        [Route("FindSectionParagraphTranslations")]
        public IHttpActionResult FindSectionParagraphTranslations(SectionParagraphTranslationRequest request)
        {
            SectionParagraphTranslationMessage message = new SectionParagraphTranslationMessage();
            List<string> errors = ValidateFindSectionParagraphTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionParagraphTraslationClient.FindSectionParagraphTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region validate private methods translation paragraph
        /// <summary>
        /// Validate Create Section Paragraph Traslation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSectionParagraphTranslation(SectionParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionParagraphTranslationDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes(
                    "ParagraphDescription", request.SectionParagraphTranslationDto.ParagraphDescription));
                errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes(
                    "ParagraphId", request.SectionParagraphTranslationDto.ParagraphId.ToString()));
                errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes(
                    "LanguageId", request.SectionParagraphTranslationDto.LanguageId.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes("ParagraphTitle",
                        request.SectionParagraphTranslationDto.ParagraphTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate Create Section Paragraph Traslation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSectionParagraphTranslationRange(SectionParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionParagraphTranslationDtoList == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.SectionParagraphTranslationDtoList)
                {
                    errors.AddRange(
                        GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes(
                            "ParagraphDescription", translation.ParagraphDescription));
                    errors.AddRange(
                        GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes("ParagraphId",
                            translation.ParagraphId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes("LanguageId",
                            translation.LanguageId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes("ParagraphTitle",
                            translation.ParagraphTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update Section Paragraph Translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSectionParagraphTranslation(SectionParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionParagraphTranslationDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes(
                    "ParagraphDescription", request.SectionParagraphTranslationDto.ParagraphDescription));
                errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes(
                    "TranslationId", request.SectionParagraphTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes(
                    "ParagraphId", request.SectionParagraphTranslationDto.ParagraphId.ToString()));
                errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes(
                    "LanguageId", request.SectionParagraphTranslationDto.LanguageId.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes("ParagraphTitle",
                        request.SectionParagraphTranslationDto.ParagraphTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate update Section Paragraph Translation Range.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSectionParagraphTranslationRange(SectionParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionParagraphTranslationDtoList == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.SectionParagraphTranslationDtoList)
                {
                    errors.AddRange(
                        GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes(
                            "ParagraphDescription", translation.ParagraphDescription));
                    errors.AddRange(
                        GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes("TranslationId",
                            translation.TranslationId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes("ParagraphId",
                            translation.ParagraphId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes("LanguageId",
                            translation.LanguageId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes("ParagraphTitle",
                            translation.ParagraphTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate delete Section Paragraph Translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteSectionParagraphTranslation(SectionParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionParagraphTranslationDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes(
                    "TranslationId", request.SectionParagraphTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate Find Section Paragraph Translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindSectionParagraphTranslation(SectionParagraphTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionParagraphTranslationDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindSectionParagraphTranslationDto)
                {
                    case FindSectionParagraphTranslationDto.SectionParagraphTranslationId:
                        errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes("TranslationId", request.SectionParagraphTranslationDto.TranslationId.ToString()));
                        break;
                    case FindSectionParagraphTranslationDto.SectionParagraphId:
                        errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationDto>.ValidateAttributes("ParagraphId", request.SectionParagraphTranslationDto.ParagraphId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion


        #region publics methods file section

        /// <summary>
        /// Create new SectionFile.
        /// </summary>
        /// <returns>SectionFile message.</returns>
        [Route("CreateSectionFile")]
        public IHttpActionResult CreateSectionFile(SectionFileRequest request)
        {
            SectionFileMessage message = new SectionFileMessage();
            List<string> errors = ValidateCreateSectionFile(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionFileClient.CreateSectionFile(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change SectionFile informations.
        /// </summary>
        /// <returns>SectionFile message.</returns>
        [Route("UpdateSectionFile")]
        public IHttpActionResult UpdateSectionFile(SectionFileRequest request)
        {
            SectionFileMessage message = new SectionFileMessage();
            List<string> errors = ValidateUpdateSectionFile(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionFileClient.UpdateSectionFile(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete SectionFile.
        /// </summary>
        /// <returns>SectionFile message.</returns>
        [Route("RemoveSectionFile")]
        public IHttpActionResult DeleteSectionFile(int fileId)
        {
            SectionFileRequest request = new SectionFileRequest { SectionFileDto = new SectionFileDto { SectionFileId = fileId } };
            SectionFileMessage message = new SectionFileMessage();
            List<string> errors = ValidateDeleteSectionFile(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionFileClient.DeleteSectionFile(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of SectionFile.
        /// </summary>
        /// <returns>SectionFile message.</returns>
        [Route("GetSectionFiles")]
        public IHttpActionResult GetAllSectionFiles()
        {
            SectionFileMessage message = _serviceSectionFileClient.GetAllSectionFiles();
            return Json(message);
        }

        /// <summary>
        /// Find SectionFile.
        /// </summary>
        /// <returns>SectionFile message.</returns>
        [Route("FindSectionFiles")]
        public IHttpActionResult FindSectionFiles(SectionFileRequest request)
        {
            SectionFileMessage message = new SectionFileMessage();
            List<string> errors = ValidateFindSectionFile(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionFileClient.FindSectionFiles(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation methods file section

        /// <summary>
        /// Validate create section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSectionFile(SectionFileRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionFileDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionFileDto>.ValidateAttributes("SectionId", request.SectionFileDto.SectionId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSectionFile(SectionFileRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionFileDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionFileDto>.ValidateAttributes("SectionFileId", request.SectionFileDto.SectionFileId.ToString()));
                errors.AddRange(GenericValidationAttribute<SectionFileDto>.ValidateAttributes("SectionId", request.SectionFileDto.SectionId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteSectionFile(SectionFileRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionFileDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionFileDto>.ValidateAttributes("SectionFileId", request.SectionFileDto.SectionFileId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete section translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindSectionFile(SectionFileRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionFileDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindSectionFileDto)
                {
                    case FindSectionFileDto.SectionFileId:
                        errors.AddRange(GenericValidationAttribute<SectionFileDto>.ValidateAttributes("SectionFileId", request.SectionFileDto.SectionFileId.ToString()));
                        break;
                    case FindSectionFileDto.SectionId:
                        errors.AddRange(GenericValidationAttribute<SectionFileDto>.ValidateAttributes("SectionId", request.SectionFileDto.SectionId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion

        #region public methods file section translation

        /// <summary>
        /// Create new SectionFileTranslation
        /// </summary>
        /// <returns>SectionFileTranslation message.</returns>
        [Route("CreateSectionFileTranslation")]
        public IHttpActionResult CreateSectionFileTranslation(SectionFileTranslationRequest request)
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            List<string> errors = ValidateCreateSectionFileTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionFileTranslationClient.CreateSectionFileTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new SectionFileTranslation List
        /// </summary>
        /// <returns>SectionFileTranslation message.</returns>
        [Route("CreateSectionFileTranslationRange")]
        public IHttpActionResult CreateSectionFileTranslationRange(SectionFileTranslationRequest request)
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            List<string> errors = ValidateCreateSectionFileTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionFileTranslationClient.CreateSectionFileTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change SectionFileTranslation informations.
        /// </summary>
        /// <returns>SectionFileTranslation message.</returns>
        [Route("UpdateSectionFileTranslation")]
        public IHttpActionResult UpdateSectionFileTranslation(SectionFileTranslationRequest request)
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            List<string> errors = ValidateUpdateSectionFileTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionFileTranslationClient.UpdateSectionFileTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change SectionFileTranslation informations Range.
        /// </summary>
        /// <returns>SectionFileTranslation message.</returns>
        [Route("UpdateSectionFileTranslationRange")]
        public IHttpActionResult UpdateSectionFileTranslationRange(SectionFileTranslationRequest request)
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            List<string> errors = ValidateUpdateSectionFileTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionFileTranslationClient.UpdateSectionFileTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete SectionFileTranslation
        /// </summary>
        /// <returns>SectionFileTranslation message.</returns>
        [Route("RemoveSectionFileTranslation")]
        public IHttpActionResult DeleteSectionFileTranslation(SectionFileTranslationRequest request)
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            List<string> errors = ValidateDeleteSectionFileTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionFileTranslationClient.DeleteSectionFileTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of SectionFileTranslation
        /// </summary>
        /// <returns>SectionFileTranslation message.</returns>
        [Route("GetSectionFileTranslations")]
        public IHttpActionResult GetAllSectionFileTranslations()
        {
            SectionFileTranslationMessage message = _serviceSectionFileTranslationClient.GetAllSectionFileTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find SectionFileTranslation
        /// </summary>
        /// <returns>SectionFileTranslation message.</returns>
        [Route("FindSectionFileTranslations")]
        public IHttpActionResult FindSectionFileTranslations(SectionFileTranslationRequest request)
        {
            SectionFileTranslationMessage message = new SectionFileTranslationMessage();
            List<string> errors = ValidateFindSectionFileTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = SectionMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSectionFileTranslationClient.FindSectionFileTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation methods file section translation

        /// <summary>
        /// Validate create section file translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSectionFileTranslation(SectionFileTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionFileTranslationDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("SectionFileId", request.SectionFileTranslationDto.SectionFileId.ToString()));
                errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("SectionFileText", request.SectionFileTranslationDto.SectionFileText));
                errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("LanguageId", request.SectionFileTranslationDto.LanguageId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate create section file translation range.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSectionFileTranslationRange(SectionFileTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionFileTranslationDtoList == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.SectionFileTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("SectionFileId", translation.SectionFileId.ToString()));
                    errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("SectionFileText", translation.SectionFileText));
                    errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update section file translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSectionFileTranslation(SectionFileTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionFileTranslationDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("SectionFileId", request.SectionFileTranslationDto.SectionFileId.ToString()));
                errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("TranslationId", request.SectionFileTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("SectionFileText", request.SectionFileTranslationDto.SectionFileText));
                errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("LanguageId", request.SectionFileTranslationDto.LanguageId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update section file translation range.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSectionFileTranslationRange(SectionFileTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionFileTranslationDtoList == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.SectionFileTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("SectionFileId", translation.SectionFileId.ToString()));
                    errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("TranslationId", translation.TranslationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("SectionFileText", translation.SectionFileText));
                    errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate delete section file translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteSectionFileTranslation(SectionFileTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionFileTranslationDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("TranslationId", request.SectionFileTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find section file translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindSectionFileTranslation(SectionFileTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SectionFileTranslationDto == null)
            {
                errors.Add(SectionMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindSectionFileTranslationDto)
                {
                    case FindSectionFileTranslationDto.SectionFileId:
                        errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("SectionFileId", request.SectionFileTranslationDto.SectionFileId.ToString()));
                        break;
                    case FindSectionFileTranslationDto.SectionFileTranslationId:
                        errors.AddRange(GenericValidationAttribute<SectionFileTranslationDto>.ValidateAttributes("TranslationId", request.SectionFileTranslationDto.TranslationId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion
    }
}