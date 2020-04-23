using Admin.Riafco.Dataflex.Pro.Authorization;
using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.Assembler;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ResultData;
using Riafco.Framework.Dataflex.pro.Web.ActionResult;
using Riafco.Framework.Dataflex.pro.Web.AjaxComponent;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Admin.Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// The profile controller.
    /// </summary>
    public class ProfileController : Controller
    {
        /// <summary>
        /// The index page profile.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            if (Session["ConnectedUser"] == null) { return RedirectToAction("Index", "Home"); }
            bool isAuthorizedUser = await AuthorizeUserAttribute.IsUserExiste();
            if (!isAuthorizedUser) return RedirectToAction("Index", "Home");

            UserRequestData findRequest = new UserRequestData { UserDto = new UserItemData { UserId = int.Parse(User.Identity.Name) } };
            ManageUserFormData userFormData = new ManageUserFormData();

            UserResultData result = await WebApiClient.PostFormJsonAsync<UserRequestData, UserResultData>(Constant.WebApiControllerUser, Constant.WebApiFindUser, findRequest);
            if (result != null && result.OperationSuccess && result.UserDto != null)
            {
                userFormData = result.ToUserFormData();
            }
            return View(userFormData);
        }

        /// <summary>
        /// Set profile informations.
        /// </summary>
        /// <param name="userForm">the form data.</param>
        /// <returns>the action result.</returns>
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<OmsJsonResult> UpdateProfile(ManageUserFormData userForm)
        {
            UserResultData result = await WebApiClient.PostFormJsonAsync<UserRequestData, UserResultData>(Constant.WebApiControllerUser, Constant.WebApiUpdateUser, userForm.ToRequestData());
            JsonReturnData data = new JsonReturnData();

            if (result != null && result.OperationSuccess)
            {
                data.SuccessMessage = UserResources.Ok;
                data.OperationSuccess = true;
            }
            else if (result != null && result.OperationSuccess == false && result.Errors != null && result.Errors.Any())
            {
                data.ErrorMessage = result.Errors.First();
                data.OperationSuccess = false;
            }
            else if (result == null)
            {
                data.ErrorMessage = SharedResources.ServerError;
                data.OperationSuccess = false;
            }
            return new OmsJsonResult(data);
        }
    }
}
