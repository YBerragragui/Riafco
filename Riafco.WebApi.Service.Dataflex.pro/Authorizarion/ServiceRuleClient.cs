using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Service.Dataflex.Pro.Authorizarion.Interface;
using Riafco.Service.Dataflex.Pro.Authorizarion.Response;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Assembler;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Message;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Request;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Ressource;
using System;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using Riafco.Service.Dataflex.Pro.Authorizarion.Request;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion
{
    /// <summary>
    /// The Rule service client class.
    /// </summary>
    public class ServiceRuleClient : IServiceRuleClient
    {
        #region private attributes

        /// <summary>
        /// The Rule service instance.
        /// </summary>
        private readonly IServiceRule _serviceRule;

        /// <summary>
        /// The User service instance.
        /// </summary>
        private readonly IServiceUser _serviceUser;

        /// <summary>
        /// The UserRule service instance.
        /// </summary>
        private readonly IServiceUserRule _serviceUserRule;

        #endregion

        #region constructor

        /// <summary>
        /// Set the User instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceUser">injected instance</param>
        /// <param name="injectedServiceUserRule">injected instance</param>
        /// <param name="injectedServiceRule">injected instance</param>
        public ServiceRuleClient(IServiceUser injectedServiceUser, IServiceUserRule injectedServiceUserRule, IServiceRule injectedServiceRule)
        {
            _serviceUserRule = injectedServiceUserRule;
            _serviceUser = injectedServiceUser;
            _serviceRule = injectedServiceRule;
        }
        #endregion

        #region public methods

        /// <summary>
        /// Create new Rule.
        /// </summary>
        /// <param name="request">rule request.</param>
        /// <returns>Rule message.</returns>
        public RuleMessage CreateRule(RuleRequest request)
        {
            RuleMessage message = new RuleMessage();
            try
            {
                message = _serviceRule.CreateRule(request.ToPivot()).ToMessage();
                if (message?.RuleDto != null)
                {
                    //create user rule.
                    UserMessage userMessage = _serviceUser.GetAllUsers().ToMessage();
                    if (userMessage?.UserDtoList != null)
                    {
                        foreach (var user in userMessage.UserDtoList)
                        {
                            _serviceUserRule.CreateUserRule(new UserRuleRequestPivot()
                            {
                                UserRulePivot = new UserRulePivot()
                                {
                                    RuleId = message.RuleDto.RuleId,
                                    UserRuleStatus = false,
                                    UserId = user.UserId
                                }
                            });
                        }
                    }
                    message.OperationSuccess = true;
                }
                else
                {
                    if (message != null)
                    {
                        message.ErrorMessage = RuleMessageResource.ServiceResponseNull;
                        message.ErrorType = ErrorType.TechnicalError;
                        message.OperationSuccess = false;
                    }
                }
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Change Rule informations.
        /// </summary>
        /// <param name="request">rule request.</param>
        /// <returns>Rule message.</returns>
        public RuleMessage UpdateRule(RuleRequest request)
        {
            RuleMessage message = new RuleMessage();
            try
            {
                request.FindRuleDto = FindRuleDto.RuleId;
                RuleResponsePivot response = _serviceRule.FindRules(request.ToPivot());
                if (response?.RulePivot != null)
                {
                    _serviceRule.UpdateRule(request.ToPivot());
                    message.OperationSuccess = true;
                }
                else
                {
                    message.ErrorMessage = RuleMessageResource.NotFound;
                    message.ErrorType = ErrorType.FunctionalError;
                    message.OperationSuccess = false;
                }
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Delete Rule
        /// </summary>
        /// <param name="request">rule request.</param>
        /// <returns>Rule message.</returns>
        public RuleMessage DeleteRule(RuleRequest request)
        {
            RuleMessage message = new RuleMessage();
            try
            {
                request.FindRuleDto = FindRuleDto.RuleId;
                RuleResponsePivot response = _serviceRule.FindRules(request.ToPivot());
                if (response?.RulePivot != null)
                {
                    _serviceRule.DeleteRule(request.ToPivot());
                    message.OperationSuccess = true;
                }
                else
                {
                    message.ErrorMessage = RuleMessageResource.NotFound;
                    message.ErrorType = ErrorType.FunctionalError;
                    message.OperationSuccess = false;
                }
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Get list of Rule
        /// </summary>
        /// <returns>Rule message.</returns>
        public RuleMessage GetAllRules()
        {
            RuleMessage message = new RuleMessage();
            try
            {
                message = _serviceRule.GetAllRules().ToMessage();
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Search Rule
        /// </summary>
        /// <param name="request">rule request.</param>
        /// <returns>Rule message.</returns>
        public RuleMessage FindRules(RuleRequest request)
        {
            RuleMessage message = new RuleMessage();
            try
            {
                message = _serviceRule.FindRules(request.ToPivot()).ToMessage();
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }
        #endregion
    }
}