using Admin.Riafco.Dataflex.Pro.Authorization;
using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.Assembler;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ResultData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ViewData;
using Riafco.Framework.Dataflex.pro.Communication.Mailling;
using Riafco.Framework.Dataflex.pro.Web.ActionResult;
using Riafco.Framework.Dataflex.pro.Web.AjaxComponent;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Admin.Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// The profileController controller.
    /// </summary>
    public class UsersController : Controller
    {
        /// <summary>
        /// The index page.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            if (Session["ConnectedUser"] == null) { return RedirectToAction("Index", "Home"); }
            bool isAuthorizedUser = await AuthorizeUserAttribute.Authorize("A_USERS");
            if (!isAuthorizedUser) return RedirectToAction("NoAccess", "Errors");
            UserViewData userViewData = new UserViewData { Users = new List<UserItemData>() };
            UserResultData result = await WebApiClient.GetAsync<UserResultData>(Constant.WebApiControllerUser, Constant.WebApiUserList);
            if (result?.UserDtoList != null && result.OperationSuccess) { userViewData.Users = result.UserDtoList; }
            ViewBag.Users = "active";
            return View(userViewData);
        }

        #region USERS

        /// <summary>
        /// Page users: List of the users.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Users()
        {
            UserViewData userViewData = new UserViewData { Users = new List<UserItemData>() };
            UserResultData result = await WebApiClient.GetAsync<UserResultData>(Constant.WebApiControllerUser, Constant.WebApiUserList);
            if (result?.UserDtoList != null && result.OperationSuccess)
            {
                userViewData.Users = result.UserDtoList;
            }
            return View("Partials/_UsersList", userViewData);
        }

        /// <summary>
        /// Get the list of the users.
        /// </summary>
        /// <returns>action user</returns>
        public async Task<ActionResult> GetUsers()
        {
            UserViewData userViewData = new UserViewData { Users = new List<UserItemData>() };
            UserResultData result = await WebApiClient.GetAsync<UserResultData>(Constant.WebApiControllerUser, Constant.WebApiUserList);
            if (result.OperationSuccess && result.UserDtoList != null)
            {
                userViewData.Users = result.UserDtoList;
            }
            return PartialView("Partials/_UsersList", userViewData);
        }

        /// <summary>
        /// Get the view to creating new user.
        /// </summary>
        /// <returns>creating view</returns>
        public ActionResult GetCreateUser()
        {
            ManageUserFormData userFormData = new ManageUserFormData { UserId = 0 };
            ViewBag.action = "CreateUser";

            return PartialView("Partials/_ManageUser", userFormData);
        }

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="userFormData">user form data.</param>
        /// <returns>return true if the user were created.</returns>
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<OmsJsonResult> CreateUser(ManageUserFormData userFormData)
        {
            UserRequestData userRequestData = userFormData.ToRequestData();
            if (userRequestData.UserDto.UserPicture == null)
            {
                userRequestData.UserDto.UserPicture = "default-user.png";
            }
            else
            {
                userFormData.UserPicture.SaveAs(Server.MapPath($"~/Images/Users/" + userFormData.UserPicture.FileName));
            }

            UserResultData result =
                await WebApiClient.PostFormJsonAsync<UserRequestData, UserResultData>(Constant.WebApiControllerUser,
                    Constant.WebApiCreateUser, userRequestData);
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
                //send mail :
                string bodyText = System.IO.File.ReadAllText(Server.MapPath($"/Templates/NewUserMail.html"));
                bodyText = bodyText.Replace("{passe}", result.UserDto.UserPassword);
                bodyText = bodyText.Replace("{login}", result.UserDto.UserMail);

                Thread mailThread = new Thread(() =>
                    MaillingService.SendMail(result.UserDto.UserMail, SharedResources.SubjectUserMail, bodyText, true));
                mailThread.Start();

                data.SuccessMessage = UserResources.Ok;
                data.OperationSuccess = true;
            }

            return new OmsJsonResult(data);
        }

        /// <summary>
        /// The update user view.
        /// </summary>
        /// <param name="userId">the user id to update.</param>
        /// <returns>updating view</returns>
        public async Task<ActionResult> GetUpdateUser(int userId)
        {
            ManageUserFormData userFormData = new ManageUserFormData();
            UserRequestData findRequest = new UserRequestData()
            {
                UserDto = new UserItemData { UserId = userId },
                FindUserDto = FindUserItemData.UserId
            };

            UserResultData result = await WebApiClient.PostFormJsonAsync<UserRequestData, UserResultData>(Constant.WebApiControllerUser, Constant.WebApiFindUser, findRequest);
            if (result != null && result.OperationSuccess && result.UserDto != null)
            {
                userFormData = result.ToUserFormData();
            }

            ViewBag.action = "UpdateUser";
            return PartialView("Partials/_ManageUser", userFormData);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="userFormData">user form data.</param>
        /// <returns>return true if the user were created.</returns>
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<OmsJsonResult> UpdateUser(ManageUserFormData userFormData)
        {
            UserResultData result = await WebApiClient.PostFormJsonAsync<UserRequestData, UserResultData>(Constant.WebApiControllerUser, Constant.WebApiUpdateUser, userFormData.ToRequestData());
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
        /// Activate user.
        /// </summary>
        /// <param name="userId">the user to activate.</param>
        /// <returns></returns>
        public async Task<OmsJsonResult> ActivateUser(int? userId)
        {
            JsonReturnData data = new JsonReturnData();
            if (userId.HasValue)
            {
                //find user.
                UserRequestData findRequest = new UserRequestData
                {
                    UserDto = new UserItemData()
                    {
                        UserId = userId.Value
                    },
                    FindUserDto = FindUserItemData.UserId
                };

                UserResultData result = await WebApiClient.PostFormJsonAsync<UserRequestData, UserResultData>(Constant.WebApiControllerUser, Constant.WebApiFindUser, findRequest);
                if (result != null && result.OperationSuccess && result.UserDto != null)
                {
                    result.UserDto.UserStatut = !result.UserDto.UserStatut;

                    //update user.
                    UserResultData updatedResult = await WebApiClient.PostFormJsonAsync<UserRequestData, UserResultData>(Constant.WebApiControllerUser, Constant.WebApiUpdateUser, result.ToUserRequestData());
                    if (updatedResult == null)
                    {
                        data.ErrorMessage = SharedResources.ServerError;
                        data.OperationSuccess = false;
                    }
                    else if (!updatedResult.OperationSuccess && updatedResult.Errors != null &&
                             updatedResult.Errors.Count > 0)
                    {
                        data.ErrorMessage = updatedResult.Errors.First();
                        data.OperationSuccess = false;
                    }
                    else if (updatedResult.OperationSuccess)
                    {
                        data.SuccessMessage = UserResources.Ok;
                        data.OperationSuccess = true;
                    }
                }
                else
                {
                    data.SuccessMessage = UserResources.NotFound;
                    data.OperationSuccess = false;
                }
            }
            else
            {
                data.ErrorMessage = UserResources.RequiredUserId;
                data.OperationSuccess = false;
            }
            return new OmsJsonResult(data);
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="userId">the userId to delete.</param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteUser(int userId)
        {
            JsonReturnData data = new JsonReturnData();
            if (userId > 0)
            {
                string param = $"{nameof(userId)}={userId}";
                UserResultData result = await WebApiClient.DeleteAsync<UserResultData>(Constant.WebApiControllerUser, Constant.WebApiDeleteUser, param);
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

        #region USER RULES
        /// <summary>
        /// Get user rule
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <returns>views to set rules.</returns>
        public async Task<ActionResult> GetUserRules(int? userId)
        {
            ManageUserRulesFormData manageUserRulesFormData = new ManageUserRulesFormData();

            if (!userId.HasValue) return PartialView("Partials/_UserRules", manageUserRulesFormData);
            manageUserRulesFormData.UserId = userId.Value;
            manageUserRulesFormData.Rules = new List<ManageUserRuleFormData>();

            UserRuleRequestData findUserRuleRequest = new UserRuleRequestData
            {
                UserRuleDto = new UserRuleItemData { UserId = userId.Value },
                FindUserRuleDto = FindUserRuleItemData.UserId
            };

            UserRuleResultData userRuleResultData = await WebApiClient.PostFormJsonAsync<UserRuleRequestData, UserRuleResultData>(Constant.WebApiControllerUser, Constant.WebApiFindUserRules, findUserRuleRequest);

            if (userRuleResultData != null && userRuleResultData.OperationSuccess && userRuleResultData.UserRuleDtoList != null)
            {
                foreach (var userRule in userRuleResultData.UserRuleDtoList)
                {
                    manageUserRulesFormData.Rules.Add(userRule.ToUserRuleFormData());
                }
            }
            return PartialView("Partials/_UserRules", manageUserRulesFormData);
        }


        /// <summary>
        /// update user rule
        /// </summary>
        /// <param name="manageUserRulesFormData">the user rule form data</param>
        /// <returns>result updating user rule</returns>
        public async Task<OmsJsonResult> SetUserRules(ManageUserRulesFormData manageUserRulesFormData)
        {
            UserRuleRequestData userRuleRequestData = new UserRuleRequestData
            {
                UserRuleDtoList = new List<UserRuleItemData>()
            };

            foreach (var userRule in manageUserRulesFormData.Rules)
            {
                UserRuleItemData userRuleItemData = userRule.ToUserRuleItemData();
                userRuleItemData.UserId = manageUserRulesFormData.UserId;
                userRuleRequestData.UserRuleDtoList.Add(userRuleItemData);
            }


            UserRuleResultData userRuleResultData = await WebApiClient.PostFormJsonAsync<UserRuleRequestData, UserRuleResultData>(Constant.WebApiControllerUser, Constant.WebApiUpdateUserRuleRange, userRuleRequestData);

            JsonReturnData data = new JsonReturnData();
            if (userRuleResultData == null)
            {
                data.ErrorMessage = SharedResources.ServerError;
                data.OperationSuccess = false;
            }
            else if (!userRuleResultData.OperationSuccess && userRuleResultData.Errors != null && userRuleResultData.Errors.Count > 0)
            {
                data.ErrorMessage = userRuleResultData.Errors.First();
                data.OperationSuccess = false;
            }
            else if (userRuleResultData.OperationSuccess)
            {
                data.SuccessMessage = UserResources.Ok;
                data.OperationSuccess = true;
            }
            return new OmsJsonResult(data);
        }

        #endregion
    }
}
