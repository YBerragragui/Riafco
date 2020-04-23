using Admin.Riafco.Dataflex.Pro.Authorization;
using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.Activities.Assembler;
using Admin.Riafco.Dataflex.Pro.Models.Activities.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.Activities.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ResultData;
using Admin.Riafco.Dataflex.Pro.Models.Activities.ViewData;
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
    /// The Activities controller.
    /// </summary>
    public class ActivitiesController : Controller
    {
        /// <summary>
        /// The index page.
        /// </summary>
        /// Activities Index Action
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            if (Session["ConnectedUser"] == null) { return RedirectToAction("Index", "Home"); }

            bool isAuthorizedUser = await AuthorizeUserAttribute.Authorize("A_ACTIVITES");
            if (!isAuthorizedUser) return RedirectToAction("NoAccess", "Errors");
            List<ActivityViewData> activities = await GetActivitiesList();
            ActivitiesViewData activitiesViewData = new ActivitiesViewData { Activities = activities };
            ViewBag.Activities = "active";
            return View(activitiesViewData);
        }

        /// <summary>
        /// Get activities List
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetActivities()
        {
            List<ActivityViewData> activities = await GetActivitiesList();
            ActivitiesViewData activitiesViewData = new ActivitiesViewData { Activities = activities };
            return View("Partials/_ActivitiesList", activitiesViewData);
        }

        #region CREATE ACTIVITY 

        /// <summary>
        /// Get activity form to create.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetCreateActivity()
        {
            CreateActivityFormData activityFormData = new CreateActivityFormData { TranslationsList = new List<ActivityTranslationFormData>() };
            LanguageResultData result = await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages, Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new ActivityTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId,
                    };
                    activityFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateActivity";
            return PartialView("Partials/_CreateActivity", activityFormData);
        }

        /// <summary>
        /// Create Activity Action
        /// </summary>
        /// <param name="activityFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateActivity(CreateActivityFormData activityFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                ActivityRequestData request = activityFormData.ToRequestData();
                ActivityResultData result = await WebApiClient.PostFormJsonAsync<ActivityRequestData, ActivityResultData>(Constant.WebApiControllerActivities, Constant.WebApiCreateActivity, request);
                if (result != null && result.OperationSuccess && result.ActivityDto != null)
                {
                    foreach (var translation in activityFormData.TranslationsList.ToList())
                    {
                        translation.ActivityId = result.ActivityDto.ActivityId;
                    }
                    ActivityTranslationRequestData translationRequest = new ActivityTranslationRequestData
                    {
                        ActivityTranslationDtoList = activityFormData.TranslationsList.ToItemDataList()
                    };

                    ActivityTranslationResultData activityTranslationResultData = await WebApiClient.PostFormJsonAsync<ActivityTranslationRequestData, ActivityTranslationResultData>(Constant.WebApiControllerActivities, Constant.WebApiCreateActivityTranslationRange, translationRequest);
                    if (activityTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!activityTranslationResultData.OperationSuccess && activityTranslationResultData.Errors != null && activityTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = activityTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (activityTranslationResultData.OperationSuccess)
                    {
                        Directory.CreateDirectory(
                            Server.MapPath($"~/Images/Activities/" + result.ActivityDto.ActivityId));

                        activityFormData.ActivityImage?.SaveAs(
                            Server.MapPath($"~/Images/Activities/" + result.ActivityDto.ActivityId + $"/") +
                            activityFormData.ActivityImage.FileName);

                        activityFormData.ActivityIcon?.SaveAs(
                            Server.MapPath($"~/Images/Activities/" + result.ActivityDto.ActivityId + $"/") +
                            activityFormData.ActivityIcon.FileName);

                        System.IO.File.Copy(Server.MapPath($"~/Images/Default/default-image-activity.jpg"),
                            Server.MapPath($"~/Images/Activities/" + result.ActivityDto.ActivityId +
                                           $"/default-image-activity.jpg"));
                        System.IO.File.Copy(Server.MapPath($"~/Images/Default/default-icon-activity.png"),
                            Server.MapPath($"~/Images/Activities/" + result.ActivityDto.ActivityId +
                                           $"/default-icon-activity.png"));

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
                    ErrorMessage = ActivityResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region UPDATE ACTIVITY

        /// <summary>
        /// Get Activity Model for Update
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetUpdateActivity(int? activityId)
        {
            UpdateActivityFormData activityFormData = new UpdateActivityFormData
            {
                TranslationsList = new List<ActivityTranslationFormData>()
            };

            if (activityId.HasValue)
            {
                ActivityRequestData findActivityRequest = new ActivityRequestData
                {
                    ActivityDto = new ActivityItemData { ActivityId = activityId.Value },
                    FindActivityDto = FindActivityItemData.ActivityId
                };
                ActivityResultData resultActivity = await WebApiClient.PostFormJsonAsync<ActivityRequestData, ActivityResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivities, findActivityRequest);

                if (resultActivity != null && resultActivity.OperationSuccess && resultActivity.ActivityDto != null)
                {
                    activityFormData.ActivityId = resultActivity.ActivityDto.ActivityId;
                    ActivityTranslationRequestData findActivityTranslationRequest = new ActivityTranslationRequestData()
                    {
                        ActivityTranslationDto = new ActivityTranslationItemData { ActivityId = activityId.Value },
                        FindActivityTranslationDto = FindActivityTranslationItemData.ActivityId
                    };
                    ActivityTranslationResultData resultActivityTranslation = await WebApiClient.PostFormJsonAsync<ActivityTranslationRequestData, ActivityTranslationResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivityTranslations, findActivityTranslationRequest);
                    if (resultActivityTranslation != null && resultActivityTranslation.OperationSuccess && resultActivityTranslation.ActivityTranslationDtoList != null)
                    {
                        activityFormData.TranslationsList = resultActivityTranslation.ActivityTranslationDtoList.ToFormDataList();
                    }
                }
            }
            ViewBag.Action = "UpdateActivity";
            return PartialView("Partials/_UpdateActivity", activityFormData);
        }

        /// <summary>
        /// Update Activity Action
        /// </summary>
        /// <param name="activityFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateActivity(UpdateActivityFormData activityFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                ActivityRequestData request = activityFormData.ToRequestData();
                ActivityResultData activityResult = await WebApiClient.PostFormJsonAsync<ActivityRequestData, ActivityResultData>(Constant.WebApiControllerActivities, Constant.WebApiUpdateActivity, request);
                if (activityResult != null && activityResult.OperationSuccess)
                {
                    ActivityTranslationRequestData activityTranslationRequestData = new ActivityTranslationRequestData
                    {
                        ActivityTranslationDtoList = activityFormData.TranslationsList.ToItemDataList()
                    };

                    ActivityTranslationResultData activityTranslationResultData = await WebApiClient.PostFormJsonAsync<ActivityTranslationRequestData, ActivityTranslationResultData>(Constant.WebApiControllerActivities, Constant.WebApiUpdateActivityTranslationRange, activityTranslationRequestData);
                    if (activityTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!activityTranslationResultData.OperationSuccess && activityTranslationResultData.Errors != null && activityTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = activityTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (activityTranslationResultData.OperationSuccess)
                    {
                        if (!Directory.Exists(Server.MapPath($"~/Images/Activities/" + activityFormData.ActivityId)))
                        {
                            Directory.CreateDirectory(
                                Server.MapPath($"~/Images/Activities/" + activityFormData.ActivityId));
                        }

                        activityFormData.ActivityImage?.SaveAs(
                            Server.MapPath($"~/Images/Activities/" + activityFormData.ActivityId + $"/") +
                            activityFormData.ActivityImage.FileName);
                        activityFormData.ActivityIcon?.SaveAs(
                            Server.MapPath($"~/Images/Activities/" + activityFormData.ActivityId + $"/") +
                            activityFormData.ActivityIcon.FileName);

                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (activityResult == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!activityResult.OperationSuccess && activityResult.Errors != null && activityResult.Errors.Count > 0)
                {
                    data.ErrorMessage = activityResult.Errors.First();
                    data.OperationSuccess = false;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = ActivityResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region DELETE ACTIVITY

        public ActionResult GetDeleteActivity(int activityId)
        {
            if (Directory.Exists(Server.MapPath($"~/Images/Activities/" + activityId)))
            {
                Directory.Delete(Server.MapPath($"~/Images/Activities/" + activityId), true);

            }

            if (Directory.Exists(Server.MapPath($"~/Icons/Activities/" + activityId)))
            {
                Directory.Delete(Server.MapPath($"~/Icons/Activities/" + activityId), true);

            }
            return View("Partials/_DeleteActivity", activityId);
        }



        /// <summary>
        /// Delete Activity
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteActivity(int activityId)
        {
            JsonReturnData data = new JsonReturnData();
            if (activityId > 0)
            {
                string param = $"{nameof(activityId)}={activityId}";
                ActivityResultData result = await WebApiClient.DeleteAsync<ActivityResultData>(Constant.WebApiControllerActivities, Constant.WebApiRemoveActivity, param);
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

        #region ACTIVITY VALIDATION

        /// <summary>
        /// validate create activity.
        /// </summary>
        /// <param name="activityFormData">the activityFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateCreateActivityFormData(CreateActivityFormData activityFormData)
        {
            List<string> errors = new List<string>();
            if (activityFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                if (string.IsNullOrEmpty(activityFormData.ActivityIconSource)) { errors.Add(ActivityResources.RequiredActivityIcon); }
                if (string.IsNullOrEmpty(activityFormData.ActivityImageSource)) { errors.Add(ActivityResources.RequiredActivityImage); }
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// validate create activity.
        /// </summary>
        /// <param name="activityFormData">the activityFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateUpdateActivityFormData(UpdateActivityFormData activityFormData)
        {
            List<string> errors = new List<string>();
            if (activityFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// validate create activity translation.
        /// </summary>
        /// <param name="activityTranslationFormData">the activityTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateActivityTranslationFormData(ActivityTranslationFormData activityTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (activityTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityTranslationFormData>.ValidateAttributes("ActivityIntroduction", activityTranslationFormData.ActivityIntroduction));
                errors.AddRange(GenericValidationAttribute<ActivityTranslationFormData>.ValidateAttributes("ActivityDescription", activityTranslationFormData.ActivityDescription));
                errors.AddRange(GenericValidationAttribute<ActivityTranslationFormData>.ValidateAttributes("LanguageId", activityTranslationFormData.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<ActivityTranslationFormData>.ValidateAttributes("ActivityTitle", activityTranslationFormData.ActivityTitle));
            }
            return errors.Count == 0;
        }
        #endregion

        #region ACTIVITY PARAGRAPHS

        /// <summary>
        /// Manage activity paragraph form.
        /// </summary>
        /// <param name="activityId">the activity id</param>
        /// <returns></returns>
        public async Task<ActionResult> GetManageParagraphs(int activityId)
        {
            ParagraphsViewData paragraphViewData = new ParagraphsViewData
            {
                Paragraphs = await GetParagraphs(activityId),
                ActivityId = activityId
            };
            return View("Partials/_Paragraphs", paragraphViewData);
        }

        /// <summary>
        /// Return activity paragraph list.
        /// </summary>
        /// <param name="activityId">the activity id</param>
        /// <returns></returns>
        public async Task<ActionResult> GetActivityParagraphs(int activityId)
        {
            ParagraphsViewData paragraphViewData = new ParagraphsViewData
            {
                Paragraphs = await GetParagraphs(activityId),
                ActivityId = activityId
            };
            return View("Partials/_ParagraphsList", paragraphViewData);
        }
        #endregion

        #region CREATE ACTIVITY PARAGRAPH

        /// <summary>
        /// Get the view to create activity paragraph.
        /// </summary>
        /// <param name="activityId">the activivity id</param>
        /// <returns>action view result.</returns>
        public async Task<ActionResult> GetCreateActivityParagraph(int activityId)
        {
            ActivityParagraphFormData activityParagraphFormData = new ActivityParagraphFormData
            {
                TranslationsList = new List<ActivityParagraphTranslationFormData>(),
                ActivityId = activityId
            };

            LanguageResultData result =
                await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages,
                    Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new ActivityParagraphTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId
                    };
                    activityParagraphFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateActivityParagraph";
            return PartialView("Partials/_ManageActivityParagraph", activityParagraphFormData);
        }

        /// <summary>
        /// Create paragraph.
        /// </summary>
        /// <param name="activityParagraphFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateActivityParagraph(ActivityParagraphFormData activityParagraphFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                ActivityParagraphRequestData request = activityParagraphFormData.ToRequestData();
                if (request.ActivityParagraphDto.ParagraphImage == null)
                {
                    request.ActivityParagraphDto.ParagraphImage = "default-image-activity.jpg";
                }

                ActivityParagraphResultData result =
                    await WebApiClient.PostFormJsonAsync<ActivityParagraphRequestData, ActivityParagraphResultData>(
                        Constant.WebApiControllerActivities, Constant.WebApiCreateActivityParagraph, request);
                if (result != null && result.OperationSuccess && result.ActivityParagraphDto != null)
                {
                    foreach (var translation in activityParagraphFormData.TranslationsList.ToList())
                    {
                        translation.ParagraphId = result.ActivityParagraphDto.ParagraphId;
                    }

                    ActivityParagraphTranslationRequestData translationRequest = new ActivityParagraphTranslationRequestData
                    {
                        ActivityParagraphTranslationDtoList = activityParagraphFormData.TranslationsList.ToItemDataList(),
                    };

                    ActivityParagraphTranslationResultData activityParagraphTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<ActivityParagraphTranslationRequestData,
                                ActivityParagraphTranslationResultData>(Constant.WebApiControllerActivities,
                                Constant.WebApiCreateActivityParagraphTranslationRange, translationRequest);
                    if (activityParagraphTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (activityParagraphTranslationResultData.Errors != null && (!activityParagraphTranslationResultData.OperationSuccess || activityParagraphTranslationResultData.Errors != null || activityParagraphTranslationResultData.Errors.Count > 0))
                    {
                        data.ErrorMessage = activityParagraphTranslationResultData.Errors.FirstOrDefault();
                        data.OperationSuccess = false;
                    }
                    else if (activityParagraphTranslationResultData.OperationSuccess)
                    {
                        Directory.CreateDirectory(
                            Server.MapPath($"~/Images/Activities/Paragraph/" +
                                           result.ActivityParagraphDto.ParagraphId));

                        activityParagraphFormData.ParagraphImage?.SaveAs(
                            Server.MapPath($"~/Images/Activities/Paragraph/" + result.ActivityParagraphDto.ParagraphId +
                                           $"/") +
                            activityParagraphFormData.ParagraphImage.FileName);

                        System.IO.File.Copy(Server.MapPath($"~/Images/Default/default-icon-activity.png"),
                            Server.MapPath($"~/Images/Activities/Paragraph/" + result.ActivityParagraphDto.ParagraphId +
                                           $"/default-image-activity.jpg"));
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
                    ErrorMessage = ActivityResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region UPDATE ACTIVITY PARAGRAPH

        /// <summary>
        /// Get the view to create activity paragraph.
        /// </summary>
        /// <param name="paragraphId">the paragraph id to update.</param>
        /// <returns>action view result.</returns>
        public async Task<ActionResult> GetUpdateActivityParagraph(int paragraphId)
        {
            ActivityParagraphFormData activityParagraphFormData = new ActivityParagraphFormData
            {
                TranslationsList = new List<ActivityParagraphTranslationFormData>(),
                ParagraphId = paragraphId
            };

            ActivityParagraphTranslationRequestData activityParagraphTranslationRequestData = new ActivityParagraphTranslationRequestData
            {
                ActivityParagraphTranslationDto = new ActivityParagraphTranslationItemData { ParagraphId = paragraphId },
                FindActivityParagraphTranslationDto = FindActivityParagraphTranslationItemData.ActivityParagraphId
            };

            ActivityParagraphTranslationResultData activityParagraphTranslation = await WebApiClient.PostFormJsonAsync<ActivityParagraphTranslationRequestData, ActivityParagraphTranslationResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivityParagraphTranslations, activityParagraphTranslationRequestData);
            if (activityParagraphTranslation != null && activityParagraphTranslation.OperationSuccess && activityParagraphTranslation.ActivityParagraphTranslationDtoList != null)
            {
                foreach (var paragraphTranslation in activityParagraphTranslation.ActivityParagraphTranslationDtoList)
                {
                    activityParagraphFormData.ActivityId = paragraphTranslation.ActivityParagraph?.ActivityId;

                    var translation = new ActivityParagraphTranslationFormData
                    {
                        LanguagePrefix = paragraphTranslation.Language?.LanguagePrefix,
                        LanguageId = paragraphTranslation.Language?.LanguageId,
                        TranslationId = paragraphTranslation.TranslationId,
                        ParagraphDescription = paragraphTranslation.ParagraphDescription,
                        ParagraphTitle = paragraphTranslation.ParagraphTitle,
                        ParagraphId = paragraphTranslation.ParagraphId
                    };
                    activityParagraphFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "UpdateActivityParagraph";
            return PartialView("Partials/_ManageActivityParagraph", activityParagraphFormData);
        }

        /// <summary>
        /// Update paragraph activity.
        /// </summary>
        /// <param name="activityParagraphFormData">the activityParagraphFormData to update.</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateActivityParagraph(ActivityParagraphFormData activityParagraphFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                ActivityParagraphRequestData request = activityParagraphFormData.ToRequestData();
                ActivityParagraphResultData result = await WebApiClient.PostFormJsonAsync<ActivityParagraphRequestData, ActivityParagraphResultData>(Constant.WebApiControllerActivities, Constant.WebApiUpdateActivityParagraph, request);
                if (result != null && result.OperationSuccess)
                {
                    ActivityParagraphTranslationRequestData translationRequest = new ActivityParagraphTranslationRequestData
                    {
                        ActivityParagraphTranslationDtoList = activityParagraphFormData.TranslationsList.ToItemDataList()
                    };

                    ActivityParagraphTranslationResultData activityParagraphTranslationResultData = await WebApiClient.PostFormJsonAsync<ActivityParagraphTranslationRequestData, ActivityParagraphTranslationResultData>(Constant.WebApiControllerActivities, Constant.WebApiUpdateActivityParagraphTranslationRange, translationRequest);
                    if (activityParagraphTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (activityParagraphTranslationResultData.Errors != null && (!activityParagraphTranslationResultData.OperationSuccess || activityParagraphTranslationResultData.Errors != null || activityParagraphTranslationResultData.Errors.Count > 0))
                    {
                        data.ErrorMessage = activityParagraphTranslationResultData.Errors.FirstOrDefault();
                        data.OperationSuccess = false;
                    }
                    else if (activityParagraphTranslationResultData.OperationSuccess)
                    {
                        if (!Directory.Exists(Server.MapPath($"~/Images/Activities/Paragraph/" + activityParagraphFormData.ParagraphId)))
                        {
                            Directory.CreateDirectory(
                                Server.MapPath($"~/Images/Activities/Paragraph/" + activityParagraphFormData.ParagraphId));
                        }

                        activityParagraphFormData.ParagraphImage?.SaveAs(
                            Server.MapPath($"~/Images/Activities/Paragraph/" + activityParagraphFormData.ParagraphId + $"/") +
                            activityParagraphFormData.ParagraphImage.FileName);


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
                    ErrorMessage = ActivityResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region DELETE ACTIVITY PARAGRAPH

        /// <summary>
        /// Get the delete activity paragraph.
        /// </summary>
        /// <param name="paragraphId">paragraphId to delete.</param>
        /// <param name="activityId">activityId to load list.</param>
        /// <returns></returns>
        public ActionResult GetDeleteActivityParagraph(int activityId, int paragraphId)
        {
            ViewBag.activityId = activityId;
            return View("Partials/_DeleteActivityParagraph", paragraphId);
        }

        /// <summary>
        /// Delete Activity
        /// </summary>
        /// <param name="paragraphId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteActivityParagraph(int paragraphId)
        {
            JsonReturnData data = new JsonReturnData();
            if (paragraphId > 0)
            {
                string param = $"{nameof(paragraphId)}={paragraphId}";
                ActivityParagraphResultData result =
                    await WebApiClient.DeleteAsync<ActivityParagraphResultData>(Constant.WebApiControllerActivities,
                        Constant.WebApiRemoveActivityParagraph, param);
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
                    data.SuccessMessage = SharedResources.Ok;
                    data.OperationSuccess = true;

                    if (Directory.Exists(Server.MapPath($"~/Images/Activities/Paragraph/" + paragraphId)))
                    {
                        Directory.Delete(Server.MapPath($"~/Images/Activities/Paragraph/" + paragraphId), true);
                    }
                }
            }
            else
            {
                data.ErrorMessage = ActivityParagraphResources.RequiredParagraphId;
                data.OperationSuccess = false;
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region ACTVITY PARAGRAPH VALIDATION

        /// <summary>
        /// validate create activity paragraph.
        /// </summary>
        /// <param name="activityParagraphFormData">the activityParagraphFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateActivityParagraph(ActivityParagraphFormData activityParagraphFormData)
        {
            List<string> errors = new List<string>();
            if (activityParagraphFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityParagraphFormData>.ValidateAttributes("ActivityId",
                    activityParagraphFormData.ActivityId.ToString()));
            }

            return errors.Count == 0;
        }

        /// <summary>
        /// validate create activity paragraph translation.
        /// </summary>
        /// <param name="activityParagraphTranslationFormData">the activityParagraphTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateActivityParagraphTranslation(ActivityParagraphTranslationFormData activityParagraphTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (activityParagraphTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ActivityParagraphTranslationFormData>.ValidateAttributes(
                    "ParagraphDescription", activityParagraphTranslationFormData.ParagraphDescription));
                errors.AddRange(
                    GenericValidationAttribute<ActivityParagraphTranslationFormData>.ValidateAttributes("LanguageId",
                        activityParagraphTranslationFormData.LanguageId.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<ActivityParagraphTranslationFormData>.ValidateAttributes(
                        "ParagraphTitle", activityParagraphTranslationFormData.ParagraphTitle));
            }

            return errors.Count == 0;
        }
        #endregion

        #region ACTIVITY FILES

        /// <summary>
        /// Manage activity File form.
        /// </summary>
        /// <param name="activityId">the activity id</param>
        /// <returns></returns>
        public async Task<ActionResult> GetManageFiles(int activityId)
        {
            FilesViewData fileViewData = new FilesViewData
            {
                Files = await GetFiles(activityId),
                ActivityId = activityId
            };
            return View("Partials/_Files", fileViewData);
        }

        /// <summary>
        /// Return activity File list.
        /// </summary>
        /// <param name="activityId">the activity id</param>
        /// <returns></returns>
        public async Task<ActionResult> GetActivityFiles(int activityId)
        {
            FilesViewData fileViewData = new FilesViewData
            {
                Files = await GetFiles(activityId),
                ActivityId = activityId
            };
            return View("Partials/_FilesList", fileViewData);
        }
        #endregion

        #region CREATE ACTIVITY FILE

        /// <summary>
        /// Get the view to create activity File.
        /// </summary>
        /// <param name="activityId">the activivity id</param>
        /// <returns>action view result.</returns>
        public async Task<ActionResult> GetCreateActivityFile(int activityId)
        {
            CreateActivityFileFormData activityFileFormData = new CreateActivityFileFormData
            {
                TranslationsList = new List<CreateActivityFileTranslationFormData>(),
                ActivityId = activityId
            };

            LanguageResultData result = await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages, Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new CreateActivityFileTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId
                    };
                    activityFileFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateActivityFile";
            return PartialView("Partials/_CreateActivityFile", activityFileFormData);
        }

        /// <summary>
        /// Create activity File.
        /// </summary>
        /// <param name="activityFileFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateActivityFile(CreateActivityFileFormData activityFileFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                ActivityFileRequestData request = activityFileFormData.ToRequestData();
                ActivityFileResultData result =
                    await WebApiClient.PostFormJsonAsync<ActivityFileRequestData, ActivityFileResultData>(
                        Constant.WebApiControllerActivities, Constant.WebApiCreateActivityFile, request);
                if (result != null && result.OperationSuccess && result.ActivityFileDto != null)
                {
                    foreach (var translation in activityFileFormData.TranslationsList.ToList())
                    {
                        translation.ActivityFileId = result.ActivityFileDto.ActivityFileId;
                    }

                    ActivityFileTranslationRequestData translationRequest = new ActivityFileTranslationRequestData
                    {
                        ActivityFileTranslationDtoList = activityFileFormData.TranslationsList.ToItemDataList()
                    };

                    ActivityFileTranslationResultData activityFileTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<ActivityFileTranslationRequestData, ActivityFileTranslationResultData>(
                                Constant.WebApiControllerActivities, Constant.WebApiCreateActivityFileTranslationRange,
                                translationRequest);
                    if (activityFileTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (activityFileTranslationResultData.Errors != null && (!activityFileTranslationResultData.OperationSuccess || activityFileTranslationResultData.Errors != null || activityFileTranslationResultData.Errors.Count > 0))
                    {
                        data.ErrorMessage = activityFileTranslationResultData.Errors.FirstOrDefault();
                        data.OperationSuccess = false;
                    }
                    else if (activityFileTranslationResultData.OperationSuccess)
                    {
                        if (!Directory.Exists(Server.MapPath($"~/Images/Activities/Files/" + result.ActivityFileDto.ActivityFileId)))
                        {
                            Directory.CreateDirectory(
                                Server.MapPath($"~/Images/Activities/Files/" + result.ActivityFileDto.ActivityFileId));
                        }
                        foreach (var translation in activityFileFormData.TranslationsList)
                        {
                            translation.ActivityFileSource.SaveAs(
                                Server.MapPath(
                                    $"~/Images/Activities/Files/" + result.ActivityFileDto.ActivityFileId + $"/") +
                                translation.ActivityFileSource.FileName);
                        }
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
                    ErrorMessage = ActivityResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region UPDATE ACTIVITY File

        /// <summary>
        /// Get the view to create activity File.
        /// </summary>
        /// <param name="fileId">the File id to update.</param>
        /// <returns>action view result.</returns>
        public async Task<ActionResult> GetUpdateActivityFile(int fileId)
        {
            UpdateActivityFileFormData activityFileFormData = new UpdateActivityFileFormData
            {
                TranslationsList = new List<UpdateActivityFileTranslationFormData>(),
                ActivityFileId = fileId
            };

            ActivityFileTranslationRequestData activityFileTranslationRequestData = new ActivityFileTranslationRequestData
            {
                ActivityFileTranslationDto = new ActivityFileTranslationItemData { ActivityFileId = fileId },
                FindActivityFileTranslationDto = FindActivityFileTranslationItemData.ActivityFileId
            };

            ActivityFileTranslationResultData activityFileTranslation = await WebApiClient.PostFormJsonAsync<ActivityFileTranslationRequestData, ActivityFileTranslationResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivityFileTranslations, activityFileTranslationRequestData);
            if (activityFileTranslation != null && activityFileTranslation.OperationSuccess && activityFileTranslation.ActivityFileTranslationDtoList != null)
            {
                foreach (var fileTranslation in activityFileTranslation.ActivityFileTranslationDtoList)
                {
                    activityFileFormData.ActivityId = fileTranslation.ActivityFile?.ActivityId;

                    var translation = new UpdateActivityFileTranslationFormData
                    {
                        LanguagePrefix = fileTranslation.Language?.LanguagePrefix,
                        ActivityFileText = fileTranslation.ActivityFileText,
                        LanguageId = fileTranslation.Language?.LanguageId,
                        ActivityFileId = fileTranslation.ActivityFileId,
                        TranslationId = fileTranslation.TranslationId
                    };
                    activityFileFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "UpdateActivityFile";
            return PartialView("Partials/_UpdateActivityFile", activityFileFormData);
        }

        /// <summary>
        /// Update File activity.
        /// </summary>
        /// <param name="activityFileFormData">the activityFileFormData to update.</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateActivityFile(UpdateActivityFileFormData activityFileFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                ActivityFileRequestData request = activityFileFormData.ToRequestData();
                ActivityFileResultData result =
                    await WebApiClient.PostFormJsonAsync<ActivityFileRequestData, ActivityFileResultData>(
                        Constant.WebApiControllerActivities, Constant.WebApiUpdateActivityFile, request);
                if (result != null && result.OperationSuccess)
                {
                    ActivityFileTranslationRequestData translationRequest = new ActivityFileTranslationRequestData
                    {
                        ActivityFileTranslationDtoList = activityFileFormData.TranslationsList.ToItemDataList()
                    };

                    ActivityFileTranslationResultData activityFileTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<ActivityFileTranslationRequestData, ActivityFileTranslationResultData>(
                                Constant.WebApiControllerActivities, Constant.WebApiUpdateActivityFileTranslationRange,
                                translationRequest);
                    if (activityFileTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (activityFileTranslationResultData.Errors != null && (!activityFileTranslationResultData.OperationSuccess || activityFileTranslationResultData.Errors != null || activityFileTranslationResultData.Errors.Count > 0))
                    {
                        data.ErrorMessage = activityFileTranslationResultData.Errors.FirstOrDefault();
                        data.OperationSuccess = false;
                    }
                    else if (activityFileTranslationResultData.OperationSuccess)
                    {
                        foreach (var translation in activityFileFormData.TranslationsList)
                        {
                            if (!Directory.Exists(
                                Server.MapPath($"~/Images/Activities/Files/" + translation.ActivityFileId)))
                            {
                                Directory.CreateDirectory(
                                    Server.MapPath(
                                        $"~/Images/Activities/Files/" + translation.ActivityFileId));
                            }

                            translation.ActivityFileSource?.SaveAs(
                                Server.MapPath(
                                    $"~/Images/Activities/Files/" + translation.ActivityFileId + $"/") +
                                translation.ActivityFileSource?.FileName);
                        }

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
                    ErrorMessage = ActivityResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region DELETE ACTIVITY FILE

        /// <summary>
        /// Get delete activity file.
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public ActionResult GetDeleteActivityFile(int activityId, int fileId)
        {
            ViewBag.activityId = activityId;
            return View("Partials/_DeleteActivityFile", fileId);
        }

        /// <summary>
        /// Delete Activity
        /// </summary>
        /// <param name="fileId">the fileId to delete.</param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteActivityFile(int fileId)
        {
            JsonReturnData data = new JsonReturnData();
            if (fileId > 0)
            {
                string param = $"{nameof(fileId)}={fileId}";
                ActivityFileResultData result = await WebApiClient.DeleteAsync<ActivityFileResultData>(Constant.WebApiControllerActivities, Constant.WebApiRemoveActivityFile, param);
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
                    if (Directory.Exists(Server.MapPath($"~/Images/Activities/Files/" + fileId)))
                    {
                        Directory.Delete(Server.MapPath($"~/Images/Activities/Files/" + fileId), true);
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

        #region DOWNLOAD ACTIVITY FILE


        #endregion

        #region ACTVITY FILE VALIDATION


        /// <summary>
        /// validate create activity File translation.
        /// </summary>
        /// <param name="activityFileTranslationFormData">the activityFileTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateCreateActivityFileTranslation(CreateActivityFileTranslationFormData activityFileTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (activityFileTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                if (string.IsNullOrEmpty(activityFileTranslationFormData.ActivityFileSourceValue))
                {
                    errors.Add(FileResources.RequiredActivityFileSource);
                }

                errors.AddRange(
                    GenericValidationAttribute<UpdateActivityFileTranslationFormData>.ValidateAttributes(
                        "ActivityFileText", activityFileTranslationFormData.ActivityFileText));
                errors.AddRange(
                    GenericValidationAttribute<UpdateActivityFileTranslationFormData>.ValidateAttributes("LanguageId",
                        activityFileTranslationFormData.LanguageId.ToString()));
            }

            return errors.Count == 0;
        }

        /// <summary>
        /// validate create activity File translation.
        /// </summary>
        /// <param name="activityFileTranslationFormData">the activityFileTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateUpdateActivityFileTranslation(UpdateActivityFileTranslationFormData activityFileTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (activityFileTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<UpdateActivityFileTranslationFormData>.ValidateAttributes("ActivityFileText", activityFileTranslationFormData.ActivityFileText));
                errors.AddRange(GenericValidationAttribute<UpdateActivityFileTranslationFormData>.ValidateAttributes("LanguageId", activityFileTranslationFormData.LanguageId.ToString()));
            }
            return errors.Count == 0;
        }
        #endregion

        #region PRIVATE ACTIVITY METHODS

        /// <summary>
        /// Get the activites list.
        /// </summary>
        /// <returns></returns>
        private async Task<List<ActivityViewData>> GetActivitiesList()
        {
            ActivityResultData activityResultData = await WebApiClient.GetAsync<ActivityResultData>(Constant.WebApiControllerActivities, Constant.WebApiActivityList);
            List<ActivityViewData> activitiesList = new List<ActivityViewData>();

            if (activityResultData == null || !activityResultData.OperationSuccess ||
                activityResultData.ActivityDtoList == null) return activitiesList;
            foreach (var activityDto in activityResultData.ActivityDtoList)
            {
                ActivityViewData activity = new ActivityViewData
                {
                    TranslationsList = new List<ActivityTranslationItemData>(),
                    Activity = activityDto
                };
                activity.TranslationsList = await GetActivityTranslations(activityDto.ActivityId);
                activitiesList.Add(activity);
            }
            return activitiesList;
        }

        /// <summary>
        /// Find the activity translations
        /// </summary>
        /// <param name="activityId">the activity id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<ActivityTranslationItemData>> GetActivityTranslations(int activityId)
        {
            List<ActivityTranslationItemData> translationsList = new List<ActivityTranslationItemData>();
            ActivityTranslationRequestData findActivityTranslationRequest = new ActivityTranslationRequestData()
            {
                ActivityTranslationDto = new ActivityTranslationItemData { ActivityId = activityId },
                FindActivityTranslationDto = FindActivityTranslationItemData.ActivityId
            };
            ActivityTranslationResultData resultActivityTranslation = await WebApiClient.PostFormJsonAsync<ActivityTranslationRequestData, ActivityTranslationResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivityTranslations, findActivityTranslationRequest);
            if (resultActivityTranslation != null && resultActivityTranslation.OperationSuccess && resultActivityTranslation.ActivityTranslationDtoList != null)
            {
                translationsList.AddRange(resultActivityTranslation.ActivityTranslationDtoList);
            }
            return translationsList;
        }

        #endregion

        #region PRIVATE ACTIVITY PARAGRAPHS METHODS

        /// <summary>
        /// Get the paragraphe of the activity.
        /// </summary>
        /// <returns></returns>
        private async Task<List<ParagraphViewData>> GetParagraphs(int activityId)
        {
            ActivityParagraphRequestData findActivityParagraphRequestData = new ActivityParagraphRequestData
            {
                ActivityParagraphDto = new ActivityParagraphItemData { ActivityId = activityId },
                FindActivityParagraphDto = FindActivityParagraphItemData.ActivityId
            };

            ActivityParagraphResultData activityParagraphResultData = await WebApiClient.PostFormJsonAsync<ActivityParagraphRequestData, ActivityParagraphResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivityParagraphs, findActivityParagraphRequestData);
            List<ParagraphViewData> paragraphsList = new List<ParagraphViewData>();

            if (activityParagraphResultData != null && activityParagraphResultData.OperationSuccess && activityParagraphResultData.ActivityParagraphDtoList != null)
            {
                foreach (var paragraphDto in activityParagraphResultData.ActivityParagraphDtoList)
                {
                    ParagraphViewData paragraph = new ParagraphViewData
                    {
                        TranslationsList = new List<ActivityParagraphTranslationItemData>(),
                        Paragraph = paragraphDto
                    };

                    paragraph.TranslationsList = await GetParagraphTranslations(paragraphDto.ParagraphId);
                    paragraphsList.Add(paragraph);
                }
            }
            return paragraphsList;
        }

        /// <summary>
        /// Find the paragraph translations
        /// </summary>
        /// <param name="paragraphId">the activity id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<ActivityParagraphTranslationItemData>> GetParagraphTranslations(int paragraphId)
        {
            List<ActivityParagraphTranslationItemData> translationsList = new List<ActivityParagraphTranslationItemData>();
            ActivityParagraphTranslationRequestData findActivityParagraphTranslationRequest = new ActivityParagraphTranslationRequestData()
            {
                ActivityParagraphTranslationDto = new ActivityParagraphTranslationItemData { ParagraphId = paragraphId },
                FindActivityParagraphTranslationDto = FindActivityParagraphTranslationItemData.ActivityParagraphId
            };

            ActivityParagraphTranslationResultData activityParagraphTranslationResultData = await WebApiClient.PostFormJsonAsync<ActivityParagraphTranslationRequestData, ActivityParagraphTranslationResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivityParagraphTranslations, findActivityParagraphTranslationRequest);
            if (activityParagraphTranslationResultData != null && activityParagraphTranslationResultData.OperationSuccess && activityParagraphTranslationResultData.ActivityParagraphTranslationDtoList != null)
            {
                translationsList.AddRange(activityParagraphTranslationResultData.ActivityParagraphTranslationDtoList);
            }
            return translationsList;
        }

        #endregion

        #region PRIVATE ACTIVITY FILES METHODS

        /// <summary>
        /// Get the paragraphe of the activity.
        /// </summary>
        /// <returns></returns>
        private async Task<List<FileViewData>> GetFiles(int activityId)
        {
            ActivityFileRequestData findActivityFileRequestData = new ActivityFileRequestData
            {
                ActivityFileDto = new ActivityFileItemData { ActivityId = activityId },
                FindActivityFileDto = FindActivityFileItemData.ActivityId
            };

            ActivityFileResultData activityFileResultData = await WebApiClient.PostFormJsonAsync<ActivityFileRequestData, ActivityFileResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivityFiles, findActivityFileRequestData);
            List<FileViewData> filesList = new List<FileViewData>();

            if (activityFileResultData != null && activityFileResultData.OperationSuccess && activityFileResultData.ActivityFileDtoList != null)
            {
                foreach (var fileDto in activityFileResultData.ActivityFileDtoList)
                {
                    FileViewData file = new FileViewData
                    {
                        TranslationsList = new List<ActivityFileTranslationItemData>(),
                        File = fileDto
                    };

                    file.TranslationsList = await GetFileTranslations(fileDto.ActivityFileId);
                    filesList.Add(file);
                }
            }
            return filesList;
        }

        /// <summary>
        /// Find the file translations
        /// </summary>
        /// <param name="activityFileId">the file id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<ActivityFileTranslationItemData>> GetFileTranslations(int activityFileId)
        {
            List<ActivityFileTranslationItemData> translationsList = new List<ActivityFileTranslationItemData>();
            ActivityFileTranslationRequestData findActivityFileTranslationRequest = new ActivityFileTranslationRequestData
            {
                ActivityFileTranslationDto = new ActivityFileTranslationItemData { ActivityFileId = activityFileId },
                FindActivityFileTranslationDto = FindActivityFileTranslationItemData.ActivityFileId
            };

            ActivityFileTranslationResultData activityFileTranslationResultData = await WebApiClient.PostFormJsonAsync<ActivityFileTranslationRequestData, ActivityFileTranslationResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivityFileTranslations, findActivityFileTranslationRequest);
            if (activityFileTranslationResultData != null && activityFileTranslationResultData.OperationSuccess && activityFileTranslationResultData.ActivityFileTranslationDtoList != null)
            {
                translationsList.AddRange(activityFileTranslationResultData.ActivityFileTranslationDtoList);
            }
            return translationsList;
        }
        #endregion
    }
}