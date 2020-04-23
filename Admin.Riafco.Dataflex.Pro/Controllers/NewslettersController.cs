using Admin.Riafco.Dataflex.Pro.Authorization;
using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.Assembler;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.ResultData;
using Admin.Riafco.Dataflex.Pro.Models.Newsletters.ViewData;
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
    /// Newsletter controller.
    /// </summary>
    public class NewslettersController : Controller
    {
        /// <summary>
        /// The index page.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            if (Session["ConnectedUser"] == null) { return RedirectToAction("Index", "Home"); }
            bool isAuthorizedUser = await AuthorizeUserAttribute.Authorize("A_NEWSLETTERS");
            if (!isAuthorizedUser) return RedirectToAction("NoAccess", "Errors");
            SubscribersViewData subscriberViewData = new SubscribersViewData();
            SubscriberResultData result = await WebApiClient.GetAsync<SubscriberResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiSubscriberList);
            if (result?.SubscriberDtoList != null && result.OperationSuccess)
            {
                subscriberViewData.Subscribers = result.SubscriberDtoList;
            }

            ViewBag.Newsletters = "active";
            return View(subscriberViewData);
        }

        #region Subscribers
        /// <summary>
        /// The subscribers section.
        /// </summary>
        /// <returns>htm section.</returns>
        public async Task<ActionResult> Subscribers()
        {
            SubscribersViewData subscriberViewData = new SubscribersViewData();

            SubscriberResultData result = await WebApiClient.GetAsync<SubscriberResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiSubscriberList);
            if (result?.SubscriberDtoList != null && result.OperationSuccess)
            {
                subscriberViewData.Subscribers = result.SubscriberDtoList;
            }

            return View("Partials/_Subscribers", subscriberViewData);
        }

        /// <summary>
        /// subscriber section list.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetSubscribers()
        {
            SubscribersViewData subscriberViewData = new SubscribersViewData();
            SubscriberResultData result = await WebApiClient.GetAsync<SubscriberResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiSubscriberList);
            if (result?.SubscriberDtoList != null && result.OperationSuccess)
            {
                subscriberViewData.Subscribers = result.SubscriberDtoList;
            }

            return PartialView("Partials/_SubscribersList", subscriberViewData);
        }

        /// <summary>
        /// Return the view to add subscriber.
        /// </summary>
        /// <returns>adding view</returns>
        public ActionResult GetCreateSubscriber()
        {
            SubscriberFormData subscriberFormData = new SubscriberFormData();
            ViewBag.Action = "CreateSubscriber";
            return PartialView("Partials/_ManageSubscriber", subscriberFormData);
        }

        /// <summary>
        /// Create new subscriber.
        /// </summary>
        /// <param name="subscriberFormData">subscriber form data.</param>
        /// <returns>return true if the subscriber were created.</returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateSubscriber(SubscriberFormData subscriberFormData)
        {
            SubscriberRequestData request = subscriberFormData.ToRequestData();
            SubscriberResultData result = await WebApiClient.PostFormJsonAsync<SubscriberRequestData, SubscriberResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiCreateSubscriber, request);
            JsonReturnData data = new JsonReturnData();
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
            return new OmsJsonResult(data);
        }

        /// <summary>
        /// The update subscriber view.
        /// </summary>
        /// <param name="subscriberId">the subscriber id to update.</param>
        /// <returns>updating view</returns>
        public async Task<ActionResult> GetUpdateSubscriber(int subscriberId)
        {
            SubscriberFormData subscriberFormData = new SubscriberFormData();
            SubscriberRequestData findRequest = new SubscriberRequestData
            {
                SubscriberDto = new SubscriberItemData
                {
                    SubscriberId = subscriberId
                },
                FindSubscriberDto = FindSubscriberItemData.SubscriberId
            };

            SubscriberResultData result = await WebApiClient.PostFormJsonAsync<SubscriberRequestData, SubscriberResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiFindSubscribers, findRequest);
            if (result != null && result.OperationSuccess && result.SubscriberDto != null)
            {
                subscriberFormData = result.ToFormData();
            }
            ViewBag.Action = "UpdateSubscriber";
            return PartialView("Partials/_ManageSubscriber", subscriberFormData);
        }


        /// <summary>
        /// update subscriber.
        /// </summary>
        /// <param name="subscriberFormData">subscriber form data.</param>
        /// <returns>return true if the subscriber were created.</returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateSubscriber(SubscriberFormData subscriberFormData)
        {
            SubscriberRequestData request = subscriberFormData.ToRequestData();
            SubscriberResultData result = await WebApiClient.PostFormJsonAsync<SubscriberRequestData, SubscriberResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiUpdateSubscriber, request);
            JsonReturnData data = new JsonReturnData();
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
            return new OmsJsonResult(data);
        }

        /// <summary>
        /// The GetDeleteSection Method
        /// </summary>
        /// <param name="subscriberId"></param>
        /// <returns></returns>
        public ActionResult GetDeleteSubscriber(int subscriberId)
        {
            return View("Partials/_DeleteSubscriber", subscriberId);
        }
        /// <summary>
        /// Delete subscriber.
        /// </summary>
        /// <param name="subscriberId">the subscriber id to delete.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OmsJsonResult> DeleteSubscriber(int subscriberId)
        {
            JsonReturnData data = new JsonReturnData();
            if (subscriberId > 0)
            {
                string param = $"{nameof(subscriberId)}={subscriberId}";
                SubscriberResultData result = await WebApiClient.DeleteAsync<SubscriberResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiRemoveSubscriber, param);
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
                data.ErrorMessage = SubscriberResources.RequiredId;
                data.OperationSuccess = false;
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region NewsletterMail
        /// <summary>
        /// Get newsletterMails List
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> NewsletterMails()
        {
            NewsletterMailsViewData newsletterMailsViewData = new NewsletterMailsViewData { NewsletterMails = await GetNewsletterMailsList() };
            return View("Partials/_NewsletterMails", newsletterMailsViewData);
        }

        /// <summary>
        /// Get newsletterMails List
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetNewsletterMails()
        {
            NewsletterMailsViewData newsletterMailsViewData = new NewsletterMailsViewData { NewsletterMails = await GetNewsletterMailsList() };
            return View("Partials/_NewsletterMailsList", newsletterMailsViewData);
        }
        #endregion

        #region CREATE NEWSLETTER 

        /// <summary>
        /// Get newsletterMail form to create.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetCreateNewsletterMail()
        {
            NewsletterMailFormData newsletterMailFormData = new NewsletterMailFormData { TranslationsList = new List<NewsletterMailTranslationFormData>() };
            LanguageResultData result = await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages, Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new NewsletterMailTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId,
                    };
                    newsletterMailFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateNewsletterMail";
            return PartialView("Partials/_ManageNewsletterMail", newsletterMailFormData);
        }


        /// <summary>
        /// Create NewsletterMail Action
        /// </summary>
        /// <param name="newsletterMailFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateNewsletterMail(NewsletterMailFormData newsletterMailFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                NewsletterMailRequestData request = newsletterMailFormData.ToRequestData();

                NewsletterMailResultData result = await WebApiClient.PostFormJsonAsync<NewsletterMailRequestData, NewsletterMailResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiCreateNewsletterMail, request);
                if (result != null && result.OperationSuccess && result.NewsletterMailDto != null)
                {
                    foreach (var translation in newsletterMailFormData.TranslationsList.ToList())
                    {
                        translation.NewsletterMailId = result.NewsletterMailDto.NewsletterMailId;
                    }
                    NewsletterMailTranslationRequestData translationRequest = new NewsletterMailTranslationRequestData
                    {
                        NewsletterMailTranslationDtoList = newsletterMailFormData.TranslationsList.ToItemDataList()
                    };

                    NewsletterMailTranslationResultData newsletterMailTranslationResultData = await WebApiClient.PostFormJsonAsync<NewsletterMailTranslationRequestData, NewsletterMailTranslationResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiCreateNewsletterMailTranslationRange, translationRequest);
                    if (newsletterMailTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!newsletterMailTranslationResultData.OperationSuccess && newsletterMailTranslationResultData.Errors != null && newsletterMailTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = newsletterMailTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (newsletterMailTranslationResultData.OperationSuccess)
                    {
                        Directory.CreateDirectory(
                            Server.MapPath($"~/Images/Newsletters/" + result.NewsletterMailDto.NewsletterMailId));

                        foreach (var translation in newsletterMailFormData.TranslationsList)
                        {
                            translation.NewsletterMailSource.SaveAs(
                                Server.MapPath(
                                    $"~/Images/Newsletters/" + result.NewsletterMailDto.NewsletterMailId + $"/") +
                                translation.NewsletterMailSource.FileName);
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
                    ErrorMessage = NewsletterMailResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region UPDATE NEWSLETTER

        /// <summary>
        /// Get NewsletterMail Model for Update
        /// </summary>
        /// <param name="newsletterMailId"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetUpdateNewsletterMail(int? newsletterMailId)
        {
            NewsletterMailFormData newsletterMailFormData = new NewsletterMailFormData
            {
                TranslationsList = new List<NewsletterMailTranslationFormData>()
            };

            if (newsletterMailId.HasValue)
            {
                NewsletterMailRequestData findNewsletterMailRequest = new NewsletterMailRequestData
                {
                    NewsletterMailDto = new NewsletterMailItemData { NewsletterMailId = newsletterMailId.Value },
                    FindNewsletterMailDto = FindNewsletterMailItemData.NewsletterMailId
                };
                NewsletterMailResultData resultNewsletterMail = await WebApiClient.PostFormJsonAsync<NewsletterMailRequestData, NewsletterMailResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiFindNewsletterMails, findNewsletterMailRequest);

                if (resultNewsletterMail != null && resultNewsletterMail.OperationSuccess && resultNewsletterMail.NewsletterMailDto != null)
                {
                    newsletterMailFormData.NewsletterMailId = resultNewsletterMail.NewsletterMailDto.NewsletterMailId;

                    NewsletterMailTranslationRequestData findNewsletterMailTranslationRequest = new NewsletterMailTranslationRequestData()
                    {
                        NewsletterMailTranslationDto = new NewsletterMailTranslationItemData { NewsletterMailId = newsletterMailId.Value },
                        FindNewsletterMailTranslationDto = FindNewsletterMailTranslationItemData.NewsletterMailId
                    };
                    NewsletterMailTranslationResultData resultNewsletterMailTranslation = await WebApiClient.PostFormJsonAsync<NewsletterMailTranslationRequestData, NewsletterMailTranslationResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiFindNewsletterMailTranslations, findNewsletterMailTranslationRequest);
                    if (resultNewsletterMailTranslation != null && resultNewsletterMailTranslation.OperationSuccess && resultNewsletterMailTranslation.NewsletterMailTranslationDtoList != null)
                    {
                        newsletterMailFormData.TranslationsList = resultNewsletterMailTranslation.NewsletterMailTranslationDtoList.ToFormDataList();
                    }
                }
            }
            ViewBag.Action = "UpdateNewsletterMail";
            return PartialView("Partials/_ManageNewsletterMail", newsletterMailFormData);
        }

        /// <summary>
        /// Update NewsletterMail Action
        /// </summary>
        /// <param name="newsletterMailFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateNewsletterMail(NewsletterMailFormData newsletterMailFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                NewsletterMailRequestData request = newsletterMailFormData.ToRequestData();
                NewsletterMailResultData newsletterMailResult = await WebApiClient.PostFormJsonAsync<NewsletterMailRequestData, NewsletterMailResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiUpdateNewsletterMail, request);
                if (newsletterMailResult != null && newsletterMailResult.OperationSuccess)
                {
                    NewsletterMailTranslationRequestData newsletterMailTranslationRequestData = new NewsletterMailTranslationRequestData
                    {
                        NewsletterMailTranslationDtoList = newsletterMailFormData.TranslationsList.ToItemDataList()
                    };

                    NewsletterMailTranslationResultData newsletterMailTranslationResultData = await WebApiClient.PostFormJsonAsync<NewsletterMailTranslationRequestData, NewsletterMailTranslationResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiUpdateNewsletterMailTranslationRange, newsletterMailTranslationRequestData);
                    if (newsletterMailTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!newsletterMailTranslationResultData.OperationSuccess && newsletterMailTranslationResultData.Errors != null && newsletterMailTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = newsletterMailTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (newsletterMailTranslationResultData.OperationSuccess)
                    {
                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (newsletterMailResult == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!newsletterMailResult.OperationSuccess && newsletterMailResult.Errors != null && newsletterMailResult.Errors.Count > 0)
                {
                    data.ErrorMessage = newsletterMailResult.Errors.First();
                    data.OperationSuccess = false;
                }
                else if (newsletterMailResult.OperationSuccess)
                {
                    foreach (var translation in newsletterMailFormData.TranslationsList)
                    {
                        translation.NewsletterMailSource?.SaveAs(
                            Server.MapPath(
                                $"~/Images/Newsletters/" + translation.NewsletterMailId + $"/") +
                            translation.NewsletterMailSource.FileName);
                    }

                    data.SuccessMessage = UserResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data = new JsonReturnData
                {

                    ErrorMessage = NewsletterMailResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region DELETE NEWSLETTER

        public ActionResult GetDeleteNewsletterMail(int newsletterMailId)
        {
            return View("Partials/_DeleteNewsletterMail", newsletterMailId);
        }
        /// <summary>
        /// Delete NewsletterMail
        /// </summary>
        /// <param name="newsletterMailId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteNewsletterMail(int newsletterMailId)
        {
            JsonReturnData data = new JsonReturnData();
            if (newsletterMailId > 0)
            {
                string param = $"{nameof(newsletterMailId)}={newsletterMailId}";
                NewsletterMailResultData result = await WebApiClient.DeleteAsync<NewsletterMailResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiRemoveNewsletterMail, param);
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
                    if (Directory.Exists(Server.MapPath($"~/Images/Newsletters/" + newsletterMailId)))

                    {
                        Directory.Delete(Server.MapPath($"~/Images/Newsletters/" + newsletterMailId), true);
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

        #region NEWSLETTER VALIDATION

        /// <summary>
        /// validate create newsletterMail translation.
        /// </summary>
        /// <param name="newsletterMailTranslationFormData">the newsletterMailTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateCreateNewsletterMailTranslationFormData(NewsletterMailTranslationFormData newsletterMailTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (newsletterMailTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                if (string.IsNullOrEmpty(newsletterMailTranslationFormData.NewsletterMailSourceName))
                {
                    errors.Add(NewsletterMailResources.RequiredNewsletterMailSource);
                }
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationFormData>.ValidateAttributes("NewsletterMailSubject", newsletterMailTranslationFormData.NewsletterMailSubject));
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationFormData>.ValidateAttributes("LanguageId", newsletterMailTranslationFormData.LanguageId.ToString()));
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// validate create newsletterMail translation.
        /// </summary>
        /// <param name="newsletterMailTranslationFormData">the newsletterMailTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateUpdateNewsletterMailTranslationFormData(NewsletterMailTranslationFormData newsletterMailTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (newsletterMailTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationFormData>.ValidateAttributes("NewsletterMailSubject", newsletterMailTranslationFormData.NewsletterMailSubject));
                errors.AddRange(GenericValidationAttribute<NewsletterMailTranslationFormData>.ValidateAttributes("LanguageId", newsletterMailTranslationFormData.LanguageId.ToString()));
            }
            return errors.Count == 0;
        }
        #endregion

        #region PRIVATE NEWSLETTER METHODS

        /// <summary>
        /// Get the activites list.
        /// </summary>
        /// <returns></returns>
        private async Task<List<NewsletterMailViewData>> GetNewsletterMailsList()
        {
            NewsletterMailResultData newsletterMailResultData = await WebApiClient.GetAsync<NewsletterMailResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiNewsletterMailList);
            List<NewsletterMailViewData> newsletterMailsList = new List<NewsletterMailViewData>();

            if (newsletterMailResultData == null || !newsletterMailResultData.OperationSuccess ||
                newsletterMailResultData.NewsletterMailDtoList == null) return newsletterMailsList;
            foreach (var newsletterMailDto in newsletterMailResultData.NewsletterMailDtoList)
            {
                NewsletterMailViewData newsletterMail = new NewsletterMailViewData
                {
                    TranslationsList = new List<NewsletterMailTranslationItemData>(),
                    NewsletterMail = newsletterMailDto
                };
                newsletterMail.TranslationsList = await GetNewsletterMailTranslations(newsletterMailDto.NewsletterMailId);
                newsletterMailsList.Add(newsletterMail);
            }
            return newsletterMailsList;
        }

        /// <summary>
        /// Find the newsletterMail translations
        /// </summary>
        /// <param name="newsletterMailId">the newsletterMail id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<NewsletterMailTranslationItemData>> GetNewsletterMailTranslations(int newsletterMailId)
        {
            List<NewsletterMailTranslationItemData> translationsList = new List<NewsletterMailTranslationItemData>();
            NewsletterMailTranslationRequestData findNewsletterMailTranslationRequest = new NewsletterMailTranslationRequestData()
            {
                NewsletterMailTranslationDto = new NewsletterMailTranslationItemData { NewsletterMailId = newsletterMailId },
                FindNewsletterMailTranslationDto = FindNewsletterMailTranslationItemData.NewsletterMailId
            };
            NewsletterMailTranslationResultData resultNewsletterMailTranslation = await WebApiClient.PostFormJsonAsync<NewsletterMailTranslationRequestData, NewsletterMailTranslationResultData>(Constant.WebApiControllerNewsletters, Constant.WebApiFindNewsletterMailTranslations, findNewsletterMailTranslationRequest);
            if (resultNewsletterMailTranslation != null && resultNewsletterMailTranslation.OperationSuccess && resultNewsletterMailTranslation.NewsletterMailTranslationDtoList != null)
            {
                translationsList.AddRange(resultNewsletterMailTranslation.NewsletterMailTranslationDtoList);
            }
            return translationsList;
        }
        #endregion
    }
}