using Admin.Riafco.Dataflex.Pro.Authorization;
using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.Assembler;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ResultData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ViewData;
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
    /// <summary>
    /// The ressources controller.
    /// </summary>
    public class RessourcesController : Controller
    {
        /// <summary>
        /// The home page.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            if (Session["ConnectedUser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            bool isAuthorizedUser = await AuthorizeUserAttribute.Authorize("A_RESSOURCES");
            if (!isAuthorizedUser) return RedirectToAction("NoAccess", "Errors");

            AuthorResultData authorResultData =
                await WebApiClient.GetAsync<AuthorResultData>(Constant.WebApiControllerRessources,
                    Constant.WebApiAuthorList);
            List<AuthorViewData> authorsList = new List<AuthorViewData>();
            AuthorsViewData authorViewData = new AuthorsViewData { Authors = authorsList };

            if (authorResultData?.AuthorDtoList != null && authorResultData.OperationSuccess)
            {
                authorsList.AddRange(
                    authorResultData.AuthorDtoList.Select(authorDto => new AuthorViewData { Author = authorDto }));
            }
            ViewBag.Ressources = "active";
            return View(authorViewData);
        }

        #region AUTHORS

        /// <summary>
        /// Get Authors section.
        /// </summary>
        /// <returns>authors view.</returns>
        public async Task<ActionResult> Authors()
        {
            AuthorResultData authorResultData =
                await WebApiClient.GetAsync<AuthorResultData>(Constant.WebApiControllerRessources,
                    Constant.WebApiAuthorList);
            List<AuthorViewData> authorsList = new List<AuthorViewData>();
            AuthorsViewData authorViewData = new AuthorsViewData { Authors = authorsList };

            if (authorResultData?.AuthorDtoList != null && authorResultData.OperationSuccess)
            {
                authorsList.AddRange(
                    authorResultData.AuthorDtoList.Select(authorDto => new AuthorViewData { Author = authorDto }));
            }
            return View("Partials/_Authors", authorViewData);
        }

        /// <summary>
        /// Get authors list.
        /// </summary>
        /// <returns>authors view.</returns>
        public async Task<ActionResult> GetAuthors()
        {
            AuthorResultData authorResultData =
                await WebApiClient.GetAsync<AuthorResultData>(Constant.WebApiControllerRessources,
                    Constant.WebApiAuthorList);
            List<AuthorViewData> authorsList = new List<AuthorViewData>();
            AuthorsViewData authorViewData = new AuthorsViewData { Authors = authorsList };

            if (authorResultData?.AuthorDtoList != null && authorResultData.OperationSuccess)
            {
                authorsList.AddRange(
                    authorResultData.AuthorDtoList.Select(authorDto => new AuthorViewData { Author = authorDto }));
            }
            return View("Partials/_AuthorsList", authorViewData);
        }

        #region CREATE AUTHOR

        /// <summary>
        /// Get create author page.
        /// </summary>
        /// <returns>the manage page.</returns>
        public ActionResult GetCreateAuthor()
        {
            AuthorFormData authorFormData = new AuthorFormData();
            ViewBag.action = "CreateAuthor";

            return View("Partials/_ManageAuthor", authorFormData);
        }

        /// <summary>
        /// Create new author.
        /// </summary>
        /// <param name="authorFormData">the author to craete.</param>
        /// <returns>operatiopn result.</returns>
        public async Task<OmsJsonResult> CreateAuthor(AuthorFormData authorFormData)
        {
            AuthorRequestData request = authorFormData.ToRequestData();
            AuthorResultData result =
                await WebApiClient.PostFormJsonAsync<AuthorRequestData, AuthorResultData>(
                    Constant.WebApiControllerRessources, Constant.WebApiCreateAuthor, request);
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
                data.SuccessMessage = AuthorResources.Ok;
                data.OperationSuccess = true;
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region UPDATE AUTHOR

        /// <summary>
        /// Get update author page.
        /// </summary>
        /// <returns>the manage page.</returns>
        public async Task<ActionResult> GetUpdateAuthor(int authorId)
        {
            AuthorFormData authorFormData = new AuthorFormData();
            AuthorRequestData findRequest = new AuthorRequestData
            {
                AuthorDto = new AuthorItemData { AuthorId = authorId },
                FindAuthorDto = FindAuthorItemData.AuthorId
            };

            AuthorResultData result =
                await WebApiClient.PostFormJsonAsync<AuthorRequestData, AuthorResultData>(
                    Constant.WebApiControllerRessources, Constant.WebApiFindAuthors, findRequest);
            if (result != null && result.OperationSuccess && result.AuthorDto != null)
            {
                authorFormData = result.AuthorDto.ToFormData();
            }
            ViewBag.action = "UpdateAuthor";
            return View("Partials/_ManageAuthor", authorFormData);
        }

        /// <summary>
        /// Update author.
        /// </summary>
        /// <param name="authorFormData">the author to update.</param>
        /// <returns>operatiopn result.</returns>
        public async Task<OmsJsonResult> UpdateAuthor(AuthorFormData authorFormData)
        {
            AuthorRequestData request = authorFormData.ToRequestData();
            AuthorResultData result =
                await WebApiClient.PostFormJsonAsync<AuthorRequestData, AuthorResultData>(
                    Constant.WebApiControllerRessources, Constant.WebApiUpdateAuthor, request);
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
                data.SuccessMessage = AuthorResources.Ok;
                data.OperationSuccess = true;
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region DELETE AUTHOR

        /// <summary>
        /// Get the form to delete author.
        /// </summary>
        /// <param name="authorId">the authorid  to delete.</param>
        /// <returns></returns>
        public ActionResult GetDeleteAuthor(int authorId)
        {
            return View("Partials/_DeleteAuthor", authorId);
        }

        /// <summary>
        /// Delete author.
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OmsJsonResult> DeleteAuthor(int authorId = 0)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                if (authorId > 0)
                {
                    string param = $"{nameof(authorId)}={authorId}";
                    AuthorResultData result =
                        await WebApiClient.DeleteAsync<AuthorResultData>(Constant.WebApiControllerRessources,
                            Constant.WebApiRemoveAuthor, param);
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
                        data.SuccessMessage = AuthorResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else
                {
                    data.ErrorMessage = AuthorResources.RequiredId;
                    data.OperationSuccess = false;
                }
            }
            else
            {
                data.ErrorMessage = SharedResources.ValidationErrors;
                data.OperationSuccess = false;
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #endregion

        #region THEMES

        /// <summary>
        /// Get Themes section.
        /// </summary>
        /// <returns>Themes view.</returns>
        public async Task<ActionResult> Themes()
        {
            ThemeResultData themeResultData =
                await WebApiClient.GetAsync<ThemeResultData>(Constant.WebApiControllerRessources,
                    Constant.WebApiThemeList);
            List<ThemeViewData> themesList = new List<ThemeViewData>();

            if (themeResultData?.ThemeDtoList != null && themeResultData.OperationSuccess)
            {
                foreach (var themeItemData in themeResultData.ThemeDtoList)
                {
                    List<ThemeTranslationItemData> translationsList = new List<ThemeTranslationItemData>();
                    ThemeTranslationRequestData findThemeTranslationRequest = new ThemeTranslationRequestData
                    {
                        ThemeTranslationDto = new ThemeTranslationItemData { ThemeId = themeItemData.ThemeId },
                        FindThemeTranslationDto = FindThemeTranslationItemData.ThemeId
                    };
                    ThemeTranslationResultData resultThemeTranslation =
                        await WebApiClient.PostFormJsonAsync<ThemeTranslationRequestData, ThemeTranslationResultData>(
                            Constant.WebApiControllerRessources, Constant.WebApiFindThemeTranslations,
                            findThemeTranslationRequest);
                    if (resultThemeTranslation != null && resultThemeTranslation.OperationSuccess &&
                        resultThemeTranslation.ThemeTranslationDtoList != null)
                    {
                        translationsList.AddRange(resultThemeTranslation.ThemeTranslationDtoList);
                    }

                    themesList.Add(new ThemeViewData
                    {
                        TranslationsList = translationsList,
                        Theme = themeItemData
                    });
                }
            }

            ThemesViewData themeViewData = new ThemesViewData { Themes = themesList };
            return View("Partials/_Themes", themeViewData);
        }

        /// <summary>
        /// Get themes list.
        /// </summary>
        /// <returns>themes view.</returns>
        public async Task<ActionResult> GetThemes()
        {
            ThemeResultData themeResultData =
                await WebApiClient.GetAsync<ThemeResultData>(Constant.WebApiControllerRessources,
                    Constant.WebApiThemeList);
            List<ThemeViewData> themesList = new List<ThemeViewData>();

            if (themeResultData?.ThemeDtoList != null && themeResultData.OperationSuccess)
            {
                foreach (var themeItemData in themeResultData.ThemeDtoList)
                {
                    List<ThemeTranslationItemData> translationsList = new List<ThemeTranslationItemData>();
                    ThemeTranslationRequestData findThemeTranslationRequest = new ThemeTranslationRequestData
                    {
                        ThemeTranslationDto = new ThemeTranslationItemData { ThemeId = themeItemData.ThemeId },
                        FindThemeTranslationDto = FindThemeTranslationItemData.ThemeId
                    };
                    ThemeTranslationResultData resultThemeTranslation =
                        await WebApiClient.PostFormJsonAsync<ThemeTranslationRequestData, ThemeTranslationResultData>(
                            Constant.WebApiControllerRessources, Constant.WebApiFindThemeTranslations,
                            findThemeTranslationRequest);
                    if (resultThemeTranslation != null && resultThemeTranslation.OperationSuccess &&
                        resultThemeTranslation.ThemeTranslationDtoList != null)
                    {
                        translationsList.AddRange(resultThemeTranslation.ThemeTranslationDtoList);
                    }

                    themesList.Add(new ThemeViewData
                    {
                        TranslationsList = translationsList,
                        Theme = themeItemData
                    });
                }
            }

            ThemesViewData themeViewData = new ThemesViewData { Themes = themesList };
            return View("Partials/_ThemesList", themeViewData);
        }

        #region CREATE THEME 

        /// <summary>
        /// Get theme form to create.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetCreateTheme()
        {
            ThemeFormData themeFormData = new ThemeFormData { TranslationsList = new List<ThemeTranslationFormData>() };
            LanguageResultData result =
                await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages,
                    Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new ThemeTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId
                    };
                    themeFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateTheme";
            return PartialView("Partials/_ManageTheme", themeFormData);
        }


        /// <summary>
        /// Create Theme Action
        /// </summary>
        /// <param name="themeFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateTheme(ThemeFormData themeFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                ThemeRequestData request = themeFormData.ToRequestData();
                ThemeResultData result =
                    await WebApiClient.PostFormJsonAsync<ThemeRequestData, ThemeResultData>(
                        Constant.WebApiControllerRessources, Constant.WebApiCreateTheme, request);
                if (result != null && result.OperationSuccess && result.ThemeDto != null)
                {
                    foreach (var translation in themeFormData.TranslationsList.ToList())
                    {
                        translation.ThemeId = result.ThemeDto.ThemeId;
                    }
                    ThemeTranslationRequestData translationRequest = new ThemeTranslationRequestData
                    {
                        ThemeTranslationDtoList = themeFormData.TranslationsList.ToItemDataList()
                    };

                    ThemeTranslationResultData themeTranslationResultData =
                        await WebApiClient.PostFormJsonAsync<ThemeTranslationRequestData, ThemeTranslationResultData>(
                            Constant.WebApiControllerRessources, Constant.WebApiCreateThemeTranslationRange,
                            translationRequest);
                    if (themeTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!themeTranslationResultData.OperationSuccess &&
                             themeTranslationResultData.Errors != null && themeTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = themeTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (themeTranslationResultData.OperationSuccess)
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
                    ErrorMessage = ThemeResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region UPDATE THEME

        /// <summary>
        /// Get Theme Model for Update
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetUpdateTheme(int? themeId)
        {
            ThemeFormData themeFormData = new ThemeFormData
            {
                TranslationsList = new List<ThemeTranslationFormData>()
            };

            if (themeId.HasValue)
            {
                ThemeRequestData findThemeRequest = new ThemeRequestData
                {
                    ThemeDto = new ThemeItemData { ThemeId = themeId.Value },
                    FindThemeDto = FindThemeItemData.ThemeId
                };
                ThemeResultData resultTheme =
                    await WebApiClient.PostFormJsonAsync<ThemeRequestData, ThemeResultData>(
                        Constant.WebApiControllerRessources, Constant.WebApiFindThemes, findThemeRequest);

                if (resultTheme != null && resultTheme.OperationSuccess && resultTheme.ThemeDto != null)
                {
                    themeFormData.ThemeId = resultTheme.ThemeDto.ThemeId;
                    ThemeTranslationRequestData findThemeTranslationRequest = new ThemeTranslationRequestData
                    {
                        ThemeTranslationDto = new ThemeTranslationItemData { ThemeId = themeId.Value },
                        FindThemeTranslationDto = FindThemeTranslationItemData.ThemeId
                    };
                    ThemeTranslationResultData resultThemeTranslation =
                        await WebApiClient.PostFormJsonAsync<ThemeTranslationRequestData, ThemeTranslationResultData>(
                            Constant.WebApiControllerRessources, Constant.WebApiFindThemeTranslations,
                            findThemeTranslationRequest);
                    if (resultThemeTranslation != null && resultThemeTranslation.OperationSuccess &&
                        resultThemeTranslation.ThemeTranslationDtoList != null)
                    {
                        themeFormData.TranslationsList = resultThemeTranslation.ThemeTranslationDtoList
                            .ToFormDataList();
                    }
                }
            }
            ViewBag.Action = "UpdateTheme";
            return PartialView("Partials/_ManageTheme", themeFormData);
        }

        /// <summary>
        /// Update Theme Action
        /// </summary>
        /// <param name="themeFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateTheme(ThemeFormData themeFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                ThemeRequestData request = themeFormData.ToRequestData();
                ThemeResultData themeResult =
                    await WebApiClient.PostFormJsonAsync<ThemeRequestData, ThemeResultData>(
                        Constant.WebApiControllerRessources, Constant.WebApiUpdateTheme, request);
                if (themeResult != null && themeResult.OperationSuccess)
                {
                    ThemeTranslationRequestData themeTranslationRequestData = new ThemeTranslationRequestData
                    {
                        ThemeTranslationDtoList = themeFormData.TranslationsList.ToItemDataList()
                    };

                    ThemeTranslationResultData themeTranslationResultData =
                        await WebApiClient.PostFormJsonAsync<ThemeTranslationRequestData, ThemeTranslationResultData>(
                            Constant.WebApiControllerRessources, Constant.WebApiUpdateThemeTranslationRange,
                            themeTranslationRequestData);
                    if (themeTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!themeTranslationResultData.OperationSuccess &&
                             themeTranslationResultData.Errors != null && themeTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = themeTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (themeTranslationResultData.OperationSuccess)
                    {
                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (themeResult == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!themeResult.OperationSuccess && themeResult.Errors != null && themeResult.Errors.Count > 0)
                {
                    data.ErrorMessage = themeResult.Errors.First();
                    data.OperationSuccess = false;
                }
                else if (themeResult.OperationSuccess)
                {
                    data.SuccessMessage = UserResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = ThemeResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region DELETE THEME

        /// <summary>
        /// Get delete theme.
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public ActionResult GetDeleteTheme(int themeId)
        {
            return View("Partials/_DeleteTheme", themeId);
        }

        /// <summary>
        /// Delete Theme
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteTheme(int themeId)
        {
            JsonReturnData data = new JsonReturnData();
            if (themeId > 0)
            {
                string param = $"{nameof(themeId)}={themeId}";
                ThemeResultData result =
                    await WebApiClient.DeleteAsync<ThemeResultData>(Constant.WebApiControllerRessources,
                        Constant.WebApiRemoveTheme, param);
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

        #region THEME VALIDATION

        /// <summary>
        /// validate create theme translation.
        /// </summary>
        /// <param name="themeTranslationFormData">the themeTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateThemeTranslationFormData(ThemeTranslationFormData themeTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (themeTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ThemeTranslationFormData>.ValidateAttributes("LanguageId",
                    themeTranslationFormData.LanguageId.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<ThemeTranslationFormData>.ValidateAttributes("ThemeName",
                        themeTranslationFormData.ThemeName));
            }
            return errors.Count == 0;
        }

        #endregion

        #endregion

        #region AREAS

        /// <summary>
        /// Get Areas section.
        /// </summary>
        /// <returns>Areas view.</returns>
        public async Task<ActionResult> Areas()
        {
            AreaResultData areaResultData =
                await WebApiClient.GetAsync<AreaResultData>(Constant.WebApiControllerRessources,
                    Constant.WebApiAreaList);
            List<AreaViewData> areasList = new List<AreaViewData>();

            if (areaResultData?.AreaDtoList != null && areaResultData.OperationSuccess)
            {
                foreach (var areaItemData in areaResultData.AreaDtoList)
                {
                    List<AreaTranslationItemData> translationsList = new List<AreaTranslationItemData>();
                    AreaTranslationRequestData findAreaTranslationRequest = new AreaTranslationRequestData
                    {
                        AreaTranslationDto = new AreaTranslationItemData { AreaId = areaItemData.AreaId },
                        FindAreaTranslationDto = FindAreaTranslationItemData.AreaId
                    };
                    AreaTranslationResultData resultAreaTranslation =
                        await WebApiClient.PostFormJsonAsync<AreaTranslationRequestData, AreaTranslationResultData>(
                            Constant.WebApiControllerRessources, Constant.WebApiFindAreaTranslations,
                            findAreaTranslationRequest);
                    if (resultAreaTranslation != null && resultAreaTranslation.OperationSuccess &&
                        resultAreaTranslation.AreaTranslationDtoList != null)
                    {
                        translationsList.AddRange(resultAreaTranslation.AreaTranslationDtoList);
                    }

                    areasList.Add(new AreaViewData
                    {
                        TranslationsList = translationsList,
                        Area = areaItemData
                    });
                }
            }

            AreasViewData areaViewData = new AreasViewData { Areas = areasList };
            return View("Partials/_Areas", areaViewData);
        }

        /// <summary>
        /// Get areas list.
        /// </summary>
        /// <returns>areas view.</returns>
        public async Task<ActionResult> GetAreas()
        {
            AreaResultData areaResultData =
                await WebApiClient.GetAsync<AreaResultData>(Constant.WebApiControllerRessources,
                    Constant.WebApiAreaList);
            List<AreaViewData> areasList = new List<AreaViewData>();

            if (areaResultData?.AreaDtoList != null && areaResultData.OperationSuccess)
            {
                foreach (var areaItemData in areaResultData.AreaDtoList)
                {
                    List<AreaTranslationItemData> translationsList = new List<AreaTranslationItemData>();
                    AreaTranslationRequestData findAreaTranslationRequest = new AreaTranslationRequestData
                    {
                        AreaTranslationDto = new AreaTranslationItemData { AreaId = areaItemData.AreaId },
                        FindAreaTranslationDto = FindAreaTranslationItemData.AreaId
                    };
                    AreaTranslationResultData resultAreaTranslation =
                        await WebApiClient.PostFormJsonAsync<AreaTranslationRequestData, AreaTranslationResultData>(
                            Constant.WebApiControllerRessources, Constant.WebApiFindAreaTranslations,
                            findAreaTranslationRequest);
                    if (resultAreaTranslation != null && resultAreaTranslation.OperationSuccess &&
                        resultAreaTranslation.AreaTranslationDtoList != null)
                    {
                        translationsList.AddRange(resultAreaTranslation.AreaTranslationDtoList);
                    }

                    areasList.Add(new AreaViewData
                    {
                        TranslationsList = translationsList,
                        Area = areaItemData
                    });
                }
            }

            AreasViewData areaViewData = new AreasViewData { Areas = areasList };
            return View("Partials/_AreasList", areaViewData);
        }

        #region CREATE THEME 

        /// <summary>
        /// Get area form to create.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetCreateArea()
        {
            AreaFormData areaFormData = new AreaFormData { TranslationsList = new List<AreaTranslationFormData>() };
            LanguageResultData result =
                await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages,
                    Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new AreaTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId
                    };
                    areaFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateArea";
            return PartialView("Partials/_ManageArea", areaFormData);
        }

        /// <summary>
        /// Create Area Action
        /// </summary>
        /// <param name="areaFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateArea(AreaFormData areaFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                AreaRequestData request = areaFormData.ToRequestData();
                AreaResultData result =
                    await WebApiClient.PostFormJsonAsync<AreaRequestData, AreaResultData>(
                        Constant.WebApiControllerRessources, Constant.WebApiCreateArea, request);
                if (result != null && result.OperationSuccess && result.AreaDto != null)
                {
                    foreach (var translation in areaFormData.TranslationsList.ToList())
                    {
                        translation.AreaId = result.AreaDto.AreaId;
                    }
                    AreaTranslationRequestData translationRequest = new AreaTranslationRequestData
                    {
                        AreaTranslationDtoList = areaFormData.TranslationsList.ToItemDataList()
                    };

                    AreaTranslationResultData areaTranslationResultData =
                        await WebApiClient.PostFormJsonAsync<AreaTranslationRequestData, AreaTranslationResultData>(
                            Constant.WebApiControllerRessources, Constant.WebApiCreateAreaTranslationRange,
                            translationRequest);
                    if (areaTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!areaTranslationResultData.OperationSuccess && areaTranslationResultData.Errors != null &&
                             areaTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = areaTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (areaTranslationResultData.OperationSuccess)
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
                    ErrorMessage = AreaResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region UPDATE THEME

        /// <summary>
        /// Get Area Model for Update
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetUpdateArea(int? areaId)
        {
            AreaFormData areaFormData = new AreaFormData
            {
                TranslationsList = new List<AreaTranslationFormData>()
            };

            if (areaId.HasValue)
            {
                AreaRequestData findAreaRequest = new AreaRequestData
                {
                    AreaDto = new AreaItemData { AreaId = areaId.Value },
                    FindAreaDto = FindAreaItemData.AreaId
                };
                AreaResultData resultArea =
                    await WebApiClient.PostFormJsonAsync<AreaRequestData, AreaResultData>(
                        Constant.WebApiControllerRessources, Constant.WebApiFindAreas, findAreaRequest);

                if (resultArea != null && resultArea.OperationSuccess && resultArea.AreaDto != null)
                {
                    areaFormData.AreaId = resultArea.AreaDto.AreaId;
                    AreaTranslationRequestData findAreaTranslationRequest = new AreaTranslationRequestData
                    {
                        AreaTranslationDto = new AreaTranslationItemData { AreaId = areaId.Value },
                        FindAreaTranslationDto = FindAreaTranslationItemData.AreaId
                    };
                    AreaTranslationResultData resultAreaTranslation =
                        await WebApiClient.PostFormJsonAsync<AreaTranslationRequestData, AreaTranslationResultData>(
                            Constant.WebApiControllerRessources, Constant.WebApiFindAreaTranslations,
                            findAreaTranslationRequest);
                    if (resultAreaTranslation != null && resultAreaTranslation.OperationSuccess &&
                        resultAreaTranslation.AreaTranslationDtoList != null)
                    {
                        areaFormData.TranslationsList = resultAreaTranslation.AreaTranslationDtoList.ToFormDataList();
                    }
                }
            }
            ViewBag.Action = "UpdateArea";
            return PartialView("Partials/_ManageArea", areaFormData);
        }

        /// <summary>
        /// Update Area Action
        /// </summary>
        /// <param name="areaFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateArea(AreaFormData areaFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                AreaRequestData request = areaFormData.ToRequestData();
                AreaResultData areaResult =
                    await WebApiClient.PostFormJsonAsync<AreaRequestData, AreaResultData>(
                        Constant.WebApiControllerRessources, Constant.WebApiUpdateArea, request);
                if (areaResult != null && areaResult.OperationSuccess)
                {
                    AreaTranslationRequestData areaTranslationRequestData = new AreaTranslationRequestData
                    {
                        AreaTranslationDtoList = areaFormData.TranslationsList.ToItemDataList()
                    };

                    AreaTranslationResultData areaTranslationResultData =
                        await WebApiClient.PostFormJsonAsync<AreaTranslationRequestData, AreaTranslationResultData>(
                            Constant.WebApiControllerRessources, Constant.WebApiUpdateAreaTranslationRange,
                            areaTranslationRequestData);
                    if (areaTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!areaTranslationResultData.OperationSuccess &&
                             areaTranslationResultData.Errors != null && areaTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = areaTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (areaTranslationResultData.OperationSuccess)
                    {
                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (areaResult == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!areaResult.OperationSuccess && areaResult.Errors != null && areaResult.Errors.Count > 0)
                {
                    data.ErrorMessage = areaResult.Errors.First();
                    data.OperationSuccess = false;
                }
                else if (areaResult.OperationSuccess)
                {
                    data.SuccessMessage = UserResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = AreaResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region DELETE THEME

        /// <summary>
        /// Get delete area.
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public ActionResult GetDeleteArea(int areaId)
        {
            return View("Partials/_DeleteArea", areaId);
        }

        /// <summary>
        /// Delete Area
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteArea(int areaId)
        {
            JsonReturnData data = new JsonReturnData();
            if (areaId > 0)
            {
                string param = $"{nameof(areaId)}={areaId}";
                AreaResultData result =
                    await WebApiClient.DeleteAsync<AreaResultData>(Constant.WebApiControllerRessources,
                        Constant.WebApiRemoveArea, param);
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

        #region AREA VALIDATION

        /// <summary>
        /// validate create area translation.
        /// </summary>
        /// <param name="areaTranslationFormData">the areaTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateAreaTranslationFormData(AreaTranslationFormData areaTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (areaTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<AreaTranslationFormData>.ValidateAttributes("LanguageId",
                    areaTranslationFormData.LanguageId.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<AreaTranslationFormData>.ValidateAttributes("AreaName",
                        areaTranslationFormData.AreaName));
            }
            return errors.Count == 0;
        }

        #endregion

        #endregion

        #region PUBLICATIONS

        /// <summary>
        /// Get Publications section.
        /// </summary>
        /// <returns>Publications view.</returns>
        public async Task<ActionResult> Publications()
        {
            PublicationResultData publicationResultData =
                await WebApiClient.GetAsync<PublicationResultData>(Constant.WebApiControllerRessources,
                    Constant.WebApiPublicationList);
            List<PublicationViewData> publicationsList = new List<PublicationViewData>();

            if (publicationResultData?.PublicationDtoList != null && publicationResultData.OperationSuccess)
            {
                foreach (var publicationItemData in publicationResultData.PublicationDtoList)
                {
                    List<PublicationTranslationItemData> translationsList = new List<PublicationTranslationItemData>();
                    PublicationTranslationRequestData findPublicationTranslationRequest =
                        new PublicationTranslationRequestData
                        {
                            PublicationTranslationDto =
                                new PublicationTranslationItemData { PublicationId = publicationItemData.PublicationId },
                            FindPublicationTranslationDto = FindPublicationTranslationItemData.PublicationId
                        };
                    PublicationTranslationResultData resultPublicationTranslation =
                        await WebApiClient
                            .PostFormJsonAsync<PublicationTranslationRequestData, PublicationTranslationResultData>(
                                Constant.WebApiControllerRessources, Constant.WebApiFindPublicationTranslations,
                                findPublicationTranslationRequest);
                    if (resultPublicationTranslation != null && resultPublicationTranslation.OperationSuccess &&
                        resultPublicationTranslation.PublicationTranslationDtoList != null)
                    {
                        translationsList.AddRange(resultPublicationTranslation.PublicationTranslationDtoList);
                    }

                    publicationsList.Add(new PublicationViewData
                    {
                        TranslationsList = translationsList,
                        Publication = publicationItemData
                    });
                }
            }
            PublicationsViewData publicationViewData = new PublicationsViewData { Publications = publicationsList };
            return View("Partials/_Publications", publicationViewData);
        }

        /// <summary>
        /// Get publications list.
        /// </summary>
        /// <returns>publications view.</returns>
        public async Task<ActionResult> GetPublications()
        {
            PublicationResultData publicationResultData =
                await WebApiClient.GetAsync<PublicationResultData>(Constant.WebApiControllerRessources,
                    Constant.WebApiPublicationList);
            List<PublicationViewData> publicationsList = new List<PublicationViewData>();

            if (publicationResultData?.PublicationDtoList != null && publicationResultData.OperationSuccess)
            {
                foreach (var publicationItemData in publicationResultData.PublicationDtoList)
                {
                    List<PublicationTranslationItemData> translationsList = new List<PublicationTranslationItemData>();
                    PublicationTranslationRequestData findPublicationTranslationRequest =
                        new PublicationTranslationRequestData
                        {
                            PublicationTranslationDto =
                                new PublicationTranslationItemData { PublicationId = publicationItemData.PublicationId },
                            FindPublicationTranslationDto = FindPublicationTranslationItemData.PublicationId
                        };
                    PublicationTranslationResultData resultPublicationTranslation =
                        await WebApiClient
                            .PostFormJsonAsync<PublicationTranslationRequestData, PublicationTranslationResultData>(
                                Constant.WebApiControllerRessources, Constant.WebApiFindPublicationTranslations,
                                findPublicationTranslationRequest);
                    if (resultPublicationTranslation != null && resultPublicationTranslation.OperationSuccess &&
                        resultPublicationTranslation.PublicationTranslationDtoList != null)
                    {
                        translationsList.AddRange(resultPublicationTranslation.PublicationTranslationDtoList);
                    }

                    publicationsList.Add(new PublicationViewData
                    {
                        TranslationsList = translationsList,
                        Publication = publicationItemData
                    });
                }
            }

            PublicationsViewData publicationViewData = new PublicationsViewData { Publications = publicationsList };
            return View("Partials/_PublicationsList", publicationViewData);
        }

        #region CREATE PUBLICATION 

        /// <summary>
        /// Get publication form to create.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetCreatePublication()
        {
            //GET THE LIST OF THE AREAS.
            AreaResultData areaResultData =
                await WebApiClient.GetAsync<AreaResultData>(Constant.WebApiControllerRessources,
                    Constant.WebApiAreaList);
            List<AreaViewData> areasList = new List<AreaViewData>();
            if (areaResultData?.AreaDtoList != null && areaResultData.OperationSuccess)
            {
                foreach (var areaItemData in areaResultData.AreaDtoList)
                {
                    List<AreaTranslationItemData> translationsList = new List<AreaTranslationItemData>();
                    AreaTranslationRequestData findAreaTranslationRequest = new AreaTranslationRequestData
                    {
                        AreaTranslationDto = new AreaTranslationItemData { AreaId = areaItemData.AreaId },
                        FindAreaTranslationDto = FindAreaTranslationItemData.AreaId
                    };
                    AreaTranslationResultData resultAreaTranslation =
                        await WebApiClient.PostFormJsonAsync<AreaTranslationRequestData, AreaTranslationResultData>(
                            Constant.WebApiControllerRessources, Constant.WebApiFindAreaTranslations,
                            findAreaTranslationRequest);
                    if (resultAreaTranslation != null && resultAreaTranslation.OperationSuccess &&
                        resultAreaTranslation.AreaTranslationDtoList != null)
                    {
                        translationsList.AddRange(resultAreaTranslation.AreaTranslationDtoList);
                    }

                    areasList.Add(new AreaViewData
                    {
                        TranslationsList = translationsList,
                        Area = areaItemData
                    });
                }
            }

            List<SelectListItem> areas = (from areaViewData in areasList
                                          where areaViewData?.Area != null && areaViewData.TranslationsList != null
                                          let areaTranslationItemData = areaViewData.TranslationsList.FirstOrDefault()
                                          where areaTranslationItemData != null
                                          select new SelectListItem
                                          {
                                              Text = areaTranslationItemData.AreaName,
                                              Value = areaViewData.Area.AreaId.ToString()
                                          }).ToList();
            ViewBag.Areas = areas;

            //GET THE LIST OF THE AUTHORS .
            AuthorResultData authorResultData =
                await WebApiClient.GetAsync<AuthorResultData>(Constant.WebApiControllerRessources,
                    Constant.WebApiAuthorList);
            List<SelectListItem> authors = new List<SelectListItem>();

            if (authorResultData?.AuthorDtoList != null && authorResultData.OperationSuccess)
            {
                authors.AddRange(from authorItemData in authorResultData.AuthorDtoList
                                 select new SelectListItem
                                 {
                                     Text = authorItemData.AuthorFirstName + @" " + authorItemData.AuthorLastName,
                                     Value = authorItemData.AuthorId.ToString()
                                 });
            }
            ViewBag.Authors = authors;

            //GET THE LIST OF LANGS.
            CreatePublicationFormData publicationFormData =
                new CreatePublicationFormData
                {
                    PublicationDate = DateTime.Now.ToString("dd/MM/yyyy"),
                    TranslationsList = new List<CreatePublicationTranslationFormData>()
                };
            LanguageResultData result =
                await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages,
                    Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new CreatePublicationTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId
                    };
                    publicationFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreatePublication";
            return PartialView("Partials/_CreatePublication", publicationFormData);
        }

        /// <summary>
        /// Create Publication Action
        /// </summary>
        /// <param name="publicationFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreatePublication(CreatePublicationFormData publicationFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                PublicationRequestData request = publicationFormData.ToRequestData();
                if (request.PublicationDto.PublicationImage == null)
                {
                    request.PublicationDto.PublicationImage = "default-image-publication.jpg";
                }

                PublicationResultData result =
                    await WebApiClient.PostFormJsonAsync<PublicationRequestData, PublicationResultData>(
                        Constant.WebApiControllerRessources, Constant.WebApiCreatePublication, request);
                if (result != null && result.OperationSuccess && result.PublicationDto != null)
                {
                    foreach (var translation in publicationFormData.TranslationsList.ToList())
                    {
                        translation.PublicationId = result.PublicationDto.PublicationId;
                    }
                    PublicationTranslationRequestData translationRequest = new PublicationTranslationRequestData
                    {
                        PublicationTranslationDtoList = publicationFormData.TranslationsList.ToItemDataList()
                    };

                    PublicationTranslationResultData publicationTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<PublicationTranslationRequestData, PublicationTranslationResultData>(
                                Constant.WebApiControllerRessources, Constant.WebApiCreatePublicationTranslationRange,
                                translationRequest);
                    if (publicationTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!publicationTranslationResultData.OperationSuccess &&
                             publicationTranslationResultData.Errors != null &&
                             publicationTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = publicationTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (publicationTranslationResultData.OperationSuccess)
                    {
                        Directory.CreateDirectory(
                            Server.MapPath($"~/Images/Ressources/Pulication/" + result.PublicationDto.PublicationId));

                        publicationFormData.PublicationImage?.SaveAs(
                            Server.MapPath($"~/Images/Ressources/Pulication/" + result.PublicationDto.PublicationId) +
                            $"/" +
                            publicationFormData.PublicationImage?.FileName);

                        foreach (var publicationTranslationFormData in publicationFormData.TranslationsList.ToList())
                        {
                            publicationTranslationFormData.PublicationFile?.SaveAs(
                                Server.MapPath($"~/Images/Ressources/Pulication/" +
                                               result.PublicationDto.PublicationId) +
                                $"/" +
                                publicationTranslationFormData.PublicationFile?.FileName);
                        }

                        System.IO.File.Copy(Server.MapPath($"~/Images/Default/default-image-publication.jpg"),
                            Server.MapPath($"~/Images/Ressources/Pulication/" + result.PublicationDto.PublicationId +
                                           $"/default-image-publication.jpg"));

                        data.SuccessMessage = PublicationResources.Ok;
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
                    ErrorMessage = PublicationResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region UPDATE PUBLICATION

        /// <summary>
        /// Get Publication Model for Update
        /// </summary>
        /// <param name="publicationId"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetUpdatePublication(int? publicationId)
        {
            UpdatePublicationFormData publicationFormData = new UpdatePublicationFormData
            {
                TranslationsList = new List<UpdatePublicationTranslationFormData>()
            };

            if (publicationId.HasValue)
            {
                //GET THE LIST OF THE AREAS.
                AreaResultData areaResultData =
                    await WebApiClient.GetAsync<AreaResultData>(Constant.WebApiControllerRessources,
                        Constant.WebApiAreaList);
                List<AreaViewData> areasList = new List<AreaViewData>();
                if (areaResultData?.AreaDtoList != null && areaResultData.OperationSuccess)
                {
                    foreach (var areaItemData in areaResultData.AreaDtoList)
                    {
                        List<AreaTranslationItemData> translationsList = new List<AreaTranslationItemData>();
                        AreaTranslationRequestData findAreaTranslationRequest = new AreaTranslationRequestData
                        {
                            AreaTranslationDto = new AreaTranslationItemData { AreaId = areaItemData.AreaId },
                            FindAreaTranslationDto = FindAreaTranslationItemData.AreaId
                        };
                        AreaTranslationResultData resultAreaTranslation =
                            await WebApiClient.PostFormJsonAsync<AreaTranslationRequestData, AreaTranslationResultData>(
                                Constant.WebApiControllerRessources, Constant.WebApiFindAreaTranslations,
                                findAreaTranslationRequest);
                        if (resultAreaTranslation != null && resultAreaTranslation.OperationSuccess &&
                            resultAreaTranslation.AreaTranslationDtoList != null)
                        {
                            translationsList.AddRange(resultAreaTranslation.AreaTranslationDtoList);
                        }

                        areasList.Add(new AreaViewData
                        {
                            TranslationsList = translationsList,
                            Area = areaItemData
                        });
                    }
                }

                List<SelectListItem> areas = (from areaViewData in areasList
                                              where areaViewData?.Area != null && areaViewData.TranslationsList != null
                                              let areaTranslationItemData = areaViewData.TranslationsList.FirstOrDefault()
                                              where areaTranslationItemData != null
                                              select new SelectListItem
                                              {
                                                  Text = areaTranslationItemData.AreaName,
                                                  Value = areaViewData.Area.AreaId.ToString()
                                              }).ToList();
                ViewBag.Areas = areas;

                //GET THE LIST OF THE AUTHORS .
                AuthorResultData authorResultData =
                    await WebApiClient.GetAsync<AuthorResultData>(Constant.WebApiControllerRessources,
                        Constant.WebApiAuthorList);
                List<SelectListItem> authors = new List<SelectListItem>();

                if (authorResultData?.AuthorDtoList != null && authorResultData.OperationSuccess)
                {
                    authors.AddRange(from authorItemData in authorResultData.AuthorDtoList
                                     select new SelectListItem
                                     {
                                         Text = authorItemData.AuthorFirstName + @" " + authorItemData.AuthorLastName,
                                         Value = authorItemData.AuthorId.ToString()
                                     });
                }
                ViewBag.Authors = authors;

                //GET THE PUBLICATION TO UPDATE.
                PublicationRequestData findPublicationRequest = new PublicationRequestData
                {
                    PublicationDto = new PublicationItemData { PublicationId = publicationId.Value },
                    FindPublicationDto = FindPublicationItemData.PublicationId
                };
                PublicationResultData resultPublication =
                    await WebApiClient.PostFormJsonAsync<PublicationRequestData, PublicationResultData>(
                        Constant.WebApiControllerRessources, Constant.WebApiFindPublications, findPublicationRequest);

                if (resultPublication != null && resultPublication.OperationSuccess &&
                    resultPublication.PublicationDto != null)
                {
                    publicationFormData.PublicationDate =
                        resultPublication.PublicationDto.PublicationDate.ToString("dd/MM/yyyy");
                    publicationFormData.PublicationId = resultPublication.PublicationDto.PublicationId;
                    publicationFormData.AuthorId = resultPublication.PublicationDto.AuthorId;
                    publicationFormData.AreaId = resultPublication.PublicationDto.AreaId;

                    PublicationTranslationRequestData findPublicationTranslationRequest =
                        new PublicationTranslationRequestData
                        {
                            PublicationTranslationDto =
                                new PublicationTranslationItemData { PublicationId = publicationId.Value },
                            FindPublicationTranslationDto = FindPublicationTranslationItemData.PublicationId
                        };
                    PublicationTranslationResultData resultPublicationTranslation =
                        await WebApiClient
                            .PostFormJsonAsync<PublicationTranslationRequestData, PublicationTranslationResultData>(
                                Constant.WebApiControllerRessources, Constant.WebApiFindPublicationTranslations,
                                findPublicationTranslationRequest);
                    if (resultPublicationTranslation != null && resultPublicationTranslation.OperationSuccess &&
                        resultPublicationTranslation.PublicationTranslationDtoList != null)
                    {
                        publicationFormData.TranslationsList = resultPublicationTranslation
                            .PublicationTranslationDtoList.ToUpdateFormDataList();
                    }
                }
            }
            ViewBag.Action = "UpdatePublication";
            return PartialView("Partials/_UpdatePublication", publicationFormData);
        }

        /// <summary>
        /// Update Publication Action
        /// </summary>
        /// <param name="publicationFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdatePublication(UpdatePublicationFormData publicationFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                PublicationRequestData request = publicationFormData.ToRequestData();
                PublicationResultData publicationResult =
                    await WebApiClient.PostFormJsonAsync<PublicationRequestData, PublicationResultData>(
                        Constant.WebApiControllerRessources, Constant.WebApiUpdatePublication, request);
                if (publicationResult != null && publicationResult.OperationSuccess)
                {
                    PublicationTranslationRequestData publicationTranslationRequestData =
                        new PublicationTranslationRequestData
                        {
                            FindPublicationTranslationDto = FindPublicationTranslationItemData.PublicationTranslationId,
                            PublicationTranslationDtoList = publicationFormData.TranslationsList.ToItemDataList(),
                            PublicationTranslationDto = new PublicationTranslationItemData()
                        };

                    PublicationTranslationResultData publicationTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<PublicationTranslationRequestData, PublicationTranslationResultData>(
                                Constant.WebApiControllerRessources, Constant.WebApiUpdatePublicationTranslationRange,
                                publicationTranslationRequestData);
                    if (publicationTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!publicationTranslationResultData.OperationSuccess &&
                             publicationTranslationResultData.Errors != null &&
                             publicationTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = publicationTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (publicationTranslationResultData.OperationSuccess)
                    {
                        if (!Directory.Exists(
                            Server.MapPath($"~/Images/Ressources/Pulication/" + publicationFormData.PublicationId)))
                        {
                            Directory.CreateDirectory(
                                Server.MapPath($"~/Images/Ressources/Pulication/" + publicationFormData.PublicationId));
                        }

                        publicationFormData.PublicationImage?.SaveAs(
                            Server.MapPath(
                                $"~/Images/Ressources/Pulication/" + publicationFormData.PublicationId + $"/") +
                            publicationFormData.PublicationImage?.FileName);


                        foreach (var publicationTranslationFormData in publicationFormData.TranslationsList.ToList())
                        {
                            publicationTranslationFormData.PublicationFile?.SaveAs(
                                Server.MapPath($"~/Images/Ressources/Pulication/" + publicationFormData.PublicationId +
                                               $"/") + publicationTranslationFormData.PublicationFile?.FileName);
                        }

                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (publicationResult == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!publicationResult.OperationSuccess && publicationResult.Errors != null &&
                         publicationResult.Errors.Count > 0)
                {
                    data.ErrorMessage = publicationResult.Errors.First();
                    data.OperationSuccess = false;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = PublicationResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region DELETE PUBLICATION

        /// <summary>
        /// Get delete publication.
        /// </summary>
        /// <param name="publicationId"></param>
        /// <returns></returns>
        public ActionResult GetDeletePublication(int publicationId)
        {
            return View("Partials/_DeletePublication", publicationId);
        }

        /// <summary>
        /// Delete Publication
        /// </summary>
        /// <param name="publicationId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeletePublication(int publicationId)
        {
            JsonReturnData data = new JsonReturnData();
            if (publicationId > 0)
            {
                string param = $"{nameof(publicationId)}={publicationId}";
                PublicationResultData result =
                    await WebApiClient.DeleteAsync<PublicationResultData>(Constant.WebApiControllerRessources,
                        Constant.WebApiRemovePublication, param);
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
                    if (Directory.Exists(Server.MapPath($"~/Images/Ressources/Pulication/" + publicationId)))
                    {
                        Directory.Delete(Server.MapPath($"~/Images/Ressources/Pulication/" + publicationId), true);
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

        #region PUBLICATION VALIDATION

        /// <summary>
        /// validate create publication translation.
        /// </summary>
        /// <param name="publicationFormData">the publicationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateCreatePublicationFormData(CreatePublicationFormData publicationFormData)
        {
            List<string> errors = new List<string>();
            if (publicationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<CreatePublicationFormData>.ValidateAttributes("PublicationDate",
                    publicationFormData.PublicationDate));
                errors.AddRange(GenericValidationAttribute<CreatePublicationFormData>.ValidateAttributes("AuthorId",
                    publicationFormData.AuthorId.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<CreatePublicationFormData>.ValidateAttributes("AreaId",
                        publicationFormData.AreaId.ToString()));
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// validate create publication translation.
        /// </summary>
        /// <param name="publicationTranslationFormData">the publicationTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateCreatePublicationTranslationFormData(
            CreatePublicationTranslationFormData publicationTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (publicationTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                if (string.IsNullOrEmpty(publicationTranslationFormData.PublicationFileSource)) { errors.Add(PublicationResources.DisplayPublicationFile); }
                errors.AddRange(GenericValidationAttribute<CreatePublicationTranslationFormData>.ValidateAttributes(
                    "PublicationSummary", publicationTranslationFormData.PublicationSummary));
                errors.AddRange(
                    GenericValidationAttribute<CreatePublicationTranslationFormData>.ValidateAttributes("LanguageId",
                        publicationTranslationFormData.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<CreatePublicationTranslationFormData>.ValidateAttributes(
                    "PublicationTitle", publicationTranslationFormData.PublicationTitle));
            }
            return errors.Count == 0;
        }


        /// <summary>
        /// validate create publication translation.
        /// </summary>
        /// <param name="publicationFormData">the publicationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateUpdatePublicationFormData(UpdatePublicationFormData publicationFormData)
        {
            List<string> errors = new List<string>();
            if (publicationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<UpdatePublicationFormData>.ValidateAttributes("PublicationId",
                    publicationFormData.PublicationId.ToString()));
                errors.AddRange(GenericValidationAttribute<UpdatePublicationFormData>.ValidateAttributes("PublicationDate",
                    publicationFormData.PublicationDate));
                errors.AddRange(GenericValidationAttribute<UpdatePublicationFormData>.ValidateAttributes("AuthorId",
                    publicationFormData.AuthorId.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<CreatePublicationFormData>.ValidateAttributes("AreaId",
                        publicationFormData.AreaId.ToString()));
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// validate create publication translation.
        /// </summary>
        /// <param name="publicationTranslationFormData">the publicationTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateUpdatePublicationTranslationFormData(
            UpdatePublicationTranslationFormData publicationTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (publicationTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<UpdatePublicationTranslationFormData>.ValidateAttributes(
                    "PublicationId", publicationTranslationFormData.PublicationId.ToString()));

                errors.AddRange(GenericValidationAttribute<UpdatePublicationTranslationFormData>.ValidateAttributes(
                    "PublicationTranslationId", publicationTranslationFormData.PublicationTranslationId.ToString()));

                errors.AddRange(GenericValidationAttribute<UpdatePublicationTranslationFormData>.ValidateAttributes(
                    "PublicationSummary", publicationTranslationFormData.PublicationSummary));

                errors.AddRange(
                    GenericValidationAttribute<UpdatePublicationTranslationFormData>.ValidateAttributes("LanguageId",
                        publicationTranslationFormData.LanguageId.ToString()));

                errors.AddRange(GenericValidationAttribute<UpdatePublicationTranslationFormData>.ValidateAttributes(
                    "PublicationTitle", publicationTranslationFormData.PublicationTitle));
            }
            return errors.Count == 0;
        }
        #endregion

        #endregion

        #region PUBLICATION THEME

        /// <summary>
        /// Get publicationThemes list.
        /// </summary>
        /// <returns>publications view.</returns>
        public async Task<ActionResult> PublicationThemes(int publicationId)
        {
            PublicationThemeRequestData findPublicationThemeRequest = new PublicationThemeRequestData
            {
                PublicationThemeDto = new PublicationThemeItemData { PublicationId = publicationId },
                FindPublicationThemeDto = FindPublicationThemeItemData.PublicationId
            };
            PublicationThemeResultData publicationThemeResultData =
                await WebApiClient.PostFormJsonAsync<PublicationThemeRequestData, PublicationThemeResultData>(
                    Constant.WebApiControllerRessources, Constant.WebApiFindPublicationThemes,
                    findPublicationThemeRequest);
            List<PublicationThemeViewData> publicationsThemeList = new List<PublicationThemeViewData>();

            if (publicationThemeResultData?.PublicationThemeDtoList != null &&
                publicationThemeResultData.ThemeTranslationDtoList != null &&
                publicationThemeResultData.PublicationTranslationDtoList != null &&
                publicationThemeResultData.OperationSuccess)
            {
                publicationsThemeList.AddRange(
                    from publicationThemeItemData in publicationThemeResultData?.PublicationThemeDtoList
                    select new PublicationThemeViewData
                    {
                        PublicationTheme = new PublicationThemeItemData
                        {
                            PublicationTranslation =
                                publicationThemeResultData.PublicationTranslationDtoList.FirstOrDefault(
                                    p => p.PublicationId == publicationThemeItemData.PublicationId),
                            ThemeTranslation =
                                publicationThemeResultData.ThemeTranslationDtoList.FirstOrDefault(
                                    t => t.ThemeId == publicationThemeItemData.ThemeId),
                            PublicationThemeId = publicationThemeItemData.PublicationThemeId,
                            PublicationId = publicationThemeItemData.PublicationId,
                            ThemeId = publicationThemeItemData.ThemeId
                        }
                    });
            }

            PublicationsThemeViewData publicationsThemeViewData =
                new PublicationsThemeViewData
                {
                    PublicationThemes = publicationsThemeList,
                    PublicationId = publicationId
                };
            return View("Partials/_PublicationThemes", publicationsThemeViewData);
        }

        /// <summary>
        /// Get publicationThemes list.
        /// </summary>
        /// <returns>publications view.</returns>
        public async Task<ActionResult> GetPublicationThemes(int publicationId)
        {
            PublicationThemeRequestData findPublicationThemeRequest = new PublicationThemeRequestData
            {
                PublicationThemeDto = new PublicationThemeItemData { PublicationId = publicationId },
                FindPublicationThemeDto = FindPublicationThemeItemData.PublicationId
            };
            PublicationThemeResultData publicationThemeResultData =
                await WebApiClient.PostFormJsonAsync<PublicationThemeRequestData, PublicationThemeResultData>(
                    Constant.WebApiControllerRessources, Constant.WebApiFindPublicationThemes,
                    findPublicationThemeRequest);
            List<PublicationThemeViewData> publicationsThemeList = new List<PublicationThemeViewData>();

            if (publicationThemeResultData?.PublicationThemeDtoList != null &&
                publicationThemeResultData.ThemeTranslationDtoList != null &&
                publicationThemeResultData.PublicationTranslationDtoList != null &&
                publicationThemeResultData.OperationSuccess)
            {
                publicationsThemeList.AddRange(
                    from publicationThemeItemData in publicationThemeResultData?.PublicationThemeDtoList
                    select new PublicationThemeViewData
                    {
                        PublicationTheme = new PublicationThemeItemData
                        {
                            PublicationTranslation =
                                publicationThemeResultData.PublicationTranslationDtoList.FirstOrDefault(
                                    p => p.PublicationId == publicationThemeItemData.PublicationId),
                            ThemeTranslation =
                                publicationThemeResultData.ThemeTranslationDtoList.FirstOrDefault(
                                    t => t.ThemeId == publicationThemeItemData.ThemeId),
                            PublicationThemeId = publicationThemeItemData.PublicationThemeId,
                            PublicationId = publicationThemeItemData.PublicationId,
                            ThemeId = publicationThemeItemData.ThemeId
                        }
                    });
            }

            PublicationsThemeViewData publicationsThemeViewData =
                new PublicationsThemeViewData
                {
                    PublicationThemes = publicationsThemeList,
                    PublicationId = publicationId
                };
            return View("Partials/_PublicationThemesList", publicationsThemeViewData);
        }

        #region CREATE PUBLICATION THEME

        /// <summary>
        /// Get publication theme form to create.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetCreatePublicationTheme(int publicationId)
        {
            ThemeResultData themeResultData =
                await WebApiClient.GetAsync<ThemeResultData>(Constant.WebApiControllerRessources,
                    Constant.WebApiThemeList);
            List<SelectListItem> themes = new List<SelectListItem>();

            if (themeResultData?.ThemeDtoList != null && themeResultData.OperationSuccess)
            {
                foreach (var themeItemData in themeResultData.ThemeDtoList)
                {
                    ThemeTranslationRequestData findThemeTranslationRequest = new ThemeTranslationRequestData
                    {
                        ThemeTranslationDto = new ThemeTranslationItemData { ThemeId = themeItemData.ThemeId },
                        FindThemeTranslationDto = FindThemeTranslationItemData.ThemeId
                    };

                    ThemeTranslationResultData resultThemeTranslation =
                        await WebApiClient.PostFormJsonAsync<ThemeTranslationRequestData, ThemeTranslationResultData>(
                            Constant.WebApiControllerRessources, Constant.WebApiFindThemeTranslations,
                            findThemeTranslationRequest);
                    if (resultThemeTranslation != null && resultThemeTranslation.OperationSuccess &&
                        resultThemeTranslation.ThemeTranslationDtoList != null)
                    {
                        themes.Add(new SelectListItem
                        {
                            Text = resultThemeTranslation.ThemeTranslationDtoList.FirstOrDefault()?.ThemeName,
                            Value = themeItemData.ThemeId.ToString()
                        });
                    }
                }
            }
            ViewBag.Themes = themes;

            PublicationThemeFormData publicationThemeFormData =
                new PublicationThemeFormData { PublicationId = publicationId };

            ViewBag.Action = "CreatePublicationTheme";
            return PartialView("Partials/_ManagePublicationTheme", publicationThemeFormData);
        }

        /// <summary>
        /// Create PublicationTheme Action
        /// </summary>
        /// <param name="publicationThemeFormData">the publicationtheme</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreatePublicationTheme(PublicationThemeFormData publicationThemeFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                PublicationThemeRequestData request = publicationThemeFormData.ToRequestData();
                PublicationThemeResultData result =
                    await WebApiClient.PostFormJsonAsync<PublicationThemeRequestData, PublicationThemeResultData>(
                        Constant.WebApiControllerRessources, Constant.WebApiCreatePublicationTheme, request);

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
                    data.SuccessMessage = AuthorResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = PublicationThemeResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion


        #region DELETE PUBLICATION THEME

        /// <summary>
        /// Get delete publication.
        /// </summary>
        /// <param name="publicationThemeId">publicationThemeId to delete.</param>
        /// <param name="publicationId">the publication id to get the list.</param>
        /// <returns></returns>
        public ActionResult GetDeletePublicationTheme(int publicationThemeId, int publicationId)
        {
            ViewBag.PublicationId = publicationId;
            return View("Partials/_DeletePublicationTheme", publicationThemeId);
        }

        /// <summary>
        /// Delete Publication
        /// </summary>
        /// <param name="publicationThemeId">The publicationThemeId to delete.</param>
        /// <returns></returns>
        public async Task<ActionResult> DeletePublicationTheme(int publicationThemeId)
        {
            JsonReturnData data = new JsonReturnData();
            if (publicationThemeId > 0)
            {
                string param = $"{nameof(publicationThemeId)}={publicationThemeId}";
                PublicationThemeResultData result =
                    await WebApiClient.DeleteAsync<PublicationThemeResultData>(Constant.WebApiControllerRessources,
                        Constant.WebApiRemovePublicationTheme, param);
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

        #endregion
    }
}