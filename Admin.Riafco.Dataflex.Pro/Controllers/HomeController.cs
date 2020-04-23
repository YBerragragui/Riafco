using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ResultData;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Admin.Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// The home controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Connection page.
        /// </summary>
        /// <returns>home page</returns>
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated && Session["ConnectedUser"] != null)
            {
                return RedirectToAction("Index", "Activities");
            }
            return View(new ConnectionFormData());
        }

        /// <summary>
        /// Post connextion form
        /// </summary>
        /// <param name="formData">the submited informations</param>
        /// <returns>action result return</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Connection(ConnectionFormData formData)
        {
            if (!ModelState.IsValid) return View("Index", formData);
            try
            {
                UserRequestData request = new UserRequestData
                {
                    UserDto = new UserItemData { UserMail = formData.Username },
                    FindUserDto = FindUserItemData.UserMail
                };
                UserResultData result = await WebApiClient.PostFormJsonAsync<UserRequestData, UserResultData>(Constant.WebApiControllerUser, Constant.WebApiFindUser, request);
                if (result != null && result.OperationSuccess && result.UserDto != null)
                {
                    if (result.UserDto.UserPassword == formData.Password)
                    {
                        FormsAuthentication.SetAuthCookie(result.UserDto.UserId.ToString(), true);
                        Session["ConnectedUser"] = result.UserDto;
                        return RedirectToAction("Index", "Activities");
                    }
                    ViewBag.Errors = ConnectionResources.Errors;
                    return View("Index", formData);
                }
                ViewBag.Errors = result?.ErrorMessage;
                return View("Index", formData);
            }
            catch (Exception e)
            {
                var message = e.Message;
                ViewBag.Errors = message;
            }
            return View("Index", formData);
        }

        /// <summary>
        /// Logout the user profile ans redirection de connection page.
        /// </summary>
        /// <returns>connection page.</returns>
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}