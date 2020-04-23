using Admin.Riafco.Dataflex.Pro.Authorization;
using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.Occurrences.Assembler;
using Admin.Riafco.Dataflex.Pro.Models.Occurrences.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Occurrences.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Occurrences.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.Occurrences.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Occurrences.ResultData;
using Admin.Riafco.Dataflex.Pro.Models.Occurrences.ViewData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ResultData;
using Riafco.Framework.Dataflex.pro.Web.ActionResult;
using Riafco.Framework.Dataflex.pro.Web.AjaxComponent;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Admin.Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// The Occurrences controller.
    /// </summary>
    public class OccurrencesController : Controller
    {
        /// <summary>
        /// The index page.
        /// </summary>
        /// Occurrences Index Action
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            if (Session["ConnectedUser"] == null) { return RedirectToAction("Index", "Home"); }
            bool isAuthorizedUser = await AuthorizeUserAttribute.Authorize("A_EVENTS");
            if (!isAuthorizedUser) return RedirectToAction("NoAccess", "Errors");

            OccurrencesViewData occurrencesViewData =
                new OccurrencesViewData { Occurrences = await GetOccurrencesList() };
            ViewBag.Occurrences = "active";
            return View(occurrencesViewData);
        }

        /// <summary>
        /// Get occurrences List
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetOccurrences()
        {
            OccurrencesViewData occurrencesViewData =
                new OccurrencesViewData { Occurrences = await GetOccurrencesList() };
            return View("Partials/_OccurrencesList", occurrencesViewData);
        }

        #region CREATE OCCURRENCE 

        /// <summary>
        /// Get occurrence form to create.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetCreateOccurrence()
        {
            OccurrenceFormData occurrenceFormData = new OccurrenceFormData
            {
                OccurrenceStartDate = DateTime.Now.ToString("dd/MM/yyyy"),
                OccurrenceEndDate = DateTime.Now.ToString("dd/MM/yyyy"),
                TranslationsList = new List<OccurrenceTranslationFormData>()
            };
            LanguageResultData result =
                await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages,
                    Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new OccurrenceTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId
                    };
                    occurrenceFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateOccurrence";
            return PartialView("Partials/_ManageOccurrence", occurrenceFormData);
        }


        /// <summary>
        /// Create Occurrence Action
        /// </summary>
        /// <param name="occurrenceFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateOccurrence(OccurrenceFormData occurrenceFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                OccurrenceRequestData request = occurrenceFormData.ToRequestData();

                OccurrenceResultData result =
                    await WebApiClient.PostFormJsonAsync<OccurrenceRequestData, OccurrenceResultData>(
                        Constant.WebApiControllerOccurrences, Constant.WebApiCreateOccurrence, request);
                if (result != null && result.OperationSuccess && result.OccurrenceDto != null)
                {
                    foreach (var translation in occurrenceFormData.TranslationsList.ToList())
                    {
                        translation.OccurrenceId = result.OccurrenceDto.OccurrenceId;
                    }
                    OccurrenceTranslationRequestData translationRequest = new OccurrenceTranslationRequestData
                    {
                        OccurrenceTranslationDtoList = occurrenceFormData.TranslationsList.ToItemDataList()
                    };

                    OccurrenceTranslationResultData occurrenceTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<OccurrenceTranslationRequestData, OccurrenceTranslationResultData>(
                                Constant.WebApiControllerOccurrences, Constant.WebApiCreateOccurrenceTranslationRange,
                                translationRequest);
                    if (occurrenceTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!occurrenceTranslationResultData.OperationSuccess && occurrenceTranslationResultData.Errors != null && occurrenceTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = occurrenceTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (occurrenceTranslationResultData.OperationSuccess)
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
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = OccurrenceResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region UPDATE OCCURRENCE

        /// <summary>
        /// Get Occurrence Model for Update
        /// </summary>
        /// <param name="occurrenceId"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetUpdateOccurrence(int? occurrenceId)
        {
            OccurrenceFormData occurrenceFormData = new OccurrenceFormData
            {
                TranslationsList = new List<OccurrenceTranslationFormData>()
            };

            if (occurrenceId.HasValue)
            {
                OccurrenceRequestData findOccurrenceRequest = new OccurrenceRequestData
                {
                    OccurrenceDto = new OccurrenceItemData { OccurrenceId = occurrenceId.Value },
                    FindOccurrenceDto = FindOccurrenceItemData.OccurrenceId
                };
                OccurrenceResultData resultOccurrence =
                    await WebApiClient.PostFormJsonAsync<OccurrenceRequestData, OccurrenceResultData>(
                        Constant.WebApiControllerOccurrences, Constant.WebApiFindOccurrences, findOccurrenceRequest);

                if (resultOccurrence != null && resultOccurrence.OperationSuccess && resultOccurrence.OccurrenceDto != null)
                {
                    occurrenceFormData = resultOccurrence.OccurrenceDto.ToFormData();
                    OccurrenceTranslationRequestData findOccurrenceTranslationRequest = new OccurrenceTranslationRequestData()
                    {
                        OccurrenceTranslationDto = new OccurrenceTranslationItemData { OccurrenceId = occurrenceId.Value },
                        FindOccurrenceTranslationDto = FindOccurrenceTranslationItemData.OccurrenceId
                    };
                    OccurrenceTranslationResultData resultOccurrenceTranslation =
                        await WebApiClient
                            .PostFormJsonAsync<OccurrenceTranslationRequestData, OccurrenceTranslationResultData>(
                                Constant.WebApiControllerOccurrences, Constant.WebApiFindOccurrenceTranslations,
                                findOccurrenceTranslationRequest);
                    if (resultOccurrenceTranslation != null && resultOccurrenceTranslation.OperationSuccess && resultOccurrenceTranslation.OccurrenceTranslationDtoList != null)
                    {
                        occurrenceFormData.TranslationsList = resultOccurrenceTranslation.OccurrenceTranslationDtoList.ToFormDataList();
                    }
                }
            }
            ViewBag.Action = "UpdateOccurrence";
            return PartialView("Partials/_ManageOccurrence", occurrenceFormData);
        }

        /// <summary>
        /// Update Occurrence Action
        /// </summary>
        /// <param name="occurrenceFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateOccurrence(OccurrenceFormData occurrenceFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                OccurrenceRequestData request = occurrenceFormData.ToRequestData();
                OccurrenceResultData occurrenceResult =
                    await WebApiClient.PostFormJsonAsync<OccurrenceRequestData, OccurrenceResultData>(
                        Constant.WebApiControllerOccurrences, Constant.WebApiUpdateOccurrence, request);
                if (occurrenceResult != null && occurrenceResult.OperationSuccess)
                {
                    OccurrenceTranslationRequestData occurrenceTranslationRequestData = new OccurrenceTranslationRequestData
                    {
                        OccurrenceTranslationDtoList = occurrenceFormData.TranslationsList.ToItemDataList()
                    };

                    OccurrenceTranslationResultData occurrenceTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<OccurrenceTranslationRequestData, OccurrenceTranslationResultData>(
                                Constant.WebApiControllerOccurrences, Constant.WebApiUpdateOccurrenceTranslationRange,
                                occurrenceTranslationRequestData);
                    if (occurrenceTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!occurrenceTranslationResultData.OperationSuccess && occurrenceTranslationResultData.Errors != null && occurrenceTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = occurrenceTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (occurrenceTranslationResultData.OperationSuccess)
                    {
                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (occurrenceResult == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!occurrenceResult.OperationSuccess && occurrenceResult.Errors != null && occurrenceResult.Errors.Count > 0)
                {
                    data.ErrorMessage = occurrenceResult.Errors.First();
                    data.OperationSuccess = false;
                }
                else if (occurrenceResult.OperationSuccess)
                {
                    data.SuccessMessage = UserResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = OccurrenceResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region DELETE OCCURRENCE

        public ActionResult GetDeleteOccurrence(int occurrenceId)
        {
            return View("Partials/_DeleteOccurrence", occurrenceId);
        }
        /// <summary>
        /// Delete Occurrence
        /// </summary>
        /// <param name="occurrenceId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteOccurrence(int occurrenceId)
        {
            JsonReturnData data = new JsonReturnData();
            if (occurrenceId > 0)
            {
                string param = $"{nameof(occurrenceId)}={occurrenceId}";
                OccurrenceResultData result = await WebApiClient.DeleteAsync<OccurrenceResultData>(Constant.WebApiControllerOccurrences, Constant.WebApiRemoveOccurrence, param);
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

        #region OCCURRENCE VALIDATION

        /// <summary>
        /// validate create occurrence.
        /// </summary>
        /// <param name="occurrenceFormData">the occurrenceFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateOccurrenceFormData(OccurrenceFormData occurrenceFormData)
        {
            List<string> errors = new List<string>();
            if (occurrenceFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<OccurrenceFormData>.ValidateAttributes("OccurrenceStartDate",
                    occurrenceFormData.OccurrenceStartDate));
                errors.AddRange(GenericValidationAttribute<OccurrenceFormData>.ValidateAttributes("OccurrenceEndDate",
                    occurrenceFormData.OccurrenceEndDate));
                errors.AddRange(GenericValidationAttribute<OccurrenceFormData>.ValidateAttributes("OccurrenceLink",
                    occurrenceFormData.OccurrenceLink));
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// validate create occurrence translation.
        /// </summary>
        /// <param name="occurrenceTranslationFormData">the occurrenceTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateOccurrenceTranslationFormData(OccurrenceTranslationFormData occurrenceTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (occurrenceTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<OccurrenceTranslationFormData>.ValidateAttributes(
                    "OccurrenceDescription", occurrenceTranslationFormData.OccurrenceDescription));
                errors.AddRange(
                    GenericValidationAttribute<OccurrenceTranslationFormData>.ValidateAttributes("LanguageId",
                        occurrenceTranslationFormData.LanguageId.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<OccurrenceTranslationFormData>.ValidateAttributes("OccurrenceTitle",
                        occurrenceTranslationFormData.OccurrenceTitle));
            }
            return errors.Count == 0;
        }
        #endregion

        #region PRIVATE OCCURRENCE METHODS

        /// <summary>
        /// Get the activites list.
        /// </summary>
        /// <returns></returns>
        private async Task<List<OccurrenceViewData>> GetOccurrencesList()
        {
            OccurrenceResultData occurrenceResultData = await WebApiClient.GetAsync<OccurrenceResultData>(Constant.WebApiControllerOccurrences, Constant.WebApiOccurrenceList);
            List<OccurrenceViewData> occurrencesList = new List<OccurrenceViewData>();

            if (occurrenceResultData == null || !occurrenceResultData.OperationSuccess ||
                occurrenceResultData.OccurrenceDtoList == null) return occurrencesList;
            foreach (var occurrenceDto in occurrenceResultData.OccurrenceDtoList)
            {
                OccurrenceViewData occurrence = new OccurrenceViewData
                {
                    TranslationsList = new List<OccurrenceTranslationItemData>(),
                    Occurrence = occurrenceDto
                };
                occurrence.TranslationsList = await GetOccurrenceTranslations(occurrenceDto.OccurrenceId);
                occurrencesList.Add(occurrence);
            }
            return occurrencesList;
        }

        /// <summary>
        /// Find the occurrence translations
        /// </summary>
        /// <param name="occurrenceId">the occurrence id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<OccurrenceTranslationItemData>> GetOccurrenceTranslations(int occurrenceId)
        {
            List<OccurrenceTranslationItemData> translationsList = new List<OccurrenceTranslationItemData>();
            OccurrenceTranslationRequestData findOccurrenceTranslationRequest = new OccurrenceTranslationRequestData()
            {
                OccurrenceTranslationDto = new OccurrenceTranslationItemData { OccurrenceId = occurrenceId },
                FindOccurrenceTranslationDto = FindOccurrenceTranslationItemData.OccurrenceId
            };
            OccurrenceTranslationResultData resultOccurrenceTranslation = await WebApiClient.PostFormJsonAsync<OccurrenceTranslationRequestData, OccurrenceTranslationResultData>(Constant.WebApiControllerOccurrences, Constant.WebApiFindOccurrenceTranslations, findOccurrenceTranslationRequest);
            if (resultOccurrenceTranslation != null && resultOccurrenceTranslation.OperationSuccess && resultOccurrenceTranslation.OccurrenceTranslationDtoList != null)
            {
                translationsList.AddRange(resultOccurrenceTranslation.OccurrenceTranslationDtoList);
            }
            return translationsList;
        }

        #endregion
    }
}