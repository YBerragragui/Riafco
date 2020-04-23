using Admin.Riafco.Dataflex.Pro.Authorization;
using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.Settings.Assembler;
using Admin.Riafco.Dataflex.Pro.Models.Settings.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.Settings.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ResultData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ViewData;
using Riafco.Framework.Dataflex.pro.Web.ActionResult;
using Riafco.Framework.Dataflex.pro.Web.AjaxComponent;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Admin.Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// The Settings Controller controller.
    /// </summary>
    public class SettingsController : Controller
    {
        /// <summary>
        /// The index page.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            if (Session["ConnectedUser"] == null) { return RedirectToAction("Index", "Home"); }
            bool isAuthorizedUser = await AuthorizeUserAttribute.AuthorizeSettings();
            if (!isAuthorizedUser) return RedirectToAction("NoAccess", "Errors");

            LanguageViewData languageViewData = new LanguageViewData();
            LanguageResultData result =
                await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages,
                Constant.WebApiLanguageList);
            if (result?.LanguageDtoList != null && result.OperationSuccess)
            {
                languageViewData.Languages = result.LanguageDtoList;
            }

            ViewBag.Settings = "active";
            return View(languageViewData);
        }

        #region Languages
        /// <summary>
        /// The languages section.
        /// </summary>
        /// <returns>htm section.</returns>
        public async Task<ActionResult> Languages()
        {
            LanguageViewData languageViewData = new LanguageViewData();

            LanguageResultData result = await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages, Constant.WebApiLanguageList);
            if (result?.LanguageDtoList != null && result.OperationSuccess)
            {
                languageViewData.Languages = result.LanguageDtoList;
            }

            return View("Partials/_Languages", languageViewData);
        }

        /// <summary>
        /// language section list.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetLanguages()
        {
            LanguageViewData languageViewData = new LanguageViewData();
            LanguageResultData result = await WebApiClient.GetAsync<LanguageResultData>(Constant.WebApiControllerLanguages, Constant.WebApiLanguageList);
            if (result?.LanguageDtoList != null && result.OperationSuccess)
            {
                languageViewData.Languages = result.LanguageDtoList;
            }

            return PartialView("Partials/_LanguagesList", languageViewData);
        }

        /// <summary>
        /// Return the view to add language.
        /// </summary>
        /// <returns>adding view</returns>
        public ActionResult GetCreateLanguage()
        {
            AddLanguageFormData languageFormData = new AddLanguageFormData();
            return PartialView("Partials/_CreateLanguage", languageFormData);
        }

        /// <summary>
        /// Create new language.
        /// </summary>
        /// <param name="languageFormData">langue form data.</param>
        /// <returns>return true if the langue were created.</returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateLanguage(AddLanguageFormData languageFormData)
        {
            LanguageRequestData request = languageFormData.ToAddRequestData();
            LanguageResultData result = await WebApiClient.PostFormJsonAsync<LanguageRequestData, LanguageResultData>(Constant.WebApiControllerLanguages, Constant.WebApiCreateLanguage, request);
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
                Directory.CreateDirectory(
                    Server.MapPath($"~/Images/Languages/" + result.LanguageDto.LanguageId));

                languageFormData.LanguagePicture?.SaveAs(
                    Server.MapPath($"~/Images/Languages/" + result.LanguageDto.LanguageId + $"/") +
                    languageFormData.LanguagePicture.FileName);

                data.SuccessMessage = LanguageResources.ok;
                data.OperationSuccess = true;
            }
            return new OmsJsonResult(data);
        }

        /// <summary>
        /// The update langue view.
        /// </summary>
        /// <param name="languageId">the langue id to update.</param>
        /// <returns>updating view</returns>
        public async Task<ActionResult> GetUpdateLanguage(int languageId)
        {
            UpdateLanguageFormData languageFormData = new UpdateLanguageFormData();
            LanguageRequestData findRequest = new LanguageRequestData
            {
                LanguageDto = new LanguageItemData
                {
                    LanguageId = languageId
                },
                FindLanguageDtoEnum = FindLanguageItemData.LanguageId
            };

            LanguageResultData result = await WebApiClient.PostFormJsonAsync<LanguageRequestData, LanguageResultData>(Constant.WebApiControllerLanguages, Constant.WebApiFindLanguage, findRequest);
            if (result != null && result.OperationSuccess && result.LanguageDto != null)
            {
                languageFormData = result.ToUpdateLangueFormData();
            }
            return PartialView("Partials/_UpdateLanguage", languageFormData);
        }


        /// <summary>
        /// update language.
        /// </summary>
        /// <param name="languageFormData">langue form data.</param>
        /// <returns>return true if the langue were created.</returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateLanguage(UpdateLanguageFormData languageFormData)
        {
            LanguageRequestData request = languageFormData.ToUpdateRequestData();
            LanguageResultData result = await WebApiClient.PostFormJsonAsync<LanguageRequestData, LanguageResultData>(Constant.WebApiControllerLanguages, Constant.WebApiUpdateLanguage, request);
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
                if (!Directory.Exists(Server.MapPath($"~/Images/Languages/" + languageFormData.LanguageId)))
                {
                    Directory.CreateDirectory(
                        Server.MapPath($"~/Images/Languages/" + languageFormData.LanguageId));
                }
                languageFormData.LanguagePicture?.SaveAs(
                    Server.MapPath($"~/Images/Languages/" + languageFormData.LanguageId + $"/") +
                    languageFormData.LanguagePicture.FileName);

                data.SuccessMessage = LanguageResources.ok;
                data.OperationSuccess = true;
            }
            return new OmsJsonResult(data);
        }

        /// <summary>
        /// Delete language.
        /// </summary>
        /// <param name="languageId">the language id to delete.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OmsJsonResult> DeleteLanguage(int languageId)
        {
            JsonReturnData data = new JsonReturnData();
            if (languageId > 0)
            {
                string param = $"{nameof(languageId)}={languageId}";
                LanguageResultData result = await WebApiClient.DeleteAsync<LanguageResultData>(Constant.WebApiControllerLanguages, Constant.WebApiRemoveLanguage, param);
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
                    if (Directory.Exists(Server.MapPath($"~/Images/Languages/" + languageId)))
                    {
                        Directory.Delete(Server.MapPath($"~/Images/Languages/" + languageId), true);
                    }

                    data.SuccessMessage = LanguageResources.ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data.ErrorMessage = LanguageResources.RequiredId;
                data.OperationSuccess = false;
            }
            return new OmsJsonResult(data);
        }
        #endregion

        #region Rules
        /// <summary>
        /// The languages section.
        /// </summary>
        /// <returns>htm section.</returns>
        public async Task<ActionResult> Rules()
        {
            RuleViewData ruleViewData = new RuleViewData();

            RuleResultData result = await WebApiClient.GetAsync<RuleResultData>(Constant.WebApiControllerRule, Constant.WebApiRuleList);
            if (result?.RuleDtoList != null && result.OperationSuccess)
            {
                ruleViewData.Rules = result.RuleDtoList;
            }

            return View("Partials/_Rules", ruleViewData);
        }

        /// <summary>
        /// Rule list.
        /// </summary>
        /// <returns>rules page.</returns>
        public async Task<ActionResult> GetRules()
        {
            RuleViewData ruleViewData = new RuleViewData();
            RuleResultData result = await WebApiClient.GetAsync<RuleResultData>(Constant.WebApiControllerRule, Constant.WebApiRuleList);
            if (result?.RuleDtoList != null && result.OperationSuccess)
            {
                ruleViewData.Rules = result.RuleDtoList;
            }
            return PartialView("Partials/_RulesList", ruleViewData);
        }

        /// <summary>
        /// Return the view to add rule.
        /// </summary>
        /// <returns>adding view</returns>
        public ActionResult GetCreateRule()
        {
            ManageRuleFormData ruleFormData = new ManageRuleFormData();
            ViewBag.action = "CreateRule";

            return PartialView("Partials/_ManageRule", ruleFormData);
        }

        /// <summary>
        /// create rule.
        /// </summary>
        /// <param name="ruleFormData">rule form data to create rule.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<OmsJsonResult> CreateRule(ManageRuleFormData ruleFormData)
        {
            RuleRequestData request = ruleFormData.ToRequestData();
            RuleResultData result = await WebApiClient.PostFormJsonAsync<RuleRequestData, RuleResultData>(Constant.WebApiControllerRule, Constant.WebApiCreateRule, request);
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
                data.SuccessMessage = RuleResources.Ok;
                data.OperationSuccess = true;
            }
            return new OmsJsonResult(data);
        }

        /// <summary>
        /// The update rule view.
        /// </summary>
        /// <param name="ruleId">the rule id to update.</param>
        /// <returns>updating view</returns>
        public async Task<ActionResult> GetUpdateRule(int ruleId)
        {
            ManageRuleFormData ruleFormData = new ManageRuleFormData();
            RuleRequestData findRequest = new RuleRequestData
            {
                RuleDto = new RuleItemData
                {
                    RuleId = ruleId
                },
                FindRuleItemData = FindRuleItemData.RuleId
            };

            RuleResultData result = await WebApiClient.PostFormJsonAsync<RuleRequestData, RuleResultData>(Constant.WebApiControllerRule, Constant.WebApiFindRules, findRequest);
            if (result != null && result.OperationSuccess && result.RuleDto != null)
            {
                ruleFormData = result.ToFormData();
            }
            ViewBag.action = "UpdateRule";
            return PartialView("Partials/_ManageRule", ruleFormData);
        }

        /// <summary>
        /// update rule.
        /// </summary>
        /// <param name="ruleFormData">rule form data.</param>
        /// <returns>return true if the langue were created.</returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdateRule(ManageRuleFormData ruleFormData)
        {
            RuleRequestData request = ruleFormData.ToRequestData();
            RuleResultData result = await WebApiClient.PostFormJsonAsync<RuleRequestData, RuleResultData>(Constant.WebApiControllerRule, Constant.WebApiUpdateRule, request);
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
                data.SuccessMessage = RuleResources.Ok;
                data.OperationSuccess = true;
            }
            return new OmsJsonResult(data);
        }

        /// <summary>
        /// Delete rule.
        /// </summary>
        /// <param name="ruleId">the rule id to delete.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OmsJsonResult> DeleteRule(int ruleId)
        {
            JsonReturnData data = new JsonReturnData();
            if (ruleId > 0)
            {
                string param = $"{nameof(ruleId)}={ruleId}";
                RuleResultData result = await WebApiClient.DeleteAsync<RuleResultData>(Constant.WebApiControllerRule, Constant.WebApiRemoveRule, param);
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
                    data.SuccessMessage = RuleResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data.ErrorMessage = RuleResources.RequiredId;
                data.OperationSuccess = false;
            }
            return new OmsJsonResult(data);
        }
        #endregion
    }
}