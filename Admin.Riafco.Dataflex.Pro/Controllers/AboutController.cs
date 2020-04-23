using Admin.Riafco.Dataflex.Pro.Authorization;
using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.About.Assembler;
using Admin.Riafco.Dataflex.Pro.Models.About.FormData;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.About.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.About.ResultData;
using Admin.Riafco.Dataflex.Pro.Models.About.ViewData;
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
    /// The AboutController class.
    /// </summary>
    public class AboutController : Controller
    {
        /// <summary>
        /// The index page.
        /// </summary>
        /// Sections Index Action
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            if (Session["ConnectedUser"] == null) { return RedirectToAction("Index", "Home"); }

            bool isAuthorizedUser = await AuthorizeUserAttribute.Authorize("A_ABOUT");
            if (!isAuthorizedUser) return RedirectToAction("NoAccess", "Errors");

            List<SectionViewData> sections = await GetSectionsList();
            SectionsViewData sectionsViewData = new SectionsViewData { Sections = sections };
            ViewBag.About = "active";
            return View(sectionsViewData);
        }

        #region RIAFCO & GOUVERNANCE
        /// <summary>
        /// The about page.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> About()
        {
            List<SectionViewData> sections = await GetSectionsList();
            SectionsViewData sectionsViewData = new SectionsViewData { Sections = sections };
            return View("Partials/_About", sectionsViewData);
        }

        /// <summary>
        /// Get sections List
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetSections()
        {
            List<SectionViewData> sections = await GetSectionsList();
            SectionsViewData sectionsViewData = new SectionsViewData { Sections = sections };
            return View("Partials/_SectionsList", sectionsViewData);
        }

        #region CREATE SECTION 

        /// <summary>
        /// Get section form to create.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetCreateSection()
        {
            SectionFormData sectionFormData = new SectionFormData { TranslationsList = new List<SectionTranslationFormData>() };
            LanguageResultData result = await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages, Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new SectionTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId,
                    };
                    sectionFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateSection";
            return PartialView("Partials/_ManageSection", sectionFormData);
        }


        /// <summary>
        /// Create Section Action
        /// </summary>
        /// <param name="sectionFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateSection(SectionFormData sectionFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                SectionRequestData request = sectionFormData.ToRequestData();

                SectionResultData result =
                    await WebApiClient.PostFormJsonAsync<SectionRequestData, SectionResultData>(
                        Constant.WebApiControllerAbout, Constant.WebApiCreateSection, request);
                if (result != null && result.OperationSuccess && result.SectionDto != null)
                {
                    foreach (var translation in sectionFormData.TranslationsList.ToList())
                    {
                        translation.SectionId = result.SectionDto.SectionId;
                    }
                    SectionTranslationRequestData translationRequest = new SectionTranslationRequestData
                    {
                        SectionTranslationDtoList = sectionFormData.TranslationsList.ToItemDataList()
                    };

                    SectionTranslationResultData sectionTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<SectionTranslationRequestData, SectionTranslationResultData>(
                                Constant.WebApiControllerAbout, Constant.WebApiCreateSectionTranslationRange,
                                translationRequest);
                    if (sectionTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!sectionTranslationResultData.OperationSuccess && sectionTranslationResultData.Errors != null && sectionTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = sectionTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (sectionTranslationResultData.OperationSuccess)
                    {
                        Directory.CreateDirectory(
                            Server.MapPath($"~/Images/Sections/" + result.SectionDto.SectionId));

                        sectionFormData.SectionImage?.SaveAs(
                        Server.MapPath($"~/Images/Sections/" + result.SectionDto.SectionId + $"/") +
                        sectionFormData.SectionImage.FileName);

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
                    ErrorMessage = SectionResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region UPDATE SECTION

        /// <summary>
        /// Get Section Model for Update
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetUpdateSection(int? sectionId)
        {
            SectionFormData sectionFormData = new SectionFormData
            {
                TranslationsList = new List<SectionTranslationFormData>()
            };

            if (sectionId.HasValue)
            {
                SectionRequestData findSectionRequest = new SectionRequestData
                {
                    SectionDto = new SectionItemData { SectionId = sectionId.Value },
                    FindSectionDto = FindSectionItemData.SectionId
                };
                SectionResultData resultSection = await WebApiClient.PostFormJsonAsync<SectionRequestData, SectionResultData>(Constant.WebApiControllerAbout, Constant.WebApiFindSections, findSectionRequest);

                if (resultSection != null && resultSection.OperationSuccess && resultSection.SectionDto != null)
                {
                    sectionFormData.SectionId = resultSection.SectionDto.SectionId;
                    SectionTranslationRequestData findSectionTranslationRequest = new SectionTranslationRequestData()
                    {
                        SectionTranslationDto = new SectionTranslationItemData { SectionId = sectionId.Value },
                        FindSectionTranslationDto = FindSectionTranslationItemData.SectionId
                    };
                    SectionTranslationResultData resultSectionTranslation = await WebApiClient.PostFormJsonAsync<SectionTranslationRequestData, SectionTranslationResultData>(Constant.WebApiControllerAbout, Constant.WebApiFindSectionTranslations, findSectionTranslationRequest);
                    if (resultSectionTranslation != null && resultSectionTranslation.OperationSuccess && resultSectionTranslation.SectionTranslationDtoList != null)
                    {
                        sectionFormData.TranslationsList = resultSectionTranslation.SectionTranslationDtoList.ToFormDataList();
                    }
                }
            }
            ViewBag.Action = "UpdateSection";
            return PartialView("Partials/_ManageSection", sectionFormData);
        }

        /// <summary>
        /// Update Section Action
        /// </summary>
        /// <param name="sectionFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateSection(SectionFormData sectionFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                SectionRequestData request = sectionFormData.ToRequestData();
                SectionResultData sectionResult =
                    await WebApiClient.PostFormJsonAsync<SectionRequestData, SectionResultData>(
                        Constant.WebApiControllerAbout, Constant.WebApiUpdateSection, request);
                if (sectionResult != null && sectionResult.OperationSuccess)
                {
                    if (!Directory.Exists(Server.MapPath($"~/Images/Sections/" + sectionFormData.SectionId)))
                    {
                        Directory.CreateDirectory(Server.MapPath($"~/Images/Sections/" + sectionFormData.SectionId));
                    }
                    sectionFormData.SectionImage?.SaveAs(
                        Server.MapPath($"~/Images/Sections/" + sectionFormData.SectionId + $"/") +
                        sectionFormData.SectionImage?.FileName);

                    SectionTranslationRequestData sectionTranslationRequestData = new SectionTranslationRequestData
                    {
                        SectionTranslationDtoList = sectionFormData.TranslationsList.ToItemDataList()
                    };

                    SectionTranslationResultData sectionTranslationResultData = await WebApiClient.PostFormJsonAsync<SectionTranslationRequestData, SectionTranslationResultData>(Constant.WebApiControllerAbout, Constant.WebApiUpdateSectionTranslationRange, sectionTranslationRequestData);
                    if (sectionTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!sectionTranslationResultData.OperationSuccess && sectionTranslationResultData.Errors != null && sectionTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = sectionTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (sectionTranslationResultData.OperationSuccess)
                    {
                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (sectionResult == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!sectionResult.OperationSuccess && sectionResult.Errors != null && sectionResult.Errors.Count > 0)
                {
                    data.ErrorMessage = sectionResult.Errors.First();
                    data.OperationSuccess = false;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = SectionResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region DELETE SECTION

        public ActionResult GetDeleteSection(int sectionId)
        {
            return View("Partials/_DeleteSection", sectionId);
        }

        /// <summary>
        /// Delete Section
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteSection(int sectionId)
        {
            JsonReturnData data = new JsonReturnData();
            if (sectionId > 0)
            {
                string param = $"{nameof(sectionId)}={sectionId}";
                SectionResultData result = await WebApiClient.DeleteAsync<SectionResultData>(Constant.WebApiControllerAbout, Constant.WebApiRemoveSection, param);
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
                    if (Directory.Exists(Server.MapPath($"~/Images/Sections/" + sectionId)))
                    {
                        Directory.Delete(Server.MapPath($"~/Images/Sections/" + sectionId), true);
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

        #region SECTION VALIDATION

        /// <summary>
        /// validate create section.
        /// </summary>
        /// <param name="sectionFormData">the sectionFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateSectionFormData(SectionFormData sectionFormData)
        {
            List<string> errors = new List<string>();
            if (sectionFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// validate create section translation.
        /// </summary>
        /// <param name="sectionTranslationFormData">the sectionTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateSectionTranslationFormData(SectionTranslationFormData sectionTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (sectionTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionTranslationFormData>.ValidateAttributes("LanguageId",
                    sectionTranslationFormData.LanguageId.ToString()));
                errors.AddRange(
                    GenericValidationAttribute<SectionTranslationFormData>.ValidateAttributes("SectionDesciption",
                        sectionTranslationFormData.SectionDesciption));
                errors.AddRange(
                    GenericValidationAttribute<SectionTranslationFormData>.ValidateAttributes("SectionTitle",
                        sectionTranslationFormData.SectionTitle));
            }

            return errors.Count == 0;
        }
        #endregion

        #region PRIVATE SECTION METHODS

        /// <summary>
        /// Get the sections list.
        /// </summary>
        /// <returns></returns>
        private async Task<List<SectionViewData>> GetSectionsList()
        {
            SectionResultData sectionResultData = await WebApiClient.GetAsync<SectionResultData>(Constant.WebApiControllerAbout, Constant.WebApiSectionList);
            List<SectionViewData> sectionsList = new List<SectionViewData>();

            if (sectionResultData == null || !sectionResultData.OperationSuccess ||
                sectionResultData.SectionDtoList == null) return sectionsList;
            foreach (var sectionDto in sectionResultData.SectionDtoList)
            {
                SectionViewData section = new SectionViewData
                {
                    TranslationsList = new List<SectionTranslationItemData>(),
                    Section = sectionDto
                };
                section.TranslationsList = await GetSectionTranslations(sectionDto.SectionId);
                sectionsList.Add(section);
            }
            return sectionsList;
        }

        /// <summary>
        /// Find the section translations
        /// </summary>
        /// <param name="sectionId">the section id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<SectionTranslationItemData>> GetSectionTranslations(int sectionId)
        {
            List<SectionTranslationItemData> translationsList = new List<SectionTranslationItemData>();
            SectionTranslationRequestData findSectionTranslationRequest = new SectionTranslationRequestData
            {
                SectionTranslationDto = new SectionTranslationItemData { SectionId = sectionId },
                FindSectionTranslationDto = FindSectionTranslationItemData.SectionId
            };
            SectionTranslationResultData resultSectionTranslation = await WebApiClient.PostFormJsonAsync<SectionTranslationRequestData, SectionTranslationResultData>(Constant.WebApiControllerAbout, Constant.WebApiFindSectionTranslations, findSectionTranslationRequest);
            if (resultSectionTranslation != null && resultSectionTranslation.OperationSuccess && resultSectionTranslation.SectionTranslationDtoList != null)
            {
                translationsList.AddRange(resultSectionTranslation.SectionTranslationDtoList);
            }
            return translationsList;
        }

        #endregion

        #region SECTION PARAGRAPHS

        /// <summary>
        /// Manage section paragraph form.
        /// </summary>
        /// <param name="sectionId">the section id</param>
        /// <returns></returns>
        public async Task<ActionResult> GetManageParagraphs(int sectionId)
        {
            ParagraphsViewData paragraphViewData = new ParagraphsViewData
            {
                Paragraphs = await GetParagraphs(sectionId),
                SectionId = sectionId
            };
            return View("Partials/_Paragraphs", paragraphViewData);
        }

        /// <summary>
        /// Return section paragraph list.
        /// </summary>
        /// <param name="sectionId">the section id</param>
        /// <returns></returns>
        public async Task<ActionResult> GetSectionParagraphs(int sectionId)
        {
            ParagraphsViewData paragraphViewData = new ParagraphsViewData
            {
                Paragraphs = await GetParagraphs(sectionId),
                SectionId = sectionId
            };
            return View("Partials/_ParagraphsList", paragraphViewData);
        }
        #endregion

        #region CREATE SECTION PARAGRAPH

        /// <summary>
        /// Get the view to create section paragraph.
        /// </summary>
        /// <param name="sectionId">the activivity id</param>
        /// <returns>action view result.</returns>
        public async Task<ActionResult> GetCreateSectionParagraph(int sectionId)
        {
            SectionParagraphFormData sectionParagraphFormData = new SectionParagraphFormData
            {
                TranslationsList = new List<SectionParagraphTranslationFormData>(),
                SectionId = sectionId
            };

            LanguageResultData result = await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages, Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new SectionParagraphTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId,
                    };
                    sectionParagraphFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateSectionParagraph";
            return PartialView("Partials/_ManageSectionParagraph", sectionParagraphFormData);
        }

        /// <summary>
        /// Create paragraph.
        /// </summary>
        /// <param name="sectionParagraphFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateSectionParagraph(SectionParagraphFormData sectionParagraphFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                SectionParagraphRequestData request = sectionParagraphFormData.ToRequestData();
                SectionParagraphResultData result = await WebApiClient.PostFormJsonAsync<SectionParagraphRequestData, SectionParagraphResultData>(Constant.WebApiControllerAbout, Constant.WebApiCreateSectionParagraph, request);
                if (result != null && result.OperationSuccess && result.SectionParagraphDto != null)
                {
                    foreach (var translation in sectionParagraphFormData.TranslationsList.ToList())
                    {
                        translation.ParagraphId = result.SectionParagraphDto.ParagraphId;
                    }

                    SectionParagraphTranslationRequestData translationRequest = new SectionParagraphTranslationRequestData
                    {
                        SectionParagraphTranslationDtoList = sectionParagraphFormData.TranslationsList.ToItemDataList(),
                    };

                    SectionParagraphTranslationResultData sectionParagraphTranslationResultData = await WebApiClient.PostFormJsonAsync<SectionParagraphTranslationRequestData, SectionParagraphTranslationResultData>(Constant.WebApiControllerAbout, Constant.WebApiCreateSectionParagraphTranslationRange, translationRequest);
                    if (sectionParagraphTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (sectionParagraphTranslationResultData.Errors != null && (!sectionParagraphTranslationResultData.OperationSuccess || sectionParagraphTranslationResultData.Errors != null || sectionParagraphTranslationResultData.Errors.Count > 0))
                    {
                        data.ErrorMessage = sectionParagraphTranslationResultData.Errors.FirstOrDefault();
                        data.OperationSuccess = false;
                    }
                    else if (sectionParagraphTranslationResultData.OperationSuccess)
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
                    ErrorMessage = SectionResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region UPDATE SECTION PARAGRAPH

        /// <summary>
        /// Get the view to create section paragraph.
        /// </summary>
        /// <param name="paragraphId">the paragraph id to update.</param>
        /// <returns>action view result.</returns>
        public async Task<ActionResult> GetUpdateSectionParagraph(int paragraphId)
        {
            SectionParagraphFormData sectionParagraphFormData = new SectionParagraphFormData
            {
                TranslationsList = new List<SectionParagraphTranslationFormData>(),
                ParagraphId = paragraphId
            };

            SectionParagraphTranslationRequestData sectionParagraphTranslationRequestData = new SectionParagraphTranslationRequestData
            {
                SectionParagraphTranslationDto = new SectionParagraphTranslationItemData { ParagraphId = paragraphId },
                FindSectionParagraphTranslationDto = FindSectionParagraphTranslationItemData.SectionParagraphId
            };

            SectionParagraphTranslationResultData sectionParagraphTranslation = await WebApiClient.PostFormJsonAsync<SectionParagraphTranslationRequestData, SectionParagraphTranslationResultData>(Constant.WebApiControllerAbout, Constant.WebApiFindSectionParagraphTranslations, sectionParagraphTranslationRequestData);
            if (sectionParagraphTranslation != null && sectionParagraphTranslation.OperationSuccess && sectionParagraphTranslation.SectionParagraphTranslationDtoList != null)
            {
                foreach (var paragraphTranslation in sectionParagraphTranslation.SectionParagraphTranslationDtoList)
                {
                    sectionParagraphFormData.SectionId = paragraphTranslation.SectionParagraph?.SectionId;

                    var translation = new SectionParagraphTranslationFormData
                    {
                        LanguagePrefix = paragraphTranslation.Language?.LanguagePrefix,
                        LanguageId = paragraphTranslation.Language?.LanguageId,
                        TranslationId = paragraphTranslation.TranslationId,
                        ParagraphDescription = paragraphTranslation.ParagraphDescription,
                        ParagraphTitle = paragraphTranslation.ParagraphTitle,
                        ParagraphId = paragraphTranslation.ParagraphId
                    };
                    sectionParagraphFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "UpdateSectionParagraph";
            return PartialView("Partials/_ManageSectionParagraph", sectionParagraphFormData);
        }

        /// <summary>
        /// Update paragraph section.
        /// </summary>
        /// <param name="sectionParagraphFormData">the sectionParagraphFormData to update.</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateSectionParagraph(SectionParagraphFormData sectionParagraphFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                SectionParagraphRequestData request = sectionParagraphFormData.ToRequestData();
                SectionParagraphResultData result = await WebApiClient.PostFormJsonAsync<SectionParagraphRequestData, SectionParagraphResultData>(Constant.WebApiControllerAbout, Constant.WebApiUpdateSectionParagraph, request);
                if (result != null && result.OperationSuccess)
                {
                    SectionParagraphTranslationRequestData translationRequest = new SectionParagraphTranslationRequestData
                    {
                        SectionParagraphTranslationDtoList = sectionParagraphFormData.TranslationsList.ToItemDataList()
                    };

                    SectionParagraphTranslationResultData sectionParagraphTranslationResultData = await WebApiClient.PostFormJsonAsync<SectionParagraphTranslationRequestData, SectionParagraphTranslationResultData>(Constant.WebApiControllerAbout, Constant.WebApiUpdateSectionParagraphTranslationRange, translationRequest);
                    if (sectionParagraphTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (sectionParagraphTranslationResultData.Errors != null && (!sectionParagraphTranslationResultData.OperationSuccess || sectionParagraphTranslationResultData.Errors != null || sectionParagraphTranslationResultData.Errors.Count > 0))
                    {
                        data.ErrorMessage = sectionParagraphTranslationResultData.Errors.FirstOrDefault();
                        data.OperationSuccess = false;
                    }
                    else if (sectionParagraphTranslationResultData.OperationSuccess)
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
                    ErrorMessage = SectionResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region DELETE SECTION PARAGRAPH

        /// <summary>
        /// Get the delete section paragraph.
        /// </summary>
        /// <param name="paragraphId">paragraphId to delete.</param>
        /// <param name="sectionId">sectionId to load list.</param>
        /// <returns></returns>
        public ActionResult GetDeleteSectionParagraph(int sectionId, int paragraphId)
        {
            ViewBag.sectionId = sectionId;
            return View("Partials/_DeleteSectionParagraph", paragraphId);
        }

        /// <summary>
        /// Delete Section
        /// </summary>
        /// <param name="paragraphId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteSectionParagraph(int paragraphId)
        {
            JsonReturnData data = new JsonReturnData();
            if (paragraphId > 0)
            {
                string param = $"{nameof(paragraphId)}={paragraphId}";
                SectionParagraphResultData result = await WebApiClient.DeleteAsync<SectionParagraphResultData>(Constant.WebApiControllerAbout, Constant.WebApiRemoveSectionParagraph, param);

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
                }
            }
            else
            {
                data.ErrorMessage = SectionParagraphResources.RequiredParagraphId;
                data.OperationSuccess = false;
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region ACTVITY PARAGRAPH VALIDATION

        /// <summary>
        /// validate create section paragraph translation.
        /// </summary>
        /// <param name="sectionParagraphTranslationFormData">the sectionParagraphTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateSectionParagraphTranslation(SectionParagraphTranslationFormData sectionParagraphTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (sectionParagraphTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationFormData>.ValidateAttributes("ParagraphDescription", sectionParagraphTranslationFormData.ParagraphDescription));
                errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationFormData>.ValidateAttributes("LanguageId", sectionParagraphTranslationFormData.LanguageId.ToString()));
                errors.AddRange(GenericValidationAttribute<SectionParagraphTranslationFormData>.ValidateAttributes("ParagraphTitle", sectionParagraphTranslationFormData.ParagraphTitle));
            }
            return errors.Count == 0;
        }
        #endregion

        #region PRIVATE SECTION PARAGRAPHS METHODS

        /// <summary>
        /// Get the paragraphe of the section.
        /// </summary>
        /// <returns></returns>
        private async Task<List<ParagraphViewData>> GetParagraphs(int sectionId)
        {
            SectionParagraphRequestData findSectionParagraphRequestData = new SectionParagraphRequestData
            {
                SectionParagraphDto = new SectionParagraphItemData { SectionId = sectionId },
                FindSectionParagraphDto = FindSectionParagraphItemData.SectionId
            };

            SectionParagraphResultData sectionParagraphResultData = await WebApiClient.PostFormJsonAsync<SectionParagraphRequestData, SectionParagraphResultData>(Constant.WebApiControllerAbout, Constant.WebApiFindSectionParagraphs, findSectionParagraphRequestData);
            List<ParagraphViewData> paragraphsList = new List<ParagraphViewData>();

            if (sectionParagraphResultData != null && sectionParagraphResultData.OperationSuccess && sectionParagraphResultData.SectionParagraphDtoList != null)
            {
                foreach (var paragraphDto in sectionParagraphResultData.SectionParagraphDtoList)
                {
                    ParagraphViewData paragraph = new ParagraphViewData
                    {
                        TranslationsList = new List<SectionParagraphTranslationItemData>(),
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
        /// <param name="paragraphId">the section id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<SectionParagraphTranslationItemData>> GetParagraphTranslations(int paragraphId)
        {
            List<SectionParagraphTranslationItemData> translationsList = new List<SectionParagraphTranslationItemData>();
            SectionParagraphTranslationRequestData findSectionParagraphTranslationRequest = new SectionParagraphTranslationRequestData()
            {
                SectionParagraphTranslationDto = new SectionParagraphTranslationItemData { ParagraphId = paragraphId },
                FindSectionParagraphTranslationDto = FindSectionParagraphTranslationItemData.SectionParagraphId
            };

            SectionParagraphTranslationResultData sectionParagraphTranslationResultData = await WebApiClient.PostFormJsonAsync<SectionParagraphTranslationRequestData, SectionParagraphTranslationResultData>(Constant.WebApiControllerAbout, Constant.WebApiFindSectionParagraphTranslations, findSectionParagraphTranslationRequest);
            if (sectionParagraphTranslationResultData != null && sectionParagraphTranslationResultData.OperationSuccess && sectionParagraphTranslationResultData.SectionParagraphTranslationDtoList != null)
            {
                translationsList.AddRange(sectionParagraphTranslationResultData.SectionParagraphTranslationDtoList);
            }
            return translationsList;
        }
        #endregion

        #region SECTION FILES

        /// <summary>
        /// Manage section File form.
        /// </summary>
        /// <param name="sectionId">the section id</param>
        /// <returns></returns>
        public async Task<ActionResult> GetManageFiles(int sectionId)
        {
            FilesViewData fileViewData = new FilesViewData
            {
                Files = await GetFiles(sectionId),
                SectionId = sectionId
            };
            return View("Partials/_Files", fileViewData);
        }

        /// <summary>
        /// Return section File list.
        /// </summary>
        /// <param name="sectionId">the section id</param>
        /// <returns></returns>
        public async Task<ActionResult> GetSectionFiles(int sectionId)
        {
            FilesViewData fileViewData = new FilesViewData
            {
                Files = await GetFiles(sectionId),
                SectionId = sectionId
            };
            return View("Partials/_FilesList", fileViewData);
        }
        #endregion

        #region CREATE SECTION FILE

        /// <summary>
        /// Get the view to create section File.
        /// </summary>
        /// <param name="sectionId">the activivity id</param>
        /// <returns>action view result.</returns>
        public async Task<ActionResult> GetCreateSectionFile(int sectionId)
        {
            CreateSectionFileFormData sectionFileFormData = new CreateSectionFileFormData
            {
                TranslationsList = new List<CreateSectionFileTranslationFormData>(),
                SectionId = sectionId
            };

            LanguageResultData result =
                await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages,
                    Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new CreateSectionFileTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId
                    };
                    sectionFileFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateSectionFile";
            return PartialView("Partials/_CreateSectionFile", sectionFileFormData);
        }

        /// <summary>
        /// Create section File.
        /// </summary>
        /// <param name="sectionFileFormData"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateSectionFile(CreateSectionFileFormData sectionFileFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                SectionFileRequestData request = sectionFileFormData.ToRequestData();
                SectionFileResultData result = await WebApiClient.PostFormJsonAsync<SectionFileRequestData, SectionFileResultData>(Constant.WebApiControllerAbout, Constant.WebApiCreateSectionFile, request);
                if (result != null && result.OperationSuccess && result.SectionFileDto != null)
                {
                    foreach (var translation in sectionFileFormData.TranslationsList.ToList())
                    {
                        translation.SectionFileId = result.SectionFileDto.SectionFileId;
                    }

                    SectionFileTranslationRequestData translationRequest = new SectionFileTranslationRequestData
                    {
                        SectionFileTranslationDtoList = sectionFileFormData.TranslationsList.ToItemDataList(),
                    };

                    SectionFileTranslationResultData sectionFileTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<SectionFileTranslationRequestData, SectionFileTranslationResultData>(
                                Constant.WebApiControllerAbout, Constant.WebApiCreateSectionFileTranslationRange,
                                translationRequest);
                    if (sectionFileTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (sectionFileTranslationResultData.Errors != null && sectionFileTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = sectionFileTranslationResultData.Errors.FirstOrDefault();
                        data.OperationSuccess = false;
                    }
                    else if (sectionFileTranslationResultData.OperationSuccess)
                    {
                        if (!Directory.Exists(Server.MapPath($"~/Images/Section/Files/" +
                                                             result.SectionFileDto.SectionFileId)))
                        {
                            Directory.CreateDirectory(
                                Server.MapPath($"~/Images/Section/Files/" + result.SectionFileDto.SectionFileId));
                        }
                        foreach (var translation in sectionFileFormData.TranslationsList)
                        {
                            translation.SectionFileSource?.SaveAs(
                                Server.MapPath(
                                    $"~/Images/Section/Files/" + result.SectionFileDto.SectionFileId + $"/") +
                                translation.SectionFileSource?.FileName);
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
                    ErrorMessage = SectionResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region UPDATE SECTION File

        /// <summary>
        /// Get the view to create section File.
        /// </summary>
        /// <param name="fileId">the File id to update.</param>
        /// <returns>action view result.</returns>
        public async Task<ActionResult> GetUpdateSectionFile(int fileId)
        {
            UpdateSectionFileFormData sectionFileFormData = new UpdateSectionFileFormData
            {
                TranslationsList = new List<UpdateSectionFileTranslationFormData>(),
                SectionFileId = fileId
            };

            SectionFileTranslationRequestData sectionFileTranslationRequestData = new SectionFileTranslationRequestData
            {
                SectionFileTranslationDto = new SectionFileTranslationItemData { SectionFileId = fileId },
                FindSectionFileTranslationDto = FindSectionFileTranslationItemData.SectionFileId
            };

            SectionFileTranslationResultData sectionFileTranslation =
                await WebApiClient
                    .PostFormJsonAsync<SectionFileTranslationRequestData, SectionFileTranslationResultData>(
                        Constant.WebApiControllerAbout, Constant.WebApiFindSectionFileTranslations,
                        sectionFileTranslationRequestData);
            if (sectionFileTranslation != null && sectionFileTranslation.OperationSuccess && sectionFileTranslation.SectionFileTranslationDtoList != null)
            {
                foreach (var fileTranslation in sectionFileTranslation.SectionFileTranslationDtoList)
                {
                    sectionFileFormData.SectionId = fileTranslation.SectionFile?.SectionId;

                    var translation = new UpdateSectionFileTranslationFormData
                    {
                        LanguagePrefix = fileTranslation.Language?.LanguagePrefix,
                        SectionFileText = fileTranslation.SectionFileText,
                        LanguageId = fileTranslation.Language?.LanguageId,
                        SectionFileId = fileTranslation.SectionFileId,
                        TranslationId = fileTranslation.TranslationId
                    };
                    sectionFileFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "UpdateSectionFile";
            return PartialView("Partials/_UpdateSectionFile", sectionFileFormData);
        }

        /// <summary>
        /// Update File section.
        /// </summary>
        /// <param name="sectionFileFormData">the sectionFileFormData to update.</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateSectionFile(UpdateSectionFileFormData sectionFileFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                SectionFileRequestData request = sectionFileFormData.ToRequestData();
                SectionFileResultData result =
                    await WebApiClient.PostFormJsonAsync<SectionFileRequestData, SectionFileResultData>(
                        Constant.WebApiControllerAbout, Constant.WebApiUpdateSectionFile, request);
                if (result != null && result.OperationSuccess)
                {
                    SectionFileTranslationRequestData translationRequest = new SectionFileTranslationRequestData
                    {
                        SectionFileTranslationDtoList = sectionFileFormData.TranslationsList.ToItemDataList()
                    };

                    SectionFileTranslationResultData sectionFileTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<SectionFileTranslationRequestData, SectionFileTranslationResultData>(
                                Constant.WebApiControllerAbout, Constant.WebApiUpdateSectionFileTranslationRange,
                                translationRequest);
                    if (sectionFileTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (sectionFileTranslationResultData.Errors != null && (!sectionFileTranslationResultData.OperationSuccess || sectionFileTranslationResultData.Errors != null || sectionFileTranslationResultData.Errors.Count > 0))
                    {
                        data.ErrorMessage = sectionFileTranslationResultData.Errors.FirstOrDefault();
                        data.OperationSuccess = false;
                    }
                    else if (sectionFileTranslationResultData.OperationSuccess)
                    {
                        foreach (var translation in sectionFileFormData.TranslationsList)
                        {
                            if (!Directory.Exists(Server.MapPath($"~/Images/Section/Files/" +
                                                                 translation.SectionFileId)))
                            {
                                Directory.CreateDirectory(
                                    Server.MapPath($"~/Images/Section/Files/" + translation.SectionFileId));
                            }

                            translation.SectionFileSource?.SaveAs(
                                Server.MapPath(
                                    $"~/Images/Section/Files/" + translation.SectionFileId + $"/") +
                                translation.SectionFileSource?.FileName);
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
                    ErrorMessage = SectionResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region DELETE SECTION FILE

        /// <summary>
        /// Get delete section file.
        /// </summary>
        /// <param name="fileId">the file id.</param>
        /// <param name="sectionId">the section id</param>
        /// <returns></returns>
        public ActionResult GetDeleteSectionFile(int sectionId, int fileId)
        {
            ViewBag.sectionId = sectionId;
            return View("Partials/_DeleteSectionFile", fileId);
        }

        /// <summary>
        /// Delete Section.
        /// </summary>
        /// <param name="fileId">the fileId to delete.</param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteSectionFile(int fileId)
        {
            JsonReturnData data = new JsonReturnData();
            if (fileId > 0)
            {
                string param = $"{nameof(fileId)}={fileId}";
                SectionFileResultData result = await WebApiClient.DeleteAsync<SectionFileResultData>(Constant.WebApiControllerAbout, Constant.WebApiRemoveSectionFile, param);
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
                    if (Directory.Exists(Server.MapPath($"~/Images/Section/Files/" + fileId)))
                    {
                        Directory.Delete(Server.MapPath($"~/Images/Section/Files/" + fileId), true);
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

        #region ACTVITY FILE VALIDATION

        /// <summary>
        /// validate update section file translation.
        /// </summary>
        /// <param name="sectionFileTranslationFormData">the sectionFileTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateCreateSectionFileTranslation(CreateSectionFileTranslationFormData sectionFileTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (sectionFileTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                if (sectionFileTranslationFormData.SectionFileSource != null) { errors.Add(SectionFileResources.RequiredSectionFileSource); }
                errors.AddRange(
                    GenericValidationAttribute<UpdateSectionFileTranslationFormData>.ValidateAttributes(
                        "SectionFileText", sectionFileTranslationFormData.SectionFileText));
                errors.AddRange(GenericValidationAttribute<UpdateSectionFileTranslationFormData>.ValidateAttributes(
                    "LanguageId", sectionFileTranslationFormData.LanguageId.ToString()));
            }
            return errors.Count == 0;
        }


        /// <summary>
        /// validate update section File translation.
        /// </summary>
        /// <param name="sectionFileTranslationFormData">the sectionFileTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateUpdateSectionFileTranslation(UpdateSectionFileTranslationFormData sectionFileTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (sectionFileTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(
                    GenericValidationAttribute<UpdateSectionFileTranslationFormData>.ValidateAttributes(
                        "SectionFileText", sectionFileTranslationFormData.SectionFileText));
                errors.AddRange(GenericValidationAttribute<UpdateSectionFileTranslationFormData>.ValidateAttributes(
                    "LanguageId", sectionFileTranslationFormData.LanguageId.ToString()));
            }
            return errors.Count == 0;
        }
        #endregion

        #region PRIVATE SECTION FILES METHODS

        /// <summary>
        /// Get the paragraphe of the section.
        /// </summary>
        /// <returns></returns>
        private async Task<List<FileViewData>> GetFiles(int sectionId)
        {
            SectionFileRequestData findSectionFileRequestData = new SectionFileRequestData
            {
                SectionFileDto = new SectionFileItemData { SectionId = sectionId },
                FindSectionFileDto = FindSectionFileItemData.SectionId
            };

            SectionFileResultData sectionFileResultData =
                await WebApiClient.PostFormJsonAsync<SectionFileRequestData, SectionFileResultData>(
                    Constant.WebApiControllerAbout, Constant.WebApiFindSectionFiles, findSectionFileRequestData);
            List<FileViewData> filesList = new List<FileViewData>();

            if (sectionFileResultData != null && sectionFileResultData.OperationSuccess && sectionFileResultData.SectionFileDtoList != null)
            {
                foreach (var fileDto in sectionFileResultData.SectionFileDtoList)
                {
                    FileViewData file = new FileViewData
                    {
                        TranslationsList = new List<SectionFileTranslationItemData>(),
                        File = fileDto
                    };

                    file.TranslationsList = await GetFileTranslations(fileDto.SectionFileId);
                    filesList.Add(file);
                }
            }
            return filesList;
        }

        /// <summary>
        /// Find the file translations
        /// </summary>
        /// <param name="sectionFileId">the file id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<SectionFileTranslationItemData>> GetFileTranslations(int sectionFileId)
        {
            List<SectionFileTranslationItemData> translationsList = new List<SectionFileTranslationItemData>();
            SectionFileTranslationRequestData findSectionFileTranslationRequest = new SectionFileTranslationRequestData
            {
                SectionFileTranslationDto = new SectionFileTranslationItemData { SectionFileId = sectionFileId },
                FindSectionFileTranslationDto = FindSectionFileTranslationItemData.SectionFileId
            };

            SectionFileTranslationResultData sectionFileTranslationResultData =
                await WebApiClient
                    .PostFormJsonAsync<SectionFileTranslationRequestData, SectionFileTranslationResultData>(
                        Constant.WebApiControllerAbout, Constant.WebApiFindSectionFileTranslations,
                        findSectionFileTranslationRequest);
            if (sectionFileTranslationResultData != null && sectionFileTranslationResultData.OperationSuccess && sectionFileTranslationResultData.SectionFileTranslationDtoList != null)
            {
                translationsList.AddRange(sectionFileTranslationResultData.SectionFileTranslationDtoList);
            }
            return translationsList;
        }
        #endregion

        #endregion

        #region HISTORIQUE

        /// <summary>
        /// Get steps List
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Steps()
        {
            StepsViewData steps = await GetStepsList();
            return View("Partials/_Steps", steps);
        }

        /// <summary>
        /// The list of steps.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetSteps()
        {
            StepsViewData steps = await GetStepsList();
            return View("Partials/_StepList", steps);
        }

        #region CREATE STEP
        /// <summary>
        /// Get the create step page.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCreateStep()
        {
            ManageStepFormData stepFormData = new ManageStepFormData();
            ViewBag.Action = "CreateStep";

            return View("Partials/_ManageStep", stepFormData);
        }

        /// <summary>
        /// Create new step.
        /// </summary>
        /// <param name="formData">stap form data to create.</param>
        /// <returns></returns>
        public async Task<OmsJsonResult> CreateStep(ManageStepFormData formData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                StepRequestData request = formData.ToRequestData();
                StepResultData result =
                    await WebApiClient.PostFormJsonAsync<StepRequestData, StepResultData>(
                        Constant.WebApiControllerSteps, Constant.WebApiCreateStep, request);

                if (result == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (result.Errors != null && result.Errors.Count > 0)
                {
                    data.ErrorMessage = result.Errors.FirstOrDefault();
                    data.OperationSuccess = false;
                }
                else if (result.OperationSuccess)
                {
                    data.SuccessMessage = SharedResources.Ok;
                    data.OperationSuccess = true;
                }
                return new OmsJsonResult(data);
            }
            data = new JsonReturnData
            {
                ErrorMessage = StepResources.RequiredFields,
                OperationSuccess = false
            };
            return new OmsJsonResult(data);
        }

        #endregion

        #region UPDATE STEP

        /// <summary>
        /// Get view to update step.
        /// </summary>
        /// <param name="stepId">the step id to update.</param>
        /// <returns>the view to update.</returns>
        public async Task<ActionResult> GetUpdateStep(int stepId)
        {
            ManageStepFormData formData = new ManageStepFormData();
            StepRequestData request = new StepRequestData
            {
                StepDto = new StepItemData { StepId = stepId },
                FindStepDto = FindStepItemData.StepId
            };

            StepResultData result =
                await WebApiClient.PostFormJsonAsync<StepRequestData, StepResultData>(
                    Constant.WebApiControllerSteps, Constant.WebApiFindSteps, request);

            if (result != null && result.OperationSuccess && request.StepDto != null)
            {
                formData = result.ToFormData();
            }

            ViewBag.Action = "UpdateStep";
            return View("Partials/_ManageStep", formData);
        }

        /// <summary>
        /// Update step.
        /// </summary>
        /// <param name="formData">the formdata to update.</param>
        /// <returns></returns>
        public async Task<OmsJsonResult> UpdateStep(ManageStepFormData formData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                StepRequestData request = formData.ToRequestData();
                StepResultData result =
                    await WebApiClient.PostFormJsonAsync<StepRequestData, StepResultData>(
                        Constant.WebApiControllerSteps, Constant.WebApiUpdateStep, request);

                if (result == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (result.Errors != null && result.Errors.Count > 0)
                {
                    data.ErrorMessage = result.Errors.FirstOrDefault();
                    data.OperationSuccess = false;
                }
                else if (result.OperationSuccess)
                {
                    data.SuccessMessage = SharedResources.Ok;
                    data.OperationSuccess = true;
                }
                return new OmsJsonResult(data);
            }
            data = new JsonReturnData
            {
                ErrorMessage = StepResources.RequiredFields,
                OperationSuccess = false
            };
            return new OmsJsonResult(data);
        }
        #endregion

        #region DELETE STEP

        /// <summary>
        /// Get view to update step.
        /// </summary>
        /// <param name="stepId">the step id to update.</param>
        /// <returns>the view to update.</returns>
        public async Task<ActionResult> GetDeleteStep(int stepId)
        {
            int returnStepId = 0;
            StepRequestData request = new StepRequestData
            {
                StepDto = new StepItemData { StepId = stepId },
                FindStepDto = FindStepItemData.StepId
            };

            StepResultData result =
                await WebApiClient.PostFormJsonAsync<StepRequestData, StepResultData>(
                    Constant.WebApiControllerSteps, Constant.WebApiFindSteps, request);

            if (result != null && result.OperationSuccess && request.StepDto != null)
            {
                returnStepId = result.StepDto.StepId;
            }

            return View("Partials/_DeleteStep", returnStepId);
        }

        /// <summary>
        /// Update step.
        /// </summary>
        /// <param name="stepId">the stepId to delete.</param>
        /// <returns></returns>
        public async Task<OmsJsonResult> DeleteStep(int stepId)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                string param = $"{nameof(stepId)}={stepId}";
                StepResultData result = await WebApiClient.DeleteAsync<StepResultData>(Constant.WebApiControllerSteps, Constant.WebApiRemoveStep, param);

                if (result == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (result.Errors != null && result.Errors.Count > 0)
                {
                    data.ErrorMessage = result.Errors.FirstOrDefault();
                    data.OperationSuccess = false;
                }
                else if (result.OperationSuccess)
                {
                    data.SuccessMessage = SharedResources.Ok;
                    data.OperationSuccess = true;
                }
                return new OmsJsonResult(data);
            }
            data = new JsonReturnData
            {
                ErrorMessage = StepResources.RequiredFields,
                OperationSuccess = false
            };
            return new OmsJsonResult(data);
        }
        #endregion

        #region STEP PARAGRAPH

        public async Task<ActionResult> StepParagraphs(int stepId)
        {
            StepParagraphsViewData paragraphs = await GetStepParagraphs(stepId);
            return View("Partials/_StepParagraphs", paragraphs);
        }

        #endregion

        #region CREATE PARAGRAPH STEP

        /// <summary>
        /// validate create step paragraph.
        /// </summary>
        /// <param name="stepParagraphTranslationFormData">the stepParagraphTranslationFormData to validate.</param>
        /// <returns>true if the proportises are valide.</returns>
        public bool ValidateStepParagraphTranslation(StepParagraphTranslationFormData stepParagraphTranslationFormData)
        {
            List<string> errors = new List<string>();
            if (stepParagraphTranslationFormData == null)
            {
                errors.Add(SharedResources.NullFormData);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationFormData>.ValidateAttributes(
                    "ParagraphDescription", stepParagraphTranslationFormData.ParagraphDescription));

                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationFormData>.ValidateAttributes(
                    "ParagraphTitle", stepParagraphTranslationFormData.ParagraphTitle));

                errors.AddRange(GenericValidationAttribute<StepParagraphTranslationFormData>.ValidateAttributes(
                    "ParagraphId", stepParagraphTranslationFormData.ParagraphId.ToString()));
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// Get the view to create paragraph.
        /// </summary>
        /// <param name="stepId">the step id.</param>
        /// <returns></returns>
        public async Task<ActionResult> GetCreateStepParagraph(int stepId)
        {
            StepParagraphFormData paragraphFormData = new StepParagraphFormData
            {
                TranslationsList = new List<StepParagraphTranslationFormData>(),
                StepId = stepId,
                ParagraphId = 0
            };
            LanguageResultData result =
                await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages,
                    Constant.WebApiLanguageList);
            if (result != null && result.OperationSuccess && result.LanguageDtoList != null)
            {
                foreach (var language in result.LanguageDtoList)
                {
                    var translation = new StepParagraphTranslationFormData
                    {
                        LanguagePrefix = language.LanguagePrefix,
                        LanguageId = language.LanguageId,
                    };
                    paragraphFormData.TranslationsList.Add(translation);
                }
            }
            ViewBag.Action = "CreateStepParagraph";
            return View("Partials/_ManageStepParagraph", paragraphFormData);
        }


        /// <summary>
        /// Create step paragraph
        /// </summary>
        /// <param name="paragraphFormData">the step paragpaph</param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateStepParagraph(StepParagraphFormData paragraphFormData)
        {
            JsonReturnData data = new JsonReturnData();

            if (ModelState.IsValid)
            {
                StepParagraphRequestData paragraphRequest = new StepParagraphRequestData
                {
                    StepParagraphDto = new StepParagraphItemData { StepId = paragraphFormData.StepId }
                };

                StepParagraphResultData paragraphResult =
                    await WebApiClient.PostFormJsonAsync<StepParagraphRequestData, StepParagraphResultData>(
                        Constant.WebApiControllerSteps, Constant.WebApiCreateStepParagraphs, paragraphRequest);


                if (paragraphResult != null && paragraphResult.OperationSuccess && paragraphResult.StepParagraphDto != null)
                {
                    foreach (var translation in paragraphFormData.TranslationsList.ToList())
                    {
                        translation.ParagraphId = paragraphResult.StepParagraphDto.ParagraphId;
                    }

                    List<StepParagraphTranslationItemData> translations = new List<StepParagraphTranslationItemData>();
                    foreach (var translation in paragraphFormData.TranslationsList)
                    {
                        translations.Add(new StepParagraphTranslationItemData
                        {
                            ParagraphDescription = translation.ParagraphDescription,
                            ParagraphTitle = translation.ParagraphTitle,
                            ParagraphId = translation.ParagraphId,
                            LanguageId = translation.LanguageId
                        });
                    }

                    StepParagraphTranslationRequestData translationRequest = new StepParagraphTranslationRequestData
                    {
                        StepParagraphTranslationDtoList = translations
                    };

                    StepParagraphTranslationResultData sectionTranslationResultData =
                        await WebApiClient
                            .PostFormJsonAsync<StepParagraphTranslationRequestData, StepParagraphTranslationResultData>(
                                Constant.WebApiControllerSteps, Constant.WebApiCreateStepParagraphTranslationRange,
                                translationRequest);
                    if (sectionTranslationResultData == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!sectionTranslationResultData.OperationSuccess && sectionTranslationResultData.Errors != null && sectionTranslationResultData.Errors.Count > 0)
                    {
                        data.ErrorMessage = sectionTranslationResultData.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (sectionTranslationResultData.OperationSuccess)
                    {
                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else if (paragraphResult == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!paragraphResult.OperationSuccess && paragraphResult.Errors != null && paragraphResult.Errors.Count > 0)
                {
                    data.ErrorMessage = paragraphResult.Errors.First();
                    data.OperationSuccess = false;
                }
                else if (paragraphResult.OperationSuccess)
                {
                    data.SuccessMessage = UserResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data = new JsonReturnData
                {
                    ErrorMessage = StepResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }


        #endregion

        #region DELETE PARAGRAPH

        /// <summary>
        /// Get the view to delete paragraph.
        /// </summary>
        /// <param name="paragraphId">thre paragraph to delete.</param>
        /// <param name="stepId">the stepId to get the list.</param>
        /// <returns></returns>
        public ActionResult GetDeleteStepParagraph(int paragraphId = 0, int stepId = 0)
        {
            ViewBag.Step = stepId;
            return View("Partials/_DeleteStepParagraph", paragraphId);
        }

        /// <summary>
        /// delete paragraph step.
        /// </summary>
        /// <param name="paragraphId">the paragraphId to delete.</param>
        /// <returns></returns>
        public async Task<OmsJsonResult> DeleteStepParagraph(int paragraphId = 0)
        {
            JsonReturnData data = new JsonReturnData();
            if (paragraphId > 0)
            {
                string param = $"{nameof(paragraphId)}={paragraphId}";
                StepResultData result = await WebApiClient.DeleteAsync<StepResultData>(Constant.WebApiControllerSteps,
                    Constant.WebApiRemoveStepParagraphs, param);

                if (result == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (result.Errors != null && result.Errors.Count > 0)
                {
                    data.ErrorMessage = result.Errors.FirstOrDefault();
                    data.OperationSuccess = false;
                }
                else if (result.OperationSuccess)
                {
                    data.SuccessMessage = SharedResources.Ok;
                    data.OperationSuccess = true;
                }
                return new OmsJsonResult(data);
            }
            data = new JsonReturnData
            {
                ErrorMessage = StepResources.RequiredFields,
                OperationSuccess = false
            };
            return new OmsJsonResult(data);
        }
        #endregion

        #region UPDATE PARAGRAPH STEP

        /// <summary>
        /// Get the view to update paragraph.
        /// </summary>
        /// <param name="paragraphId">the paragraph id to delete.</param>
        /// <returns></returns>
        public async Task<ActionResult> GetUpdateStepParagraph(int paragraphId)
        {
            StepParagraphFormData paragraphFormData = new StepParagraphFormData
            {
                TranslationsList = new List<StepParagraphTranslationFormData>(),
                ParagraphId = paragraphId,
            };

            List<StepParagraphTranslationItemData> paragraphTranslations = await GetStepParagraphTranslations(paragraphId);

            foreach (var paragraphTranslation in paragraphTranslations)
            {
                if (paragraphTranslation.StepParagraph.StepId != null)
                    paragraphFormData.StepId = paragraphTranslation.StepParagraph.StepId.Value;

                paragraphFormData.TranslationsList.Add(new StepParagraphTranslationFormData
                {
                    ParagraphDescription = paragraphTranslation.ParagraphDescription,
                    LanguagePrefix = paragraphTranslation.Language.LanguagePrefix,
                    ParagraphTitle = paragraphTranslation.ParagraphTitle,
                    TranslationId = paragraphTranslation.TranslationId,
                    ParagraphId = paragraphTranslation.ParagraphId,
                    LanguageId = paragraphTranslation.LanguageId
                });
            }
            ViewBag.Action = "UpdateStepParagraph";
            return View("Partials/_ManageStepParagraph", paragraphFormData);
        }


        /// <summary>
        /// Update step paragraph
        /// </summary>
        /// <param name="paragraphFormData">the step paragpaph</param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateStepParagraph(StepParagraphFormData paragraphFormData)
        {
            JsonReturnData data = new JsonReturnData();

            if (ModelState.IsValid)
            {
                List<StepParagraphTranslationItemData> translationItemDataList = new List<StepParagraphTranslationItemData>();
                foreach (var stepParagraphTranslationFormData in paragraphFormData.TranslationsList)
                {
                    translationItemDataList.Add(new StepParagraphTranslationItemData
                    {
                        ParagraphDescription = stepParagraphTranslationFormData.ParagraphDescription,
                        ParagraphTitle = stepParagraphTranslationFormData.ParagraphTitle,
                        TranslationId = stepParagraphTranslationFormData.TranslationId,
                        ParagraphId = stepParagraphTranslationFormData.ParagraphId,
                        LanguageId = stepParagraphTranslationFormData.LanguageId
                    });
                }
                StepParagraphTranslationRequestData request = new StepParagraphTranslationRequestData
                {
                    StepParagraphTranslationDtoList = translationItemDataList
                };

                StepParagraphTranslationResultData result =
                    await WebApiClient
                        .PostFormJsonAsync<StepParagraphTranslationRequestData, StepParagraphTranslationResultData>(
                            Constant.WebApiControllerSteps, Constant.WebApiUpdateStepParagraphTranslationRange, request);

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
                data = new JsonReturnData
                {
                    ErrorMessage = StepResources.RequiredFields,
                    OperationSuccess = false
                };
            }
            return new OmsJsonResult(data);
        }

        #endregion

        #region PRIVATE STEP METHODS
        /// <summary>
        /// Get the list of the steps using web api.
        /// </summary>
        /// <returns>the list of the steps.</returns>
        private async Task<StepsViewData> GetStepsList()
        {
            StepsViewData stepsViewData = new StepsViewData { Steps = new List<StepViewData>() };
            StepResultData stepResultData = await WebApiClient.GetAsync<StepResultData>(Constant.WebApiControllerSteps, Constant.WebApiStepList);

            if (stepResultData == null || !stepResultData.OperationSuccess ||
                stepResultData.StepDtoList == null) return stepsViewData;

            foreach (var stepItem in stepResultData.StepDtoList.OrderByDescending(s => s.StepDate).ToList())
            {
                StepViewData step = new StepViewData
                {
                    Paragraphs = new StepParagraphsViewData(),
                    Step = stepItem,
                };
                stepsViewData.Steps.Add(step);
            }
            return stepsViewData;
        }

        /// <summary>
        /// Get the list of the paragraphs.
        /// </summary>
        /// <param name="stepId">the step id.</param>
        /// <returns>paragraph return</returns>
        private async Task<StepParagraphsViewData> GetStepParagraphs(int stepId = 0)
        {
            StepParagraphsViewData paragraphs = new StepParagraphsViewData
            {
                StepParagraphViewDataList = new List<StepParagraphViewData>(),
                StepId = stepId
            };
            if (stepId == 0) return paragraphs;

            StepParagraphRequestData request = new StepParagraphRequestData
            {
                StepParagraphDto = new StepParagraphItemData { StepId = stepId },
                FindStepParagraphDto = FindStepParagraphItemData.StepId
            };

            StepParagraphResultData result =
                await WebApiClient.PostFormJsonAsync<StepParagraphRequestData, StepParagraphResultData>(
                    Constant.WebApiControllerSteps, Constant.WebApiFindStepParagraphs, request);

            if (result == null || !result.OperationSuccess ||
                result.StepParagraphDtoList == null) return paragraphs;

            foreach (var paragraph in result.StepParagraphDtoList)
            {
                paragraphs.StepParagraphViewDataList.Add(new StepParagraphViewData
                {
                    Translations = await GetStepParagraphTranslations(paragraph.ParagraphId),
                    Paragraph = paragraph
                });
            }
            return paragraphs;
        }

        /// <summary>
        /// Get the stap paragraph translations.
        /// </summary>
        /// <param name="paragraphId">the paragrapraph id</param>
        /// <returns>translation list.</returns>
        private async Task<List<StepParagraphTranslationItemData>> GetStepParagraphTranslations(int paragraphId = 0)
        {
            List<StepParagraphTranslationItemData> translations = new List<StepParagraphTranslationItemData>();
            if (paragraphId == 0) { return translations; }
            StepParagraphTranslationRequestData request = new StepParagraphTranslationRequestData
            {
                FindStepParagraphTranslationDto = FindStepParagraphTranslationItemData.StepParagraphId,
                StepParagraphTranslationDto = new StepParagraphTranslationItemData { ParagraphId = paragraphId }
            };

            StepParagraphTranslationResultData result =
                await WebApiClient
                    .PostFormJsonAsync<StepParagraphTranslationRequestData, StepParagraphTranslationResultData>(
                        Constant.WebApiControllerSteps, Constant.WebApiFindStepParagraphTranslation, request);
            if (result == null || !result.OperationSuccess ||
                result.StepParagraphTranslationDtoList == null) return translations;

            foreach (var translation in result.StepParagraphTranslationDtoList) { translations.Add(translation); }
            return translations;
        }

        #endregion

        #endregion
    }
}