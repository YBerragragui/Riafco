using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Message;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Request;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Ressource;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Riafco.WebApi.Dataflex.pro.Controllers.Authorizarion
{
    /// <summary>
    /// The Rule web api controller.
    /// </summary>
    [RoutePrefix("api/Rules")]
    public class RuleController : ApiController
    {
        #region private attributes

        /// <summary>
        /// The Rule service client instance.
        /// </summary>
        private readonly IServiceRuleClient _serviceRuleClient;

        #endregion

        #region constructor

        /// <summary>
        /// Set the IServiceRuleClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceRuleClient">injected instance</param>
        public RuleController(IServiceRuleClient injectedServiceRuleClient)
        {
            _serviceRuleClient = injectedServiceRuleClient;
        }

        #endregion

        #region public rule methods

        /// <summary>
        /// Create new Rule
        /// </summary>
        /// <returns>Rule message.</returns>
        [Route("CreateRule")]
        public IHttpActionResult CreateRule(RuleRequest request)
        {
            List<string> errors = ValidateCreateRule(request);
            RuleMessage message = new RuleMessage();
            if (errors != null && errors.Any())
            {
                message.ErrorMessage = RuleMessageResource.ErrorsValidation;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceRuleClient.CreateRule(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change Rule informations.
        /// </summary>
        /// <returns>Rule message.</returns>
        [Route("UpdateRule")]
        public IHttpActionResult UpdateRule(RuleRequest request)
        {
            List<string> errors = ValidateUpdateRule(request);
            RuleMessage message = new RuleMessage();
            if (errors != null && errors.Any())
            {
                message.ErrorMessage = RuleMessageResource.ErrorsValidation;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceRuleClient.UpdateRule(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete Rule
        /// </summary>
        /// <returns>Rule message.</returns>
        [Route("RemoveRule")]
        public IHttpActionResult DeleteRule(int ruleId)
        {
            RuleRequest request = new RuleRequest { RuleDto = new RuleDto { RuleId = ruleId } };
            List<string> errors = ValidateDeleteRule(request);
            RuleMessage message = new RuleMessage();
            if (errors != null && errors.Any())
            {
                message.ErrorMessage = RuleMessageResource.ErrorsValidation;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceRuleClient.DeleteRule(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of Rule
        /// </summary>
        /// <returns>Rule message.</returns>
        [Route("GetRules")]
        public IHttpActionResult GetAllRules()
        {
            RuleMessage message = _serviceRuleClient.GetAllRules();
            return Json(message);
        }

        /// <summary>
        /// Find Rule
        /// </summary>
        /// <returns>Rule message.</returns>
        [Route("FindRules")]
        public IHttpActionResult FindRules(RuleRequest request)
        {
            List<string> errors = ValidateFindRule(request);
            RuleMessage message = new RuleMessage();
            if (errors != null && errors.Any())
            {
                message.ErrorMessage = RuleMessageResource.ErrorsValidation;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceRuleClient.FindRules(request);
            }
            return Json(message);
        }

        #endregion

        #region private validation methods

        /// <summary>
        /// Validate create rule.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>validation errors.</returns>
        private List<string> ValidateCreateRule(RuleRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.RuleDto == null)
            {
                errors.Add(RuleMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<RuleDto>.ValidateAttributes("RulePrefix", request.RuleDto.RulePrefix));
                errors.AddRange(GenericValidationAttribute<RuleDto>.ValidateAttributes("RuleName", request.RuleDto.RuleName));
            }
            return errors;
        }

        /// <summary>
        /// Validate create rule.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>validation errors.</returns>
        private List<string> ValidateUpdateRule(RuleRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.RuleDto == null)
            {
                errors.Add(RuleMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<RuleDto>.ValidateAttributes("RuleId", request.RuleDto.RuleId.ToString()));
                errors.AddRange(GenericValidationAttribute<RuleDto>.ValidateAttributes("RulePrefix", request.RuleDto.RulePrefix));
                errors.AddRange(GenericValidationAttribute<RuleDto>.ValidateAttributes("RuleName", request.RuleDto.RuleName));
            }
            return errors;
        }

        /// <summary>
        /// Validate create rule.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>validation errors.</returns>
        private List<string> ValidateDeleteRule(RuleRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.RuleDto == null)
            {
                errors.Add(RuleMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<RuleDto>.ValidateAttributes("RuleId", request.RuleDto.RuleId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate find rule.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>validation errors.</returns>
        private List<string> ValidateFindRule(RuleRequest request)
        {
            List<string> errors = new List<string>();
            if (request?.RuleDto == null)
            {
                errors.Add(RuleMessageResource.NullRequest);
            }
            return errors;
        }
        #endregion
    }
}