using Admin.Riafco.Dataflex.Pro.Authorization;
using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.Offices.Assembler;
using Admin.Riafco.Dataflex.Pro.Models.Offices.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.Offices.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ResultData;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ViewData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ResultData;
using Riafco.Framework.Dataflex.pro.Web.ActionResult;
using Riafco.Framework.Dataflex.pro.Web.AjaxComponent;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Admin.Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// Office controller.
    /// </summary>
    public class OfficesController : Controller
    {
        /// <summary>
        /// The index page.
        /// </summary>
        /// Countries Index Action
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            if (Session["ConnectedUser"] == null) { return RedirectToAction("Index", "Home"); }
            bool isAuthorizedUser = await AuthorizeUserAttribute.Authorize("A_OFFICES");
            if (!isAuthorizedUser) return RedirectToAction("NoAccess", "Errors");
            CountriesViewData countriesViewData = new CountriesViewData { Countries = await GetCountriesList() };
            ViewBag.Offices = "active";
            return View(countriesViewData);
        }

        /// <summary>
        /// Get countries List
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetCountries()
        {
            CountriesViewData countriesViewData = new CountriesViewData { Countries = await GetCountriesList() };
            return View("Partials/_CountriesList", countriesViewData);
        }

        #region CREATE COUNTRY 

        /// <summary>
        /// Get country form to create.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetCreateCountry()
        {
            CreateCountryFormData countryFormData =
                new CreateCountryFormData { TranslationsList = new List<CountryTranslationFormData>() };
            LanguageResultData result =
                await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages,
                    Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new CountryTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId,
                    };
                    countryFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateCountry";
            return PartialView("Partials/_CreateCountry", countryFormData);
        }


        /// <summary>
        /// Create Country Action
        /// </summary>
        /// <param name="countryFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateCountry(CreateCountryFormData countryFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                CountryRequestData request = countryFormData.ToRequestData();
                if (request.CountryDto.CountryImage == null)
                {
                    request.CountryDto.CountryImage = "default-image-country.jpg";
                }

                CountryResultData result =
                    await WebApiClient.PostFormJsonAsync<CountryRequestData, CountryResultData>(
                        Constant.WebApiControllerOffices, Constant.WebApiCreateCountry, request);
                if (result != null && result.OperationSuccess && result.CountryDto != null)
                {
                    foreach (var translation in countryFormData.TranslationsList.ToList())
                    {
                        translation.CountryId = result.CountryDto.CountryId;
                    }
                    CountryTranslationRequestData translationRequest = new CountryTranslationRequestData
                    {
                        CountryTranslationDtoList = countryFormData.TranslationsList.ToItemDataList()
                    };

                    CountryTranslationResultData countryTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<CountryTranslationRequestData, CountryTranslationResultData>(
                                Constant.WebApiControllerOffices, Constant.WebApiCreateCountryTranslationRange,
                                translationRequest);
                    if (countryTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!countryTranslationResultData.OperationSuccess && countryTranslationResultData.Errors != null && countryTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = countryTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (countryTranslationResultData.OperationSuccess)
                    {

                        Directory.CreateDirectory(
                            Server.MapPath($"~/Images/Countries/" + result.CountryDto.CountryId));

                        countryFormData.CountryImage?.SaveAs(
                            Server.MapPath($"~/Images/Countries/" + result.CountryDto.CountryId + $"/") +
                            countryFormData.CountryImage?.FileName);

                        System.IO.File.Copy(Server.MapPath($"~/Images/Default/default-image-country.jpg"),
                            Server.MapPath($"~/Images/Countries/" + result.CountryDto.CountryId +
                                           $"/default-image-country.jpg"));
                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (result == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!result.OperationSuccess && result.Errors != null && result.Errors.Count > 0)
                {
                    data.ErrorMessage = result.Errors.First();
                    data.OperationSuccess = false;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = CountryResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region UPDATE COUNTRY

        /// <summary>
        /// Get Country Model for Update
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetUpdateCountry(int? countryId)
        {
            UpdateCountryFormData countryFormData = new UpdateCountryFormData
            {
                TranslationsList = new List<CountryTranslationFormData>()
            };

            if (countryId.HasValue)
            {
                CountryRequestData findCountryRequest = new CountryRequestData
                {
                    CountryDto = new CountryItemData { CountryId = countryId.Value },
                    FindCountryDto = FindCountryItemData.CountryId
                };
                CountryResultData resultCountry =
                    await WebApiClient.PostFormJsonAsync<CountryRequestData, CountryResultData>(
                        Constant.WebApiControllerOffices, Constant.WebApiFindCountries, findCountryRequest);

                if (resultCountry != null && resultCountry.OperationSuccess && resultCountry.CountryDto != null)
                {
                    countryFormData = resultCountry.CountryDto.ToUpdateFormData();
                    CountryTranslationRequestData findCountryTranslationRequest = new CountryTranslationRequestData()
                    {
                        CountryTranslationDto = new CountryTranslationItemData { CountryId = countryId.Value },
                        FindCountryTranslationDto = FindCountryTranslationItemData.CountryId
                    };
                    CountryTranslationResultData resultCountryTranslation =
                        await WebApiClient
                            .PostFormJsonAsync<CountryTranslationRequestData, CountryTranslationResultData>(
                                Constant.WebApiControllerOffices, Constant.WebApiFindCountryTranslations,
                                findCountryTranslationRequest);
                    if (resultCountryTranslation != null && resultCountryTranslation.OperationSuccess && resultCountryTranslation.CountryTranslationDtoList != null)
                    {
                        countryFormData.TranslationsList = resultCountryTranslation.CountryTranslationDtoList.ToFormDataList();
                    }
                }
            }
            ViewBag.Action = "UpdateCountry";
            return PartialView("Partials/_UpdateCountry", countryFormData);
        }

        /// <summary>
        /// Update Country Action
        /// </summary>
        /// <param name="countryFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateCountry(UpdateCountryFormData countryFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                CountryRequestData request = countryFormData.ToRequestData();
                CountryResultData countryResult =
                    await WebApiClient.PostFormJsonAsync<CountryRequestData, CountryResultData>(
                        Constant.WebApiControllerOffices, Constant.WebApiUpdateCountry, request);
                if (countryResult != null && countryResult.OperationSuccess)
                {
                    CountryTranslationRequestData countryTranslationRequestData = new CountryTranslationRequestData
                    {
                        CountryTranslationDtoList = countryFormData.TranslationsList.ToItemDataList()
                    };

                    CountryTranslationResultData countryTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<CountryTranslationRequestData, CountryTranslationResultData>(
                                Constant.WebApiControllerOffices, Constant.WebApiUpdateCountryTranslationRange,
                                countryTranslationRequestData);
                    if (countryTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!countryTranslationResultData.OperationSuccess && countryTranslationResultData.Errors != null && countryTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = countryTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (countryTranslationResultData.OperationSuccess)
                    {
                        if (!Directory.Exists(Server.MapPath($"~/Images/Countries/" + countryFormData.CountryId)))
                        {
                            Directory.CreateDirectory(
                                Server.MapPath($"~/Images/Countries/" + countryFormData.CountryId));
                        }

                        countryFormData.CountryImage?.SaveAs(
                            Server.MapPath($"~/Images/Countries/" + countryFormData.CountryId + $"/") +
                            countryFormData.CountryImage?.FileName);

                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (countryResult == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!countryResult.OperationSuccess && countryResult.Errors != null && countryResult.Errors.Count > 0)
                {
                    data.ErrorMessage = countryResult.Errors.First();
                    data.OperationSuccess = false;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = CountryResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region DELETE COUNTRY
        public ActionResult GetDeleteCountry(int countryId)
        {
            return View("Partials/_DeleteCountry", countryId);
        }

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteCountry(int countryId)
        {
            JsonReturnData data = new JsonReturnData();
            if (countryId > 0)
            {
                string param = $"{nameof(countryId)}={countryId}";
                CountryResultData result =
                    await WebApiClient.DeleteAsync<CountryResultData>(Constant.WebApiControllerOffices,
                        Constant.WebApiRemoveCountry, param);
                if (result == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!result.OperationSuccess && result.Errors != null && result.Errors.Count > 0)
                {
                    data.ErrorMessage = result.Errors.First();
                    data.OperationSuccess = false;
                }
                else if (result.OperationSuccess)
                {
                    if (Directory.Exists(Server.MapPath($"~/Images/Countries/" + countryId)))
                    {
                        Directory.Delete(Server.MapPath($"~/Images/Countries/" + countryId), true);
                    }
                    data.SuccessMessage = UserResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data.ErrorMessage = UserResources.RequiredUserId;
                data.OperationSuccess = false;
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region COUNTRY VALIDATION

        /// <summary>
        /// validate create country.
        /// </summary>
        /// <param name="countryFormData">the countryFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateCreateCountryFormData(CreateCountryFormData countryFormData)
        {
            List<string> errors = new List<string>();
            if (countryFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                if (string.IsNullOrEmpty(countryFormData.CountryImageValue)) { errors.Add(CountryResources.RequiredCountryImage); }
                errors.AddRange(GenericValidationAttribute<CreateCountryFormData>.ValidateAttributes("CountryShortName",
                    countryFormData.CountryShortName));
                errors.AddRange(GenericValidationAttribute<CreateCountryFormData>.ValidateAttributes("CountryCode",
                    countryFormData.CountryCode.ToString()));
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// validate create country.
        /// </summary>
        /// <param name="countryFormData">the countryFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateUpdateCountryFormData(UpdateCountryFormData countryFormData)
        {
            List<string> errors = new List<string>();
            if (countryFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<CreateCountryFormData>.ValidateAttributes("CountryId",
                    countryFormData.CountryId.ToString()));
                errors.AddRange(GenericValidationAttribute<CreateCountryFormData>.ValidateAttributes("CountryShortName",
                    countryFormData.CountryShortName));
                errors.AddRange(GenericValidationAttribute<CreateCountryFormData>.ValidateAttributes("CountryCode",
                    countryFormData.CountryCode.ToString()));
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// validate create country translation.
        /// </summary>
        /// <param name="countryTranslationFormData">the countryTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateCountryTranslationFormData(CountryTranslationFormData countryTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (countryTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(
                    GenericValidationAttribute<CountryTranslationFormData>.ValidateAttributes("CountrySummary",
                        countryTranslationFormData.CountrySummary));
                errors.AddRange(
                    GenericValidationAttribute<CountryTranslationFormData>.ValidateAttributes("CountryDescription",
                        countryTranslationFormData.CountryDescription));
                errors.AddRange(GenericValidationAttribute<CountryTranslationFormData>.ValidateAttributes("LanguageId",
                    countryTranslationFormData.LanguageId.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<CountryTranslationFormData>.ValidateAttributes("CountryTitle",
                        countryTranslationFormData.CountryTitle));
                errors.AddRange(GenericValidationAttribute<CountryTranslationFormData>.ValidateAttributes("CountryName",
                    countryTranslationFormData.CountryName));
            }
            return errors.Count == 0;
        }
        #endregion

        #region PRIVATE COUNTRY METHODS

        /// <summary>
        /// Get the countres list.
        /// </summary>
        /// <returns></returns>
        private async Task<List<CountryViewData>> GetCountriesList()
        {
            CountryResultData countryResultData = await WebApiClient.GetAsync<CountryResultData>(Constant.WebApiControllerOffices, Constant.WebApiCountryList);
            List<CountryViewData> countriesList = new List<CountryViewData>();

            if (countryResultData == null || !countryResultData.OperationSuccess ||
                countryResultData.CountryDtoList == null) return countriesList;
            foreach (var countryDto in countryResultData.CountryDtoList)
            {
                CountryViewData country = new CountryViewData
                {
                    TranslationsList = new List<CountryTranslationItemData>(),
                    Country = countryDto
                };
                country.TranslationsList = await GetCountryTranslations(countryDto.CountryId);
                countriesList.Add(country);
            }
            return countriesList;
        }

        /// <summary>
        /// Find the country translations
        /// </summary>
        /// <param name="countryId">the country id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<CountryTranslationItemData>> GetCountryTranslations(int countryId)
        {
            List<CountryTranslationItemData> translationsList = new List<CountryTranslationItemData>();
            CountryTranslationRequestData findCountryTranslationRequest = new CountryTranslationRequestData()
            {
                CountryTranslationDto = new CountryTranslationItemData { CountryId = countryId },
                FindCountryTranslationDto = FindCountryTranslationItemData.CountryId
            };
            CountryTranslationResultData resultCountryTranslation = await WebApiClient.PostFormJsonAsync<CountryTranslationRequestData, CountryTranslationResultData>(Constant.WebApiControllerOffices, Constant.WebApiFindCountryTranslations, findCountryTranslationRequest);
            if (resultCountryTranslation != null && resultCountryTranslation.OperationSuccess && resultCountryTranslation.CountryTranslationDtoList != null)
            {
                translationsList.AddRange(resultCountryTranslation.CountryTranslationDtoList);
            }
            return translationsList;
        }

        #endregion

        #region SHEETS

        /// <summary>
        /// Manage  sheet form.
        /// </summary>
        /// <param name="countryId">the  id</param>
        /// <returns></returns>
        public async Task<ActionResult> GetManageSheets(int countryId)
        {
            SheetsViewData sheetViewData = new SheetsViewData
            {
                Sheets = await GetSheetsList(countryId),
                CountryId = countryId
            };
            return View("Partials/_Sheets", sheetViewData);
        }

        /// <summary>
        /// Return  sheet list.
        /// </summary>
        /// <param name="countryId">the  id</param>
        /// <returns></returns>
        public async Task<ActionResult> GetSheets(int countryId)
        {
            SheetsViewData sheetsViewData = new SheetsViewData
            {
                Sheets = await GetSheetsList(countryId),
                CountryId = countryId
            };
            return View("Partials/_SheetsList", sheetsViewData);
        }
        #endregion

        #region CREATE SHEET

        /// <summary>
        /// Get the view to create  sheet.
        /// </summary>
        /// <param name="countryId">the activivity id</param>
        /// <returns>action view result.</returns>
        public async Task<ActionResult> GetCreateSheet(int countryId)
        {
            SheetFormData sheetFormData = new SheetFormData
            {
                TranslationsList = new List<SheetTranslationFormData>(),
                CountryId = countryId
            };

            LanguageResultData result = await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages, Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new SheetTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId,
                    };
                    sheetFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateSheet";
            return PartialView("Partials/_ManageSheet", sheetFormData);
        }

        /// <summary>
        /// Create sheet.
        /// </summary>
        /// <param name="sheetFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateSheet(SheetFormData sheetFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                SheetRequestData request = sheetFormData.ToRequestData();

                SheetResultData result = await WebApiClient.PostFormJsonAsync<SheetRequestData, SheetResultData>(Constant.WebApiControllerOffices, Constant.WebApiCreateSheet, request);
                if (result != null && result.OperationSuccess && result.SheetDto != null)
                {
                    foreach (var translation in sheetFormData.TranslationsList.ToList())
                    {
                        translation.SheetId = result.SheetDto.SheetId;
                    }

                    SheetTranslationRequestData translationRequest = new SheetTranslationRequestData
                    {
                        SheetTranslationDtoList = sheetFormData.TranslationsList.ToItemDataList(),
                    };

                    SheetTranslationResultData sheetTranslationResultData = await WebApiClient.PostFormJsonAsync<SheetTranslationRequestData, SheetTranslationResultData>(Constant.WebApiControllerOffices, Constant.WebApiCreateSheetTranslationRange, translationRequest);
                    if (sheetTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (sheetTranslationResultData.Errors != null && (!sheetTranslationResultData.OperationSuccess || sheetTranslationResultData.Errors != null || sheetTranslationResultData.Errors.Count > 0))
                    {
                        data.ErrorMessage = sheetTranslationResultData.Errors.FirstOrDefault();
                        data.OperationSuccess = false;
                    }
                    else if (sheetTranslationResultData.OperationSuccess)
                    {
                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (result == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!result.OperationSuccess && result.Errors != null && result.Errors.Count > 0)
                {
                    data.ErrorMessage = result.Errors.First();
                    data.OperationSuccess = false;
                }
                else if (result.OperationSuccess)
                {
                    data.SuccessMessage = UserResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = CountryResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region UPDATE SHEET

        /// <summary>
        /// Get the view to create sheet.
        /// </summary>
        /// <param name="sheetId">the sheet id to update.</param>
        /// <returns>action view result.</returns>
        public async Task<ActionResult> GetUpdateSheet(int sheetId)
        {
            SheetFormData sheetFormData = new SheetFormData
            {
                TranslationsList = new List<SheetTranslationFormData>(),
                SheetId = sheetId
            };

            SheetTranslationRequestData sheetTranslationRequestData = new SheetTranslationRequestData
            {
                SheetTranslationDto = new SheetTranslationItemData { SheetId = sheetId },
                FindSheetTranslationDto = FindSheetTranslationItemData.SheetId
            };

            SheetTranslationResultData sheetTranslation = await WebApiClient.PostFormJsonAsync<SheetTranslationRequestData, SheetTranslationResultData>(Constant.WebApiControllerOffices, Constant.WebApiFindSheetTranslations, sheetTranslationRequestData);
            if (sheetTranslation != null && sheetTranslation.OperationSuccess && sheetTranslation.SheetTranslationDtoList != null)
            {
                foreach (var item in sheetTranslation.SheetTranslationDtoList)
                {
                    sheetFormData.CountryId = item.Sheet?.CountryId;

                    var translation = new SheetTranslationFormData
                    {
                        LanguagePrefix = item.Language?.LanguagePrefix,
                        LanguageId = item.Language?.LanguageId,
                        TranslationId = item.TranslationId,
                        SheetValue = item.SheetValue,
                        SheetTitle = item.SheetTitle,
                        SheetId = item.SheetId
                    };
                    sheetFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "UpdateSheet";
            return PartialView("Partials/_ManageSheet", sheetFormData);
        }

        /// <summary>
        /// Update sheet.
        /// </summary>
        /// <param name="sheetFormData">the sheetFormData to update.</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateSheet(SheetFormData sheetFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                SheetRequestData request = sheetFormData.ToRequestData();
                SheetResultData result = await WebApiClient.PostFormJsonAsync<SheetRequestData, SheetResultData>(Constant.WebApiControllerOffices, Constant.WebApiUpdateSheet, request);
                if (result != null && result.OperationSuccess)
                {
                    SheetTranslationRequestData translationRequest = new SheetTranslationRequestData
                    {
                        SheetTranslationDtoList = sheetFormData.TranslationsList.ToItemDataList()
                    };

                    SheetTranslationResultData sheetTranslationResultData = await WebApiClient.PostFormJsonAsync<SheetTranslationRequestData, SheetTranslationResultData>(Constant.WebApiControllerOffices, Constant.WebApiUpdateSheetTranslationRange, translationRequest);
                    if (sheetTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (sheetTranslationResultData.Errors != null && (!sheetTranslationResultData.OperationSuccess || sheetTranslationResultData.Errors != null || sheetTranslationResultData.Errors.Count > 0))
                    {
                        data.ErrorMessage = sheetTranslationResultData.Errors.FirstOrDefault();
                        data.OperationSuccess = false;
                    }
                    else if (sheetTranslationResultData.OperationSuccess)
                    {
                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (result == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!result.OperationSuccess && result.Errors != null && result.Errors.Count > 0)
                {
                    data.ErrorMessage = result.Errors.First();
                    data.OperationSuccess = false;
                }
                else if (result.OperationSuccess)
                {
                    data.SuccessMessage = UserResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = CountryResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region DELETE SHEET

        public ActionResult GetDeleteSheet(int countryId, int sheetId)
        {
            ViewBag.countryId = countryId;
            return View("Partials/_DeleteSheet", sheetId);
        }

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="sheetId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteSheet(int sheetId)
        {
            JsonReturnData data = new JsonReturnData();
            if (sheetId > 0)
            {
                string param = $"{nameof(sheetId)}={sheetId}";
                SheetResultData result = await WebApiClient.DeleteAsync<SheetResultData>(Constant.WebApiControllerOffices, Constant.WebApiRemoveSheet, param);
                if (result == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!result.OperationSuccess && result.Errors != null && result.Errors.Count > 0)
                {
                    data.ErrorMessage = result.Errors.First();
                    data.OperationSuccess = false;
                }
                else if (result.OperationSuccess)
                {
                    data.SuccessMessage = UserResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data.ErrorMessage = UserResources.RequiredUserId;
                data.OperationSuccess = false;
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region ACTVITY PARAGRAPH VALIDATION

        /// <summary>
        /// validate create  sheet.
        /// </summary>
        /// <param name="sheetFormData">the sheetFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateSheet(SheetFormData sheetFormData)
        {
            List<string> errors = new List<string>();
            if (sheetFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SheetFormData>.ValidateAttributes("CountryId", sheetFormData.CountryId.ToString()));
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// validate create  sheet translation.
        /// </summary>
        /// <param name="sheetTranslationFormData">the sheetTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateSheetTranslation(SheetTranslationFormData sheetTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (sheetTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SheetTranslationFormData>.ValidateAttributes("SheetValue", sheetTranslationFormData.SheetValue));
                errors.AddRange(GenericValidationAttribute<SheetTranslationFormData>.ValidateAttributes("LanguageId", sheetTranslationFormData.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<SheetTranslationFormData>.ValidateAttributes("SheetTitle", sheetTranslationFormData.SheetTitle));
            }
            return errors.Count == 0;
        }
        #endregion

        #region PRIVATE SHEETS METHODS

        /// <summary>
        /// Get the sheete of the country .
        /// </summary>
        /// <returns></returns>
        private async Task<List<SheetViewData>> GetSheetsList(int countryId)
        {
            SheetRequestData findSheetRequestData = new SheetRequestData
            {
                SheetDto = new SheetItemData { CountryId = countryId },
                FindSheetDto = FindSheetItemData.CountryId
            };

            SheetResultData sheetResultData = await WebApiClient.PostFormJsonAsync<SheetRequestData, SheetResultData>(Constant.WebApiControllerOffices, Constant.WebApiFindSheets, findSheetRequestData);
            List<SheetViewData> sheetsList = new List<SheetViewData>();

            if (sheetResultData != null && sheetResultData.OperationSuccess && sheetResultData.SheetDtoList != null)
            {
                foreach (var sheetDto in sheetResultData.SheetDtoList)
                {
                    SheetViewData sheet = new SheetViewData
                    {
                        TranslationsList = new List<SheetTranslationItemData>(),
                        Sheet = sheetDto
                    };

                    sheet.TranslationsList = await GetSheetTranslations(sheetDto.SheetId);
                    sheetsList.Add(sheet);
                }
            }
            return sheetsList;
        }

        /// <summary>
        /// Find the sheet translations
        /// </summary>
        /// <param name="sheetId">the  id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<SheetTranslationItemData>> GetSheetTranslations(int sheetId)
        {
            List<SheetTranslationItemData> translationsList = new List<SheetTranslationItemData>();
            SheetTranslationRequestData findSheetTranslationRequest = new SheetTranslationRequestData()
            {
                SheetTranslationDto = new SheetTranslationItemData { SheetId = sheetId },
                FindSheetTranslationDto = FindSheetTranslationItemData.SheetId
            };

            SheetTranslationResultData sheetTranslationResultData = await WebApiClient.PostFormJsonAsync<SheetTranslationRequestData, SheetTranslationResultData>(Constant.WebApiControllerOffices, Constant.WebApiFindSheetTranslations, findSheetTranslationRequest);
            if (sheetTranslationResultData != null && sheetTranslationResultData.OperationSuccess && sheetTranslationResultData.SheetTranslationDtoList != null)
            {
                translationsList.AddRange(sheetTranslationResultData.SheetTranslationDtoList);
            }
            return translationsList;
        }

        #endregion
    }
}