using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Message;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Request;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Ressource;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Riafco.WebApi.Dataflex.pro.Controllers.Offices
{
    /// <summary>
    /// The Country web api controller.
    /// </summary>
    [RoutePrefix("api/Offices")]
    public class OfficeController : ApiController
    {
        #region private properties
        /// <summary>
        /// The Country service client instance.
        /// </summary>
        private readonly IServiceCountryClient _serviceCountryClient;

        /// <summary>
        /// The CountryTranslation service client instance.
        /// </summary>
        private readonly IServiceCountryTranslationClient _serviceCountryTranslationClient;

        /// <summary>
        /// The Sheet service client instance.
        /// </summary>
        private readonly IServiceSheetClient _serviceSheetClient;

        /// <summary>
        /// The SheetTranslation service client instance.
        /// </summary>
        private readonly IServiceSheetTranslationClient _serviceSheetTranslationClient;

        #endregion

        #region constructor

        /// <summary>
        /// Set the IServiceCountryClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceCountryClient">injected instance</param>
        /// <param name="serviceCountryTranslationClient"></param>
        /// <param name="serviceSheetClient"></param>
        /// <param name="serviceSheetTranslationClient"></param>
        public OfficeController(IServiceCountryClient injectedServiceCountryClient, IServiceCountryTranslationClient serviceCountryTranslationClient, IServiceSheetClient serviceSheetClient, IServiceSheetTranslationClient serviceSheetTranslationClient)
        {
            _serviceCountryClient = injectedServiceCountryClient;
            _serviceCountryTranslationClient = serviceCountryTranslationClient;
            _serviceSheetClient = serviceSheetClient;
            _serviceSheetTranslationClient = serviceSheetTranslationClient;
        }
        #endregion

        #region public methods : country

        /// <summary>
        /// Create new Country
        /// </summary>
        /// <returns>Country message.</returns>
        [Route("CreateCountry")]
        public IHttpActionResult CreateCountry(CountryRequest request)
        {
            List<string> errors = ValidateCreateCountry(request);
            CountryMessage message = new CountryMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceCountryClient.CreateCountry(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change Country informations.
        /// </summary>
        /// <returns>Country message.</returns>
        [Route("UpdateCountry")]
        public IHttpActionResult UpdateCountry(CountryRequest request)
        {
            List<string> errors = ValidateUpdateCountry(request);
            CountryMessage message = new CountryMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceCountryClient.UpdateCountry(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <returns>Country message.</returns>
        [Route("RemoveCountry")]
        public IHttpActionResult DeleteCountry(int countryId)
        {
            CountryRequest request = new CountryRequest
            {
                CountryDto = new CountryDto { CountryId = countryId }
            };
            List<string> errors = ValidateDeleteCountry(request);
            CountryMessage message = new CountryMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceCountryClient.DeleteCountry(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Country
        /// </summary>
        /// <returns>Country message.</returns>
        [Route("GetCountries")]
        public IHttpActionResult GetAllCountries()
        {
            CountryMessage message = _serviceCountryClient.GetAllCountries();
            return Json(message);
        }

        /// <summary>
        /// Find Country
        /// </summary>
        /// <returns>Country message.</returns>
        [Route("FindCountries")]
        public IHttpActionResult FindCountries(CountryRequest request)
        {
            List<string> errors = ValidateFindCountries(request);
            CountryMessage message = new CountryMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceCountryClient.FindCountries(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation country methods
        /// <summary>
        /// Validation creation country.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateCountry(CountryRequest request)
        {
            var errors = new List<string>();
            if (request?.CountryDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<CountryDto>.ValidateAttributes("CountryImage",
                    request.CountryDto.CountryImage.ToString()));
            }

            return errors;
        }

        /// <summary>
        /// Validation update country.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateCountry(CountryRequest request)
        {
            var errors = new List<string>();
            if (request?.CountryDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<CountryDto>.ValidateAttributes("CountryId",
                    request.CountryDto.CountryId.ToString()));
            }

            return errors;
        }

        /// <summary>
        /// Validation delete country.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteCountry(CountryRequest request)
        {
            var errors = new List<string>();
            if (request?.CountryDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<CountryDto>.ValidateAttributes("CountryId",
                    request.CountryDto.CountryId.ToString()));
            }

            return errors;
        }

        /// <summary>
        /// Validation delete country.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindCountries(CountryRequest request)
        {
            var errors = new List<string>();
            if (request?.CountryDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindCountryDto)
                {
                    case FindCountryDto.CountryId:
                        errors.AddRange(GenericValidationAttribute<CountryDto>.ValidateAttributes("CountryId",
                            request.CountryDto.CountryId.ToString()));
                        break;
                    case FindCountryDto.CountryCode:
                        errors.AddRange(GenericValidationAttribute<CountryDto>.ValidateAttributes("CountryCode",
                            request.CountryDto.CountryCode.ToString()));
                        break;
                    case FindCountryDto.CountryShortName:
                        errors.AddRange(GenericValidationAttribute<CountryDto>.ValidateAttributes("CountryShortName",
                            request.CountryDto.CountryShortName));
                        break;

                }

            }

            return errors;
        }
        #endregion

        #region public methods : countryTranslation

        /// <summary>
        /// Create new CountryTranslation
        /// </summary>
        /// <returns>CountryTranslation message.</returns>
        [Route("CreateCountryTranslation")]
        public IHttpActionResult CreateCountryTranslation(CountryTranslationRequest request)
        {
            List<string> errors = ValidateCreateCountryTranslation(request);
            CountryTranslationMessage message = new CountryTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceCountryTranslationClient.CreateCountryTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new CountryTranslation
        /// </summary>
        /// <returns>CountryTranslation message.</returns>
        [Route("CreateCountryTranslationRange")]
        public IHttpActionResult CreateCountryTranslationRange(CountryTranslationRequest request)
        {
            List<string> errors = ValidateCreateCountryTranslationRange(request);
            CountryTranslationMessage message = new CountryTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceCountryTranslationClient.CreateCountryTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change CountryTranslation informations.
        /// </summary>
        /// <returns>CountryTranslation message.</returns>
        [Route("UpdateCountryTranslation")]
        public IHttpActionResult UpdateCountryTranslation(CountryTranslationRequest request)
        {
            List<string> errors = ValidateUpdateCountryTranslation(request);
            CountryTranslationMessage message = new CountryTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceCountryTranslationClient.UpdateCountryTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change CountryTranslation informations.
        /// </summary>
        /// <returns>CountryTranslation message.</returns>
        [Route("UpdateCountryTranslationRange")]
        public IHttpActionResult UpdateCountryTranslationRange(CountryTranslationRequest request)
        {
            List<string> errors = ValidateUpdateCountryTranslationRange(request);
            CountryTranslationMessage message = new CountryTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceCountryTranslationClient.UpdateCountryTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete CountryTranslation
        /// </summary>
        /// <returns>CountryTranslation message.</returns>
        [Route("RemoveCountryTranslation")]
        public IHttpActionResult DeleteCountryTranslation(int translationId)
        {
            CountryTranslationRequest request = new CountryTranslationRequest
            {
                CountryTranslationDto = new CountryTranslationDto
                {
                    TranslationId = translationId
                }
            };

            List<string> errors = ValidateDeleteCountryTranslation(request);
            CountryTranslationMessage message = new CountryTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceCountryTranslationClient.DeleteCountryTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of CountryTranslation
        /// </summary>
        /// <returns>CountryTranslation message.</returns>
        [Route("GetCountryTranslations")]
        public IHttpActionResult GetAllCountryTranslations()
        {
            CountryTranslationMessage message = _serviceCountryTranslationClient.GetAllCountryTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find CountryTranslation
        /// </summary>
        /// <returns>CountryTranslation message.</returns>
        [Route("FindCountryTranslations")]
        public IHttpActionResult FindCountryTranslations(CountryTranslationRequest request)
        {
            List<string> errors = ValidateFindCountryTranslations(request);
            CountryTranslationMessage message = new CountryTranslationMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceCountryTranslationClient.FindCountryTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region private translate country methods
        /// <summary>
        /// Validate create country translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateCountryTranslation(CountryTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.CountryTranslationDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountrySummary",
                    request.CountryTranslationDto.CountrySummary));
                errors.AddRange(
                    GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryDescription",
                        request.CountryTranslationDto.CountryDescription));
                errors.AddRange(GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryId",
                    request.CountryTranslationDto.CountryId.ToString()));
                errors.AddRange(GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("LanguageId",
                    request.CountryTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryTitle",
                    request.CountryTranslationDto.CountryTitle));
                errors.AddRange(GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryName",
                    request.CountryTranslationDto.CountryName));
            }

            return errors;
        }

        /// <summary>
        /// Validate create country translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateCountryTranslationRange(CountryTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.CountryTranslationDtoList == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.CountryTranslationDtoList)
                {
                    errors.AddRange(
                        GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountrySummary",
                            translation.CountrySummary));
                    errors.AddRange(
                        GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryDescription",
                            translation.CountryDescription));
                    errors.AddRange(
                        GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("LanguageId",
                            translation.LanguageId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryId",
                            translation.CountryId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryTitle",
                            translation.CountryTitle));
                    errors.AddRange(
                        GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryName",
                            translation.CountryName));
                }
            }

            return errors;
        }

        /// <summary>
        /// Validate update country translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateCountryTranslation(CountryTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.CountryTranslationDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountrySummary",
                    request.CountryTranslationDto.CountrySummary));
                errors.AddRange(
                    GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryDescription",
                        request.CountryTranslationDto.CountryDescription));
                errors.AddRange(GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("TranslationId",
                    request.CountryTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryTitle",
                    request.CountryTranslationDto.CountryTitle));
                errors.AddRange(GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryName",
                    request.CountryTranslationDto.CountryName));
            }

            return errors;
        }

        /// <summary>
        /// Validate update country translation list.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateCountryTranslationRange(CountryTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.CountryTranslationDtoList == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.CountryTranslationDtoList)
                {
                    errors.AddRange(
                        GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountrySummary",
                            translation.CountrySummary));
                    errors.AddRange(
                        GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryDescription",
                            translation.CountryDescription));
                    errors.AddRange(
                        GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("TranslationId",
                            translation.TranslationId.ToString()));
                    errors.AddRange(
                        GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryTitle",
                            translation.CountryTitle));
                    errors.AddRange(
                        GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryName",
                            translation.CountryName));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate find country translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindCountryTranslations(CountryTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.CountryTranslationDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindCountryTranslationDto)
                {
                    case FindCountryTranslationDto.CountryId:
                        errors.AddRange(
                            GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryId",
                                request.CountryTranslationDto.CountryId.ToString()));
                        break;
                    case FindCountryTranslationDto.CountryTranslationId:
                        errors.AddRange(GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes(
                            "TranslationId", request.CountryTranslationDto.TranslationId.ToString()));
                        break;
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate find country translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteCountryTranslation(CountryTranslationRequest request)
        {
            var errors = new List<string>();
            if (request?.CountryTranslationDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("TranslationId",
                    request.CountryTranslationDto.TranslationId.ToString()));
            }

            return errors;
        }
        #endregion

        #region public methods country sheet

        /// <summary>
        /// Create new Sheet
        /// </summary>
        /// <returns>Sheet message.</returns>
        [Route("CreateSheet")]
        public IHttpActionResult CreateSheet(SheetRequest request)
        {
            SheetMessage message = new SheetMessage();
            List<string> errors = ValidateCreateSheet(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSheetClient.CreateSheet(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change Sheet informations.
        /// </summary>
        /// <returns>Sheet message.</returns>
        [Route("UpdateSheet")]
        public IHttpActionResult UpdateSheet(SheetRequest request)
        {
            SheetMessage message = new SheetMessage();
            List<string> errors = ValidateUpdateSheet(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSheetClient.UpdateSheet(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Sheet
        /// </summary>
        /// <returns>Sheet message.</returns>
        [Route("RemoveSheet")]
        public IHttpActionResult DeleteSheet(int sheetId)
        {
            SheetRequest request = new SheetRequest
            {
                SheetDto = new SheetDto { SheetId = sheetId },
                FindSheetDto = FindSheetDto.SheetId
            };

            SheetMessage message = new SheetMessage();
            List<string> errors = ValidateDeleteSheet(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSheetClient.DeleteSheet(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Sheet
        /// </summary>
        /// <returns>Sheet message.</returns>
        [Route("GetSheets")]
        public IHttpActionResult GetAllSheets()
        {
            SheetMessage message = _serviceSheetClient.GetAllSheets();
            return Json(message);
        }

        /// <summary>
        /// Find Sheet
        /// </summary>
        /// <returns>Sheet message.</returns>
        [Route("FindSheets")]
        public IHttpActionResult FindSheets(SheetRequest request)
        {
            SheetMessage message = new SheetMessage();
            List<string> errors = ValidateFindSheet(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSheetClient.FindSheets(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation methods sheet

        /// <summary>
        /// Validate create country translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSheet(SheetRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SheetDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SheetDto>.ValidateAttributes("CountryId", request.SheetDto.CountryId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate update country translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSheet(SheetRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SheetDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SheetDto>.ValidateAttributes("SheetId", request.SheetDto.SheetId.ToString()));
                errors.AddRange(GenericValidationAttribute<SheetDto>.ValidateAttributes("CountryId", request.SheetDto.CountryId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate delete country translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteSheet(SheetRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SheetDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SheetDto>.ValidateAttributes("SheetId", request.SheetDto.SheetId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find country translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindSheet(SheetRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SheetDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindSheetDto)
                {
                    case FindSheetDto.CountryId:
                        errors.AddRange(GenericValidationAttribute<CountryTranslationDto>.ValidateAttributes("CountryId", request.SheetDto.CountryId.ToString()));
                        break;
                    case FindSheetDto.SheetId:
                        errors.AddRange(GenericValidationAttribute<SheetDto>.ValidateAttributes("SheetId", request.SheetDto.SheetId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion

        #region publics methods translation sheet 
        /// <summary>
        /// Create new SheetTraslation
        /// </summary>
        /// <returns>SheetTraslation message.</returns>
        [Route("CreateSheetTranslation")]
        public IHttpActionResult CreateSheetTranslation(SheetTranslationRequest request)
        {
            SheetTranslationMessage message = new SheetTranslationMessage();
            List<string> errors = ValidateCreateSheetTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSheetTranslationClient.CreateSheetTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Create new SheetTraslation range
        /// </summary>
        /// <returns>SheetTraslation message.</returns>
        [Route("CreateSheetTranslationRange")]
        public IHttpActionResult CreateSheetTranslationRange(SheetTranslationRequest request)
        {
            SheetTranslationMessage message = new SheetTranslationMessage();
            List<string> errors = ValidateCreateSheetTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSheetTranslationClient.CreateSheetTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change SheetTraslation informations.
        /// </summary>
        /// <returns>SheetTraslation message.</returns>
        [Route("UpdateSheetTranslation")]
        public IHttpActionResult UpdateSheetTranslation(SheetTranslationRequest request)
        {
            SheetTranslationMessage message = new SheetTranslationMessage();
            List<string> errors = ValidateUpdateSheetTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSheetTranslationClient.UpdateSheetTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change SheetTraslation informations.
        /// </summary>
        /// <returns>SheetTraslation message.</returns>
        [Route("UpdateSheetTranslationRange")]
        public IHttpActionResult UpdateSheetTranslationRange(SheetTranslationRequest request)
        {
            SheetTranslationMessage message = new SheetTranslationMessage();
            List<string> errors = ValidateUpdateSheetTranslationRange(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSheetTranslationClient.UpdateSheetTranslationRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete SheetTraslation
        /// </summary>
        /// <returns>SheetTraslation message.</returns>
        [Route("DeleteSheetTranslation")]
        public IHttpActionResult DeleteSheetTranslation(int translationId)
        {
            SheetTranslationRequest request = new SheetTranslationRequest
            {
                SheetTranslationDto = new SheetTranslationDto { TranslationId = translationId },
                FindSheetTranslationDto = FindSheetTranslationDto.SheetTranslationId
            };

            SheetTranslationMessage message = new SheetTranslationMessage();
            List<string> errors = ValidateDeleteSheetTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSheetTranslationClient.DeleteSheetTranslation(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of SheetTraslation
        /// </summary>
        /// <returns>SheetTraslation message.</returns>
        [Route("GetSheetTranslations")]
        public IHttpActionResult GetAllSheetTranslations()
        {
            SheetTranslationMessage message = _serviceSheetTranslationClient.GetAllSheetTranslations();
            return Json(message);
        }

        /// <summary>
        /// Find SheetTraslation
        /// </summary>
        /// <returns>SheetTraslation message.</returns>
        [Route("FindSheetTranslations")]
        public IHttpActionResult FindSheetTranslations(SheetTranslationRequest request)
        {
            SheetTranslationMessage message = new SheetTranslationMessage();
            List<string> errors = ValidateFindSheetTranslation(request);

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = CountryMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceSheetTranslationClient.FindSheetTranslations(request);
            }
            return Json(message);
        }
        #endregion

        #region validate private methods translation sheet
        /// <summary>
        /// Validate Create Country Sheet Traslation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSheetTranslation(SheetTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SheetTranslationDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetValue", request.SheetTranslationDto.SheetValue));
                errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetId", request.SheetTranslationDto.SheetId.ToString()));
                errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("LanguageId", request.SheetTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetTitle", request.SheetTranslationDto.SheetTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate Create Country Sheet Traslation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateSheetTranslationRange(SheetTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SheetTranslationDtoList == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.SheetTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetValue", translation.SheetValue));
                    errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetId", translation.SheetId.ToString()));
                    errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetTitle", translation.SheetTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate update Country Sheet Translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSheetTranslation(SheetTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SheetTranslationDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetValue", request.SheetTranslationDto.SheetValue));
                errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("TranslationId", request.SheetTranslationDto.TranslationId.ToString()));
                errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetId", request.SheetTranslationDto.SheetId.ToString()));
                errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("LanguageId", request.SheetTranslationDto.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetTitle", request.SheetTranslationDto.SheetTitle));
            }
            return errors;
        }

        /// <summary>
        /// Validate update Country Sheet Translation Range.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateSheetTranslationRange(SheetTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SheetTranslationDtoList == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                foreach (var translation in request.SheetTranslationDtoList)
                {
                    errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetValue", translation.SheetValue));
                    errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("TranslationId", translation.TranslationId.ToString()));
                    errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetId", translation.SheetId.ToString()));
                    errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("LanguageId", translation.LanguageId.ToString()));
                    errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetTitle", translation.SheetTitle));
                }
            }
            return errors;
        }

        /// <summary>
        /// Validate delete Country Sheet Translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteSheetTranslation(SheetTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SheetTranslationDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("TranslationId", request.SheetTranslationDto.TranslationId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate Find Country Sheet Translation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindSheetTranslation(SheetTranslationRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.SheetTranslationDto == null)
            {
                errors.Add(CountryMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindSheetTranslationDto)
                {
                    case FindSheetTranslationDto.SheetTranslationId:
                        errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("TranslationId", request.SheetTranslationDto.TranslationId.ToString()));
                        break;
                    case FindSheetTranslationDto.SheetId:
                        errors.AddRange(GenericValidationAttribute<SheetTranslationDto>.ValidateAttributes("SheetId", request.SheetTranslationDto.SheetId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion
    }
}