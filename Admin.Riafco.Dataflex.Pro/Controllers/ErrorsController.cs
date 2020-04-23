using Admin.Riafco.Dataflex.Pro.Authorization;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Admin.Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// The ErrorsController.
    /// </summary>
    public class ErrorsController : Controller
    {
        /// <summary>
        /// User not authorazed to acces to the page.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> NoAccess()
        {
            if (Session["ConnectedUser"] == null) { return RedirectToAction("Index", "Home"); }
            bool isAuthorizedUser = await AuthorizeUserAttribute.IsUserExiste();
            if (!isAuthorizedUser) return RedirectToAction("Index", "Home");
            return View();
        }
    }
}