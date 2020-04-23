using Admin.Riafco.Dataflex.Pro.Authorization;
using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.News.Assembler;
using Admin.Riafco.Dataflex.Pro.Models.News.FormData;
using Admin.Riafco.Dataflex.Pro.Models.News.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.News.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.News.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.News.ResultData;
using Admin.Riafco.Dataflex.Pro.Models.News.ViewData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ResultData;
using Riafco.Framework.Dataflex.pro.Web.ActionResult;
using Riafco.Framework.Dataflex.pro.Web.AjaxComponent;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Admin.Riafco.Dataflex.Pro.Controllers
{
    public class NewsController : Controller
    {
        /// <summary>
        /// The index page.
        /// </summary>
        /// News Index Action
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            if (Session["ConnectedUser"] == null) { return RedirectToAction("Index", "Home"); }
            bool isAuthorizedUser = await AuthorizeUserAttribute.Authorize("A_NEWS");
            if (!isAuthorizedUser) return RedirectToAction("NoAccess", "Errors");
            NewsViewDatas newsViewData = new NewsViewDatas { News = await GetNewsList() };
            ViewBag.News = "active";
            return View(newsViewData);
        }

        /// <summary>
        /// Get news List
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetNews()
        {
            NewsViewDatas newsViewData = new NewsViewDatas { News = await GetNewsList() };
            return View("Partials/_NewsList", newsViewData);
        }

        #region CREATE NEWS 

        /// <summary>
        /// Get news form to create.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetCreateNews()
        {
            NewsFormData newsFormData = new NewsFormData
            {
                NewsDate = DateTime.Now.ToString("dd/MM/yyyy"),
                TranslationsList = new List<NewsTranslationFormData>()
            };
            LanguageResultData result =
                await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages,
                    Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new NewsTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId,
                    };
                    newsFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateNews";
            return PartialView("Partials/_ManageNews", newsFormData);
        }


        /// <summary>
        /// Create News Action.
        /// </summary>
        /// <param name="newsFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateNews(NewsFormData newsFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                NewsRequestData request = newsFormData.ToRequestData();

                if (request.NewsDto.NewsImage == null)
                {
                    request.NewsDto.NewsImage = "default-image-news.jpg";
                }

                NewsResultData result =
                    await WebApiClient.PostFormJsonAsync<NewsRequestData, NewsResultData>(Constant.WebApiControllerNews,
                        Constant.WebApiCreateNews, request);
                if (result != null && result.OperationSuccess && result.NewsDto != null)
                {
                    foreach (var translation in newsFormData.TranslationsList.ToList())
                    {
                        translation.NewsId = result.NewsDto.NewsId;
                    }
                    NewsTranslationRequestData translationRequest = new NewsTranslationRequestData
                    {
                        NewsTranslationDtoList = newsFormData.TranslationsList.ToItemDataList()
                    };

                    NewsTranslationResultData newsTranslationResultData =
                        await WebApiClient.PostFormJsonAsync<NewsTranslationRequestData, NewsTranslationResultData>(
                            Constant.WebApiControllerNews, Constant.WebApiCreateNewsTranslationRange,
                            translationRequest);
                    if (newsTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!newsTranslationResultData.OperationSuccess && newsTranslationResultData.Errors != null && newsTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = newsTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (newsTranslationResultData.OperationSuccess)
                    {
                        Directory.CreateDirectory(
                      Server.MapPath($"~/Images/News/" + result.NewsDto.NewsId));

                        newsFormData.NewsImage?.SaveAs(
                          Server.MapPath($"~/Images/News/" + result.NewsDto.NewsId + $"/") +
                       newsFormData.NewsImage.FileName);

                        System.IO.File.Copy(Server.MapPath($"~/Images/Default/default-image-news.jpg"),
                            Server.MapPath($"~/Images/News/" + result.NewsDto.NewsId +
                                           $"/default-image-news.jpg"));

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
                    ErrorMessage = NewsResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region UPDATE NEWS

        /// <summary>
        /// Get News Model for Update
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetUpdateNews(int? newsId)
        {
            NewsFormData newsFormData = new NewsFormData
            {
                TranslationsList = new List<NewsTranslationFormData>()
            };

            if (newsId.HasValue)
            {
                NewsRequestData findNewsRequest = new NewsRequestData
                {
                    NewsDto = new NewsItemData { NewsId = newsId.Value },
                    FindNewsDto = FindNewsItemData.NewsId
                };
                NewsResultData resultNews = await WebApiClient.PostFormJsonAsync<NewsRequestData, NewsResultData>(Constant.WebApiControllerNews, Constant.WebApiFindNews, findNewsRequest);

                if (resultNews != null && resultNews.OperationSuccess && resultNews.NewsDto != null)
                {
                    newsFormData.NewsId = resultNews.NewsDto.NewsId;
                    newsFormData.NewsDate = resultNews.NewsDto.NewsDate.ToString("dd/MM/yyyy");
                    NewsTranslationRequestData findNewsTranslationRequest = new NewsTranslationRequestData()
                    {
                        NewsTranslationDto = new NewsTranslationItemData { NewsId = newsId.Value },
                        FindNewsTranslationDto = FindNewsTranslationItemData.NewsId
                    };
                    NewsTranslationResultData resultNewsTranslation = await WebApiClient.PostFormJsonAsync<NewsTranslationRequestData, NewsTranslationResultData>(Constant.WebApiControllerNews, Constant.WebApiFindNewsTranslations, findNewsTranslationRequest);
                    if (resultNewsTranslation != null && resultNewsTranslation.OperationSuccess && resultNewsTranslation.NewsTranslationDtoList != null)
                    {
                        newsFormData.TranslationsList = resultNewsTranslation.NewsTranslationDtoList.ToFormDataList();
                    }
                }
            }
            ViewBag.Action = "UpdateNews";
            return PartialView("Partials/_ManageNews", newsFormData);
        }

        /// <summary>
        /// Update news Action
        /// </summary>
        /// <param name="newsFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateNews(NewsFormData newsFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                NewsRequestData request = newsFormData.ToRequestData();
                NewsResultData newsResult = await WebApiClient.PostFormJsonAsync<NewsRequestData, NewsResultData>(Constant.WebApiControllerNews, Constant.WebApiUpdateNews, request);
                if (newsResult != null && newsResult.OperationSuccess)
                {
                    NewsTranslationRequestData newsTranslationRequestData = new NewsTranslationRequestData
                    {
                        NewsTranslationDtoList = newsFormData.TranslationsList.ToItemDataList()
                    };

                    NewsTranslationResultData newsTranslationResultData = await WebApiClient.PostFormJsonAsync<NewsTranslationRequestData, NewsTranslationResultData>(Constant.WebApiControllerNews, Constant.WebApiUpdateNewsTranslationRange, newsTranslationRequestData);
                    if (newsTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!newsTranslationResultData.OperationSuccess && newsTranslationResultData.Errors != null && newsTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = newsTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (newsTranslationResultData.OperationSuccess)
                    {
                        if (!Directory.Exists(Server.MapPath($"~/Images/News/" +
                                                             newsFormData.NewsId)))
                        {
                            Directory.CreateDirectory(
                                Server.MapPath($"~/Images/News/" + newsFormData.NewsId));
                        }

                        newsFormData.NewsImage?.SaveAs(
                            Server.MapPath($"~/Images/News/" + newsFormData.NewsId + $"/") +
                            newsFormData.NewsImage.FileName);

                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (newsResult == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!newsResult.OperationSuccess && newsResult.Errors != null && newsResult.Errors.Count > 0)
                {
                    data.ErrorMessage = newsResult.Errors.First();
                    data.OperationSuccess = false;
                }
                else if (newsResult.OperationSuccess)
                {
                    data.SuccessMessage = UserResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = NewsResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region DELETE NEWS
        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public ActionResult GetDeleteNews(int newsId)
        {
            return View("Partials/_DeleteNews", newsId);
        }

        /// <summary>
        /// Delete News
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteNews(int newsId)
        {
            JsonReturnData data = new JsonReturnData();
            if (newsId > 0)
            {
                string param = $"{nameof(newsId)}={newsId}";
                NewsResultData result = await WebApiClient.DeleteAsync<NewsResultData>(Constant.WebApiControllerNews, Constant.WebApiRemoveNews, param);
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
                    if (Directory.Exists(Server.MapPath($"~/Images/News/" + newsId)))
                    {
                        Directory.Delete(Server.MapPath($"~/Images/News/" + newsId), true);
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

        #region ACTIVITY VALIDATION

        /// <summary>
        /// validate create news.
        /// </summary>
        /// <param name="newsFormData">the newsFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateNewsFormData(NewsFormData newsFormData)
        {
            List<string> errors = new List<string>();
            if (newsFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(
                    GenericValidationAttribute<NewsFormData>.ValidateAttributes("NewsImage",
                        newsFormData.NewsImage?.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<NewsFormData>.ValidateAttributes("NewsDate", newsFormData.NewsDate));
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// validate create news translation.
        /// </summary>
        /// <param name="newsTranslationFormData">the newsTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateNewsTranslationFormData(NewsTranslationFormData newsTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (newsTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<NewsTranslationFormData>.ValidateAttributes("NewsSummary", newsTranslationFormData.NewsSummary));
                errors.AddRange(GenericValidationAttribute<NewsTranslationFormData>.ValidateAttributes("NewsDescription", newsTranslationFormData.NewsDescription));
                errors.AddRange(GenericValidationAttribute<NewsTranslationFormData>.ValidateAttributes("LanguageId", newsTranslationFormData.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<NewsTranslationFormData>.ValidateAttributes("NewsTitle", newsTranslationFormData.NewsTitle));
            }
            return errors.Count == 0;
        }
        #endregion

        #region PRIVATE ACTIVITY METHODS

        /// <summary>
        /// Get the activites list.
        /// </summary>
        /// <returns></returns>
        private async Task<List<NewsViewData>> GetNewsList()
        {
            NewsResultData newsResultData = await WebApiClient.GetAsync<NewsResultData>(Constant.WebApiControllerNews, Constant.WebApiNewsList);
            List<NewsViewData> newsList = new List<NewsViewData>();

            if (newsResultData == null || !newsResultData.OperationSuccess ||
                newsResultData.NewsDtoList == null) return newsList;
            foreach (var newsDto in newsResultData.NewsDtoList)
            {
                NewsViewData news = new NewsViewData
                {
                    TranslationsList = new List<NewsTranslationItemData>(),
                    News = newsDto
                };
                news.TranslationsList = await GetNewsTranslations(newsDto.NewsId);
                newsList.Add(news);
            }
            return newsList;
        }

        /// <summary>
        /// Find the news translations
        /// </summary>
        /// <param name="newsId">the news id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<NewsTranslationItemData>> GetNewsTranslations(int newsId)
        {
            List<NewsTranslationItemData> translationsList = new List<NewsTranslationItemData>();
            NewsTranslationRequestData findNewsTranslationRequest = new NewsTranslationRequestData()
            {
                NewsTranslationDto = new NewsTranslationItemData { NewsId = newsId },
                FindNewsTranslationDto = FindNewsTranslationItemData.NewsId
            };
            NewsTranslationResultData resultNewsTranslation = await WebApiClient.PostFormJsonAsync<NewsTranslationRequestData, NewsTranslationResultData>(Constant.WebApiControllerNews, Constant.WebApiFindNewsTranslations, findNewsTranslationRequest);
            if (resultNewsTranslation != null && resultNewsTranslation.OperationSuccess && resultNewsTranslation.NewsTranslationDtoList != null)
            {
                translationsList.AddRange(resultNewsTranslation.NewsTranslationDtoList);
            }
            return translationsList;
        }

        #endregion
    }
}