using Admin.Riafco.Dataflex.Pro.Authorization;
using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.Partners.Assembler;
using Admin.Riafco.Dataflex.Pro.Models.Partners.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Partners.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Partners.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.Partners.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Partners.ResultData;
using Admin.Riafco.Dataflex.Pro.Models.Partners.ViewData;
using Riafco.Framework.Dataflex.pro.Web.ActionResult;
using Riafco.Framework.Dataflex.pro.Web.AjaxComponent;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Admin.Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// Partnets controller.
    /// </summary>
    public class PartnersController : Controller
    {
        /// <summary>
        /// The index page.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            if (Session["ConnectedUser"] == null) { return RedirectToAction("Index", "Home"); }
            bool isAuthorizedUser = await AuthorizeUserAttribute.Authorize("A_PARTNERS");
            if (!isAuthorizedUser) return RedirectToAction("NoAccess", "Errors");

            PartnersViewData partnerViewData = new PartnersViewData();
            PartnerResultData result = await WebApiClient.GetAsync<PartnerResultData>(Constant.WebApiControllerPartners, Constant.WebApiPartnerList);
            if (result?.PartnerDtoList != null && result.OperationSuccess)
            {
                partnerViewData.Partners = result.PartnerDtoList;
            }
            ViewBag.Partners = "active";
            return View(partnerViewData);
        }

        #region Partners
        /// <summary>
        /// partner section list.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetPartners()
        {
            PartnersViewData partnerViewData = new PartnersViewData();
            PartnerResultData result = await WebApiClient.GetAsync<PartnerResultData>(Constant.WebApiControllerPartners, Constant.WebApiPartnerList);
            if (result?.PartnerDtoList != null && result.OperationSuccess)
            {
                partnerViewData.Partners = result.PartnerDtoList;
            }

            return PartialView("Partials/_PartnersList", partnerViewData);
        }

        /// <summary>
        /// Return the view to add partner.
        /// </summary>
        /// <returns>adding view</returns>
        public ActionResult GetCreatePartner()
        {
            PartnerFormData partnerFormData = new PartnerFormData();
            ViewBag.Action = "CreatePartner";
            return PartialView("Partials/_ManagePartner", partnerFormData);
        }

        /// <summary>
        /// Create new partner.
        /// </summary>
        /// <param name="partnerFormData">partner form data.</param>
        /// <returns>return true if the partner were created.</returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreatePartner(PartnerFormData partnerFormData)
        {
            PartnerRequestData request = partnerFormData.ToRequestData();
            if (request.PartnerDto.PartnerImage == null)
            {
                request.PartnerDto.PartnerImage = "~/Images/Default/default-image-partner.jpg";
            }
            PartnerResultData result =
                await WebApiClient.PostFormJsonAsync<PartnerRequestData, PartnerResultData>(
                    Constant.WebApiControllerPartners, Constant.WebApiCreatePartner, request);
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
                    Server.MapPath($"~/Images/Partners/" + partnerFormData.PartnerId + $"/"));

                partnerFormData.PartnerImage?.SaveAs(
                Server.MapPath($"~/Images/Partners/" + partnerFormData.PartnerId + $"/") +
                partnerFormData.PartnerImage.FileName);

                data.SuccessMessage = UserResources.Ok;
                data.OperationSuccess = true;
            }
            return new OmsJsonResult(data);
        }

        /// <summary>
        /// The update partner view.
        /// </summary>
        /// <param name="partnerId">the partner id to update.</param>
        /// <returns>updating view</returns>
        public async Task<ActionResult> GetUpdatePartner(int partnerId)
        {
            PartnerFormData partnerFormData = new PartnerFormData();
            PartnerRequestData findRequest = new PartnerRequestData
            {
                PartnerDto = new PartnerItemData
                {
                    PartnerId = partnerId
                },
                FindPartnerDto = FindPartnerItemData.PartnerId
            };

            PartnerResultData result = await WebApiClient.PostFormJsonAsync<PartnerRequestData, PartnerResultData>(Constant.WebApiControllerPartners, Constant.WebApiFindPartners, findRequest);
            if (result != null && result.OperationSuccess && result.PartnerDto != null)
            {
                partnerFormData = result.ToFormData();
            }

            List<SelectListItem> positionList = new List<SelectListItem>();
            PartnerResultData partnerResult = await WebApiClient.GetAsync<PartnerResultData>(Constant.WebApiControllerPartners, Constant.WebApiPartnerList);

            foreach (var partner in partnerResult.PartnerDtoList.OrderBy(p => p.PartnerPosition))
            {
                positionList.Add(new SelectListItem { Text = PartnerResources.PositionText + partner.PartnerPosition, Value = partner.PartnerPosition.ToString() });
            }
            ViewBag.positionList = positionList;

            ViewBag.Action = "UpdatePartner";
            return PartialView("Partials/_ManagePartner", partnerFormData);
        }


        /// <summary>
        /// update partner.
        /// </summary>
        /// <param name="partnerFormData">partner form data.</param>
        /// <returns>return true if the partner were created.</returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> UpdatePartner(PartnerFormData partnerFormData)
        {
            PartnerRequestData request = partnerFormData.ToRequestData();
            PartnerResultData result = await WebApiClient.PostFormJsonAsync<PartnerRequestData, PartnerResultData>(Constant.WebApiControllerPartners, Constant.WebApiUpdatePartner, request);
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
                if (!Directory.Exists(Server.MapPath($"~/Images/Partners/" + partnerFormData.PartnerId + $"/")))
                {
                    Directory.CreateDirectory(
                        Server.MapPath($"~/Images/Partners/" + partnerFormData.PartnerId));
                }

                partnerFormData.PartnerImage?.SaveAs(
                    Server.MapPath($"~/Images/Partners/" + partnerFormData.PartnerId + $"/") +
                    partnerFormData.PartnerImage.FileName);

                data.SuccessMessage = UserResources.Ok;
                data.OperationSuccess = true;
            }
            return new OmsJsonResult(data);
        }

        /// <summary>
        /// The GetDeleteSection Method
        /// </summary>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public ActionResult GetDeletePartner(int partnerId)
        {
            return View("Partials/_DeletePartner", partnerId);
        }

        /// <summary>
        /// Delete partner.
        /// </summary>
        /// <param name="partnerId">the partner id to delete.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OmsJsonResult> DeletePartner(int partnerId)
        {
            JsonReturnData data = new JsonReturnData();
            if (partnerId > 0)
            {
                string param = $"{nameof(partnerId)}={partnerId}";
                PartnerResultData result = await WebApiClient.DeleteAsync<PartnerResultData>(Constant.WebApiControllerPartners, Constant.WebApiRemovePartner, param);
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
                    if (Directory.Exists(Server.MapPath($"~/Images/Partners/" + partnerId)))
                    {
                        Directory.Delete(Server.MapPath($"~/Images/Partners/" + partnerId), true);
                    }
                    data.SuccessMessage = UserResources.Ok;
                    data.OperationSuccess = true;
                }
            }
            else
            {
                data.ErrorMessage = PartnerResources.RequiredId;
                data.OperationSuccess = false;
            }
            return new OmsJsonResult(data);
        }
        #endregion
    }
}