using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Message;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Request;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Ressource;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Riafco.WebApi.Dataflex.pro.Controllers.Partners
{
    /// <summary>
    /// The Partner web api controller.
    /// </summary>
    [RoutePrefix("api/Partners")]
    public class PartnerController : ApiController
    {
        #region private properties
        /// <summary>
        /// The Partner service client instance.
        /// </summary>
        private readonly IServicePartnerClient _servicePartnerClient;
        #endregion

        #region constructor
        /// <summary>
        /// Set the IServicePartnerClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServicePartnerClient">injected instance</param>
        public PartnerController(IServicePartnerClient injectedServicePartnerClient)
        {
            _servicePartnerClient = injectedServicePartnerClient;
        }
        #endregion

        #region public methods Partners
        /// <summary>
        /// Create new Partner
        /// </summary>
        /// <returns>Partner message.</returns>
        [Route("CreatePartner")]
        public IHttpActionResult CreatePartner(PartnerRequest request)
        {
            List<string> errors = ValidateCreatePartner(request);
            PartnerMessage message = new PartnerMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PartnerMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePartnerClient.CreatePartner(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change Partner informations.
        /// </summary>
        /// <returns>Partner message.</returns>
        [Route("UpdatePartner")]
        public IHttpActionResult UpdatePartner(PartnerRequest request)
        {
            List<string> errors = ValidateUpdatePartner(request);
            PartnerMessage message = new PartnerMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PartnerMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePartnerClient.UpdatePartner(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Partner
        /// </summary>
        /// <returns>Partner message.</returns>
        [HttpDelete]
        [Route("RemovePartner")]
        public IHttpActionResult DeletePartner(int partnerId)
        {
            PartnerRequest request = new PartnerRequest { PartnerDto = new PartnerDto { PartnerId = partnerId } };
            List<string> errors = ValidateDeletePartner(request);
            PartnerMessage message = new PartnerMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PartnerMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePartnerClient.DeletePartner(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Partner
        /// </summary>
        /// <returns>Partner message.</returns>
        [Route("GetPartners")]
        public IHttpActionResult GetAllPartners()
        {
            PartnerMessage message = _servicePartnerClient.GetAllPartners();
            return Json(message);
        }

        /// <summary>
        /// Find Partner
        /// </summary>
        /// <returns>Partner message.</returns>
        [Route("FindPartners")]
        public IHttpActionResult FindPartners(PartnerRequest request)
        {
            List<string> errors = ValidateFindPartners(request);
            PartnerMessage message = new PartnerMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = PartnerMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _servicePartnerClient.FindPartners(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation partner methods
        /// <summary>
        /// Validation creation partner.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreatePartner(PartnerRequest request)
        {
            var errors = new List<string>();
            if (request?.PartnerDto == null)
            {
                errors.Add(PartnerMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PartnerDto>.ValidateAttributes("PartnerName", request.PartnerDto.PartnerName));
                errors.AddRange(GenericValidationAttribute<PartnerDto>.ValidateAttributes("PartnerLink", request.PartnerDto.PartnerLink));
            }
            return errors;
        }

        /// <summary>
        /// Validation update partner.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdatePartner(PartnerRequest request)
        {
            var errors = new List<string>();
            if (request?.PartnerDto == null)
            {
                errors.Add(PartnerMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PartnerDto>.ValidateAttributes("PartnerName", request.PartnerDto.PartnerName));
                errors.AddRange(GenericValidationAttribute<PartnerDto>.ValidateAttributes("PartnerLink", request.PartnerDto.PartnerLink));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete partner.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeletePartner(PartnerRequest request)
        {
            var errors = new List<string>();
            if (request?.PartnerDto == null)
            {
                errors.Add(PartnerMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PartnerDto>.ValidateAttributes("PartnerId", request.PartnerDto.PartnerId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete partner.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindPartners(PartnerRequest request)
        {
            var errors = new List<string>();
            if (request?.PartnerDto == null)
            {
                errors.Add(PartnerMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<PartnerDto>.ValidateAttributes("PartnerId", request.PartnerDto.PartnerId.ToString()));
            }
            return errors;
        }
        #endregion
    }
}