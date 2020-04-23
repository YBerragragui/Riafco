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

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion
{
    /// <summary>
    /// The UserRule service client class.
    /// </summary>
    public class ServiceUserRuleClient : IServiceUserRuleClient
    {
        #region private attributes

        /// <summary>
        /// The UserRule service instance.
        /// </summary>
        private readonly IServiceUserRule _serviceUserRule;

        #endregion

        #region constructor

        /// <summary>
        /// Set the UserRule instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceUserRule">injected instance</param>
        public ServiceUserRuleClient(IServiceUserRule injectedServiceUserRule)
        {
            _serviceUserRule = injectedServiceUserRule;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create new UserRule
        /// </summary>
        /// <param name="request">userRule request.</param>
        /// <returns>UserRule message.</returns>
        public UserRuleMessage CreateUserRule(UserRuleRequest request)
        {
            UserRuleMessage message = new UserRuleMessage();
            try
            {
                message = _serviceUserRule.CreateUserRule(request.ToPivot()).ToMessage();
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
        /// Change UserRule informations.
        /// </summary>
        /// <param name="request">userRule request.</param>
        /// <returns>UserRule message.</returns>
        public UserRuleMessage UpdateUserRule(UserRuleRequest request)
        {
            UserRuleMessage message = new UserRuleMessage();
            try
            {
                request.FindUserRuleDto = FindUserRuleDto.UserId;
                UserRuleResponsePivot findMessage = _serviceUserRule.FindUserRules(request.ToPivot());
                if (findMessage?.UserRulePivot != null)
                {
                    _serviceUserRule.UpdateUserRule(request.ToPivot());
                    message.OperationSuccess = true;
                }
                else
                {
                    message.ErrorMessage = UserRuleMessageResource.NotFound;
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
        /// Change UserRule informations.
        /// </summary>
        /// <param name="request">userRule request.</param>
        /// <returns>UserRule message.</returns>
        public UserRuleMessage UpdateUserRuleRange(UserRuleRequest request)
        {
            UserRuleMessage message = new UserRuleMessage();
            try
            {
                _serviceUserRule.UpdateUserRuleRange(request.ToPivot());
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
        /// Delete UserRule
        /// </summary>
        /// <param name="request">userRule request.</param>
        /// <returns>UserRule message.</returns>
        public UserRuleMessage DeleteUserRule(UserRuleRequest request)
        {
            UserRuleMessage message = new UserRuleMessage();
            try
            {
                request.FindUserRuleDto = FindUserRuleDto.UserId;
                UserRuleResponsePivot findMessage = _serviceUserRule.FindUserRules(request.ToPivot());
                if (findMessage?.UserRulePivot != null)
                {
                    _serviceUserRule.DeleteUserRule(request.ToPivot());
                    message.OperationSuccess = true;
                }
                else
                {
                    message.ErrorMessage = UserRuleMessageResource.NotFound;
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
        /// Get list of UserRule
        /// </summary>
        /// <returns>UserRule message.</returns>
        public UserRuleMessage GetAllUserRules()
        {
            UserRuleMessage message = new UserRuleMessage();
            try
            {
                message = _serviceUserRule.GetAllUserRules().ToMessage();
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
        /// Search UserRule
        /// </summary>
        /// <param name="request">userRule request.</param>
        /// <returns>UserRule message.</returns>
        public UserRuleMessage FindUserRules(UserRuleRequest request)
        {
            UserRuleMessage message = new UserRuleMessage();
            try
            {
                message = _serviceUserRule.FindUserRules(request.ToPivot()).ToMessage();
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